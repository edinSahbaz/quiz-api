using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Queries;

public class GetAllQuestions : IRequest<ICollection<Question>>
{
}