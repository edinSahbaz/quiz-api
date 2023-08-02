using MediatR;
using Domain.Entities.Quizzes;
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

        quizzes.MapGet("/", GetAllQuizzes);
        
        quizzes.MapGet("/{quizId:guid}", GetQuizById);
        
        quizzes.MapPost("/", CreateQuiz)
            .AddEndpointFilter<CreateQuizValidationFilter>();
        
        quizzes.MapPut("/", UpdateQuiz)
            .AddEndpointFilter<UpdateQuizValidationFilter>();
        
        quizzes.MapDelete("/", DeleteQuiz);
    }

    private async Task<IResult> GetAllQuizzes(IMediator mediator)
    {
        var getAllQuizzes = new GetAllQuizzes();
        var quizzes = await mediator.Send(getAllQuizzes);

        return TypedResults.Ok(quizzes);
    }
    
    private async Task<IResult> GetQuizById(IMediator mediator, Guid quizId)
    {
        var getQuiz = new GetQuizById(new QuizId(quizId));
        var quiz = await mediator.Send(getQuiz);

        return TypedResults.Ok(quiz);
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