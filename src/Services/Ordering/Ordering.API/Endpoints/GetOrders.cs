﻿namespace Ordering.API.Endpoints
{
    using BuildingBlocks.Pagination;
    using Ordering.Application.Orders.Queries.GetOrders;

    public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);

    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersQuery(request));

                var response = result.Adapt<GetOrdersResponse>();

                return Results.Ok(response);
            })
           .WithName("GetOrders")
           .Produces<CreateOrderResponse>(StatusCodes.Status200OK)
           .ProducesProblem(StatusCodes.Status400BadRequest)
           .ProducesProblem(StatusCodes.Status404NotFound)
           .WithSummary("Get Orders")
           .WithDescription("Get Orders");
        }
    }
}
