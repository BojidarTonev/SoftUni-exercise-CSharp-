using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Person
{
    private string name;
    private int age;
    private List<BankAccount> accounts;

    public string Name
    {
        get => name;
        set => name = value;
    }
    public int Age
    {
        get => age;
        set => age = value;
    }
    public List<BankAccount> Accounts
    {
        get => accounts;
        set => accounts = value;
    }

    public Person(string name, int age)
    : this(name, age, new List<BankAccount>())
    {
    }

    public Person(string name, int age, List<BankAccount> accounts)
    {
        this.name = name;
        this.age = age;
        this.accounts = new List<BankAccount>();
    }

    public decimal GetBalance()
    {
        return this.accounts.Sum(b => b.Balance);
    }
}

