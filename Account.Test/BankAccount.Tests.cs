using NUnit.Framework;
using Account;

namespace Account.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Deposit_UpdatesBalanceCorrectly()
        {
            //Arrang
            BankAccount account = new BankAccount("John Doe", 1000);

            decimal depositAmount = 500;
            //Act
            account.Deposit(depositAmount);

            decimal expectedBalance = 1000 + depositAmount;
            //Assert
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [Test]
        public void Withdraw_ValidAmount_UpdatesBalanceCorrectly()
        {
            //Arrange
            BankAccount account = new BankAccount("Jane Smith", 1500);

            decimal withdrawalAmount = 700;
            //Act
            account.Withdraw(withdrawalAmount);

            decimal expectedBalance = 1500 - withdrawalAmount;
            //Assert
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }

        [Test]
        public void Withdraw_AmountGreaterThanBalance_ReturnsFalse()
        {
            //Arrange
            BankAccount account = new BankAccount("Alice Johnson", 2000);

            decimal withdrawalAmount = 54000;
            //Act
            bool result = account.Withdraw(withdrawalAmount);
            //Assert
            Assert.IsFalse(result);
            Assert.AreEqual(2000, account.GetBalance()); // Balance should remain unchanged
        }

        [Test]
        public void Withdraw_AmountWithinOverdraftLimit_UpdatesBalanceCorrectly()
        {
            //Arrange
            BankAccount account = new BankAccount("Bob Brown", 3000);

            decimal withdrawalAmount = 3500; // Within overdraft limit
            //Act
            account.Withdraw(withdrawalAmount);

            decimal expectedBalance = 3000 - withdrawalAmount;
            //Assert
            Assert.AreEqual(expectedBalance, account.GetBalance());
        }
    }
}
