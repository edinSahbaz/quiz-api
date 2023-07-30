using MediatR;
using Domain.Entities.Quizzes;
using Application.Quizzes.Commands;
using Application.Quizzes.Queries;
using WebApi.Abstractions;

namespace WebApi.EndpointDefinitions;

public class QuizEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var quizzes = app.MapGroup("/api/quizzes");

        quizzes.MapGet("/", GetAllQuizzes);
        quizzes.MapPost("/", CreateQuiz);
    }
    
    private async Task<IResult> GetAllQuizzes(IMediator mediator)
    {
        var getAllQuizzes = new GetAllQuizzes();
        var quizzes = await mediator.Send(getAllQuizzes);

        return TypedResults.Ok(quizzes);
    }
    
    private async Task<IResult> CreateQuiz(IMediator mediator, Quiz quiz)
    {
        var createQuiz = new CreateQuiz
        {
            Id = quiz.Id,
            Title = quiz.Title,
        };
        
        var createdQuiz = await mediator.Send(createQuiz);

        return TypedResults.Ok(createdQuiz);
    }
}