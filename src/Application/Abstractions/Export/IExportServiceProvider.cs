namespace Application.Abstractions.Export;

public interface IExportServiceProvider
{
    IExportService? GetExportService(string format);
}