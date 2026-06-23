

using RestaurantShared.DTOs.CategoriesDTOs;

namespace RestaurantShared.DTOs.ProductsDTOs
{
    public class ReadProductsDto
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string CategoryName { get; set; } = null!;

        public int? PreparationTime { get; set; }

        public bool? IsAvailable { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? ImageUrl { get; set; }

    }
}
