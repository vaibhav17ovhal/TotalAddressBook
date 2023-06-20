using System;

namespace TotalAddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book\n");

            AddressBook book = new AddressBook();

            Contact con1 = new Contact
            {
                FirstName = "Vaibhav",
                LastName = "Ovhal",
                Address = "Harsiddhi",
                City = "Indore",
                State = "M.P.",
                Zip = "452007",
                PhoneNumber = "9340596362",
                Email = "vaibhavovhal15@gmail.com"
            };

            Contact con2 = new Contact
            {
                FirstName = "Ayushi",
                LastName = "Dubey",
                Address = "Juni Indore",
                City = "Indore",
                State = "M.P.",
                Zip = "452007",
                PhoneNumber = "7415887847",
                Email = "ayushidubey80@gmail.com"
            };
            
            Contact con3 = new Contact
            {
                FirstName = "Karan",
                LastName = "Soni",
                Address = "Annapurna",
                City = "Indore",
                State = "M.P.",
                Zip = "452012",
                PhoneNumber = "9845631405",
                Email = "karanS145@gmail.com"
            };
            Contact con4 = new Contact
            {
                FirstName = "Nikita",
                LastName = "Joshi",
                Address = "Anand Nagar",
                City = "Pune",
                State = "M.H.",
                Zip = "450004",
                PhoneNumber = "7964850069",
                Email = "Nikki123@gmail.com"
            };
            Contact con5 = new Contact
            {
                FirstName = "Akanksha",
                LastName = "Patidar",
                Address = "Gandhi Nagar",
                City = "Ahemdabad",
                State = "G.J.",
                Zip = "456120",
                PhoneNumber = "9764512999",
                Email = "PatidarA444@gmail.com"
            };
           

            book.AddContact(con1);
            book.AddContact(con2);
            book.AddContact(con3);
            book.AddContact(con4);
            book.AddContact(con5);

            book.DisplayContacts();

            Console.WriteLine("Add a new contact:");

            Contact newContact = new Contact();

            Console.Write("First Name: ");
            newContact.FirstName = Console.ReadLine();

            Console.Write("Last Name: ");
            newContact.LastName = Console.ReadLine();

            Console.Write("Address: ");
            newContact.Address = Console.ReadLine();

            Console.Write("City: ");
            newContact.City = Console.ReadLine();

            Console.Write("State: ");
            newContact.State = Console.ReadLine();

            Console.Write("ZIP Code: ");
            newContact.Zip = Console.ReadLine();

            Console.Write("Phone Number: ");
            newContact.PhoneNumber = Console.ReadLine();

            Console.Write("Email: ");
            newContact.Email = Console.ReadLine();

            // Add the new contact to the address book
            book.AddContact(newContact);

            // Display all contacts again, including the newly added contact
            Console.WriteLine("\nAll Contacts:");
            book.DisplayContacts();

        }
    }
}
