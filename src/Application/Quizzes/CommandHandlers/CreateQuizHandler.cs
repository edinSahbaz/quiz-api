using MediatR;
using Domain.Repositories;
using Domain.Entities.Quizzes;
using Application.Quizzes.Commands;

namespace Application.Quizzes.CommandHandlers;

public class CreateQuizHandler : IRequestHandler<CreateQuiz, Quiz>
{
    private readonly IQuizRepository _quizRepository;
    private readonly IQuestionRepository _questionRepository;
    
    public CreateQuizHandler(IQuizRepository quizRepository, IQuestionRepository questionRepository)
    {
        _quizRepository = quizRepository;
        _questionRepository = questionRepository;
    }
    
    public async Task<Quiz> Handle(CreateQuiz request, CancellationToken cancellationToken)
    {
        var questionIds = request.QuestionIds;
        var questions = await _questionRepository.GetQuestionsByIds(questionIds);

        var quiz = new Quiz
        {
            Id = new QuizId(Guid.NewGuid()),
            Title = request.Title,
            Questions = questions,
            AddedTime = DateTime.Now,
            LastModified = DateTime.Now
        };

        return await _quizRepository.CreateQuiz(quiz);
    }
}