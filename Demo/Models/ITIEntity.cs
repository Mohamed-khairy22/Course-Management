using Demo.Authentcation;
using ITI_task1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ITIEntity : IdentityDbContext<ApplicationUser>
    {
        public DbSet <Employee> Employees { get; set; }
        public DbSet <Department> Departments { get; set; }
        public DbSet <Department1> department1s { get; set; }
        public DbSet <Course> courses { get; set; }
        public DbSet <crsResult> crsResult { get; set; }
        public DbSet <Instructor> instructors { get; set; }
        public DbSet <Trainee> traines { get; set; }
        public ITIEntity():base()
        {

        }
        public ITIEntity(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //options (dbms sql ,
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-FMRLOB8\\MSSQLSERVER1;Initial Catalog=TaskDb;Integrated Security=True;Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
