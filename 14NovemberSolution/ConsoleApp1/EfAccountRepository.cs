using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class EfAccountRepository : IAccountRepository
    {
        private ECommerceContext context;
        public EfAccountRepository(ECommerceContext context)
        {
            this.context = context;
        }
        public bool Create(Account account)
        {
            context.Accounts.Add(account);
            int updates = context.SaveChanges();
            return updates > 0;
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

        public Account SelectById(string id)
        {
            return context.Accounts.Find(id);
        }

        public bool Update(Account modifiedAccount)
        {
            Account? account = context.Accounts.Find(modifiedAccount.Id);
            if (account == null)
            {
                return false;
            }
            account.Name = modifiedAccount.Name;
            account.Password = modifiedAccount.Password;
            bool added = context.SaveChanges() == 1;
            return added;
        }
    }
}
