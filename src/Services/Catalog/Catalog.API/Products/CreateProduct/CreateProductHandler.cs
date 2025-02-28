﻿namespace Catalog.API.Products.CreateProduct
{
    using System.Threading;
    using System.Threading.Tasks;
    using BuildingBlocks.CQRS;
    using Catalog.API.Models;

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price)
        : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler
        : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //TODO: save to database

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
