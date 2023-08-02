using MediatR;
using Domain.Entities.Quizzes;

namespace Application.Quizzes.Queries;

public record GetAllQuizzes(
    string? SortColumn, 
    string? SortOrder, 
    int Page, 
    int PageSize, 
    string? Title) : IRequest<ICollection<Quiz>>;