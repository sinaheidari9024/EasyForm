using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class UserApplicationConfiguration : IEntityTypeConfiguration<UserApplication>
    {
        public void Configure(EntityTypeBuilder<UserApplication> builder)
        {
            builder
                .HasMany(e => e.Answers)
                .WithOne(e => e.UserApplication)
                .HasForeignKey(e => e.UserApplicationId)
               // .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
