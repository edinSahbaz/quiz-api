namespace WebApi.Abstractions;

public interface IEndpointDefinition
{
    void RegisterEndpoints(WebApplication app);
}
