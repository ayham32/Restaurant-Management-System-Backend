
using RestaurantBusiness.InterfaceServices;
using RestaurantDataAccess.Entities;
using RestaurantShared.DTOs.DeliveriesDTOs;
using RestaurantShared.DTOs.EmployeesDTOs;
using RestaurantShared.DTOs.OrdersDTOs;
using RestaurantShared.DTOs.UsersDTOs;
using RestaurantShared.Enums;
using RestaurantShared.Results;
using RestuarantDataAccess.UintOfWork;

namespace RestaurantBusiness.Services
{
    public class DeliveriesService: IDeliveriesService
    {
        private readonly IUnitOfWork _unitOfWork;
     
        public DeliveriesService(IUnitOfWork unitOfWork,IEmployeesService employeesService)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> AddNewDeliveryAsync(CreateDeliveryDto newDelivery)
        {
            if (!await _unitOfWork.empolyeesRepository.isExistAsync(newDelivery.EmployeeId))  
                return Result<int> .Failure("No exist employee with this id");

            var Dlivery = new Delivery
            {
                EmployeeId = newDelivery.EmployeeId,
                OrderId = newDelivery.OrderId,
                Status = enDelivaryStatus.OutForDelivery
            };

            await _unitOfWork.deliveryRepository.AddAsync(Dlivery);

            return await _unitOfWork.SaveChangesAsync() >0? Result<int>.Success(Dlivery.DeliveryId):Result <int>.Failure("Something is wrong");
        }

        public async Task<Result> DeleteDeliveryAsync(int deliveryId)
        {
            if (deliveryId <= 0)
                return Result.Failure("Id must be a postive");

            var delivery = await _unitOfWork.deliveryRepository.GetByIdAsync(deliveryId);

            if(delivery==null) 
                return Result.Failure("No employee wiht this id");

            _unitOfWork.deliveryRepository.DeleteAsync(delivery);

            return await _unitOfWork.SaveChangesAsync() > 0? Result.Success(): Result.Failure("Something is wrong");
        
        }

        public async Task<Result<List<ReadDeliveriesDto>>> GetDeliveriesAsync()
        {

            var Deliveries = await _unitOfWork.deliveryRepository.GetDeliveriesAsync();

            if (Deliveries == null)
                return Result<List<ReadDeliveriesDto>>.Failure("There are no deliveries");


            var DeliveriesDto = Deliveries.Select( d => new ReadDeliveriesDto
            {
                DeliveryId = d.DeliveryId,
                Employee = new ReadEmployeesDto
                {
                    EmployeeId = d.EmployeeId,
                    User = new ReadUsersDto
                    {
                        UserId = d.Employee.UserId,
                        FullName = d.Employee.User.Person.FirstName + " " + d.Employee.User.Person.LastName,
                        NationalNo = d.Employee.User.Person.NationalNo,
                        Username = d.Employee.User.Username,
                        IsActive=d.Employee.User.IsActive
                       
                    },
                    ManagerBy = d.Employee.ManagerId,
                    Salary = d.Employee.Salary,
                    StartTime = d.Employee.StartTime,
                    EndTime = d.Employee.EndTime
                },
                Order = new ReadOrdersDto
                {
                   OrderId = d.OrderId,
                    CustomerId = (int) d.Order.CustomerId ,
                    CreatedBy = d.Order.CreatedBy,
                    OrderDate = d.Order.OrderDate,
                    OrderType = d.Order.OrderType,
                    Status=d.Order.Status,
                    TotalAmount = d.Order.TotalAmount
                },
                Status = d.Status
            });
            

            return Result < List < ReadDeliveriesDto >>.Success(DeliveriesDto.ToList()); 
        }

        public async Task<Result<ReadDeliveriesDto>>? GetDeliveryAsync(int DeliveryId)
        {
            if (DeliveryId <= 0)
                return Result<ReadDeliveriesDto>.Failure("Id must be a postive");

            var Delivery = await _unitOfWork.deliveryRepository.GetDeliveryAsync(DeliveryId);

            if(Delivery == null)
                return Result<ReadDeliveriesDto>.Failure("No exist delivery with this id");

            var DeliveryDto = new ReadDeliveriesDto
            {
                DeliveryId = Delivery.DeliveryId,
                Employee = new ReadEmployeesDto
                {
                    EmployeeId = Delivery.EmployeeId,
                    User = new ReadUsersDto
                    {
                        UserId = Delivery.Employee.UserId,
                        FullName = Delivery.Employee.User.Person.FirstName + " " + Delivery.Employee.User.Person.LastName,
                        NationalNo = Delivery.Employee.User.Person.NationalNo,
                        Username = Delivery.Employee.User.Username,
                        IsActive = Delivery.Employee.User.IsActive

                    },
                    ManagerBy = Delivery.Employee.ManagerId,
                    Salary = Delivery.Employee.Salary,
                    StartTime = Delivery.Employee.StartTime,
                    EndTime = Delivery.Employee.EndTime
                },
                Order = new ReadOrdersDto
                {
                    OrderId = Delivery.OrderId,
                    CustomerId = (int)Delivery.Order.CustomerId,
                    CreatedBy = Delivery.Order.CreatedBy,
                    OrderDate = Delivery.Order.OrderDate,
                    OrderType = Delivery.Order.OrderType,
                    Status = Delivery.Order.Status,
                    TotalAmount = Delivery.Order.TotalAmount
                },
                Status = Delivery.Status
            };

            return Result<ReadDeliveriesDto>.Success(DeliveryDto);
        }

        public async Task<bool> isDeliveryExistAsync(int DeliveryId)
        {
            if (DeliveryId <= 0)
                return false;

            return await _unitOfWork.deliveryRepository.isExistAsync(DeliveryId);
        }

        public async Task<Result> UpdateDeliveryAsync(int deliveryId, UpdateDeliveryDto delivery)
        {
            if (deliveryId<=0)
                return Result.Failure("id must be a postive");

            if (!await _unitOfWork.empolyeesRepository.isExistAsync(delivery.EmployeeId))
                return Result.Failure("No exist employee with this id");


            var DeliveryToUpdate = await _unitOfWork.deliveryRepository.GetByIdAsync(deliveryId);

            if (DeliveryToUpdate == null)
                return Result.Failure("No delivery wiht this id");

            DeliveryToUpdate.EmployeeId=delivery.EmployeeId;
            DeliveryToUpdate.OrderId = delivery.OrderId;     
            DeliveryToUpdate.Status = delivery.Status;

   
            return await _unitOfWork.SaveChangesAsync() > 0 ? Result.Success(): Result.Failure("Something is wrong");

        }
    }
}
