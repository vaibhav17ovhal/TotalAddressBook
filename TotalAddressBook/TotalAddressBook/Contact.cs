using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAddressBook
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact()
        {
        }
        public Contact(int id, string firstName, string lastName, string address, string city, string state, string zip, string phoneNumber, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Contact other = (Contact)obj;
            return string.Equals(this.FirstName, other.FirstName, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(FirstName) ^
                   StringComparer.OrdinalIgnoreCase.GetHashCode(LastName);
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nAddress: {Address}\nCity: {City}\nState: {State}\nZip: {Zip}\nPhone: {PhoneNumber}\nEmail: {Email}\n";
        }
    }
}
