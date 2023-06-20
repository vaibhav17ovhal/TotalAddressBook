using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAddressBook
{
    public class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }
        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void DisplayContacts()
        {
            foreach(var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}, {contact.City}, {contact.State}, {contact.Zip}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email:{contact.Email}");
                Console.WriteLine();
            }
        }

        public void EditContact(string firstName , string lastName)
        {
            Contact contact = FindContact(firstName , lastName);

            if(contact != null)
            {
                Console.WriteLine("Enter the new details: ");

                Console.Write("First Name: ");
                contact.FirstName = Console.ReadLine();

                Console.Write("Last Name: ");
                contact.LastName = Console.ReadLine();

                Console.Write("Address: ");
                contact.Address = Console.ReadLine();

                Console.Write("City: ");
                contact.City = Console.ReadLine();

                Console.Write("State: ");
                contact.State = Console.ReadLine();

                Console.Write("ZIP Code: ");
                contact.Zip = Console.ReadLine();

                Console.Write("Phone Number: ");
                contact.PhoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                contact.Email = Console.ReadLine();

                Console.WriteLine("Contact details updated Successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
        private Contact FindContact(string firstName , string lastName)
        {
            return contacts.Find(contact =>
            contact.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) &&
            contact.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)
            );
        }
    }
}
