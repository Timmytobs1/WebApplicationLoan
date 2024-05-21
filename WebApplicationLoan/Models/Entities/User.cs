using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationLoan.Models.Entities
{
    [PrimaryKey("Id")]
    [Index("Email", IsUnique = true)]
    [Index("BVN", IsUnique = true)]
    public class User
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [Range(18, 120)]
        public int Age { get; set; }
        [StringLength(80)]
        public string Email { get; set; }
        [StringLength(12)]
        [Required]
        public string PhoneNo { get; set; }
        [StringLength(20)]
           
        public string BVN { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;

        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [NotMapped] // This field should not be mapped to the database
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

       
    }
}
