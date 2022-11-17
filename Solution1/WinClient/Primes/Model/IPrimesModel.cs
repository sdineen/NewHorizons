using System.Threading.Tasks;

namespace WinClient.Primes.Model
{
    public interface IPrimesModel
    {
        int Count(int max);
        Task<int> CountAsync(int max);
    }
}