using Domain.Entities.Quizzes;
using Domain.Entities.Questions;

namespace Application.DTOs.Quizzes;

public class UpdateQuizDto
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}