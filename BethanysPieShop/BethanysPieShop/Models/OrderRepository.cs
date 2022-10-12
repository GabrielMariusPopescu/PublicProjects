using System;
using System.Collections.Generic;
using System.Linq;

namespace BethanysPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            this.appDbContext = appDbContext;
            this.shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            var shoppingCartItems = shoppingCart.ShoppingCartItems;
            order.OrderTotal = shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            foreach (var orderDetail in shoppingCartItems
                .Select(shoppingCartItem => new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PieId = shoppingCartItem.Pie.PieId,
                    Price = shoppingCartItem.Pie.Price
                }))
                order.OrderDetails.Add(orderDetail);

            appDbContext.Orders.Add(order);

            appDbContext.SaveChanges();
        }

        //

        private readonly AppDbContext appDbContext;
        private readonly ShoppingCart shoppingCart;
    }
}
