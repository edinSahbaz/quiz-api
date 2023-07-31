using Domain.Entities.Quizzes;
using Domain.Entities.Questions;

namespace Application.DTOs;

public sealed class NewQuiz
{
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}