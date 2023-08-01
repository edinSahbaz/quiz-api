using Domain.Entities.Questions;
using Domain.Models;

namespace Domain.Entities.Quizzes;

public sealed class Quiz : Entity<QuizId>
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    
    public ICollection<Question> Questions { get; set; }

}