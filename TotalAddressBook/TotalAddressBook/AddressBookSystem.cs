using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAddressBook
{
    public class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks;
        private Dictionary<string, List<Contact>> cityDictionary;
        private Dictionary<string, List<Contact>> stateDictionary;

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
            cityDictionary = new Dictionary<string, List<Contact>>();
            stateDictionary = new Dictionary<string, List<Contact>>();
        }
        public void AddAddressBook(string name)
        {
            if(!addressBooks.ContainsKey(name))
            {
                addressBooks[name] = new AddressBook();
                Console.WriteLine($"Address book '{name}' created.");
            }
            else
            {
                Console.WriteLine($"Address book '{name}' already exists.");
            }
        }
        public void DisplayAddressBook(string name)
        {
            if(addressBooks.ContainsKey(name))
            {
                AddressBook book = addressBooks[name];
                Console.WriteLine($"Address book: '{name}'");
                book.DisplayContacts();
                
            }
            else
            {
                Console.WriteLine($"Address Book '{name}' does not exist.");
                
            }
        }
        public AddressBook GetAddressBook(string name)
        {
            if (addressBooks.ContainsKey(name))
            {
                return addressBooks[name];
            }

            return null;
        }

        public void AddContact(Contact contact, string addressBookName)
        {
            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.AddContact(contact);

                UpdateCityDictionary(contact);
                UpdateStateDictionary(contact);
            }
            else
            {
                Console.WriteLine($"Address Book '{addressBookName}' does not exist.");
            }
        }

        public IEnumerable<Contact> GetContactsByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                return cityDictionary[city];
            }
            else
            {
                Console.WriteLine($"No contacts found in the city of {city}.");
                return Enumerable.Empty<Contact>();
            }
        }

        public IEnumerable<Contact> GetContactsByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                return stateDictionary[state];
            }
            else
            {
                Console.WriteLine($"No contacts found in the state of {state}.");
                return Enumerable.Empty<Contact>();
            }
        }

        private void UpdateCityDictionary(Contact contact)
        {
            if (!cityDictionary.ContainsKey(contact.City))
            {
                cityDictionary[contact.City] = new List<Contact>();
            }

            cityDictionary[contact.City].Add(contact);
        }

        private void UpdateStateDictionary(Contact contact)
        {
            if (!stateDictionary.ContainsKey(contact.State))
            {
                stateDictionary[contact.State] = new List<Contact>();
            }

            stateDictionary[contact.State].Add(contact);
        }

        public int GetContactCountByCity(string city)
        {
            if (cityDictionary.ContainsKey(city))
            {
                return cityDictionary[city].Count;
            }
            else
            {
                Console.WriteLine($"No contacts found in the city of {city}.");
                return 0;
            }
        }
        public int GetContactCountByState(string state)
        {
            if (stateDictionary.ContainsKey(state))
            {
                return stateDictionary[state].Count;
            }
            else
            {
                Console.WriteLine($"No contacts found in the state of {state}.");
                return 0;
            }
        }
    }
}
