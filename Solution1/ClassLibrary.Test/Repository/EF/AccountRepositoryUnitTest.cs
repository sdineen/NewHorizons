using ClassLibrary.Entity;
using ClassLibrary.Repository.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ClassLibrary.Test.Repository.EF
{
    public class AccountRepositoryUnitTest
    {
        protected EcommerceContext context;
        public AccountRepositoryUnitTest()
        {
            string connectionString = @"Data Source=.\sqlexpress;Initial Catalog = test; User ID = sa; Password = carpond; ConnectRetryCount=0";
            context = new EcommerceContext(new DbContextOptionsBuilder<EcommerceContext>()
                              .UseSqlServer(connectionString)
                              .Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        ~AccountRepositoryUnitTest() => context.Dispose();

        [Fact]
        public void Create_Should_Add_Account()
        {
            Account account = new Account("acc3", "Sue Smedley", "test");
            var accountRepository = new AccountRepository(context);
            bool created = accountRepository.Create(account);
            Assert.Equal(3, context.Accounts.Count());
        }

        [Fact]
        public void SelectById_Should_Return_Correct_Account()
        {
            var accountRepository = new AccountRepository(context);
            Account account = accountRepository.SelectById("acc1");
            Assert.Equal("John Smith", account.Name);
        }

        [Fact]
        public void Update_Should_Update_Account()
        {
            Account account = new Account { Id = "acc1", Name = "Jim Smith" };
            var accountRepository = new AccountRepository(context);
            accountRepository.Update(account);
            Account updatedAccount = context.Accounts.Find("acc1");
            Assert.Equal("Jim Smith", updatedAccount.Name);
        }

        [Fact]
        public void Delete_Should_Remove_Account()
        {
            var accountRepository = new AccountRepository(context);
            accountRepository.Delete("acc1");
            Assert.Single(context.Accounts);
        }

    }
}
