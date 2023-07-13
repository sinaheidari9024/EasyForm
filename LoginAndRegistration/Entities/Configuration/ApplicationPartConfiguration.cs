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
        }
    }
}
