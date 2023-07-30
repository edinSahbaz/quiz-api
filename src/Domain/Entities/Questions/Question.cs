using Domain.Entities.Quizzes;
using Domain.Primitives;

namespace Domain.Entities.Questions;

public sealed class Question : Entity
{
    public QuestionId Id { get; set; }
    public string Prompt { get; set; }
    public string Answer { get; set; }
    
    public ICollection<Quiz> Quizzes { get; set; }
}