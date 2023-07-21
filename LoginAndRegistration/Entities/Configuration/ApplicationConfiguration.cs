using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder
                .HasMany(e => e.UserApplications)
                .WithOne(e => e.Application)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.ApplicationId)
                .IsRequired();

            builder
                .HasMany(e => e.ApplicationParts)
                .WithOne(e => e.Application)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.ApplicationId)
                .IsRequired();
            builder.Property(s => s.SpanishTitle).IsRequired().HasColumnType("Nvarchar(MAX)");
            builder.Property(s => s.Title).HasColumnType("Varchar(MAX)").IsRequired();
        }
    }
}
