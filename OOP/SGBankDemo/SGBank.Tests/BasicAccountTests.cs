using NUnit.Framework;
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
    class BasicAccountTests
    {
        [TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false, TestName = "Basic Case 1 (fail, wrong account type)")]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false, TestName = "Basic Case 2 (fail, negative number deposited)")]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true, TestName = "Basic Case 3 (success)")]
        public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, 
            AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit noLimitRule = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;

            AccountDepositResponse response = noLimitRule.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("33333", "Basic Account", 1500, AccountType.Basic, -1000, 1500, false, 
            TestName = "Overdraft Case 1 (fail, too much withdrawn)")]
        [TestCase("33333", "Basic Account", 100, AccountType.Free, -100, 100, false,
            TestName = "Overdraft Case 2 (fail, not a basic account type)")]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, 100, 100, false,
            TestName = "Overdraft Case 3 (fail, positive number drawn)")]
        [TestCase("33333", "Basic Account", 100, AccountType.Basic, -150, -60, true,
            TestName = "Overdraft Case 4 (success)")]

        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdrawRule = new BasicAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Balance = balance;
            account.Name = name;
            account.Type = accountType;
            

            AccountWithdrawResponse response = withdrawRule.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            Assert.IsTrue(newBalance == account.Balance);
        }
    }
}
