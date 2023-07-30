using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public class DeleteQuestion : IRequest
{
    public QuestionId QuestionId { get; set; }
}