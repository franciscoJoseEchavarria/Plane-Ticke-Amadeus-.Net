using Microsoft.EntityFrameworkCore;
using AmadeusAPI.Models; // Descomentar esta línea cuando se creen los modelos de User y User_answers 

// using AmadeusAPI.Models; // Cuando se creen los modelos, descomentar esta línea

namespace AmadeusAPI.Data
{
    public class AmadeusAPIDbContext : DbContext
    {
        public AmadeusAPIDbContext(DbContextOptions<AmadeusAPIDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User_answers> User_answers { get; set;}

        public DbSet<CityModel> City { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<QuestionOption> QuestionOption { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Question>().ToTable("Question")
                .Property(q => q.Text)
                .HasColumnName("text");
            modelBuilder.Entity<Question>()
                .Property(q => q.Category) 
                .HasColumnName("category");
            modelBuilder.Entity<QuestionOption>().ToTable("question_option") .Property(o => o.Text)
                .HasColumnName("text");  
            modelBuilder.Entity<Question>().HasKey(q => q.Id);
            modelBuilder.Entity<QuestionOption>().HasKey(qo => qo.Id);
            modelBuilder.Entity<Question>()
                .HasMany(q => q.Options)
                .WithOne(qo => qo.Question)
                .HasForeignKey(qo => qo.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}