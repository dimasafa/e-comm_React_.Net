using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly StoreContext _context;
        public BasketController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        { 
            var basket = await RetrieveBasket();

            if (basket == null) return NotFound();

            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    PictureUrl = item.Product.PictureUrl,
                    Type = item.Product.Type,
                    Brand = item.Product.Brand,
                    Quantity = item.Quantity
                }).ToList()
            };
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity)
        {
            // get basket, oder create new basket, wenn es nicht erstellt wurde
            var basket = await RetrieveBasket();
            if (basket == null) basket = CreateBasket();

            // suchen product
            var product = await _context.Products.FindAsync(productId);

            if (product == null) return NotFound();
            // add item zum basket
            basket.AddItem(product, quantity);

            // speichern in DB. Wenn es > 0, dann wir haben etwas gespeichert
            var result = await _context.SaveChangesAsync() > 0;

            // return Get + Map to DTO
            if (result) return CreatedAtRoute("GetBasket", MapBasketToDto(basket));
            // if keine daten zum DB gespeichert wurden, dann return BadRequest
            return BadRequest(new ProblemDetails { Title = "Problem saving item to basket" });
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity = 1)
        {
            var basket = await RetrieveBasket();

            if (basket == null) return NotFound();

            basket.RemoveItem(productId, quantity);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Problem removing item from the basket" });
        }

        private async Task<Basket> RetrieveBasket()
        {
            // get basket
            return await _context.Baskets
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                // oder null, wenn es nicht basket findet
                .FirstOrDefaultAsync(basket => basket.BuyerId == Request.Cookies["buyerId"]);
        }

        private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString();
            // erstellen cookie
            var cookieOptions = new CookieOptions { IsEssential = true, Expires = DateTime.Now.AddDays(30) };
            Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            // erstellen basket
            var basket = new Basket { BuyerId = buyerId };
            _context.Baskets.Add(basket);
            return basket;
        }

        // Mapping to DTO
        private BasketDto MapBasketToDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Name = item.Product.Name,
                    Price = item.Product.Price,
                    PictureUrl = item.Product.PictureUrl,
                    Type = item.Product.Type,
                    Brand = item.Product.Brand,
                    Quantity = item.Quantity
                }).ToList()
            };
        }
    }
}