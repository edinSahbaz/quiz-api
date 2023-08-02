using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public record UpdateQuiz(QuizId Id, string Title, ICollection<QuestionId> QuestionIds) : IRequest<Quiz>;
