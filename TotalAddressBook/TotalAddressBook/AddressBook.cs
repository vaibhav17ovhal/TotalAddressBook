using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        public void DeleteContact(string firstName, string lastName)
        {
            Contact contact = FindContact(firstName, lastName);

            if (contact != null)
            {
                contacts.Remove(contact);
                Console.WriteLine("Contact deleted successfully.");
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

        public IEnumerable<Contact> SearchContactsByCity(string city)
        {
            return contacts.Where(contact => contact.City.Equals(city, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Contact> SearchContactsByState(string state)
        {
            return contacts.Where(contact => contact.State.Equals(state, StringComparison.OrdinalIgnoreCase));
        }

        public void SortContactsByName()
        {
            contacts = contacts.OrderBy(contact => contact.LastName)
                               .ThenBy(contact => contact.FirstName)
                               .ToList();
        }
        public void SaveAddressBookToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Contact contact in contacts)
                {
                    writer.WriteLine($"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}");
                }
            }
        }
        public void LoadAddressBookFromFile(string fileName)
        {
            if (File.Exists(fileName))
            {
                contacts.Clear();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] contactData = line.Split(',');

                        Contact contact = new Contact
                        {
                            FirstName = contactData[0],
                            LastName = contactData[1],
                            Address = contactData[2],
                            City = contactData[3],
                            State = contactData[4],
                            Zip = contactData[5],
                            PhoneNumber = contactData[6],
                            Email = contactData[7]
                        };
                        contacts.Add(contact);
                    }
                }
            }
            else
            {
                Console.WriteLine($"File {fileName} does not exist.");
            }
        }

        public void SaveAddressBookToCsv(string fileName1)
        {
            using (StreamWriter writer = new StreamWriter(fileName1))
            using (CsvWriter csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(contacts);
            }
        }

        public void LoadAddressBookFromCsv(string fileName1)
        {
            if (File.Exists(fileName1))
            {
                contacts.Clear();

                using (StreamReader reader = new StreamReader(fileName1))
                using (CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    contacts = csvReader.GetRecords<Contact>().ToList();
                }
            }
            else
            {
                Console.WriteLine($"File {fileName1} does not exist.");
            }
        }

        public void SaveAddressBookToJson(string fileName2)
        {
            string jsonData = JsonConvert.SerializeObject(contacts, Formatting.Indented);
            File.WriteAllText(fileName2, jsonData);
        }

        public void LoadAddressBookFromJson(string fileName2)
        {
            if (File.Exists(fileName2))
            {
                string jsonData = File.ReadAllText(fileName2);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(jsonData);
            }
            else
            {
                Console.WriteLine($"File {fileName2} does not exist.");
            }
        }


        public override string ToString()
        {
            string addressBookString = "Address Book:\n";
            foreach (Contact contact in contacts)
            {
                addressBookString += contact.ToString();
            }
            return addressBookString;
        }
    }
}
