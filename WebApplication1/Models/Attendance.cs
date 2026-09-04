using System;

namespace WebApplication1.Models
{
    public class Attendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public Student? Student { get; set; }

        public DateTime Date { get; set; } = DateTime.UtcNow.Date;

        public bool Present { get; set; }

        public string? Notes { get; set; }
    }
}
