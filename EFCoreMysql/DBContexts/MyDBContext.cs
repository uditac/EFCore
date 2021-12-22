using Microsoft.EntityFrameworkCore;
using EFCoreMysql.Models;


namespace EFCoreMysql.DBContexts
{
    public class MyDBContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<EmployeeProject> EmployeeProject { get; set; }

        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Use Fluent API to configure  

            // Map entities to tables  

          

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(ug => ug.EmployeeId);
                entity.Property(u => u.FirstName).IsRequired();
                entity.Property(u => u.Lastname).IsRequired();              
                entity.Property(u => u.Address).HasConversion(
                    x => x.Value, 
                    x=> Address.Create(x).Value);
                entity.Property(u => u.Email).HasConversion(
                    x => x.Value,
                    x => Email.Create(x).Value
                    ).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectId);
                entity.HasIndex(p => p.ProjectName);
                entity.Property(u => u.ProjectDescription).HasConversion(
                    x => x.Value,
                    x => Description.Create(x).Value);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasIndex(ep => ep.EmployeeId);
                entity.HasIndex(ep => ep.ProjectId);

            });
          
      

        
            modelBuilder.Entity<EmployeeProject>()
                .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(ep => ep.Employee)
                .WithMany(p => p.EmployeeProjects)
                .HasForeignKey(pc => pc.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
                .HasOne(pc => pc.Project)
                .WithMany(c => c.EmployeeProjects)
                .HasForeignKey(pc => pc.ProjectId);
        
    }
    }
}

