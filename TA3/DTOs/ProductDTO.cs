using System.Text.Json;

namespace TA3.DTOs
{
    public class ProductDTO
    {
        public ProductDTO(string name, float price, string? aisle)
        {
            this.name = name;
            this.price = price;
            this.aisle = aisle;
        }

        public string name { get; set; }

        public float price { get; set; }

        public string? aisle { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductDTO>(this);
    }
}