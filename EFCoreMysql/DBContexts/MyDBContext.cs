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
                entity.HasIndex(u => u.FirstName);
                entity.Property(u => u.Lastname);
                entity.Property(u => u.Address);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(p => p.ProjectId);
                entity.HasIndex(p => p.ProjectName);
            });

            modelBuilder.Entity<EmployeeProject>(entity =>
            {
                entity.HasIndex(ep => ep.EmployeeId);
                entity.HasIndex(ep => ep.ProjectId);

            });
          
         //   modelBuilder.Entity<EmployeeProject>().ToTable("EmployeeProjects");

         //   // Configure Primary Keys  
         //   modelBuilder.Entity<Employee>().HasKey(ug => ug.EmployeeId).HasName("PK_Employees");
         //   modelBuilder.Entity<Project>().HasKey(u => u.ProjectId).HasName("PK_Projects");
           

         //   // Configure indexes  
         //   modelBuilder.Entity<Project>().HasIndex(p => p.ProjectName).IsUnique().HasName("Idx_Name");
         //   modelBuilder.Entity<Employee>().HasIndex(u => u.FirstName).HasName("Index_FirstName");
         //   modelBuilder.Entity<Employee>().HasIndex(u => u.Lastname).HasName("Idx_LastName");

         //   // Configure columns  
         //   modelBuilder.Entity<Project>().Property(ug => ug.ProjectId).HasColumnType("int").IsRequired();
         //   modelBuilder.Entity<Project>().Property(ug => ug.ProjectName).HasColumnType("nvarchar(100)").IsRequired();
         ////   modelBuilder.Entity<Project>().Property(ug => ug.Employees).HasColumnType("int").IsRequired();

         


         //   modelBuilder.Entity<Employee>().Property(u => u.EmployeeId).HasColumnType("int").IsRequired();
         //   modelBuilder.Entity<Employee>().Property(u => u.FirstName).HasColumnType("nvarchar(50)").IsRequired();
         //   modelBuilder.Entity<Employee>().Property(u => u.Lastname).HasColumnType("nvarchar(50)").IsRequired();
         //   modelBuilder.Entity<Employee>().Property(u => u.Projects).HasColumnType("int").IsRequired();


            // Configure relationships  
            //    modelBuilder.Entity<Employee>().HasMany<Project>().WithOne().HasPrincipalKey(ug => ug.Id).HasForeignKey(u => u.UserGroupId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Users_UserGroups");
            //modelBuilder.Entity<Employee>()
            //        .HasMany<Project>(p => p.Projects)
            //        .wi
            //        .Map(pe =>
            //        {
            //            pe.MapLeftKey("EmployeeRefId");
            //            pe.MapRightKey("ProjectRefId");
            //            pe.ToTable("EmployeeProject");
            //        });


        
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

