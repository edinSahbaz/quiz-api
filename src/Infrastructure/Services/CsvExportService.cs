using System.ComponentModel.Composition;
using System.Globalization;
using Application.Abstractions.Export;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities.Quizzes;
using Domain.ValueObjects;

namespace Infrastructure.Services;

[Export(typeof(IExportService))]
public class CsvExportService : IExportService
{
    public string Format => "text/csv";
    public string Extension => ".csv";

    public byte[] ExportQuiz(Quiz quiz)
    {
        var data = new List<CsvQuizModel>();

        foreach (var question in quiz.Questions)
        {
            data.Add(new CsvQuizModel{ Questions = question.Prompt });
        }

        using var memoryStream = new MemoryStream();
        using (var writer = new StreamWriter(memoryStream))
        using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
        {
            csv.WriteRecords(data);
        }

        return memoryStream.ToArray();
    }
}
