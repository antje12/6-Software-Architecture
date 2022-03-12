using TA3.Data_Providers;
using TA3.DTOs;

namespace TA3.wwwroot.data
{
    public class SampleData
    {
        // To keep things simple, we are simply going to statically add the data to our database
        public static void Add()
        {
            using EfDataProvider context = new EfDataProvider();

            ProductDTO cheese = new ProductDTO("Cheese", (float) 2.50, "Refrigerated foods");
            context.AddProduct(cheese);

            ProductDTO crisps = new ProductDTO("Crisps", (float) 3.00, "Snack isle");
            context.AddProduct(crisps);

            ProductDTO pizza = new ProductDTO("Pizza", (float) 4.00, "Refrigerated foods");
            context.AddProduct(pizza);

            ProductDTO chocolate = new ProductDTO("Chocolate", (float) 1.50, "Snack isle");
            context.AddProduct(chocolate);

            ProductDTO flour = new ProductDTO("Self-raising flour", (float) 1.50, "Home baking");
            context.AddProduct(flour);

            ProductDTO almonds = new ProductDTO("Ground almonds", (float) 3.00, "Home baking");
            context.AddProduct(almonds);

            context.SaveChanges();
        }
    }
}