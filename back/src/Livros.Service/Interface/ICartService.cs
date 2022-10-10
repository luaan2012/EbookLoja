using Livros.Domain.Models;

namespace Livros.Service.Interface
{
    public interface ICartService
    {
        Task AddCart(int id, int userID);
        Task RemoveCart(int idUser);
        Task<int> ListCart(int idUser);

    }
}