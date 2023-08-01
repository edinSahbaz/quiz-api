using Domain.Entities.Questions;

namespace Application.DTOs;

public class EditQuestionDto
{
    public QuestionId Id { get; set; }
    public string Prompt { get; set; }
    public string Answer { get; set; }
}