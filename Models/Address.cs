using System.ComponentModel.DataAnnotations;

namespace TrainingCenterRegistry.Models
{
    public class Address
    {
        [Required]
        public string DetailedAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{6}$",
            ErrorMessage = "Pincode must be 6 digits")]
        public string Pincode { get; set; }
    }
}
