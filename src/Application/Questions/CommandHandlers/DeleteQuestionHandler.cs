using MediatR;
using Domain.Repositories;
using Application.Questions.Commands;

namespace Application.Questions.CommandHandlers;

internal sealed class DeleteQuestionHandler : IRequestHandler<DeleteQuestion>
{
    private readonly IQuestionRepository _questionRepository;
    
    public DeleteQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task Handle(DeleteQuestion request, CancellationToken cancellationToken)
    {
        await _questionRepository.DeleteQuestion(request.QuestionId);
    }
}