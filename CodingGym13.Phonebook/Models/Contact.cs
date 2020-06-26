using System;

namespace CodingGym13.Phonebook.Models
{
    // As the application designer, we don't want Contact class to be instantiated,
    // so we made this class as an abstract class
    public abstract class Contact : IEquatable<Contact>
    {
        // Properties definition
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        // Overriding the base class (Object class) virtual methods
        public override string ToString() => $"ID: {Id}\nNama: {Name}\nAlamat: {Address}\nNomer Telepon: {PhoneNumber}";

        public override bool Equals(object obj)
        {
            // if the specified object is null then it is not equal
            if (obj == null) return false;
            // Cast the specified object type to Contact type
            Contact objAsContact = obj as Contact;
            // if it is null then it is not equal,
            // else pass it to IEquatable<T>.Equals() method to check the equality of both ID's
            if (objAsContact == null) return false;
            else return Equals(objAsContact);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        // Implements IEquatable<T> interface
        // Determines whether the specified object is equal to the current object
        // by comparing whether the ID of the specified object is equal to the current object's ID
        public bool Equals(Contact other)
        {
            if (other == null) return false;
            return this.Id.Equals(other.Id);
        }
    }    
}