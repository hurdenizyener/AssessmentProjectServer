using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class EmployeeConfiguration : BaseConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Employees")
            .HasKey(e => e.Id);

        builder
            .Property(e => e.FirstName)
            .HasColumnName("FirstName")
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(e => e.LastName)
            .HasColumnName("LastName")
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(e => e.Gender)
            .HasColumnName("Gender")
            .HasMaxLength(5)
            .IsRequired();

        builder
            .Property(e => e.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(e => e.Email)
            .HasColumnName("Email")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.GraduatedSchool)
            .HasColumnName("GraduatedSchool")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.GraduatedField)
            .HasColumnName("GraduatedField")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(e => e.BirthDate)
            .HasColumnName("BirthDate")
            .IsRequired();

        builder
            .Property(e => e.DateOfEntry)
            .HasColumnName("DateOfEntry")
            .IsRequired();

        builder
            .Property(e => e.Asset)
            .HasColumnName("Asset")
            .IsRequired();

        builder
            .Property(e => e.Address)
            .HasColumnName("Address")
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(e => e.Status)
            .HasColumnName("Status")
            .IsRequired();

        builder
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.Position)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(indexExpression: e => e.Email, name: "UK_Employees_Email")
            .IsUnique();

        builder
            .HasIndex(e => e.DepartmentId);

        builder
            .HasIndex(e => e.PositionId);

        builder
            .HasData(Seeds);
    }

    private static Employee[] Seeds =>
         [
             new Employee {
                 DepartmentId=new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20"),
                 PositionId=new Guid("990765cd-4d42-4a50-9371-88ed24959cb4"),
                 FirstName="Hürdeniz",
                 LastName="Yener",
                 Gender="Erkek",
                 Phone="0111-111-11-11",
                 Email="hurdenizyener@gmail.com",
                 GraduatedSchool="Hitit Üniversitesi",
                 GraduatedField="Bilgisayar Program",
                 BirthDate=DateTime.UtcNow,
                 DateOfEntry=DateTime.UtcNow,
                 Asset=true,
                 Address="büyükçekmece",
                 Status=true,
                 CreatedDate=DateTime.UtcNow,
             },

         ];
}

