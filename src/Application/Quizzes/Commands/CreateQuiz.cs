using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public class CreateQuiz : IRequest<Quiz>
{
    public string Title { get; set; }
    public ICollection<QuestionId> QuestionIds { get; set; }
}