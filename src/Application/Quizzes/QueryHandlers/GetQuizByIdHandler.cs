using MediatR;
using Domain.Repositories;
using Domain.Entities.Quizzes;
using Application.Quizzes.Queries;

namespace Application.Quizzes.QueryHandlers;

internal sealed class GetQuizByIdHandler : IRequestHandler<GetQuizById, Quiz>
{
    private readonly IQuizRepository _quizRepository;
    
    public GetQuizByIdHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<Quiz> Handle(GetQuizById request, CancellationToken cancellationToken)
    {
        return await _quizRepository.GetQuizById(request.QuizId);
    }
}