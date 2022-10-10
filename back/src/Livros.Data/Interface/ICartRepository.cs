using Livros.Domain.Models;

namespace Livros.Data.Interface
{
    public interface ICartRepository
    {
        Task addCart(int id, int idUser);
        Task RemoveCart(int idUser);
        Task<int> ListCart(int idUser);
    }
}