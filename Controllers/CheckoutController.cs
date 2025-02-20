using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using TestApi.Models.Dto;

namespace TestApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly IConfiguration? _configuration;
        public CheckoutController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize]
        [HttpPost("checkout")]
        public IActionResult CreateCheckout([FromBody] ICollection<OrderItemDTO> orderItems)
        {
            StripeConfiguration.ApiKey = _configuration["Stripe:SecretKey"];
            var lineItems = orderItems.Select(item => new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = item.Product.Name,
                    },
                    UnitAmount = (long)(item.Product.Price * 100),
                },
                Quantity = item.Quantity,
            }).ToList();

            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = $"{Request.Scheme}://{Request.Host}/api/checkout/success",
                CancelUrl = $"{Request.Scheme}://{Request.Host}/api/checkout/cancel",
            };
            var service = new SessionService();
            var session = service.Create(options);
            return Ok(new { checkoutUrl = session.Url });
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            return Ok("Ordine effettuato con successo.");
        }

        [HttpGet("cancel")]
        public IActionResult Cancel()
        {
            return Ok("Ordine cancellato.");
        }
    }
}