using System.ComponentModel.DataAnnotations;

namespace WebApplicationLoan.Models
{
    public class UserViewModel
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Range(18, 120)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(80)]
        public string Email { get; set; }
        [Required]
        [StringLength(12)]
        public string PhoneNo { get; set; }
        [Required]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "BVN must be 11 digits")]
        [StringLength(20)]

        public string BVN { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
