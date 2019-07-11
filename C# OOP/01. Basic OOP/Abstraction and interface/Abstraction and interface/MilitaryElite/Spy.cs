using System;
using System.Collections.Generic;
using System.Text;


class Spy : ISpy
{
    public string id { get; }
    public string firstName { get; }
    public string lastName { get; }
    public string codeNumber { get; }


    public Spy(string id, string firstName, string lastName, string codeNumber)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.codeNumber = codeNumber;
    }

    public override string ToString()
    {
        return $"Name: {this.firstName} {this.lastName} Id: {this.id} \nCode Number: {this.codeNumber}";
    }
}

