using Domain.Entities.Question;
using Domain.Entities.Quiz;

namespace Domain.Entities.QuizQuestion;

public sealed record QuizQuestion
{
    public required QuizId QuizId { get; set; }
    public required QuestionId QuestionId { get; set; }
}
