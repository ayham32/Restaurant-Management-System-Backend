

using Microsoft.AspNetCore.Http;

namespace RestaurantShared.DTOs.ProductsDTOs
{
    public class CreateProductDto
    {
        
        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public int? PreparationTime { get; set; }

        public bool IsAvailable { get; set; }     
        
        public IFormFile? Image { get; set; }
    }
}
