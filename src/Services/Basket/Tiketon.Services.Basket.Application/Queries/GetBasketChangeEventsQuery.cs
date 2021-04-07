using System;
using System.Collections.Generic;
using MediatR;
using Tiketon.Services.Basket.Domain.Entities;

namespace Tiketon.Services.Basket.Application.Queries
{
    public record GetBasketChangeEventsQuery : IRequest<List<BasketChangeEvent>>
    {
        public GetBasketChangeEventsQuery(DateTime startDate, int max)
        {
            StartDate = startDate;
            Max = max;
        }

        public DateTime StartDate { get; }
        public int Max { get; }
    }
}