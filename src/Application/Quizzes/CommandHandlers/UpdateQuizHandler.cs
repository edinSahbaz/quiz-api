using MediatR;
using Domain.Repositories;
using Domain.Entities.Quizzes;
using Application.Quizzes.Commands;

namespace Application.Quizzes.CommandHandlers;

public class UpdateQuizHandler : IRequestHandler<UpdateQuiz, Quiz>
{
    private readonly IQuizRepository _quizRepository;
    
    public UpdateQuizHandler(IQuizRepository quizRepository)
    {
        _quizRepository = quizRepository;
    }

    public async Task<Quiz> Handle(UpdateQuiz request, CancellationToken cancellationToken)
    {
        return await _quizRepository.UpdateQuiz(request.Id, request.Title, request.QuestionIds);
    }
}