using MediatR;
using Domain.Entities.Quizzes;
using Application.Abstractions.Export;
using Application.Quizzes.Commands;
using Application.Quizzes.Queries;
using WebApi.Abstractions;
using WebApi.Filters.Quizzes;

namespace WebApi.EndpointDefinitions;

public class QuizEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var quizzes = app.MapGroup("/api/quizzes");

        quizzes.MapGet("/", GetAllQuizzes)
            .RequireRateLimiting("fixed");
        
        quizzes.MapGet("/{quizId:guid}", GetQuizById);
        
        quizzes.MapGet("/export/{quizId:guid}", ExportQuiz);
        
        quizzes.MapPost("/", CreateQuiz)
            .AddEndpointFilter<CreateQuizValidationFilter>();
        
        quizzes.MapPut("/", UpdateQuiz)
            .AddEndpointFilter<UpdateQuizValidationFilter>();
        
        quizzes.MapDelete("/{quizId:guid}", DeleteQuiz);
    }

    private async Task<IResult> GetAllQuizzes(
        IMediator mediator, 
        string? sortColumn, 
        string? sortOrder, 
        int page, 
        int pageSize, 
        string? title)
    {
        var getAllQuizzes = new GetAllQuizzes(sortColumn, sortOrder, page, pageSize, title);
        var quizzes = await mediator.Send(getAllQuizzes);

        return TypedResults.Ok(quizzes);
    }
    
    private async Task<IResult> GetQuizById(IMediator mediator, Guid quizId)
    {
        var getQuiz = new GetQuizById(new QuizId(quizId));
        var quiz = await mediator.Send(getQuiz);

        return TypedResults.Ok(quiz);
    }
    
    private async Task<IResult> ExportQuiz(IMediator mediator, IExportServiceProvider exportServiceProvider, string format, string fileName, Guid quizId)
    {
        var getQuiz = new GetQuizById(new QuizId(quizId));
        var quiz = await mediator.Send(getQuiz);

        var exporter = exportServiceProvider.GetExportService(format);

        if (exporter is null)
        {
            return Results.BadRequest("Unsupported export format.");
        }
        
        var exportedData = exporter.ExportQuiz(quiz);

        return Results.File(exportedData, "application/octet-stream", $"{fileName}{exporter.Extension}");
    }
    
    private async Task<IResult> CreateQuiz(IMediator mediator, CreateQuiz command)
    {
        var createdQuiz = await mediator.Send(command);

        return TypedResults.Ok(createdQuiz);
    }
    
    private async Task<IResult> UpdateQuiz(IMediator mediator, UpdateQuiz command)
    {
        var updatedQuiz = await mediator.Send(command);

        return TypedResults.Ok(updatedQuiz);
    }
    
    private async Task<IResult> DeleteQuiz(IMediator mediator, Guid quizId)
    {
        var deleteQuiz = new DeleteQuiz(new QuizId(quizId));
        
        await mediator.Send(deleteQuiz);

        return TypedResults.NoContent();
    }
}