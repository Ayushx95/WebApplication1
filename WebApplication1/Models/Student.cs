using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required.")]
        [StringLength(50,MinimumLength =2, ErrorMessage = "Student Name must be between 2 and 50 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Age is required.")]
        [Range(5,100,ErrorMessage = "Age must be between 5 and 100.")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Stuent Class is required.")]
        [Range(1,12,ErrorMessage ="Class must be between 1 and 12.")]
        public string? Class { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;

    }
}
