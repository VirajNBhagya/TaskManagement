using Microsoft.EntityFrameworkCore;

namespace SampleProject.DTO
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskManagement> TaskManagements { get; set; }
    }
}
