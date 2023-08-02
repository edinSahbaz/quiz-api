using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public record DeleteQuiz(QuizId QuizId) : IRequest;