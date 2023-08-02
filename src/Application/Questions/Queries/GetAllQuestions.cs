using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Queries;

public record GetAllQuestions(
    string? SortColumn, 
    string? SortOrder, 
    int Page, 
    int PageSize, 
    string? Prompt) : IRequest<ICollection<Question>>;
