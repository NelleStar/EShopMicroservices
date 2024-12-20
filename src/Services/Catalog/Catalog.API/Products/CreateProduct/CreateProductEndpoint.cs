namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);
    public record CreateProductResponse(Guid Id);
    public class CreateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (CreateProductRequest request, ISender sender) =>
            {
                // Mapster Adapt method takes generic Command Obj(CreateProductCommand) and convert from a request to command object
                var command = request.Adapt<CreateProductCommand>();

                // MediatR requires Command Obj to trigger Command Handler so trigger MediatR using the Sender Obj
                var result = await sender.Send(command);

                // need to convert back to CreateProductResponse
                var response = result.Adapt<CreateProductResponse>();

                // return the newly created product ID using the results class from ASP.Net
                return Results.Created($"/products/{response.Id}", response);
            })
                // Carter library extension methods to provide ways to configure out HTTP method
            .WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Create Product");
        }
    }
}
