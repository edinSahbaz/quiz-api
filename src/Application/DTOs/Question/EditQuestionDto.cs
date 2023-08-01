using Domain.Entities.Questions;

namespace Application.DTOs.Question;

public class EditQuestionDto
{
    public QuestionId Id { get; set; }
    public string Prompt { get; set; }
    public string Answer { get; set; }
}