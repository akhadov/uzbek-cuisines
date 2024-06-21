using Application.Instructions.Create;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Instructions;

internal sealed class Create : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("instructions", async (
            CreateInstructionRequest request,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var command = new CreateInstructionCommand(
                request.RecipeId,
                request.StepNumber,
                request.Description);

            Result<Guid> result = await sender.Send(command, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        })
        .WithTags(Tags.Instructions);
    }
}
