using Domain.Entities.Quiz;
using Domain.Entities.Question;
using Domain.Entities.QuizQuestion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class QuizQuestionConfiguration : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasKey(qq => new { qq.QuizId, qq.QuestionId });

        builder.Property(q => q.QuizId)
            .HasConversion(quizId => quizId.Value,
            value => new QuizId(value));

        builder.Property(q => q.QuestionId)
            .HasConversion(questionId => questionId.Value,
            value => new QuestionId(value));
    }
}
