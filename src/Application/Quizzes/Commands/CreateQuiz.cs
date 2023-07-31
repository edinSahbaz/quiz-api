using MediatR;
using Domain.Entities.Quizzes;
using Domain.Entities.Questions;

namespace Application.Quizzes.Commands;

public class CreateQuiz : IRequest<Quiz>
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}