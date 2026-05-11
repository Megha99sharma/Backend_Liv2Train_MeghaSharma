using System.ComponentModel.DataAnnotations;

namespace TrainingCenterRegistry.Models
{
    public class TrainingCenter
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string CenterName { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{12}$",
            ErrorMessage = "CenterCode should be 12 characters")]
        public string CenterCode { get; set; }

        [Required]
        public Address Address { get; set; }

        public int StudentCapacity { get; set; }

        public List<string> CoursesOffered { get; set; } = new();

        public long CreatedOn { get; set; }

        [EmailAddress]
        public string? ContactEmail { get; set; }

        [Required]
        [RegularExpression(@"^[6-9][0-9]{9}$",
            ErrorMessage = "Invalid phone number")]
        public string ContactPhone { get; set; }
    }
}
