using Domain.Entities.Questions;
using Domain.Entities.Quizzes;

namespace Domain.Repositories;

public interface IQuestionRepository
{
    Task<ICollection<Question>> GetAllQuestions();
    Task<ICollection<Question>> GetQuizQuestions(QuizId quizId);
    Task<Question> CreateQuestion(Question toCreate);
    Task<Question> UpdateQuestion(QuestionId questionId, string prompt, string answer);
    Task DeleteQuestion(QuestionId questionId);
}