using MediatR;
using Application.Questions.Queries;
using Application.Questions.Commands;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;
using WebApi.Abstractions;
using WebApi.Filters.Questions;

namespace WebApi.EndpointDefinitions;

public class QuestionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var questions = app.MapGroup("/api/questions");

        questions.MapGet("/", GetAllQuestions);
        
        questions.MapGet("/{quizId:guid}", GetQuizQuestions);
        
        questions.MapPost("/", CreateQuestion)
            .AddEndpointFilter<CreateQuestionValidationFilter>();
        
        questions.MapPut("/", UpdateQuestion)
            .AddEndpointFilter<UpdateQuestionValidationFilter>();

        questions.MapDelete("/", DeleteQuestion);
    }
    
    private async Task<IResult> GetAllQuestions(
        IMediator mediator, 
        string? sortColumn, 
        string? sortOrder, 
        int page, 
        int pageSize, 
        string? prompt)
    {
        var getAllQuestions = new GetAllQuestions(sortColumn, sortOrder, page, pageSize, prompt);
        var questions = await mediator.Send(getAllQuestions);

        return TypedResults.Ok(questions);
    }
    
    private async Task<IResult> GetQuizQuestions(IMediator mediator, Guid quizId)
    {
        var getQuestions = new GetQuizQuestions(new QuizId(quizId));
        var questions = await mediator.Send(getQuestions);

        return TypedResults.Ok(questions);
    }

    private async Task<IResult> CreateQuestion(IMediator mediator, CreateQuestion command)
    {
        var createdQuestion = await mediator.Send(command);

        return TypedResults.Ok(createdQuestion);
    }
    
    private async Task<IResult> UpdateQuestion(IMediator mediator, UpdateQuestion command)
    {
        var updatedQuestion = await mediator.Send(command);

        return TypedResults.Ok(updatedQuestion);
    }
    
    private async Task<IResult> DeleteQuestion(IMediator mediator, Guid questionId)
    {
        var deleteQuestion = new DeleteQuestion(new QuestionId(questionId));
        
        await mediator.Send(deleteQuestion);

        return TypedResults.NoContent();
    }
}