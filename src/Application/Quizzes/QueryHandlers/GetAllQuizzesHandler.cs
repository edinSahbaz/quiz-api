using MediatR;
using Domain.Entities.Quizzes;
using Application.Quizzes.Queries;
using Domain.Repositories;

namespace Application.Quizzes.QueryHandlers;

public class GetAllQuizzesHandler : IRequestHandler<GetAllQuizzes, ICollection<Quiz>>
{
    private readonly IQuizRepository _quizRepository;
    
    public GetAllQuizzesHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task<ICollection<Quiz>> Handle(GetAllQuizzes request, CancellationToken cancellationToken)
    {
        return await _quizRepository.GetAllQuizzes();
    }
}