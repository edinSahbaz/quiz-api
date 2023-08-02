using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities.Quizzes;
using Domain.ValueObjects;

public interface IExportService
{
    string Format { get; }
    string Extension { get; }
    byte[] ExportQuiz(Quiz quiz);
}

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

public interface IExportServiceProvider
{
    IExportService? GetExportService(string format);
}

public class ExportServiceProvider : IExportServiceProvider
{
    private readonly CompositionContainer _container;
    private readonly Dictionary<string, IExportService> _exporters;

    [ImportingConstructor]
    public ExportServiceProvider(CompositionContainer container)
    {
        _container = container;
        _exporters = _container.GetExports<IExportService>()
            .ToDictionary(e => e.Value.Format, e => e.Value);
    }

    public IExportService? GetExportService(string format)
    {
        _exporters.TryGetValue(format, out var exporter);
        return exporter;
    }
}

public static class ExporterExtensions
{
    public static void AddExporterProvider(this IServiceCollection services)
    {
        services.AddSingleton<IExportServiceProvider, ExportServiceProvider>();
    }
}
