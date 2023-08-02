using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public record DeleteQuestion(QuestionId QuestionId) : IRequest;
