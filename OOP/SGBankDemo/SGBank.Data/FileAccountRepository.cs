﻿using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _filePath = Settings.FilePath;
        List<Account> _accounts = new List<Account>();

        public FileAccountRepository(string filePath)
        {
            filePath = _filePath;
            

            using (StreamReader sr = new StreamReader(_filePath))
            {

                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();

                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];

                    newAccount.Name = columns[1];

                    newAccount.Balance = decimal.Parse(columns[2]);

                    string typeAbbreviation = columns[3];
                    if(typeAbbreviation == "F")
                    {
                        newAccount.Type = AccountType.Free;
                    }
                    else if (typeAbbreviation == "B")
                    {
                        newAccount.Type = AccountType.Basic;
                    }
                    else if (typeAbbreviation == "P")
                    {
                        newAccount.Type = AccountType.Premium;
                    }
                    else
                    {
                        throw new Exception("No type abbreviation was found!");
                    }
                    _accounts.Add(newAccount);
                }
            }
        }

        public Account LoadAccount(string accountNumber)
        {
            Account foundAccount = _accounts.Find(a => a.AccountNumber == accountNumber);
            return foundAccount;
        }

        public void SaveAccount(Account account)
        {
            //Account accountToSave = account;
            //account = _accounts.Find(a => a.AccountNumber == account.AccountNumber);
            //_accounts.Remove(account);
            using (StreamWriter sw = new StreamWriter(_filePath))
            {
                sw.WriteLine("AccountNumber,AccountName,Balance,TypeAbbreviation");
                foreach(var act in _accounts)
                {
                    string line = CreateCsvForAccount(act);
                    sw.WriteLine(line);
                }
            }
        }

        string typeAbbreviation;
        private string CreateCsvForAccount(Account account)
        {
            
            if(account.Type == AccountType.Free)
            {
                typeAbbreviation = "F";
            }
            else if(account.Type == AccountType.Basic)
            {
                typeAbbreviation = "B";
            }
            else if(account.Type == AccountType.Premium)
            {
                typeAbbreviation = "P";
            }
            else
            {
                throw new Exception("No account types were found in the file!");
            }
            return string.Format("{0},{1},{2},{3}", account.AccountNumber,
                    account.Name, account.Balance, typeAbbreviation);
        }
    }
}
