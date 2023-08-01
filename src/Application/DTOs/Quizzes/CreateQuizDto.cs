using Domain.Entities.Questions;

namespace Application.DTOs.Quizzes;

public class CreateQuizDto
{
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}