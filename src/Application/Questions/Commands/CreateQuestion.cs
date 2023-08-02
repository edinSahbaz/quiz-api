using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public class CreateQuestion : IRequest<Question>
{
    public string Prompt { get; set; }
    public string Answer { get; set; }
}