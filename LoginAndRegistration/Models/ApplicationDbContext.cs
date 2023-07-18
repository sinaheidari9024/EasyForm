using EasyForm.Entities;
using EasyForm.Entities.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyForm.Models
{
    public class ApplicationDbContext : IdentityDbContext<User, ApplicationRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserApplication> UserApplications { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationPart> ApplicationParts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionItem> QuestionItems { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new UserConfiguration().Configure(modelBuilder.Entity<User>());
            new ApplicationConfiguration().Configure(modelBuilder.Entity<Application>());
            new ApplicationPartConfiguration().Configure(modelBuilder.Entity<ApplicationPart>());
            new QuestionConfiguration().Configure(modelBuilder.Entity<Question>());
            new UserApplicationConfiguration().Configure(modelBuilder.Entity<UserApplication>());
            new AnswerConfiguration().Configure(modelBuilder.Entity<Answer>());
            new QuestionItemConfiguration().Configure(modelBuilder.Entity<QuestionItem>());

        }
    }
}
