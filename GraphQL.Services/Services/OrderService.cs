using GraphQL.Data;
using GraphQL.Interfaces;
using GraphQL.Models;
using System.Collections.Generic;
using System.Linq;

namespace GraphQL.Services
{
    /// <summary>
    /// Order Service Class
    /// </summary>
    public class OrderService : IOrder
    {
        private OrderDbContext orderDbContext;

        public OrderService(OrderDbContext orderDbContext)
        {
            this.orderDbContext = orderDbContext;
        }

        /// <inheritdoc cref="IOrder.AddOrder(Order)"/>
        public Order AddOrder(Order order)
        {
            orderDbContext.Orders.Add(order);

            orderDbContext.SaveChanges();

            return order;
        }

        /// <inheritdoc cref="IOrder.DeleteOrder(int)" />
        public void DeleteOrder(int id)
        {
            Order product = orderDbContext.Orders.Find(id);

            orderDbContext.Orders.Remove(product);

            orderDbContext.SaveChanges();
        }

        /// <inheritdoc cref="IOrder.DeleteOrder(int)" />
        public List<Order> GetAllOrders()
        {
            return orderDbContext.Orders.ToList();
        }

        /// <inheritdoc cref="IOrder.GetOrderById(int)" />
        public Order GetOrderById(int id)
        {
            return orderDbContext.Orders.Find(id);
        }

        /// <inheritdoc cref="IOrder.UpdateOrder(int, Order)" />
        public Order UpdateOrder(int id, Order newproduct)
        {
            Order product = orderDbContext.Orders.Find(id);

            product.OrderDate = newproduct.OrderDate;
            product.CustomerName = newproduct.CustomerName;
            product.TotalAmount = newproduct.TotalAmount;

            orderDbContext.SaveChanges();
            
            return product;
        }
    }
}
