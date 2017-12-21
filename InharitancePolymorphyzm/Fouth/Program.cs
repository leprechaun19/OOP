using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fouth
{
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
            return String.Format($"name - {FirstName} {Surname}, address - {Address}");
        }
    }
     class Client : Person
    {
        private string PassportNumber;
        private string IDNumber;
        public Client(string name, string surname, string address, string passportNumber, string idNumber)
            : base(name, surname, address)
        {
            PassportNumber = passportNumber;
            IDNumber = idNumber;
        }
        public override string ToString()
        {
            return String.Format($"Type - {GetType()}, {base.ToString()}, ID number - {IDNumber}");
        }
    }   
      abstract class Account : IOperations
    {
        private string AccountNumber;
        protected Client Client;
        public abstract void GetInformation();
        void IOperations.TransferMoney() { }
        void IOperations.WithdrawMoney() { }
        public Account( string accountNumber, Client client)
        {
            AccountNumber = accountNumber;
            Client = client;
        }

    }
        sealed class CurrentAccount : Account //текущий
    {
        private double CurrentSum;
        public CurrentAccount(string accountNumber, Client client, double currentSum) 
            : base(accountNumber, client)
        {
            CurrentSum = currentSum;
        }
        public override void GetInformation()
        {
            Console.WriteLine($"На этом счете {CurrentSum} белорусских рублей");
        }
    }
        sealed class DepositAccount : Account
    {
        private double Procent;
        public override void GetInformation()
        {
            Console.WriteLine($"Процент от вашей суммы на дебетовом счете состовляет {Procent}");
        }
        public DepositAccount(string accountNumber, Client client, double procent)
            : base(accountNumber, client)
        {
            Procent = procent;
        }
         }
        sealed class CurrencyAccount : Account //валютный
    {
        private string Currency; //валюта
        private double Sum;
        public override void GetInformation()
        {
            Console.WriteLine($"На вашем валютном счете {Sum} {Currency}");
        }
        public CurrencyAccount(string accountNumber, string currency, Client client, double sum) 
            : base(accountNumber, client)
        {
            Currency = currency;
            Sum = sum;
        }
    }
      abstract class Card : IOperations
    {
        private int PinCode;
        private string CardNumber;
        private string ValidityPeriod;
        private Client Client;
        public abstract void GetCard();
        void IOperations.TransferMoney()
        {
            Console.WriteLine($"Вызван метод TransferMiney из интерфейса Operations");
        }
        void IOperations.WithdrawMoney()
        {
            Console.WriteLine($"Вызван метод WithdrawMoney из интерфейса Operations");
        }
        public Card(string validityPeriod, string cardNumber, int pinCode, Client client)
        {
            ValidityPeriod = validityPeriod;
            CardNumber = cardNumber;
            PinCode = pinCode;
            Client = client;
        }
        public override string ToString()
        {
            return String.Format($"Type - {GetType()}, Card number - {CardNumber}, {Client.ToString()}");
        }

    }
        sealed class DebitCard : Card
    {
        private double Procent;
        public override void GetCard()
        {
            
        }
        public DebitCard(string validityPeriod, string cardNumber, int pinCode, double procent, Client client) 
            : base(validityPeriod, cardNumber, pinCode, client)
        {
            Procent = procent;
        }
    }
        sealed class CreditCard : Card
    {
        double GeneralSum;
        public override void GetCard()
        {
            
        }
        public CreditCard(string validityPeriod, string cardNumber, int pinCode, double generalSum, Client client) 
            : base(validityPeriod, cardNumber, pinCode, client)
        {
            GeneralSum = generalSum;
        }
    }
     interface IOperations
    {
        void WithdrawMoney();
        void TransferMoney();
    }
    class Printer
         { 
             public virtual void iAmPrinting(Person person)
             { 
                 Console.WriteLine($"Type: {person.GetType()}  ToString(): {person.ToString()}"); 
             } 
         } 

    class Program
    {
        static void Main(string[] args)
        {
            Client client1 = new Client("Masha", "Ivanova", "Minsk str.Vaneeva h.130", "3432tfret534", "34342rfeer3454g");
            Client client2 = new Client("Alexander", "Petrov", "minsk pr.Rokossovskogo h.132", "45tfdrgdfg45", "454gtr565hu");

            DebitCard debitCard1 = new DebitCard("12/2019", "4029_3726_8473", 2345, 34.56, client1);
            ((IOperations)debitCard1).TransferMoney();
            ((IOperations)debitCard1).WithdrawMoney();
            Console.WriteLine(debitCard1);

            CurrencyAccount currencyAccount = new CurrencyAccount("BY33frse3423fr283", "EUR", client1, 200);

            CurrentAccount currentAccount = new CurrentAccount("BY32gf43tgr5", client2, 900);

            CreditCard creditCard = new CreditCard("05/2020", "1234_5678_9012", 8363, 1000, client1);

            Card[] cards = {creditCard, debitCard1 };
            foreach ( Card card in cards)
            {
                card.GetCard();
            } 

            Account[] accounts = { currencyAccount, currentAccount};

            if(debitCard1 is Card)
            {
                Console.WriteLine("debitcard1 является Card");
            }
            else
            {
                Console.WriteLine("debitcard1 не является Card");

            }
            Person prsn = client2 as Person;
            prsn.ToString();

            Printer printer = new Printer();
            printer.iAmPrinting(prsn);

            Console.ReadKey();
        }
    }
}
