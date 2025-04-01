namespace Ordering.Application.Orders.Commands.CreateOrder
{
    using System.Threading;
    using System.Threading.Tasks;
    using BuildingBlocks.CQRS;

    public class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Create Order entity from command object
            //save to database
            //return result


            throw new NotImplementedException();
        }
    }
}
