using Application.Questions.Commands;
using Application.Questions.Queries;
using Domain.Entities.Questions;
using MediatR;
using WebApi.Abstractions;

namespace WebApi.EndpointDefinitions;

public class QuestionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var questions = app.MapGroup("/api/questions");

        questions.MapGet("/", GetAllQuestions);
        questions.MapPost("/", CreateQuestion);
        questions.MapPut("/", UpdateQuestion);
        questions.MapDelete("/", DeleteQuestion);
    }
    
    private async Task<IResult> GetAllQuestions(IMediator mediator)
    {
        var getAllQuestions = new GetAllQuestions();
        var questions = await mediator.Send(getAllQuestions);

        return TypedResults.Ok(questions);
    }
    
    private async Task<IResult> CreateQuestion(IMediator mediator, Question question)
    {
        var createQuestion = new CreateQuestion
        {
            Id = question.Id,
            Prompt = question.Prompt,
            Answer = question.Answer,
        };
        
        var createdQuestion = await mediator.Send(createQuestion);

        return TypedResults.Ok(createdQuestion);
    }
    
    private async Task<IResult> UpdateQuestion(IMediator mediator, Question question)
    {
        var updateQuestion = new UpdateQuestion
        {
            QuestionId = question.Id,
            Prompt = question.Prompt,
            Answer = question.Answer,
        };
        
        var updatedQuestion = await mediator.Send(updateQuestion);

        return TypedResults.Ok(updatedQuestion);
    }
    
    private async Task<IResult> DeleteQuestion(IMediator mediator, Guid questionId)
    {
        var deleteQuestion = new DeleteQuestion { QuestionId = new QuestionId(questionId) };
        await mediator.Send(deleteQuestion);

        return TypedResults.NoContent();
    }
}