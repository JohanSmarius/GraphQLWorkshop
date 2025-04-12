using Microsoft.EntityFrameworkCore;
using ShopAPI.Database;
using ShopAPI.Model;

namespace ShopAPI.GraphQL;

public class OrderQuery
{
    public IEnumerable<Order> GetAllOrders()
    {
        return GenerateTestOrders();
    }
    
    public Order GetOrderById(int id)
    {
        return GenerateTestOrders().Single(order => order.Id == id);
    }
    
    public IEnumerable<Order> GetOrdersEnumerable(OrderContext orderContext) =>
        orderContext.Orders
            .Include(order => order.OrderLines).ThenInclude(orderline => orderline.Product)
            .Include(order => order.Customer);
    
   // [UsePaging(IncludeTotalCount = true)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Order> GetOrders(OrderContext orderContext) => orderContext.Orders;
    
    private List<Order> GenerateTestOrders()
    {
        var order1 = new Order()
        {
            Id = 1,
            Customer = new Customer()
            {
                Id = 1, Name = "Someone", EMailAddress = "noreply@nowhere.com"
            },
            OrderStatus = OrderStatus.PAID,
            OrderTime = DateTime.Now
        };

        order1.OrderLines.Add(new OrderLine()
        {
            Id = 1,
            Order = order1,
            Product =
                new Product() {Id = 1, Name = "Samsung S20", Price = 900, Weight = 100, EanCode = "4985791347598"},
            Quantity = 2,
            DiscountPercentage = 20
        });
        order1.OrderLines.Add(new OrderLine()
        {
            Id = 2,
            Order = order1,
            Product = new Product()
                {Id = 1, Name = "iPhone 13", Price = 1200, Weight = 100, EanCode = "498430958307598"},
            Quantity = 1,
            DiscountPercentage = 10
        });

        var order2 = new Order()
        {
            Id = 2,
            Customer = new Customer()
            {
                Id = 1, Name = "Iris", EMailAddress = "whoami@nowhere.com"
            },
            OrderStatus = OrderStatus.SHIPPED,
            OrderTime = DateTime.Now.AddDays(-2)
        };

        order2.OrderLines.Add(new OrderLine()
        {
            Id = 1,
            Order = order1,
            Product = new Product() {Id = 1, Name = "Clean code", Price = 20, Weight = 200, EanCode = "94359324590380"},
            Quantity = 1,
            DiscountPercentage = 0
        });
        order2.OrderLines.Add(new OrderLine()
        {
            Id = 2,
            Order = order1,
            Product = new Product()
            {
                Id = 1, Name = "The unlikely success of a copy-paste developer", Price = 30, Weight = 150,
                EanCode = "87439587975927"
            },
            Quantity = 2,
            DiscountPercentage = 5
        });

        return [order1, order2];
    }
}