using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class QuestionItemConfiguration : IEntityTypeConfiguration<QuestionItem>
    {
        public void Configure(EntityTypeBuilder<QuestionItem> builder)
        {
            builder
                .HasMany(e => e.EnableQuestion)
                .WithOne(e => e.EnabblerItem)
                .HasForeignKey(e => e.EnabblerItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.DisableQuestion)
                .WithOne(e => e.DisablerItem)
                .HasForeignKey(e => e.DisablerItemId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
