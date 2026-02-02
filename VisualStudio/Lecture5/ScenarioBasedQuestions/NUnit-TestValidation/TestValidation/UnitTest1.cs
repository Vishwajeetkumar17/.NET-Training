using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace NUnit
{
        [TestFixture]
        public class UnitTest
        {
            [Test]
            public void Test_Deposit_ValidAmount()
            {
                // Arrange
                Program account = new Program(100);

                // Act
                account.Deposit(50);

                // Assert
                Assert.That(account.Balance, Is.EqualTo(150));
            }

            [Test]
            public void Test_Deposit_NegativeAmount()
            {
                // Arrange
                Program account = new Program(100);

                // Act & Assert
                Assert.Throws<ArgumentException>(() => account.Deposit(-50));
            }

            [Test]
            public void Test_Withdraw_ValidAmount()
            {
                // Arrange
                Program account = new Program(100);

                // Act
                account.Withdraw(30);

                // Assert
                Assert.That(account.Balance, Is.EqualTo(70));
            }

            [Test]
            public void Test_Withdraw_InsufficientFunds()
            {
                // Arrange
                Program account = new Program(100);

                // Act & Assert
                Assert.Throws<InvalidOperationException>(() => account.Withdraw(150));
            }
        }
    }
