namespace Domain.Entities;

public sealed class Quiz
{
    public QuizId Id { get; set; }
    public string Title { get; set; }
    public DateTime AddedTime { get; set; }
    public ICollection<Question> Questions { get; set; }
}

public record QuizId(Guid Value);
