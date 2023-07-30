using MediatR;
using WebApi.Abstractions;
using Application.Quizzes.Queries;

namespace WebApi.EndpointDefinitions;

public class QuizEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var quizzes = app.MapGroup("/api/quizzes");

        quizzes.MapGet("/", GetAllQuizzes);
    }
    
    private async Task<IResult> GetAllQuizzes(IMediator mediator)
    {
        var getAllQuizzes = new GetAllQuizzes();
        var quizzes = await mediator.Send(getAllQuizzes);

        return TypedResults.Ok(quizzes);
    }
}