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
            // Eager load OrderItems and ApplicationUser for complete data
            var orders = await _context.Orders
                .Include(o => o.OrderItems)
                .Include(o => o.ApplicationUser)
                .ToListAsync();

            if (orders != null)
            {
                return Ok(orders);
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostOrder([FromBody] ICollection<OrderItemDTO> orderItemDTOs)
        {
            bool isAuthenticated = User.Identity != null && User.Identity.IsAuthenticated;

            if (isAuthenticated)
            {
                string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var order = new Order();

                if (userId is not null)
                {
                    order.ApplicationUser = await _userManager.FindByIdAsync(userId);
                }

                foreach (OrderItemDTO orderItemDTO in orderItemDTOs)
                {
                    var product = await _context.Products.FindAsync(orderItemDTO.ProductId);
                    if (product == null)
                    {
                        return BadRequest($"Product with ID {orderItemDTO.ProductId} not found.");
                    }

                    var orderItem = new OrderItem
                    {
                        Order = order,
                        ProductId = orderItemDTO.ProductId,
                        Product = product,
                        Quantity = orderItemDTO.Quantity
                    };

                    order.OrderItems.Add(orderItem); // associate the orderItem to the order
                }

                order.OrderDate = DateTime.Now;
                _context.Add(order);

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
            }

            return Unauthorized();
        }
    }
}


