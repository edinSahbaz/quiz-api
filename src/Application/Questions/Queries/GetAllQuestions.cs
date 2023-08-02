using MediatR;
using Domain.Entities.Questions;

namespace Application.Questions.Queries;

public record GetAllQuestions(int Page, int PageSize) : IRequest<ICollection<Question>>;
