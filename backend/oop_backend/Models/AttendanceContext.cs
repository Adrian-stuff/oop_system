using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace oop_backend.Models
{
    public class AttendanceContext : DbContext
    {
        public AttendanceContext(DbContextOptions<AttendanceContext> options) : base(options)
        {
        }

        public DbSet<Attendance> Attendance { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure eventDate: Database DATE (DateTime) -> C# string
            var dateConverter = new ValueConverter<string, DateTime>(
                v => DateTime.Parse(v), // C# string to DateTime for database
                v => v.ToString("yyyy-MM-dd")); // DateTime from database to C# string

            modelBuilder.Entity<Attendance>()
                .Property(a => a.eventDate)
                .HasConversion(dateConverter);

            // Configure eventTime: Database TIME (TimeSpan) -> C# string
            var timeConverter = new ValueConverter<string, TimeSpan>(
                v => TimeSpan.Parse(v), // C# string to TimeSpan for database
                v => $"{v.Hours:D2}:{v.Minutes:D2}:{v.Seconds:D2}"); // TimeSpan from database to C# string (HH:mm:ss format)

            modelBuilder.Entity<Attendance>()
                .Property(a => a.eventTime)
                .HasConversion(timeConverter);
        }
    }
}
