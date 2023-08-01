using MediatR;
using Application.DTOs.Quizzes;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Commands;

public class CreateQuiz : CreateQuizDto, IRequest<Quiz>
{
}