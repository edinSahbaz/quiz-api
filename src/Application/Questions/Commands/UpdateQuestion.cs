using MediatR;
using Application.DTOs.Questions;
using Domain.Entities.Questions;

namespace Application.Questions.Commands;

public class UpdateQuestion : UpdateQuestionDto, IRequest<Question>
{
}