using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class QuestionItemConfiguration : IEntityTypeConfiguration<QuestionItem>
    {
        public void Configure(EntityTypeBuilder<QuestionItem> builder)
        {
            builder.Property(s => s.SpanishTitle).HasColumnType("Nvarchar(MAX)").IsRequired();
            builder.Property(s => s.Title).HasColumnType("Varchar(MAX)").IsRequired();

        }
    }
}
