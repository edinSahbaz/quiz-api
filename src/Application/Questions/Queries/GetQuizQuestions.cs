using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Questions.Queries;

public class GetQuizQuestions : IRequest<ICollection<Question>>
{
    public QuizId QuizId { get; set; }
}