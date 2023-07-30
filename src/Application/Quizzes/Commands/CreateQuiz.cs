using Domain.Entities.Questions;
using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public class CreateQuiz : IRequest<Quiz>
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    public ICollection<QuestionId> Questions { get; set; }
}