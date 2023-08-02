using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public record GetQuizById(QuizId QuizId) : IRequest<Quiz>;
