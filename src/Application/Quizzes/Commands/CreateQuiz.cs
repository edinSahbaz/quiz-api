using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public record CreateQuiz(string Title, ICollection<QuestionId> QuestionIds) : IRequest<Quiz>;
