namespace ConsoleApp1
{
    public interface IAccountRepository
    {
        bool Create(Account account);
        Task<Account> SelectById(string id);
        
        bool Update(Account account);
        bool Delete(string accountId);
    }
}