using ClassLibrary.Entity;
using Xunit;

namespace ClassLibrary.Test.Entity
{
    public class AccountTest
    {
        [Fact]
        public void PasswordPropertyGeneratesSha256Hash()
        {
            //arrange
            Account account = new Account();
            //act
            account.Password = "test"; //property setter generates hash
            string hashedPassword = account.Password; //property getter returns hashed password
            //assert
            Assert.Equal("9F86D081884C7D659A2FEAA0C55AD015A3BF4F1B2B0B822CD15D6C15B0F00A08", hashedPassword);

            //https://md5decrypt.net/en/Sha256/
            //https://emn178.github.io/online-tools/sha256.html
        }
    }
}
