using Domain.Models;

namespace Domain.ValueObjects;

public class CsvQuizModel : ValueObject
{
    public string Questions { get; set; }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Questions;
    }
}