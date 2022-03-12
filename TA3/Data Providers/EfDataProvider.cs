using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TA3.DTOs;
using TA3.Interfaces;
using TA3.Models;
using TA3.Services;

namespace TA3.Data_Providers
{
// Our provider inherits the DbContext class that will let us register it in the service container.
    public class EfDataProvider : DbContext, IDataProvider
    {
        // Here we create the dataset containing our Products table, and Entity Framework will take care of the rest for us.
        // If we had several tables we would have to define them here in the same way.
        // We need it to be
        public DbSet<ProductEf> Products { get; set; }

        // We have to implement the interface's method for getting the data:
        public IEnumerable<ProductDTO>? GetProducts()
        {
            if (Products == null)
            {
                return null;
            }

            return ConvertToDTO(Products);
        }

        // We implement a very simple method for adding new products to the database:
        public void AddProduct(ProductDTO product)
        {
            var p = new ProductEf()
            {
                name = product.name,
                price = product.price,
                aisle = product.aisle
            };
            Add(p);
        }

        public EfDataProvider(DbContextOptions<EfDataProvider> options) : base(options)
        {

        }

        public EfDataProvider()
        {

        }

        // Here we're telling Npgsql to use our connection string (coming from the service that we made) to access the
        // database where our data is stored. We do that by overriding the OnConfiguring methode that will be called by EF.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionStringService.GetConnectionString());
        }

        // We also implement an conversion static method (that's almost identical to the one in the JSON Provider) so that
        // the DataService stays Model-agnostic.
        // We can use a parameter of type IEnumerable<> because DbSet<> implements that interface, and therefore we
        // iterate on it just the same as before.
        private static IEnumerable<ProductDTO> ConvertToDTO(IEnumerable<ProductEf> list)
        {
            IEnumerable<ProductDTO> result = Enumerable.Empty<ProductDTO>();
            foreach (var i in list)
            {
                result = result.Concat(new[] {new ProductDTO(i.name, i.price, i.aisle)});
            }

            return result;
        }
    }
}