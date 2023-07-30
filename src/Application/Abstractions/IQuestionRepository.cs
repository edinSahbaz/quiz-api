using Domain.Entities;

namespace Application.Abstractions;

public interface IQuestionRepository
{
    Task<ICollection<Question>> GetAllQuestions();
    Task<Question> CreateQuestion(Question toCreate);
    Task<Question> UpdateQuestion(QuestionId questionId, string prompt, string answer);
    Task DeleteQuestion(QuestionId questionId);
}