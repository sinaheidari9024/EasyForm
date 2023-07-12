using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyForm.Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasMany(e => e.Applications)
                .WithOne(e => e.User)
                //.OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
        }
    }
}
