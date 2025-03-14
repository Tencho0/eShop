﻿namespace BuildingBlocks.CQRS
{
    using MediatR;

    public interface IQuery<out TResponse>
        : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}
