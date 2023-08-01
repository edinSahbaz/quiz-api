using MediatR;
using Domain.Entities.Quizzes;
using Application.Quizzes.Commands;
using Application.Quizzes.Queries;
using Application.DTOs.Quiz;
using WebApi.Abstractions;

namespace WebApi.EndpointDefinitions;

public class QuizEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var quizzes = app.MapGroup("/api/quizzes");

        quizzes.MapGet("/", GetAllQuizzes);
        quizzes.MapGet("/{quizId:guid}", GetQuizById);
        quizzes.MapPost("/", CreateQuiz);
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
        var getQuiz = new GetQuizById { QuizId = new QuizId(quizId) };
        var quiz = await mediator.Send(getQuiz);

        return TypedResults.Ok(quiz);
    }
    
    private async Task<IResult> CreateQuiz(IMediator mediator, AddQuizDto newQuiz)
    {
        var createQuiz = new CreateQuiz
        {
            Title = newQuiz.Title,
            QuestionIds = newQuiz.QuestionIds
        };
        
        var createdQuiz = await mediator.Send(createQuiz);

        return TypedResults.Ok(createdQuiz);
    }
    
    private async Task<IResult> DeleteQuiz(IMediator mediator, Guid quizId)
    {
        var deleteQuiz = new DeleteQuiz { QuizId = new QuizId(quizId) };
        await mediator.Send(deleteQuiz);

        return TypedResults.NoContent();
    }
}