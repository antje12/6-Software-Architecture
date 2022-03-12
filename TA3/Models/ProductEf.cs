using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace TA3.Models
{
    public class ProductEf
    {
#nullable enable
        [Key] public string name { get; set; }

        // We use these data indications to give more information to Entity Framework so it can build our database right
        [Required, Column(TypeName = "decimal(18,2)")]
        public float price { get; set; }

        // With the question mark EF will know that this field is nullable 
        public string? aisle { get; set; }
#nullable disable

        public override string ToString() => JsonSerializer.Serialize<ProductEf>(this);
    }
}