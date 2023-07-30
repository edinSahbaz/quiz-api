using Domain.Entities.Quiz;
using Domain.Entities.Question;
using Domain.Entities.QuizQuestion;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class EnterwellQuizDbContext : DbContext
{
    public EnterwellQuizDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EnterwellQuizDbContext).Assembly);
    }

    public DbSet<Quiz> Quizzes { get; set; }

    public DbSet<Question> Questions { get; set; }

    public DbSet<QuizQuestion> QuizQuestions { get; set; }
}
