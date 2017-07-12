using NUnit.Framework;
using SGBank.BLL;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class FreeAccountTest
    {
        //[Test]
        //public void CanLoadFreeAccountTestData()
        //{
        //    AccountManager manager = AccountManagerFactory.Create();

        //    AccountLookupResponse response = manager.LookupAccount("12345");

        //    Assert.IsNotNull(response.Account);
        //    Assert.IsTrue(response.Success);
        //    Assert.AreEqual("12345", response.Account.AccountNumber);
        //}


        //Case 1 (fail, too much deposited):
        [TestCase("12345", "Free Account", 100, AccountType.Free, 250, false, TestName = "Case 1 (fail, too much deposited)")]

        //Case 2 (fail, negative number deposited):
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false, TestName = "Case 2(fail, negative number deposited)")]

        //Case 3 (fail, not a free account type):
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false, TestName = "Case 3 (fail, not a free account type)")]

        //Case 4 (success):
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true, TestName = "Case 4 (success)")]

        public void FreeAccountDepositRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit depositRule = new FreeAccountDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;
            
            AccountDepositResponse response = depositRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
        
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, false, TestName = "Free Case 1 (fail, positive withdraw amount")]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -150, false, TestName = "Free Case 2(fail, negative withdrawal over limit")]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false, TestName = "Free Case 3(fail, wrong account type")]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -100, false, TestName = "Free Case 4(fail, overdraft")]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -50, true, TestName = "Free Case 5(success)")]

        public void FreeAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdrawRule = new FreeAccountWithdrawRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }
    }

}
