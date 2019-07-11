using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PetClinicc
{
    public class Pet
    {
        private string name;
        private int age;
        private string kind;

        public Pet(string name, int age, string kind)
        {
            this.Name = name;
            this.Age = age;
            this.Kind = kind;
        }
        public string Kind
        {
            get { return kind; }
            private set { kind = value; }
        }

        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public override string ToString()
        {
            return $"{this.name} {this.age} {this.kind}";
        }
    }
}
