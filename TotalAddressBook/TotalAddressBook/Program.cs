using System;

namespace TotalAddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book\n");

            AddressBook book = new AddressBook();

            Console.WriteLine("Add persons to the Address Book:");

            while (true)
            {
                Console.WriteLine("Enter person details or 'q' to quit.");

                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                if (firstName.ToLower() == "q")
                    break;

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Address: ");
                string address = Console.ReadLine();

                Console.Write("City: ");
                string city = Console.ReadLine();

                Console.Write("State: ");
                string state = Console.ReadLine();

                Console.Write("ZIP Code: ");
                string zip = Console.ReadLine();

                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Contact contact = new Contact
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Address = address,
                    City = city,
                    State = state,
                    Zip = zip,
                    PhoneNumber = phoneNumber,
                    Email = email
                };

                book.AddContact(contact);
            }

            Console.WriteLine("\nAll Contacts:");
            book.DisplayContacts();
        }
    }
}
