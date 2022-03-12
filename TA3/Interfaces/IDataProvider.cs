using System.Collections.Generic;
using TA3.DTOs;

namespace TA3.Interfaces
{
    public interface IDataProvider
    {
        public IEnumerable<ProductDTO>? GetProducts();
        public void AddProduct(ProductDTO product);
    }
}