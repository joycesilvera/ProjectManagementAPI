using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MvcProjectManagement.Models
{
    public class Project
    {
        [Key]
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
            optionsBuilder.UseSqlServer("Server=localhost,1401;Database=SPMS;User=sa;Password=benzy5@Rarc");
        }
    }
}
