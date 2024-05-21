using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationLoan.Data;
using WebApplicationLoan.Models;
using WebApplicationLoan.Models.Entities;

namespace WebApplicationLoan.Controllers
{
    public class LoanController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LoanController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // GET
        public IActionResult Index(int Id)
        {
            ViewData["Id"] = Id;
            return View();
        }

        public async Task<IActionResult> Store(LoanDetailsViewModel loanDetails)
        {
            double interest = 1.10;
            var amountToPay = loanDetails.AmmountCollected * (decimal)interest;
            var monthlyPayment = amountToPay / (loanDetails.Tenure * 12);


            var loan = new LoanDetails()
            {
                AmmountCollected = loanDetails.AmmountCollected,
                Tenure = loanDetails.Tenure,
                Interest = 10,
                AmmountToPay = amountToPay,
                MonthlyPayment = monthlyPayment,
                UserId = loanDetails.UserId

            };
            dbContext.LoanDetails.Add(loan);
            await dbContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Loan application was successful.";
            return RedirectToAction(nameof(Index));

            //dbContext.LoanDetails.Add(loan);
            //await dbContext.SaveChangesAsync();
            //return View("Sucess");

        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
