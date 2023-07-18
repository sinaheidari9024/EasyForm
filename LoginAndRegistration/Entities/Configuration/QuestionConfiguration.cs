﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Entities.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder
                .HasMany(e => e.Answers)
                .WithOne(e => e.Question)
                .HasForeignKey(e => e.QuestionId)
                //.OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder
                .HasMany(e => e.QuestionItems)
                .WithOne(e => e.Question)
                //.OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();
        }
    }
}
