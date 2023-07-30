using Domain.Primitives;

namespace Domain.Entities;

public sealed class Quiz : Entity
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    
    public ICollection<Question> Questions { get; set; }
}

public record QuizId(Guid Value);
