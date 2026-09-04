namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public int? Age { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

        // Add other student properties as needed
    }
}
