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

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
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
    }
}
