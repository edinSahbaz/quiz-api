using Application.DTOs.Quizzes;

namespace WebApi.Filters.Quizzes;

public class CreateQuizValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var quiz = context.GetArgument<CreateQuizDto>(1);
        
        if (string.IsNullOrEmpty(quiz.Title)) return await Task.FromResult(Results.BadRequest("Invalid title."));
        
        return await next(context);
    }
}