using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationLoan.Models.Entities
{
    public class LoanDetails
    {
        public int Id { get; set; }
        public decimal AmmountCollected { get; set; }
        public decimal Interest { get; set; }
        public decimal AmmountToPay { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int Tenure { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
