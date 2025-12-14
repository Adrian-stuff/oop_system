using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using oop_backend.Models;

namespace oop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDatasController : ControllerBase
    {
        private readonly UserDataContext _context;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public UserDatasController(UserDataContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        // GET: api/UserDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserData>> GetUserData(int? id)
        {
            var userData = await _context.Users.FindAsync(id);

            if (userData == null)
            {
                return NotFound();
            }

            return userData;
        }

        // PUT: api/UserDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserData(int? id, UserData userData)
        {
            if (id != userData.userID)
            {
                return BadRequest();
            }

            _context.Entry(userData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<UserData>> PostUserData(
            [FromForm] IFormFile Photo,
            [FromForm] string FirstName,
            [FromForm] string LastName,
            [FromForm] string Email,
            [FromForm] string BirthDate,
            [FromForm] string? StudentNumber = null)
        {
            if (Photo == null || Photo.Length == 0)
            {
                return BadRequest(new { error = "Photo is required" });
            }

            // Read image into memory (stream can only be read once)
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await Photo.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            // Validate required fields
            if (string.IsNullOrWhiteSpace(FirstName))
            {
                return BadRequest(new { error = "FirstName is required" });
            }
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return BadRequest(new { error = "LastName is required" });
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                return BadRequest(new { error = "Email is required" });
            }
            if (string.IsNullOrWhiteSpace(BirthDate))
            {
                return BadRequest(new { error = "BirthDate is required" });
            }

            // Generate Student Number: 24-XXXX
            var lastUser = await _context.Users
                .Where(u => u.StudentNumber.StartsWith("24-"))
                .OrderByDescending(u => u.StudentNumber)
                .FirstOrDefaultAsync();

            string nextStudentNumber = "24-0000";
            if (lastUser != null)
            {
                var parts = lastUser.StudentNumber.Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1], out int lastNum))
                {
                    nextStudentNumber = $"24-{(lastNum + 1):D4}";
                }
            }

            // Create UserData from request
            var userData = new UserData
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                BirthDate = DateTime.Parse(BirthDate),
                StudentNumber = nextStudentNumber
            };

            // Save user to database
            _context.Users.Add(userData);
            await _context.SaveChangesAsync();

            // Get the generated userID
            var userId = userData.userID;
            if (userId == null)
            {
                return StatusCode(500, new { error = "Failed to generate user ID" });
            }

            // Save image locally
            try 
            {
                var imagesDir = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Users");
                if (!Directory.Exists(imagesDir))
                {
                    Directory.CreateDirectory(imagesDir);
                }

                var imagePath = Path.Combine(imagesDir, $"{userId}.jpg");
                await System.IO.File.WriteAllBytesAsync(imagePath, imageBytes);
            }
            catch (Exception ex)
            {
                // Log warning but don't fail the request just for local save if remote succeeded?
                // Actually, if we rely on this for the UI, we should probably care.
                // But let's proceed to face recognition service first.
                System.Diagnostics.Debug.WriteLine($"Failed to save local image: {ex.Message}");
            }

            // Call Python face recognition service to save the face
            try
            {
                var faceServiceUrl = _configuration["FaceRecognitionServiceUrl"] ?? "http://127.0.0.1:5000";
                var httpClient = _httpClientFactory.CreateClient();
                
                // Prepare multipart/form-data for Python service
                using var formData = new MultipartFormDataContent();
                
                // Add image file
                var fileContent = new ByteArrayContent(imageBytes);
                string contentType = !string.IsNullOrEmpty(Photo.ContentType) ? Photo.ContentType : "image/jpeg";
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                formData.Add(fileContent, "img", Photo.FileName ?? "face.jpg");
                
                // Add user ID as form field
                formData.Add(new StringContent(userId.ToString()!), "id");

                var response = await httpClient.PostAsync(
                    $"{faceServiceUrl}/addFace?id={userId}",
                    formData
                );

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    
                    // Rollback user creation if face recognition fails
                    _context.Users.Remove(userData);
                    await _context.SaveChangesAsync();
                    
                    return StatusCode((int)response.StatusCode, new { 
                        error = "Failed to register face", 
                        details = errorContent 
                    });
                }

                var faceResponse = await response.Content.ReadAsStringAsync();
                // Optionally parse and log the response
            }
            catch (HttpRequestException ex)
            {
                // Rollback user creation if face recognition service is unavailable
                _context.Users.Remove(userData);
                await _context.SaveChangesAsync();
                
                return StatusCode(503, new { 
                    error = "Face recognition service unavailable", 
                    details = ex.Message 
                });
            }
            catch (Exception ex)
            {
                // Rollback user creation on any other error
                _context.Users.Remove(userData);
                await _context.SaveChangesAsync();
                
                return StatusCode(500, new { 
                    error = "An error occurred while registering face", 
                    details = ex.Message 
                });
            }

            return CreatedAtAction("GetUserData", new { id = userData.userID }, userData);
        }

        // GET: api/UserDatas/5/photo
        [HttpGet("{id}/photo")]
        public IActionResult GetUserPhoto(int id)
        {
            var imagesDir = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Users");
            var imagePath = Path.Combine(imagesDir, $"{id}.jpg");

            if (System.IO.File.Exists(imagePath))
            {
                var imageFileStream = System.IO.File.OpenRead(imagePath);
                return File(imageFileStream, "image/jpeg");
            }
            
            return NotFound();
        }

        // DELETE: api/UserDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserData(int? id)
        {
            var userData = await _context.Users.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDataExists(int? id)
        {
            return _context.Users.Any(e => e.userID == id);
        }
    }
}
