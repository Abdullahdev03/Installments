// using Domain.Entities;
// using Infrastructure.Data;
//
// namespace Infrastructure.SeedData;
//
// public static class SeedData
// {
//     public static void Seed(DataContext context)
//     {
//         if (context.Customers.Any())
//             return;
//
//         var customer = new List<Customer>()
//         {
//             new(1, "Abdulloh", "502050903", "Abdulloh@gmial.com"),
//             new(2, "Ardasher", "500000550", "Ardasher@gmial.com"),
//             new(3, "Anushervon", "55500088", "Anushervon@gmial.com"),
//             new(4, "Muhammad", "88881118", "Muhammad@gmial.com"),
//             new(5, "Muhammad", "7770007700", "MuhammadYaqubzoda@gmial.com"),
//             new(6, "Sherzod", "8881118880", "Sherzod@gmial.com"),
//         };
//
//         var product = new List<Product>()
//         {
//             new(1, "Samsung Note20", 5000),
//             new(2, "IPhone12", 10000),
//             new(3, "Samsung A31", 2000),
//             new(4, "Samsung", 3000),
//             new(5, "IPhonX", 7000),
//             new(6, "Xiaomi 20", 4000),
//         };
//
//         var order = new List<Order>()
//         {
//             new(1, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 5000, 1, 1),
//             new(2, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 10000, 2, 2),
//             new(3, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 2000, 3, 3),
//             new(4, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 3000, 4, 4),
//             new(5, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 7000, 5, 5),
//             new(6, DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc), 4000, 6, 6),
//         };
//         var customerproduct = new List<CustomerProduct>()
//         {
//             new(1,1,1),
//             new(2,2,2),
//             new(3,3,3),
//             new(4,4,4),
//             new(5,5,5),
//             new(6,6,6),
//
//         };
//         
//         context.Customers.AddRange(customer);
//         context.Products.AddRange(product);
//         context.Orders.AddRange(order);
//         context.CustomerProducts.AddRange(customerproduct);
//         context.SaveChanges();
//
//     }
// }