using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Queries;

public record GetQuestionsByPrompt(string Prompt) : IRequest<ICollection<Question>>;
