using Livros.Data.Interface;
using Livros.Domain.Models;
using Livros.Service.Interface;

namespace Livros.Service.Service
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cart;
        public CartService(ICartRepository cart)
        {
            _cart = cart;
        }
        public Task AddCart(int id, int userID)
        {
            return _cart.addCart(id, userID);
        }

        public Task<int> ListCart(int idUser)
        {
            return _cart.ListCart(idUser);
        }

        public Task RemoveCart(int idUser)
        {
            return _cart.RemoveCart(idUser);
        }
    }
}