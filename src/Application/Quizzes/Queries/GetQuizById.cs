using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public class GetQuizById : IRequest<Quiz>
{
    public QuizId QuizId { get; set; }
}