using Domain.Entities;
using Infrastructure.Persistence.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public sealed class PositionConfiguration : BaseConfiguration<Position>
{
    public override void Configure(EntityTypeBuilder<Position> builder)
    {
        base.Configure(builder);

        builder
            .ToTable("Positions")
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Id)
            .HasColumnName("Id")
            .IsRequired();

        builder
            .Property(p => p.DepartmentId)
            .HasColumnName("DepartmentId")
            .IsRequired();

        builder
            .Property(p => p.Title)
            .HasColumnName("Title")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .HasMany(p => p.Employees)
            .WithOne(e => e.Position)
            .HasForeignKey(e => e.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(p => p.Department)
            .WithMany(d => d.Positions)
            .HasForeignKey(p => p.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasIndex(indexExpression: p => p.Title, name: "UK_Positions_Title")
            .IsUnique();

        builder
            .HasIndex(p => p.DepartmentId);

        builder
            .HasData(Seeds);
    }

    private static Position[] Seeds =>
           [
               new Position {
                   Id=new Guid("fa7fc807-9f59-4452-ba36-0900b5186869") ,
                   DepartmentId=new Guid("f5fd7e8f-0a7e-41d1-81ae-945b5b675f5d") ,
                   Title = "Yönetici",
                   CreatedDate = DateTime.UtcNow,
               },
               new Position {
                   Id=new Guid("d6d90efc-e099-42e7-8360-2d90e9a26f23") ,
                   DepartmentId=new Guid("34c0160d-6db5-40c5-8597-e81318d38b8b") ,
                   Title = "İK Uzmanı",
                   CreatedDate = DateTime.UtcNow,
               },
               new Position {
                   Id=new Guid("990765cd-4d42-4a50-9371-88ed24959cb4") ,
                   DepartmentId=new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20") ,
                   Title = "Yazılım Geliştirici",
                   CreatedDate= DateTime.UtcNow,
               },
               new Position {
                   Id=new Guid("9fa7ab59-3aeb-4636-a4d8-21161c7f963a") ,
                   DepartmentId=new Guid("78ede17c-6d8a-4f89-b0ef-eee8729c4d20") ,
                   Title = "Sistem Analisti",
                   CreatedDate=DateTime.UtcNow,
               }
           ];
}
