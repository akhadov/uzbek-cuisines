
using Application.Instructions.Remove;
using MediatR;
using SharedKernel;
using Web.Api.Extensions;
using Web.Api.Infrastructure;

namespace Web.Api.Endpoints.Instructions;

internal sealed class RemoveInstruction : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("instructions/{instructionId}", async (
            Guid instructionId,
            ISender sender,
            CancellationToken cancellationToken) =>
        {
            var query = new RemoveInstructionCommand(instructionId);

            Result result = await sender.Send(query, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        })
        .WithTags(Tags.Instructions);
    }
}
