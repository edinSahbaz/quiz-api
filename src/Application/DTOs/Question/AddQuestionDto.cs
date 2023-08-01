using Domain.Entities.Questions;

namespace Application.DTOs.Questions;

public class AddQuestionDto
{
    public string Prompt { get; set; }
    public string Answer { get; set; }
}