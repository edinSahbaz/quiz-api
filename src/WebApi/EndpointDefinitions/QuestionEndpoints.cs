using Application.Questions.Commands;
using Domain.Entities.Questions;
using MediatR;
using WebApi.Abstractions;

namespace WebApi.EndpointDefinitions;

public class QuestionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var questions = app.MapGroup("/api/questions");

        questions.MapPost("/", CreateQuestion);
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
}