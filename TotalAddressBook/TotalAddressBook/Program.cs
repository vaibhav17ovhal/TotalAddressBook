using System;

namespace TotalAddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book\n");
            
            AddressBookSystem addressBookSystem = new AddressBookSystem();

            Console.WriteLine("Address Book System");

            while (true)
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Display Address Book");
                Console.WriteLine("3. Add Contact to Address Book");
                Console.WriteLine("4. View contacts by City");
                Console.WriteLine("5. View contacts by State");
                Console.WriteLine("6. Quit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter the name for the Address Book: ");
                        string addressBookName = Console.ReadLine();
                        addressBookSystem.AddAddressBook(addressBookName);
                        break;
                    case "2":
                        Console.Write("Enter the name of the Address Book to display: ");
                        string displayAddressBookName = Console.ReadLine();
                        addressBookSystem.DisplayAddressBook(displayAddressBookName);
                        break;
                    case "3":
                        Console.Write("Enter the name of the Address Book to add a contact: ");
                        string addContactAddressBookName = Console.ReadLine();
                        addressBookSystem.DisplayAddressBook(addContactAddressBookName);
                        
                        AddressBook book = addressBookSystem.GetAddressBook(addContactAddressBookName);
                        if(book != null)
                        {
                            Contact contact = new Contact();

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
                            Console.Write("Zip: ");
                            contact.Zip = Console.ReadLine();
                            Console.Write("Phone Number: ");
                            contact.PhoneNumber = Console.ReadLine();
                            Console.Write("Email: ");
                            contact.Email = Console.ReadLine();

                            book.AddContact(contact);
                        }                        
                        break;
                    case "4":
                        Console.Write("Enter the City to view contacts: ");
                        string viewCity = Console.ReadLine();
                        IEnumerable<Contact> cityContacts = addressBookSystem.GetContactsByCity(viewCity);

                        foreach (Contact contact in cityContacts)
                        {
                            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                        }
                        break;
                    case "5":
                        Console.Write("Enter the State to view contacts: ");
                        string viewState = Console.ReadLine();
                        IEnumerable<Contact> stateContacts = addressBookSystem.GetContactsByState(viewState);

                        foreach (Contact contact in stateContacts)
                        {
                            Console.WriteLine($"{contact.FirstName} {contact.LastName}");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Quitting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
