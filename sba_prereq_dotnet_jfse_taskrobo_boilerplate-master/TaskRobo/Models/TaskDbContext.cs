using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TaskRobo.Models
{
    //This class represents the DbContext class for Entity Framework to communicate with database
    // in code-first approach.
    public class TaskDbContext:DbContext
    {
        public TaskDbContext() : base("TaskRoboContext")
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
