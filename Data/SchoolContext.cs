using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        //配置数据库连接
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.IsConfigured防止重复配置
            if (!optionsBuilder.IsConfigured)
            { 
                var connectionString = "Server=localhost;Database=StudentDB;User Id=sa;Password=123456;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionString);

            }
        }
    }
}
