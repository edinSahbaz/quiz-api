using Application.DTOs.Questions;
using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public class CreateQuestion : CreateQuestionDto, IRequest<Question>
{
}