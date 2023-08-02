using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Questions.Queries;

public record GetQuizQuestions(QuizId QuizId) : IRequest<ICollection<Question>>;