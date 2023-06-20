using System;

namespace TotalAddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book\n");

            //AddressBookSystem addressBookSystem = new AddressBookSystem();

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Database = AddressBookDB; Integrated Security = True";

            AddressBookService bookService = new AddressBookService(connectionString);

            Contact newContact = new Contact
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

            // Add the contact to the address book
            bookService.AddContact(newContact);
            Console.WriteLine("Contact added successfully!");

            List<Contact> allContacts = bookService.GetAllContacts();
            Console.WriteLine("All Contacts:");
            foreach (Contact contact in allContacts)
            {
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine($"State: {contact.State}");
                Console.WriteLine($"Zip: {contact.Zip}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine();
            }
            // Update a contact
            Contact contactToUpdate = allContacts[0];
            contactToUpdate.FirstName = "Updated First Name";
            contactToUpdate.LastName = "Updated Last Name";
            bookService.UpdateContact(contactToUpdate);
            Console.WriteLine("Contact updated successfully!");

            // Delete a contact
            Contact contactToDelete = allContacts[1];
            bookService.DeleteContact(contactToDelete.Id);
            Console.WriteLine("Contact deleted successfully!");

            Console.ReadLine();
        }
    }
}
