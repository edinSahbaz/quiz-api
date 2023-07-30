using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public class DeleteQuiz : IRequest
{
    public QuizId QuizId { get; set; }
}