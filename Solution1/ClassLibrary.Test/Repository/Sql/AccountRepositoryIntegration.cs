using ClassLibrary.Entity;
using ClassLibrary.Repository.Sql;
using System.Data.SqlClient;
using System.IO;
using Xunit;

namespace ClassLibrary.Test.Repository.Sql
{
    [Collection("Collection 1")]
    public class SqlAccountRepositoryIntegrationTest
    {
        private string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond";

        public SqlAccountRepositoryIntegrationTest()
        {

            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = File.ReadAllText(@"..\..\..\repository\sql\setup.sql");
            cmd.ExecuteNonQuery();
        }

        [Fact]
        public void Create_DuplicateAccount_ShouldReturnFalse()
        {
            //arrange
            SqlAccountRepository accountRepository = new SqlAccountRepository(connectionString);
            Account account = new Account("acc5", "Fred Faucett", "test");
            //act
            bool firstAccountCreated = accountRepository.Create(account);
            bool secondAccountCreated = accountRepository.Create(account);
            //assert
            Assert.True(firstAccountCreated);
            Assert.False(secondAccountCreated);
        }


        [Fact]
        public void SelectById_WhenPassedId_ShouldReturnAccount()
        {
            //arrange
            SqlAccountRepository accountRepository = new SqlAccountRepository(connectionString);

            //act
            Account account = accountRepository.SelectById("acc1");

            //assert
            Assert.Equal("John Smith", account.Name);
        }

        [Fact]
        public void Delete_WhenPassedId_ShouldRemoveAccount()
        {
            //arrange
            SqlAccountRepository accountRepository = new SqlAccountRepository(connectionString);

            //act
            bool deleted = accountRepository.Delete("acc1");

            //assert
            Assert.True(deleted);
            Assert.Null(accountRepository.SelectById("acc1"));
        }

        [Fact]
        public void Update_Account_ShouldUpdateAccount()
        {
            //arrange
            SqlAccountRepository accountRepository = new SqlAccountRepository(connectionString);
            Account account = new Account("acc1", "Jim Smith", "test");
            //act
            bool updated = accountRepository.Update(account);
            //assert
            Assert.True(updated);
            Assert.Equal("Jim Smith", accountRepository.SelectById("acc1").Name);
        }

    }
}
