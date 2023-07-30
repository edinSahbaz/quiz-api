namespace Domain.Entities.Question;

public record Question
{
    public required QuestionId Id { get; set; }
    public required string Prompt { get; set; }
    public required string Answer { get; set; }
}
