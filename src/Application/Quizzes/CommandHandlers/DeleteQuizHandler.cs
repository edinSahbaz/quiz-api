using MediatR;
using Domain.Repositories;
using Application.Quizzes.Commands;

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