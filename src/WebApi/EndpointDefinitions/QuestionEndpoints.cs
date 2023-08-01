using MediatR;
using Application.DTOs.Questions;
using Application.Questions.Queries;
using Application.Questions.Commands;
using Domain.Entities.Questions;
using Domain.Entities.Quizzes;
using WebApi.Abstractions;

namespace WebApi.EndpointDefinitions;

public class QuestionEndpoints : IEndpointDefinition
{
    public void RegisterEndpoints(WebApplication app)
    {
        var questions = app.MapGroup("/api/questions");

        questions.MapGet("/", GetAllQuestions);
        questions.MapGet("/{quizId:guid}", GetQuizQuestions);
        questions.MapGet("/{prompt}", GetQuestionsByPrompt);
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
    
    private async Task<IResult> GetQuizQuestions(IMediator mediator, Guid quizId)
    {
        var getQuestions = new GetQuizQuestions { QuizId = new QuizId(quizId) };
        var questions = await mediator.Send(getQuestions);

        return TypedResults.Ok(questions);
    }
    
    private async Task<IResult> GetQuestionsByPrompt(IMediator mediator, string prompt)
    {
        var getQuestions = new GetQuestionsByPrompt { Prompt = prompt };
        var questions = await mediator.Send(getQuestions);

        return TypedResults.Ok(questions);
    }
    
    private async Task<IResult> CreateQuestion(IMediator mediator, CreateQuestionDto question)
    {
        var createQuestion = new CreateQuestion
        {
            Prompt = question.Prompt,
            Answer = question.Answer,
        };
        
        var createdQuestion = await mediator.Send(createQuestion);

        return TypedResults.Ok(createdQuestion);
    }
    
    private async Task<IResult> UpdateQuestion(IMediator mediator, UpdateQuestionDto question)
    {
        var updateQuestion = new UpdateQuestion
        {
            Id = question.Id,
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