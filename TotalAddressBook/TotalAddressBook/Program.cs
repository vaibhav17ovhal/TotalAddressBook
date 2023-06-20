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
                Console.WriteLine("4. Quit");

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
                        if(addressBookSystem.DisplayAddressBook(addContactAddressBookName))
                        {
                            AddressBook book = addressBookSystem.GetAddressBook(addContactAddressBookName);

                            Console.Write("First Name: ");
                            string firstName = Console.ReadLine();

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
                            Console.WriteLine("Contact Added to the Address Book.");
                        }
                        break;
                    case "4":
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
