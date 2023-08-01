using Application.DTOs.Quizzes;
using MediatR;
using Domain.Entities.Quizzes;
using Domain.Entities.Questions;

namespace Application.Quizzes.Commands;

public class UpdateQuiz : UpdateQuizDto, IRequest<Quiz>
{
}