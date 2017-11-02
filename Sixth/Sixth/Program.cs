using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Sixth
{
    interface IOperations
    {
        void WithdrawMoney();
        void TransferMoney();
    }
    enum Day
    {
        Monday = 1, Thuesday, Wensday
    }
    struct Arr
    {
    }
     abstract class Person
    {
        private string FirstName;
        private string Surname;
        private string Address;
        public Person(string name, string surname, string address)
        {
            FirstName = name;
            Surname = surname;
            Address = address;
        }
        public override string ToString()
        {
            return String.Format("Name - " + FirstName + " " + Surname + "\n" + "Address - " + Address + "\n");
        }
        public abstract bool Equals(Client obj);
    }
       class Client : Person
    {
        private string PassportNumber;
        private string IDNumber;
        private int counterAccounts = 0;
        private Account[] accounts= new Account[10];
        public Client(string name, string surname, string address, string passportNumber, string idNumber)
            : base(name, surname, address)
        {
            if(!passportNumber.Contains("R"))
            {
                throw new ClientException("Неверно введен номер паспорта!");
            }
            else
            {
                PassportNumber = passportNumber;
            }
            if (idNumber.GetType() != typeof(string))
            {
                throw new ClientException("Неверно введен идентификационный номер паспорта!");
            }
            else
            {
                IDNumber = idNumber;
            }
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
        public Account this[int i]
        {
            get

            {
                if (i >= 0 && i < counterAccounts)
                {
                    return accounts[i];
                }
                else
                {
                    Console.WriteLine("Incorrect index");
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < counterAccounts)
                {
                    accounts[i] = value;
                }
                else
                {
                    Console.WriteLine("Incorrect index");
                }
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
        class Account : IOperations
    {
        private double sum;
        private string AccountNumber;
        public Account(){}
        public Account(string accountNumber, double Summa)
        {
            if (!accountNumber.Contains("BY"))
            {
                throw new AccountException("Неверно введен номер счета!");
            }
            else
            {
                AccountNumber = accountNumber;
            }
            if (sum.GetType() != typeof(double))
            {
                throw new AccountException("неправильно введена сумма");
            }
            else
            {
                sum += Summa;
            }
        }
        public double Sum
        {
            get
            {
                return sum;
            }
        }
        public virtual void GetInformation() { }
        public virtual void BlockAccount() { }
        void IOperations.TransferMoney() { }
        void IOperations.WithdrawMoney() { }

        public override string ToString()
        {
            return String.Format("Номер счета: " + AccountNumber + "\n");
        }

    }
         sealed class CurrentAccount : Account //текущий
    {
        public bool AreBlocked = false;
        private double CurrentSum;
        public CurrentAccount(string accountNumber, double currentSum)
            : base(accountNumber, currentSum)
        {
            CurrentSum = currentSum;
        }
        public override void GetInformation()
        {
            Console.WriteLine($"На этом счете {CurrentSum} белорусских рублей");
        }
        public override void BlockAccount()
        {
            AreBlocked = true;
        }
    }
         sealed class DepositAccount : Account
    {
        public bool AreBlocked = false;
        private double Procent;
        public override void GetInformation()
        {
            Console.WriteLine($"Процент от вашей суммы на дебетовом счете состовляет {Procent}");
        }
        public DepositAccount(string accountNumber, double procent)
            : base(accountNumber, procent)
        {
            Procent = procent;
        }
        public override void BlockAccount()
        {
            AreBlocked = true;
        }
    }
         sealed class CurrencyAccount : Account //валютный
    {
        public bool AreBlocked = false;
        private string Currency; //валюта
        private double CurSum;
        public override void GetInformation()
        {
            Console.WriteLine($"На вашем валютном счете {Sum} {Currency}");
        }
        public CurrencyAccount(string accountNumber, string currency, double sum)
            : base(accountNumber, sum)
        {
            Currency = currency;
            CurSum = sum;
        }
        public override void BlockAccount()
        {
            AreBlocked = true;
        }
    }
    class Bank
    {
        private int numbersOfClients = 0;
        List<Client> clients = new List<Client>();
        public Bank()
        {

        }
        public List<Client> Clients
        {
            get
            {
                return clients;
            }
            set
            {
                if (value.GetType() == typeof(Client))
                {
                    clients = value;
                }
            }
        }
        public Client this[int i]
        {
            get

            {
                if (i >= 0 && i < numbersOfClients)
                {
                    return clients[i];
                }
                else
                {
                    Console.WriteLine("Incorrect index");
                    return null;
                }
            }
            set
            {
                if (i >= 0 && i < numbersOfClients)
                {
                    clients[i] = value;
                }
                else
                {
                    Console.WriteLine("Incorrect index");
                }
            }
        }
        public int NumberOfClients
            {
            get
            {
                return numbersOfClients;
            }
            }
        public void AddClient(Client client)
        {
            clients.Add(client);
            numbersOfClients++;

        }
        public void RemoveClient(Client client)
        {
            clients.Remove(client);
        }
        public void PrintClient()
        {
            Console.WriteLine("                   Список");
            for (int i = 0; i < clients.LongCount(); i++)
            {
                Console.WriteLine($"   {i + 1}.");
                Console.WriteLine($"{clients[i].ToString()}");
            }
        }
    }
    class Controller
    {
        Bank Bank;
        public Controller(Bank bank)
        {
            Bank = bank;
        }
        public double GeneralSum(Client client)
        {
            Account[] accounts = client.Accounts;
            List <Client> clientiki = Bank.Clients;
            double generalSum = 0;
            for (int i = 0; i < Bank.NumberOfClients; i++)
            {
                if (clientiki[i].Equals(client))
                {
                    for (int j = 0; j < client.CounterAccount; j++)
                    {
                        generalSum += accounts[j].Sum;
                    }
                }
            }
            Console.WriteLine($"Общая сумма 1го клиента  = {generalSum}");
            return generalSum;
        }
    }
    class ClientException : Exception
    {
        public ClientException() : base()
        {

        }
        public ClientException(string message) : base(message)
        {

        }
        public ClientException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
    class AccountException : ClientException
    {
        public AccountException() : base()
        {

        }
        public AccountException(string message) : base(message)
        {

        }
        public AccountException(string message, Exception inner) : base(message, inner)
        {

        }
    }
    class BankException : Exception
    {
        public BankException() : base()
        {

        }
        public BankException(string message) : base(message)
        {

        }
        public BankException(string message, Exception inner) : base(message, inner)
        {

        }
    }
    class DevideByZero : Exception
    {
        public DevideByZero() : base()
        {

        }
        public DevideByZero(string message) : base(message)
        {

        }
        public DevideByZero(string message, Exception inner) : base(message, inner)
        {

        }
    } 
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Client client2 = new Client("Alexander", "Petrov", "minsk pr.Rokossovskogo h.132", "45tfdrgdfg45", "454gtr565hu");
            }
            catch (ClientException cl_ex)
            {
                Console.WriteLine(cl_ex.Message);
            }
            Client client1 = new Client("Masha", "Ivanova", "Minsk str.Vaneeva h.130", "R534", "34342rfeer3454g");
            Client client3 = new Client("Aleksey", "Sidorov", "minsk pr.Partizansky h.128", "R45tfdrgdfg45", "454g567tg65hu");

            try
            {
                DepositAccount depositAccount1 = new DepositAccount("gfdgrr4fer2fre6g", 100);
            }
            catch (AccountException ac_ex)
            {
                Console.WriteLine(ac_ex.Message);
            }
            CurrencyAccount currencyAccount1 = new CurrencyAccount("BY33frse3423fr283", "EUR", 200);
            client1.GetAccount(currencyAccount1);

            Bank Belarusbank = new Bank();
            Belarusbank.AddClient(client1);
            Belarusbank.AddClient(client3);

            try
            {
                Controller nom1 = new Controller(Belarusbank);
                nom1.GeneralSum(client1);
            }
            catch (BankException bk_ex)
            {
                Console.WriteLine(bk_ex.Message);
            }


            try
            {
                int b = 0;
                if (b == 0)
                {
                    throw new DevideByZero("Devide by zero exception");
                }
            }
            catch (DevideByZero zero_ex)
            {
                Console.WriteLine(zero_ex.Message);
            }
            finally
            {
                Console.WriteLine("Вызван блок finally");
            }

            Console.ReadKey();
        }
    }
}



