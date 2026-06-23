using RestaurantShared.DTOs.BillsDTOs;
using RestaurantShared.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBusiness.InterfaceServices
{
    public interface IBillServices
    {

        public Task<Result<List<ReadBillsDto>>> GetBillsAsync();

        public Task<Result<ReadBillsDto>> GetBillAsync(int BillId);

        public Task<Result<int>> AddNewBill(CreateBillDto newBill);

        public Task<Result> UpdateBill(int billId, UpdateBillDto bill);

        public Task<Result> DeleteBill(int billId);

    }
}
