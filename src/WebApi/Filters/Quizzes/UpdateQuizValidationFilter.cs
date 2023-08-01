using Application.DTOs.Quizzes;

namespace WebApi.Filters.Quizzes;

public class UpdateQuizValidationFilter : IEndpointFilter
{
    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var quiz = context.GetArgument<UpdateQuizDto>(1);
        
        if (string.IsNullOrEmpty(quiz.Title)) return await Task.FromResult(Results.BadRequest("Invalid title."));
        
        return await next(context);
    }
}