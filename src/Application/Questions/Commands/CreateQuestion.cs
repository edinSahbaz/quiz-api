using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public record CreateQuestion(string Prompt, string Answer) : IRequest<Question>;
