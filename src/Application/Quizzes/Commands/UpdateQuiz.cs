using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public class UpdateQuiz : IRequest<Quiz>
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}