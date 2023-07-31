using MediatR;
using Domain.Repositories;
using Domain.Entities.Questions;
using Application.Questions.Queries;

namespace Application.Questions.QueryHandlers;

public class GetQuizQuestionsHandler : IRequestHandler<GetQuizQuestions, ICollection<Question>>
{
    private readonly IQuestionRepository _questionRepository;
    
    public GetQuizQuestionsHandler(IQuestionRepository questionRepository)
    {
        _questionRepository = questionRepository;
    }

    public async Task<ICollection<Question>> Handle(GetQuizQuestions request, CancellationToken cancellationToken)
    {
        return await _questionRepository.GetQuizQuestions(request.QuizId);
    }
}