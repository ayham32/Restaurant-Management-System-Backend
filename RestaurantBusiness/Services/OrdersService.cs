
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using RestaurantShared.DTOs.OrdersDTOs;
using RestaurantShared.Entities;
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
    public class OrdersService: IOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> AddNewOrderAsync(CreateOrderDto newOrder)
        {  

            if (!await _unitOfWork.empolyeesRepository.isExistAsync(newOrder.CreatedBy.Value))
            {
                return Result<int>.Failure("No employee exists with this id");
            }

            var order = new Order
            {
                CustomerId = newOrder.CustomerId,
                CreatedBy = newOrder.CreatedBy.Value,
                OrderDate = DateTime.Now,
                Status = newOrder.Status,
                OrderType = newOrder.OrderType,
                TableNumber = newOrder.TableNumber,
                TotalAmount = newOrder.TotalAmount,

            };

            await _unitOfWork.ordersRepository.AddAsync(order);

            return await _unitOfWork.SaveChangesAsync() > 0 ? Result<int>.Success(order.OrderId): Result<int>.Failure("Something is wrong");
        
        }

        public async Task<Result> DeleteOrder(int OrderId)
        {
            if (OrderId <= 0)
                return Result.Failure("Id must be a postiver");


            var Order = await _unitOfWork.ordersRepository.GetByIdAsync(OrderId);

            if (Order == null)
                return Result.Failure("No exist order with this id");

            _unitOfWork.ordersRepository.DeleteAsync(Order);

            return await _unitOfWork.SaveChangesAsync() > 0? Result.Success(): Result.Failure("Something is wrong");
        }

        public async Task<Result<ReadOrdersDto>> GetOrderAsync(int OrderId)
        {
            if (OrderId <= 0)
                return Result<ReadOrdersDto>.Failure("Id must be a postive");

            var order = await _unitOfWork.ordersRepository.GetOrderAsync(OrderId);

            if (order == null)
                return Result<ReadOrdersDto>.Failure("No exist order with this id");

            var orderDto = new ReadOrdersDto
            {
                OrderId = order.OrderId,
                CreatedBy = order.CreatedBy,
                CustomerId = order.CustomerId ?? 0,
                OrderDate = order.OrderDate,
                OrderType = order.OrderType,
                Status = order.Status,
                TableNumber = order.TableNumber,
                TotalAmount = order.TotalAmount
            };

            return Result<ReadOrdersDto>.Success(orderDto);
        
        }

        public async Task<Result<List<ReadOrdersDto>>> GetOrdersAsync()
        {
            var Orders = await _unitOfWork.ordersRepository.GetOrdersAsync();

            if (Orders == null)
                return Result<List<ReadOrdersDto>>.Failure("There are no orders");

            var OrdersDto = Orders.Select(o => new ReadOrdersDto
            {
                OrderId = o.OrderId,
                CreatedBy = o.CreatedBy,
                CustomerId = (int)o.CustomerId,
                Status = o.Status,
                OrderType = o.OrderType,
                OrderDate = o.OrderDate,
                TableNumber = o.TableNumber,
                TotalAmount = o.TotalAmount
            }).ToList();
        
            return Result<List<ReadOrdersDto>>.Success(OrdersDto);
        }

        public async Task<bool> isOrderExistAsync(int OrderId)
        {
            if (OrderId <= 0)
                return false;

            return await _unitOfWork.ordersRepository.isExistAsync(OrderId);

        }

        public async Task<Result> UpdateOrderAsync(int orderId, UpdateOrderDto order)
        {
            if (orderId <= 0)
                return Result.Failure("Id must be a postive");

            var orderToUpdate = await _unitOfWork.ordersRepository.GetByIdAsync(orderId);
            
            if(orderToUpdate == null)
                return Result.Failure("No exist order with this id");
        

            orderToUpdate.OrderType = order.OrderType;
            orderToUpdate.Status = order.Status;
            orderToUpdate.TotalAmount = order.TotalAmount;
            orderToUpdate.TableNumber = order.TableNumber;

            return await _unitOfWork.SaveChangesAsync() > 0? Result.Success(): Result.Failure("Something is wrong");
        }
    }
}
