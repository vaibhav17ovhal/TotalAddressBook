﻿using System;

namespace TotalAddressBook
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book\n");

            //AddressBookSystem addressBookSystem = new AddressBookSystem();

            string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Database = AddressBookDB; Integrated Security = True";
            
            AddressBook book = new AddressBook(connectionString);
            string fileName = "book.txt";
            string fileName1 = "book.csv";
            string fileName2 = "book.json";

            book.LoadContactsFromDatabase();



            Console.WriteLine("Address Book System");
            /*
            while (true)
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1. Add a new Address Book");
                Console.WriteLine("2. Display Address Book");
                Console.WriteLine("3. Add Contact to Address Book");
                Console.WriteLine("4. View contacts by City");
                Console.WriteLine("5. View contacts by State");
                Console.WriteLine("6. Count contacts by City");
                Console.WriteLine("7. Count contacts by State");
                Console.WriteLine("8. Quit");

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
                        Console.Write("Enter the City to get contact count: ");
                        string city = Console.ReadLine();
                        int contactCountByCity = addressBookSystem.GetContactCountByCity(city);
                        Console.WriteLine($"Number of contacts in {city}: {contactCountByCity}");
                        break;
                    case "7":
                        Console.Write("Enter the State to get contact count: ");
                        string state = Console.ReadLine();
                        int contactCountByState = addressBookSystem.GetContactCountByState(state);
                        Console.WriteLine($"Number of contacts in {state}: {contactCountByState}");
                        break;
                    case "8":
                        Console.WriteLine("Quitting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            */
            while (true)
            {
                Console.WriteLine("\nEnter an option:");
                Console.WriteLine("1. Add a contact");
                //Console.WriteLine("2. Display contacts sorted by name");
                //Console.WriteLine("3. Save address book to file");
                //Console.WriteLine("4. Load address book from file");
                //Console.WriteLine("5. Save address book to CSV");
                //Console.WriteLine("6. Load address book from CSV");
                //Console.WriteLine("7. Save address book to JSON");
                //Console.WriteLine("8. Load address book from JSON");
                Console.WriteLine("9. Display all contacts");
                Console.WriteLine("10. Exit");
                


                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();
                        Console.Write("Enter address: ");
                        string address = Console.ReadLine();
                        Console.Write("Enter city: ");
                        string city = Console.ReadLine();
                        Console.Write("Enter state: ");
                        string state = Console.ReadLine();
                        Console.Write("Enter ZIP code: ");
                        string zip = Console.ReadLine();
                        Console.Write("Enter phone number: ");
                        string phoneNumber = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();


                        Contact newContact = new Contact
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

                        book.AddContact(newContact);
                        break;
                    case "2":
                        book.SortContactsByName();
                        Console.WriteLine(book.ToString());
                        break;
                    case "3":
                        book.SaveAddressBookToFile(fileName);
                        Console.WriteLine("Address book saved to file.");
                        break;
                    case "4":
                        book.LoadAddressBookFromFile(fileName);
                        Console.WriteLine("Address book loaded from file.");
                        break;
                    case "5":
                        book.SaveAddressBookToCsv(fileName1);
                        Console.WriteLine("Address book saved to CSV.");
                        break;
                    case "6":
                        book.LoadAddressBookFromCsv(fileName1);
                        Console.WriteLine("Address book loaded from CSV.");
                        break;
                    case "7":
                        book.SaveAddressBookToJson(fileName2);
                        Console.WriteLine("Address book saved to JSON.");
                        break;
                    case "8":
                        book.LoadAddressBookFromJson(fileName2);
                        Console.WriteLine("Address book loaded from JSON.");
                        break;
                    case "9":
                        DisplayContacts(book);
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            static void DisplayContacts(AddressBook addressBook)
            {
                List<Contact> contacts = addressBook.GetContacts();

                Console.WriteLine("Contacts:");
                foreach (Contact contact in contacts)
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
            }
        }
    }
}
