using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public record GetAllQuizzes(int Page, int PageSize) : IRequest<ICollection<Quiz>>;