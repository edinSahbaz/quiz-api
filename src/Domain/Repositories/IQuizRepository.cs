using Domain.Entities.Quizzes;

namespace Domain.Repositories;

public interface IQuizRepository
{
    Task<ICollection<Quiz>> GetAllQuizzes();
}