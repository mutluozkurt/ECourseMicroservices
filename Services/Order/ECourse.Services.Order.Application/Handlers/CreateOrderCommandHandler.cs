﻿using ECourse.Services.Order.Application.Command;
using ECourse.Services.Order.Application.Dtos;
using ECourse.Services.Order.Domain.OrderAggregate;
using ECourse.Services.Order.Infrastructure;
using ECourse.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECourse.Services.Order.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Response<CreatedOrderDto>>
    {
        private readonly OrderDbContext _context;

        public CreateOrderCommandHandler(OrderDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedOrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var newAddress = new Address(request.Address.Province, request.Address.District, request.Address.Street, request.Address.ZipCode, request.Address.Line);

            Domain.OrderAggregate.Order newOrder = new Domain.OrderAggregate.Order(request.BuyerId, newAddress);

            request.OrderItems.ForEach(x =>
            {
                newOrder.AddOrderItem(x.ProductId, x.ProductName, x.Price, x.PictureUrl);
            });

            await _context.Orders.AddAsync(newOrder);

            await _context.SaveChangesAsync();

            return Response<CreatedOrderDto>.Success(new CreatedOrderDto { OrderId = newOrder.Id }, 200);
        }
    }

}
