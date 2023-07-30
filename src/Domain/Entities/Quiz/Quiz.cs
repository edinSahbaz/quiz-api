namespace Domain.Entities.Quiz;

public record Quiz
{
    public required QuizId Id { get; set; }
    public required string Title { get; set; }
}
