using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ClassLibrary.Entity;

namespace ClassLibrary.Repository.EF
{
    public class AccountRepository : IAccountRepository
    {
        private EcommerceContext context;

        public AccountRepository(EcommerceContext context)
        {
            this.context = context;
        }

        public bool Create(Account account)
        {
            EntityEntry<Account> accountEntry = context.Accounts.Add(account);
            return context.SaveChanges() == 1;
        }

        public Account SelectById(string id)
        {
            return context.Accounts.Find(id);
        }

        public bool Delete(string accountId)
        {
            Account account = context.Accounts.Find(accountId);
            if (account == null)
            {
                return false;
            }
            context.Remove(account);
            return context.SaveChanges() == 1;
        }

        public bool Update(Account modifiedAccount)
        {
            Account account = context.Accounts.Find(modifiedAccount.Id);
            if (account == null)
            {
                return false;
            }
            account.Name = modifiedAccount.Name;
            return context.SaveChanges() == 1;
        }
    }
}