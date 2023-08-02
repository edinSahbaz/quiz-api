using MediatR;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Application.Questions.Queries;

public record GetAllQuestions(
    string? SortColumn, 
    string? SortOrder, 
    int Page, 
    int PageSize, 
    string? Prompt,
    QuizId? QuizId) : IRequest<ICollection<Question>>;
