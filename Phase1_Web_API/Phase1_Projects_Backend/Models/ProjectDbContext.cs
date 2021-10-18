using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Phase1_Projects_Backend.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<User> UserList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().Property(p => p.TechTools).HasDefaultValue("To be Updated");
            
            modelBuilder.Entity<Project>().HasData(new Project
            {
                ProjectId = 20,
                ProjectTitle = "Title10",
                Domain = "Domain10",
                Description = "Description10",
                TechTools = "Technologies and Tools 10",
                ContactMail = "Email10"
            }, new Project
            {
                ProjectId = 21,
                ProjectTitle = "Title11",
                Domain = "Domain11",
                Description = "Description11",
                //TechTools = "Technologies and Tools 11",
                ContactMail = "Email11"
            }, new Project
            {
                ProjectId = 1,
                ProjectTitle = "Title1",
                Domain = "Domain1",
                Description = "Description1",
                TechTools = "Technologies and Tools 1",
                ContactMail = "Email1"
            }, new Project
            {
                ProjectId = 2,
                ProjectTitle = "Title2",
                Domain = "Domain2",
                Description = "Description2",
                //TechTools = "Technologies and Tools 11",
                ContactMail = "Email2"
            });

        }
        
    }
}
