using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabooGameApi.Entities;

namespace TabooGameApi.Configurations;

public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
{
    public void Configure(EntityTypeBuilder<BannedWord> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Text)
            .HasMaxLength(32)
            .IsRequired();

        builder
            .HasOne(x => x.Word)
            .WithMany(w => w.BannedWords);
    }
}
