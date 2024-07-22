using System.Reflection;
using System.Text.Json;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Infrastructure.Data;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.Brands.Any())
            {
                var brandsData = File.ReadAllText(Path.Combine(path, @"..\..\..\..\Infrastructure\Data\SeedData\brands.json"));
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.Brands.AddRange(brands);
            }

            if (!context.ProductTypes.Any())
            {
                var typesData = File.ReadAllText(Path.Combine(path, @"..\..\..\..\Infrastructure\Data\SeedData\types.json"));
                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                context.ProductTypes.AddRange(types);
            }

            if (!context.Products.Any())
            {
                var productsData = File.ReadAllText(Path.Combine(path, @"..\..\..\..\Infrastructure\Data\SeedData\products.json"));
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

            if (!context.DeliveryMethods.Any())
            {
                var deliveryData = File.ReadAllText(Path.Combine(path, @"..\..\..\..\Infrastructure\Data\SeedData\delivery.json"));
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
            }
            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}