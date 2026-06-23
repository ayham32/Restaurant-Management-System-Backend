

namespace RestaurantShared.Parameters
{
    public class ProductParameter:BaseParameters
    {
        public string? Category { get; set; }

        public string? Search { get; set; }

        public bool? IsAvailable { get; set; }
    }
}
