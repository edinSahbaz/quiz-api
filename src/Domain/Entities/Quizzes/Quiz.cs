using Domain.Entities.Questions;
using Domain.Primitives;

namespace Domain.Entities.Quizzes;

public sealed class Quiz : Entity
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    
    public ICollection<Question> Questions { get; set; }
}