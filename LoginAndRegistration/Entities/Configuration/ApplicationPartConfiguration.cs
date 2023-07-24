using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class ApplicationPartConfiguration : IEntityTypeConfiguration<ApplicationPart>
    {
        public void Configure(EntityTypeBuilder<ApplicationPart> builder)
        {
            builder
                .HasMany(e => e.Questions)
                .WithOne(e => e.Part)
                .HasForeignKey(e => e.ApplicationPartId)
                //.OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            builder.Property(s => s.SpanishTitle).HasColumnType("Nvarchar(MAX)").IsRequired();
            builder.Property(s => s.Title).HasColumnType("Varchar(MAX)").IsRequired();

        }
    }
}
