using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabooGameApi.Entities;

namespace TabooGameApi.Configurations;

public class WordConfiguration : IEntityTypeConfiguration<Word>
{
    public void Configure(EntityTypeBuilder<Word> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Text)
            .HasMaxLength(32)
            .IsRequired();

        builder
            .HasOne(x => x.Language)
            .WithMany(l => l.Words)
            .HasForeignKey(x => x.LanguageCode);

        builder
            .HasOne(x => x.Level)
            .WithMany(l => l.Words)
            .HasForeignKey(x => x.LevelId);
    }
}
