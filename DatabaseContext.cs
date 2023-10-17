using EFCore_APP001.Entitits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_APP001
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Company>()
            modelBuilder.Entity<Company>( builder => {
                builder.ToTable("Companies");

                builder
                .HasMany(company => company.Employees)
                .WithOne()
                .HasForeignKey(employee => employee.CompanyId)
                .IsRequired();


                builder.HasData(new Company { Id=1,Name="Awesome Company"});
            
            }  );

            modelBuilder.Entity<Employee>(builder =>
            {
                builder.ToTable("Employees");

                var employees= Enumerable
                .Range(1, 1000)
                .Select(id => new Employee
                {
                    Id=id,
                    Name= $"Employee #{id}",
                    Salary =100.0m,
                    CompanyId=1


                })
                .ToList();

                builder.HasData(employees);
                        
            });

        }

        //private void ConfigureCompany(EntityTypeBuilder<Company> builder)
        //{
        //    // Define the primary key
        //    builder.HasKey(c => c.CompanyId);

        //    // Define other entity configurations, such as property constraints and relationships with other entities
        //    builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        //    builder.Property(c => c.Location).HasMaxLength(200);

        //    // You can define relationships here, if the Company entity has any
        //}




    }
}
