using MediatR;
using Application.Quizzes.Commands;
using Domain.Entities.Quizzes;
using Domain.Repositories;

namespace Application.Quizzes.CommandHandlers;

public class DeleteQuizHandler : IRequestHandler<DeleteQuiz>
{
    private readonly IQuizRepository _quizRepository;
    
    public DeleteQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }
    
    public async Task Handle(DeleteQuiz request, CancellationToken cancellationToken)
    {
        await _quizRepository.DeleteQuiz(request.QuizId);
    }
}