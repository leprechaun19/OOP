using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifth
{
    partial class Client : Person
    {
        private string PassportNumber;
        private string IDNumber;
        private int counterAccounts = 0;
        private Account[] accounts = new Account[5];
        public Client(string name, string surname, string address, string passportNumber, string idNumber)
            : base(name, surname, address)
        {
            PassportNumber = passportNumber;
            IDNumber = idNumber;
        }
        public Account[] Accounts
        {
            get
            {
                return accounts;
            }
        }
        public int CounterAccount
        {
            get
            {
                return counterAccounts;
            }
        }
        public void GetAccount(Account account)
        {
            accounts[counterAccounts] = account;
            counterAccounts++;
        }
        public override bool Equals(Client obj)
        {
            bool equal;
            if (obj.IDNumber == this.IDNumber)
            {
                equal = true;
            }
            else
            {
                equal = false;
            }
            return equal;
        }
        public override string ToString()
        {
            Console.WriteLine(base.ToString());
            for (int i = 0; i < counterAccounts; i++)
            {
                Console.WriteLine((i + 1) + "-ый счет" + accounts[i].ToString());
            }
            return String.Format("ID number - " + IDNumber + "\n" + "PassportNumber - " + PassportNumber + "\n");
        }
    }
    class Class1
    {
    }
}
