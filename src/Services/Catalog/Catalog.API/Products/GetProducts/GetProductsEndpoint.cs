namespace Catalog.API.Products.GetProducts
{
    // best practice - always define request and response in the endpoint
    public record GetProductsResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async (ISender sender) =>
            {
                // Get all products
                var result = await sender.Send(new GetProductsQuery());

                // after response convert type from mediatR handle class to a getproductresponse obj
                var response = result.Adapt<GetProductsResponse>();

                // return the response
                return Results.Ok(response);
            })
            .WithName("GetProducts")
            .Produces<GetProductsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products");
        }
    }
}
