using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public record UpdateQuestion(QuestionId Id, string Prompt, string Answer) : IRequest<Question>;
