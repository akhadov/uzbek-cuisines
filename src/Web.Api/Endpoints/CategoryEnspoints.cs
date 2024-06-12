//using Application.Categories.Create;
//using MediatR;

//namespace Web.Api.Endpoints;

//public static class CategoryEnspoints
//{
//    public static void MapEndpoints(this IEndpointRouteBuilder routes)
//    {
//        routes.MapPost("api/categories", async (
//            CreateCategoryRequest request,
//            ISender sender,
//            CancellationToken cancellationToken) =>
//        {

//            var command = new CreateCategoryCommand(
//                request.Name,
//                request.Image);

//            Result<Guid> result = await sender.Send(command, cancellationToken);

//            return result.Match(Results.Ok, CustomResults.Problem);

//        });

//        //routes.MapGet("api/categories/{categoryId}", async (
//        //    Guid categoryId,
//        //    ISender sender,
//        //    CancellationToken cancellationToken) =>
//        //{
//        //    var query = new GetCategoryByIdQuery(new CategoryId(categoryId));

//        //    Result<CategoryResponse> result = await sender.Send(query, cancellationToken);

//        //    return result.Match(Results.Ok, CustomResults.Problem);
//        //});

//        //routes.MapPut("api/categories/{categoryId}", async (
//        //        Guid categoryId,
//        //        UpdateCategoryRequest request,
//        //        ISender sender,
//        //        CancellationToken cancellationToken) =>
//        //{
//        //    var command = new UpdateCategoryCommand(
//        //        new CategoryId(categoryId),
//        //        request.Name,
//        //        request.ImagePath);

//        //    Result result = await sender.Send(command, cancellationToken);

//        //    return result.Match(Results.NoContent, CustomResults.Problem);
//        //});

//        //routes.MapDelete("api/categories/{categoryId}", async (
//        //        Guid categoryId, // Change the parameter type to Guid
//        //        ISender sender,
//        //        CancellationToken cancellationToken) =>
//        //{
//        //    var query = new DeleteCategoryCommand(new CategoryId(categoryId)); // Ensure categoryId is of type Guid

//        //    Result result = await sender.Send(query, cancellationToken);

//        //    return result.Match(Results.NoContent, CustomResults.Problem);
//        //});

//    }
//}
