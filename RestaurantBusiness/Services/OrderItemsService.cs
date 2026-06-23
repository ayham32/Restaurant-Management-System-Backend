
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using RestaurantShared.DTOs.OrderItemsDTOs;
using RestaurantShared.Enums;
using RestaurantShared.Results;
using RestuarantDataAccess.UintOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.Services
{
    public class OrderItemsService: IOrderItemsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderItemsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> AddNewOrderItem(CreateOrderItemDto newOrderItem)
        {
            if (!await _unitOfWork.ordersRepository.isExistAsync(newOrderItem.OrderId) || !await _unitOfWork.productRepository.isExistAsync(newOrderItem.ProductId))
                return Result<int>.Failure("order / product invalid");

            var Product = await _unitOfWork.productRepository.GetByIdAsync(newOrderItem.ProductId);

            if(Product == null)
                return Result<int>.Failure("Product is not exist");

            if(!Product.IsAvailable)
                return Result<int>.Failure("Product is not available");

            if (Product.Quantity < newOrderItem.Quantity)
                return Result<int>.Failure("this quantity requested is currently unavaliable");

            var Order = await _unitOfWork.ordersRepository.GetByIdAsync(newOrderItem.OrderId);

            if (Order == null)
                return Result<int>.Failure("Order is not exist");

            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var OrderItem = new OrderItem
                {
                    OrderId = newOrderItem.OrderId,
                    ProductId = newOrderItem.ProductId,
                    UnitPrice = Product.Price,
                    Quantity = newOrderItem.Quantity
                };

                Product.Quantity -= newOrderItem.Quantity;

                Order.TotalAmount += (Product.Price * newOrderItem.Quantity);

                if (Product.Quantity == 0)
                    Product.IsAvailable = false;

                await _unitOfWork.orderItemsRepository.AddAsync(OrderItem);

                await _unitOfWork.SaveChangesAsync();

                await _unitOfWork.CommitTransactionAsync();

                return Result<int>.Success(OrderItem.OrderItemId);
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();

                return Result<int>.Failure("Something is wrong, try again");
            }
        }

        public async Task<Result> DeleteOrderItem(int OrderItemId)
        {
            if (OrderItemId <= 0)
                return Result.Failure("Id must be a postive");

            var OrderItem = await _unitOfWork.orderItemsRepository.GetByIdAsync(OrderItemId);

            if (OrderItem == null)
                return Result.Failure("No order item with this id");

            _unitOfWork.orderItemsRepository.DeleteAsync(OrderItem);

            return await _unitOfWork.SaveChangesAsync() >0?Result.Success():Result.Failure("Something is wrong");
        }

        public async Task<Result<ReadOrderItemsDto>> GetOrderItemAsync(int OrderItemId)
        {
            if (OrderItemId <= 0)
                return Result<ReadOrderItemsDto>.Failure("id must be a postive");

            var OrderItem = await _unitOfWork.orderItemsRepository.GetOrderItemAsync(OrderItemId);

            if (OrderItem == null)
                return Result<ReadOrderItemsDto>.Failure("No order item with this id");

            var OrderItemDto = new ReadOrderItemsDto
            {
                OrderItemId = OrderItemId,
                OrderId = OrderItem.OrderId,
                ProductId = OrderItem.ProductId,
                Quantity = OrderItem.Quantity,
                UnitPrice = OrderItem.UnitPrice
            };

            return Result<ReadOrderItemsDto>.Success(OrderItemDto);

        }

        public async Task<Result<List<ReadOrderItemsDto>>> GetOrderItemsAsync()
        {
            var OrderItems = await _unitOfWork.orderItemsRepository.GetOrderItemsAsync();

            if(OrderItems== null|| OrderItems.Count == 0)
                return Result<List<ReadOrderItemsDto>>.Failure("There are no order items");

            var OrderItemsDto = OrderItems.Select(oi => new ReadOrderItemsDto
            {
                OrderItemId = oi.OrderItemId,
                OrderId = oi.OrderId,
                ProductId = oi.ProductId,
                Quantity = oi.Quantity,
                UnitPrice = oi.UnitPrice

            }).ToList();

            return Result<List<ReadOrderItemsDto>>.Success(OrderItemsDto);

        }

        public async Task<Result> UpdateOrderItem(int OrderItemId, UpdateOrderItemDto orderItem)
        {
            if (OrderItemId <= 0)
                return Result.Failure("Id must be a postive");

            var OrderItemToUpdate = await _unitOfWork.orderItemsRepository.GetByIdAsync(OrderItemId);

            if (OrderItemToUpdate == null)
                return Result .Failure("No order item with this id");

            OrderItemToUpdate.UnitPrice = orderItem.UnitPrice;
            OrderItemToUpdate.Quantity= orderItem.Quantity;

            return await _unitOfWork.SaveChangesAsync() > 0? Result.Success(): Result.Failure("Something is wrong");

        }
    }
}
