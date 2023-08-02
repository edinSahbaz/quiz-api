using Domain.Entities.Quizzes;
using Domain.Entities.Questions;

namespace Domain.Repositories;

public interface IQuizRepository
{
    Task<ICollection<Quiz>> GetAllQuizzes(string? sortColumn, string? sortOrder, int page, int pageSize, string? title);
    Task<Quiz> GetQuizById(QuizId quizId);
    Task<Quiz> CreateQuiz(Quiz toCreate);
    Task<Quiz> UpdateQuiz(QuizId quizId, string title, ICollection<QuestionId> questionIds);
    Task DeleteQuiz(QuizId quizId);
}