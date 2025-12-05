using System.ComponentModel.DataAnnotations;

namespace Shared.Dtos.BasketModule
{
    public class BasketItemDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;

        [Range(1, double.MaxValue, ErrorMessage = "Price Must Be Greate rThan zero")]
        public decimal Price { get; set; }
        
        [Range(1, 99, ErrorMessage = "Quatity Must Be At Least One Item")]
        public int Quantity { get; set; }

    }
}