using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplicationLoan.Models.Entities;

namespace WebApplicationLoan.Models
{
    public class LoanDetailsViewModel
    {
        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public decimal AmmountCollected { get; set; }
        [Required]
        public int Tenure { get; set; }


    }
}
