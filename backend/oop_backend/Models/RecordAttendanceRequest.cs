using System.ComponentModel.DataAnnotations;

namespace oop_backend.Models;

public class RecordAttendanceRequest
{
    [Required]
    public required string Photo { get; set; }
    
    [Required]
    public required string Type { get; set; } // "time-in" or "time-out"
}

