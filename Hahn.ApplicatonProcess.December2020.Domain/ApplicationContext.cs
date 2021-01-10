using Hahn.ApplicatonProcess.December2020.Domain.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.December2020.Domain
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
                
        }
        public DbSet<Applicant> Applicants { get; set; }
    }
}
