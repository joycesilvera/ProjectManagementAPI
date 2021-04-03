using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MvcProjectManagement.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateOfStart { get; set; }
        public int TeamSize { get; set; }
    }

    public class ProjectManagementDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //Uncomment for Azure-change pwd
            //optionsBuilder.UseSqlServer("Server=tcp:spms-azure-sql-database.database.windows.net,1433;Database=SPMS;Persist Security Info=False;User=system_admin;Password=*******;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            optionsBuilder.UseSqlServer("Server=localhost,1401;Database=Practice;User=sa;Password=benzy5@Rarc");
        }
    }
}
