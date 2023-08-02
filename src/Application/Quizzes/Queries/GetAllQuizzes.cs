using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public record GetAllQuizzes() : IRequest<ICollection<Quiz>>;