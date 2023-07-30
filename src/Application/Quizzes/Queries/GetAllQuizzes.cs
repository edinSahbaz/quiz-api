using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public class GetAllQuizzes : IRequest<ICollection<Quiz>>
{
}