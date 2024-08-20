using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class DepartmentConfiguration : BaseConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Departments")
            .HasKey(d => d.Id);

        builder
            .Property(d => d.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder
            .Property(d => d.Name)
            .HasColumnName("Name")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasMany(d => d.Positions)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(indexExpression: d => d.Name, name: "UK_Departments_Name")
            .IsUnique();

        builder
            .HasData(Seeds);
    }

    private static Department[] Seeds =>
            [
                new Department {
                    Id=new Guid("f5fd7e8f-0a7e-41d1-81ae-945b5b675f5d") ,
                    Name = "Yönetim Departmanı" ,
                    CreatedDate=DateTime.UtcNow
                },
                new Department {
                    Id=new Guid("34c0160d-6db5-40c5-8597-e81318d38b8b") ,
                    Name = "İnsan Kaynakları Departmanı" ,
                    CreatedDate=DateTime.UtcNow
                },
                new Department {
                    Id=new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20") ,
                    Name = "Bilgi İşlem Departmanı" ,
                    CreatedDate=DateTime.UtcNow
                }
            ];
}

