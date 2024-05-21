using Microsoft.EntityFrameworkCore;
using WebApplicationLoan.Models.Entities;

namespace WebApplicationLoan.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<LoanDetails> LoanDetails { get; set; }
    }
}
