using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Queries;

public class GetQuestionsByPrompt : IRequest<ICollection<Question>>
{
    public string Prompt { get; set; }
}