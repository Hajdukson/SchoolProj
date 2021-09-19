using Microsoft.EntityFrameworkCore;
using SchoolProj.Models;

namespace SchoolProj
{
    public class MvcSchoolProjectContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public MvcSchoolProjectContext(DbContextOptions<MvcSchoolProjectContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
