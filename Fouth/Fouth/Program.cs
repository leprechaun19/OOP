using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fouth
{
    abstract class Person
    {
        string FirstName { get; set; }
        string Surname { get; set; }
        string Address { get; set; }
        public Person(string name, string surname, string address)
        {
            FirstName = name;
            Surname = surname;
            Address = address;
        }
    }
     class Employee : Person
    {
        public string Position;//Должность
        public Employee(string name, string surname, string address, string position) : base(name, surname, address)
        {
            Position = position;
        }
    }
     class Client : Person
    {
        string PassportNumber;
        string IDNumber;
        public Client(string name, string surname, string address, string passportNumber, string idNumber)
            : base(name, surname, address)
        {
            PassportNumber = passportNumber;
            IDNumber = idNumber;
        }

    }   
      abstract class Account : Client
    {
        string AccountNumber;
        string Currency; //валюта
        public Account(string name, string surname, string address, string passportNumber, string idNumber,
                       string accountNumber, string currency) 
            : base(name, surname, address, passportNumber, idNumber)
        {

        }

    }
        sealed class CurrentAccount : Account //текущий
    {
        public CurrentAccount(string name, string surname, string address, string passportNumber, string idNumber,
                              string accountNumber, string currency) 
            : base(name, surname, address, passportNumber, idNumber, accountNumber, currency) { }
    }
        sealed class SettlementAccount : Account //расчетный
    {
        public SettlementAccount(string name, string surname, string address, string passportNumber, string idNumber,
                                 string accountNumber, string currency) 
            : base(name, surname, address, passportNumber, idNumber, accountNumber, currency) { }
    }
        sealed class DepositAccount : Account
    {
        public DepositAccount(string name, string surname, string address, string passportNumber, string idNumber,
                              string accountNumber, string currency) 
            : base(name, surname, address, passportNumber, idNumber, accountNumber, currency) { }
    }
        sealed class CurrencyAccount : Account //валютный
    {
        public CurrencyAccount(string name, string surname, string address, string passportNumber, string idNumber,
                               string accountNumber, string currency) 
            : base(name, surname, address, passportNumber, idNumber, accountNumber, currency) { }
    }
      abstract class Card : Client
    {
        int PinCode;
        string CardNumber;
        string ValidityPeriod;
        public Card(string name, string surname, string address, string passportNumber, string idNumber,
                    string validityPeriod, string cardNumber, int pinCode) 
            : base(name, surname, address, passportNumber, idNumber)
        {
            ValidityPeriod = validityPeriod;
            CardNumber = cardNumber;
            PinCode = pinCode;
        }
        
    }
        sealed class DebitCard : Card
    {
        public DebitCard(string name, string surname, string address, string passportNumber, string idNumber,
                         string validityPeriod, string cardNumber, int pinCode) 
            : base(name, surname, address, passportNumber, idNumber, validityPeriod, cardNumber, pinCode) { }
    }
        sealed class CreditCard : Card
    {
        public CreditCard(string name, string surname, string address, string passportNumber, string idNumber,
                          string validityPeriod, string cardNumber, int pinCode) 
            : base(name, surname, address, passportNumber, idNumber, validityPeriod, cardNumber, pinCode) { }
    }
     interface IOpetationsWithAccount
    {

    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
