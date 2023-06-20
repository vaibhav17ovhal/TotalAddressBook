using System;

namespace TotalAddressBook
{
    public class Program
    {
            static void Main(string[] args)
            {
                string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Database = AddressBookDB; Integrated Security = True"; 

                // Create an instance of AddressBookService
                AddressBookService addressBookService = new AddressBookService(connectionString);

            // Add a new contact
            /*
            Contact newContact = new Contact
            {
                FirstName = "Ayushi",
                LastName = "Dubey",
                Address = "Juni Indore",
                City = "Indore",
                State = "M.P.",
                Zip = "452007",
                PhoneNumber = "7415887847",
                Email = "ayushidubey80@gmail.com",
                DateAdded = DateTime.Now
                };
                addressBookService.AddContact(newContact);
                Console.WriteLine("Contact added successfully!");*/

            // Create a new Contact object
            Contact newContact1 = new Contact
            {
                FirstName = "Vaibhav",
                LastName = "Ovhal",
                Address = "Harsiddhi",
                City = "Indore",
                State = "M.P.",
                Zip = "452007",
                PhoneNumber = "9340596362",
                Email = "vaibhavovhal15@gmail.com",
                DateAdded = DateTime.Now
            };

            // Add the contact to the database
            addressBookService.AddContactToDatabase(newContact1);
            Console.WriteLine("Contact added successfully!");

            Console.ReadLine();
            // Get contacts by city
            string city = "Indore";
                List<Contact> contactsByCity = addressBookService.GetContactsByCity(city);
                Console.WriteLine($"Contacts in {city}:");
                foreach (Contact contact in contactsByCity)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }

                // Get contacts by state
                string state = "M.P.";
                List<Contact> contactsByState = addressBookService.GetContactsByState(state);
                Console.WriteLine($"Contacts in {state}:");
                foreach (Contact contact in contactsByState)
                {
                    Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                }

                // Get contact count by city
                int contactCountByCity = addressBookService.GetContactCountByCity(city);
                Console.WriteLine($"Contact count in {city}: {contactCountByCity}");

                // Get contact count by state
                int contactCountByState = addressBookService.GetContactCountByState(state);
                Console.WriteLine($"Contact count in {state}: {contactCountByState}");

                // Update contact information
                Contact contactToUpdate = contactsByCity[0];
                contactToUpdate.FirstName = "Jane";
                contactToUpdate.LastName = "Smith";
                addressBookService.UpdateContact(contactToUpdate);
                Console.WriteLine("Contact updated successfully!");

                // Delete a contact
                Contact contactToDelete = contactsByCity[1];
                addressBookService.DeleteContact(contactToDelete.Id);
                Console.WriteLine("Contact deleted successfully!");

                
            }
    }
}

