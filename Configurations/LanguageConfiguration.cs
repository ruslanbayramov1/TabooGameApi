using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabooGameApi.Entities;

namespace TabooGameApi.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder
            .HasKey(e => e.Code);

        builder
            .HasIndex(e => e.Name)
            .IsUnique();

        builder
            .Property(e => e.Code)
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(e => e.Name)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .Property(e => e.Icon)
            .HasMaxLength(128)
            .IsRequired();
    }
}
