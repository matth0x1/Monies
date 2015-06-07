using System;

namespace GroupExpensesManager
{
    public class Person
    {
        // Used for serialisation
        private Person() { }

        public Person(string name) : this(Guid.NewGuid(), name) { }

        public Person(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
