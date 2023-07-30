using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public class UpdateQuestion : IRequest<Question>
{
    public QuestionId QuestionId { get; set; }    
    public string Prompt { get; set; }
    public string Answer { get; set; }
}