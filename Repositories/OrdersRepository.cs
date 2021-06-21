using Microsoft.EntityFrameworkCore;
using PwiAPI.Data;
using PwiAPI.DTOs;
using PwiAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PwiAPI.Repositories
{
    public class OrdersRepository
    {
        private readonly AppDbContext _context;

        public OrdersRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<OrderShortResponseDTO> GetAllOrderOfUser(User user)
        {
            var orders = _context.Orders.Where(o => o.User.Id == user.Id).ToList();

            var orderShortDto = new List<OrderShortResponseDTO>();

            foreach (var order in orders)
            {
                var productDtos = GetProductsDto(order.Id);

                float totalCost = 0;

                foreach (var product in productDtos)
                {
                    totalCost += product.Quantity * product.Price;
                }

                orderShortDto.Add(new OrderShortResponseDTO()
                {
                    Id=order.Id,
                    Customer = order.FirstName + ' ' + order.LastName,
                    OrderDate = order.OrderDate.ToString(),
                    TotalCost = totalCost
                });
            }

            return orderShortDto;
        }

        public OrderDetailsResponseDTO GetAllOrdersWithDetailsOfUser(User user, int id)
        {
            //var order = _context.Orders.Where(o => o.Id == id).Where(o => o.User.Id == user.Id).Single();

            List<ProductOrderDTO> productsDto = GetProductsDto(id);

            var reponseProducts = new List<ProductOrderResponseDTO>();

            float totalOrderPrice = 0;

            foreach (var product in productsDto)
            {
                totalOrderPrice += product.Quantity * product.Price;
            }

            foreach (var product in productsDto)
            {
                reponseProducts.Add(new ProductOrderResponseDTO() 
                { 
                    Category = product.Category,
                    Description = product.Description,
                    Id = product.Id,
                    ImageURL = product.ImageURL,
                    Name = product.Name,
                    TotalPrice = product.Price * product.Quantity,
                    Quantity = product.Quantity,
                    TotalOrderPrice = totalOrderPrice
                });
            }

            //var orderDto = new OrdersReponseDTO()
            //{
            //    Id = order.Id,
            //    Address = order.Address,
            //    City = order.City,
            //    Country = order.Country,
            //    FirstName = order.FirstName,
            //    LastName = order.LastName,
            //    OrderDate = order.OrderDate,
            //    ZipCode = order.ZipCode,
            //    Products = productsDto
            //};

            var response = new OrderDetailsResponseDTO() 
            {
                TotalOrderPrice =totalOrderPrice,
                products = reponseProducts
            };
            return response;
        }

        private List<ProductOrderDTO> GetProductsDto(int orderId)
        {
            var productOrders = _context.ProductsOrders
                .Where(po => po.OrderId == orderId)
                .Include(po => po.Product)
                .Include(po => po.Product.Category)
                .ToList();

            var productsDto = new List<ProductOrderDTO>();

            foreach (var product in productOrders)
            {
                productsDto.Add(new ProductOrderDTO()
                {
                    Name = product.Product.Name,
                    Price = product.Product.Price,
                    ImageURL = product.Product.ImageURL,
                    Description = product.Product.Description,
                    Id = product.Product.Id,
                    Category = new CategoryDTO()
                    {
                        Description = product.Product.Category.Description,
                        Name = product.Product.Name
                    },
                    Quantity = product.Quantity

                });
            }

            return productsDto;
        }

        public void AddOrder(User user, OrderAddDTO newOrder)
        {
            var order = new Order()
            {
                Address = newOrder.Address,
                City = newOrder.City,
                Country = newOrder.Country,
                FirstName = newOrder.FirstName,
                LastName = newOrder.LastName,
                ZipCode = newOrder.ZipCode,
                User = user,
            };

            using (var transaction = _context.Database.BeginTransaction())
            { 
                _context.Orders.Add(order);
                _context.SaveChanges();

                foreach (var product in newOrder.products)
                {
                    var po = new ProductsOrders()
                    {
                        OrderId = order.Id,
                        ProductId = product.Id,
                        Quantity = product.Quantity
                    };
                    _context.ProductsOrders.Add(po);

                }
                _context.SaveChanges();

                transaction.Commit();
            }
        }
    }
}
