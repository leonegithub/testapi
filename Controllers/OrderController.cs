using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.Models;
using TestApi.Models.Dto;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetOrder()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var orders = await _context.Orders
            .Where(o => o.ApplicationUser.Id == userId)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product) // Ensure Product is loaded
                .ToListAsync();

            if (orders != null)
            {
                var result = orders.Select(o => new
                {
                    o.OrderId,
                    o.OrderDate,
                    OrderItems = o.OrderItems.Select(oi => new
                    {
                        oi.Product?.Name,
                        oi.Quantity
                    }),

                });

                return Ok(result);
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] ICollection<OrderItemDTO> orderItemDTOs)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var order = new Order();

                if (userId is not null)
                {
                    order.ApplicationUser = await _userManager.FindByIdAsync(userId);
                }

                foreach (OrderItemDTO orderItemDTO in orderItemDTOs)
                {
                    var product = await _context.Products.FindAsync(orderItemDTO.Product.Id);
                    if (product == null)
                    {
                        return BadRequest($"Product {orderItemDTO.Product} not found.");
                    }

                    var orderItem = new OrderItem
                    {
                        OrderId = order.OrderId,
                        ProductId = product.ProductId,
                        Product = product,
                        Quantity = orderItemDTO.Quantity
                    };

                    order.OrderItems.Add(orderItem);
                }

                order.OrderDate = DateTime.Now;
                _context.Add(order);
                await _context.SaveChangesAsync();

                var response = new OrderDTO
                {
                    OrderId = order.OrderId,
                    OrderDate = order.OrderDate,
                    OrderItems = order.OrderItems.Select(OrderItemDTO.MapToDTOOrder)
                };

                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, response);
            }

            return Unauthorized();
        }
    }
}
