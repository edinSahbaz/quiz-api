using MediatR;
using Domain.Repositories;
using Domain.Entities.Questions;
using Application.Questions.Commands;

namespace Application.Questions.CommandHandlers;

internal sealed class UpdateQuestionHandler : IRequestHandler<UpdateQuestion, Question>
{
    private readonly IQuestionRepository _questionRepository;
    
    public UpdateQuestionHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }
    
    public async Task<Question> Handle(UpdateQuestion request, CancellationToken cancellationToken)
    {
        return await _questionRepository.UpdateQuestion(request.Id, request.Prompt, request.Answer);
    }
}