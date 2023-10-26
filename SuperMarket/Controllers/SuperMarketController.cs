using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Database;
using SuperMarket.Models;

namespace SuperMarket.Controllers
{
    [ApiController]
    [Route("api/SuperMarket")]
    public class SuperMarketController : ControllerBase
    {
        private readonly SuperMarketDbContext superMarketDbContext;

        public SuperMarketController(SuperMarketDbContext superMarketDbContext)
        {
            this.superMarketDbContext = superMarketDbContext;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetSuperMarkets()
        {
            var supermarket = await superMarketDbContext.superMarkets.ToListAsync();
            return Ok(supermarket);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> CreateSuperMarkets([FromBody] Supermarket market) {
            await superMarketDbContext.superMarkets.AddAsync(market);
            await superMarketDbContext.SaveChangesAsync();
            return Ok(market);

        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> UpdateSuperMarket([FromRoute] int id , [FromBody] Supermarket market)
        {
            var market_ = await superMarketDbContext.superMarkets.FirstOrDefaultAsync(u => u.ProductID== id);

            if(market_ != null)
            {
                market_.ProductName = market.ProductName;
                market_.ProductPrice = market.ProductPrice; 
                market_.ProductDes= market.ProductDes;

                await superMarketDbContext.SaveChangesAsync();
                return Ok(market_);
            }
            else
            {
                return NotFound("SuperMarket Not Found !...");
            }
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteSuperMarket([FromRoute] int id)
        {
            var market_ = await superMarketDbContext.superMarkets.FirstOrDefaultAsync(u => u.ProductID == id);

            if (market_ != null)
            {
                superMarketDbContext.superMarkets.Remove(market_);
                await superMarketDbContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return NotFound("SuperMarket Not Found !...");
            }
        }

    }
}
