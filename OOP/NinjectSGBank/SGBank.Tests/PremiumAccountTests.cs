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
    public class PremiumAccountTests
    {
        [TestCase("55555", "Premium Account", 500, AccountType.Free, 500, false, TestName = "Premium Case 1 (fail, wrong account type)")]
        [TestCase("55555", "Premium Account", 500, AccountType.Premium, -100, false, TestName = "Premium Case 2 (fail, negative number deposited)")]
        [TestCase("55555", "Premium Account", 500, AccountType.Premium, 500, true, TestName = "Premium Case 3 (success)")]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance,
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

        
        [TestCase("55555", "Premium Account", 600, AccountType.Free, -500, 600, false,
            TestName = "Premium Overdraft Case 1 (fail, not a premium account type)")]
        [TestCase("55555", "Premium Account", 600, AccountType.Premium, 100, 600, false,
            TestName = "Premium Overdraft Case 3 (fail, positive number drawn)")]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -150, -50, true,
            TestName = "Premium Overdraft Case 4 (success)")]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -650, -560, true,
            TestName = "Premium Overdraft Case 5 (success)")]

        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance,
            AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdrawRule = new PremiumAccountWithdrawRules();
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
