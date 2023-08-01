using MediatR;
using Domain.Repositories;
using Domain.Entities.Questions;
using Application.Questions.Queries;

namespace Application.Questions.QueryHandlers;

public class GetQuestionsByPromptHandler : IRequestHandler<GetQuestionsByPrompt, ICollection<Question>>
{
    private readonly IQuestionRepository _questionRepository;
    
    public GetQuestionsByPromptHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ICollection<Question>> Handle(GetQuestionsByPrompt request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetQuestionByPrompt(request.Prompt);
    }
}