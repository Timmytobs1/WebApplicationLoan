using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationLoan.Models.Entities;
using WebApplicationLoan.Models;
using WebApplicationLoan.Data;

namespace WebApplicationLoan.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel users)
        {
            var user = new User()
            {
                FirstName = users.FirstName,
                LastName = users.LastName,
                Age = users.Age,
                Address = users.Address,
                BVN = users.BVN,
                Email = users.Email,
                Password = users.Password,
                PhoneNo = users.PhoneNo,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now 
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var tempuser = _context.Users.FirstOrDefault(x => x.Email == user.Email);
            var tempId = tempuser.Id;
            return RedirectToAction("Index", "Loan", new { Id = tempId });
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            var templogin = _context.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            if (templogin != null)
            {
                return RedirectToAction("Index", "home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid login details. Please try again.";
                return RedirectToAction("Login");
            }
            return View();


        }
    }
}
