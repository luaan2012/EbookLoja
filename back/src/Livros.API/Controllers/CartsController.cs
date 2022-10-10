using Livros.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Livros.API.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Livros.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cart;
        public CartsController(ICartService cart)
        {
            _cart = cart;
        } 
        
        [HttpPost]
        [Route("AddCart")]
        public async Task<IActionResult> Addcart(int id)
        {
            try
            {
                await _cart.AddCart(id, User.GetUserId());

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying add to cart. Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("RemoveCart")]

        public async Task<IActionResult> RemoveCart()
        {
            try
            {
                await _cart.RemoveCart(User.GetUserId());

                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying add to cart. Error: {ex.Message}");
            }
        }

        [HttpPost]
        [Route("ListCart")]

        public async Task<IActionResult> ListCart()
        {
            try
            {
                var result = await _cart.ListCart(User.GetUserId());

                return Ok(result);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Error trying add to cart. Error: {ex.Message}");
            }
        }
    }
}