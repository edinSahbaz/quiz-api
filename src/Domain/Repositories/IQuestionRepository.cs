using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Domain.Repositories;

public interface IQuestionRepository
{
    Task<ICollection<Question>> GetAllQuestions(int page, int pageSize);
    Task<ICollection<Question>> GetQuizQuestions(QuizId quizId);
    Task<ICollection<Question>> GetQuestionsByIds(ICollection<QuestionId> questions);
    Task<ICollection<Question>> GetQuestionByPrompt(string prompt);
    Task<Question> CreateQuestion(Question toCreate);
    Task<Question> UpdateQuestion(QuestionId questionId, string prompt, string answer);
    Task DeleteQuestion(QuestionId questionId);
}

