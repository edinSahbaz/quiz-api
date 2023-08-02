using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Domain.Repositories;

public interface IQuestionRepository
{
    Task<ICollection<Question>> GetAllQuestions(string? sortColumn, string? sortOrder, int page, int pageSize, string? prompt, QuizId? quizId);
    Task<ICollection<Question>> GetQuestionsByIds(ICollection<QuestionId> questions);
    Task<Question> CreateQuestion(Question toCreate);
    Task<Question> UpdateQuestion(QuestionId questionId, string prompt, string answer);
    Task DeleteQuestion(QuestionId questionId);
}

