using ClassLibrary.Entity;
using System.Threading.Tasks;

namespace ClassLibrary.Repository
{
    public interface IAccountRepositoryAsync
    {
        Task<bool> CreateAsync(string accountId);
    }
}