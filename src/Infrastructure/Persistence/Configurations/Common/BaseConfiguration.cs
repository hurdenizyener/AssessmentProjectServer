using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Common;
using System.Net;
using Domain.Entities;

namespace Infrastructure.Persistence.Configurations.Common;

public class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .Property(p => p.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();


        builder
            .Property(p => p.LastModifiedDate)
            .HasColumnName("LastModifiedDate");
    }
}




