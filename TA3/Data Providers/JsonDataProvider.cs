using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using TA3.DTOs;
using TA3.Interfaces;
using TA3.Models;

namespace TA3.Data_Providers
{
    public class JsonDataProvider : IDataProvider
    {
        // In the constructor, we ask ASP.NET to provide the webHost
        public JsonDataProvider(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        // Asking the webHost where our file is, so we don't have to hardcode it, using the expression-bodied syntax (C#7)
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");

        // In order to display the products on our page, we need to get them from the JSON file
        // The return type is a IEnumerable<Product>, so an iterable collection of Product objects
        public IEnumerable<ProductDTO>? GetProducts()
        {
            // To do that, we deserialize them into a Product array after opening the file to read it
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return ConvertToDTO(JsonSerializer.Deserialize<ProductJson[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        // Making sure that we get the right fields no matter if the case of our variables
                        // matches the JSON file's one
                        PropertyNameCaseInsensitive = true
                    }));
            }
        }

        // For the scope of this project, we don't need a method to add products to the JSON file,
        // but of course you can try to make one yourself.
        public void AddProduct(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        // This method is made to cast the IEnumerable<ProductJson> into a IEnumerable<ProductDTO>
        // so that we effectively have data shape agnosticism from here.
        private static IEnumerable<ProductDTO> ConvertToDTO(IEnumerable<ProductJson>? list)
        {
            var result = Enumerable.Empty<ProductDTO>();
            if (list != null)
                foreach (var i in list)
                {
                    result = result.Concat(new[] {new ProductDTO(i.name, i.price, i.aisle)});
                }

            return result;
        }
    }
}