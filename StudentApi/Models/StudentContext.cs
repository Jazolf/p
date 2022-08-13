using Microsoft.EntityFrameworkCore;

namespace StudentApi.Models
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext>option)
            : base(option)
        {
        }
        public DbSet<StudentItems> StudentItems { get; set; }
    }
}
