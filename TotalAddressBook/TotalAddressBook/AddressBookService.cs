using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalAddressBook
{
    public class AddressBookService
    {
        private string connectionString;

        public AddressBookService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["Id"]);
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string address = reader["Address"].ToString();
                        string city = reader["City"].ToString();
                        string state = reader["State"].ToString();
                        string zip = reader["Zip"].ToString();
                        string phoneNumber = reader["PhoneNumber"].ToString();
                        string email = reader["Email"].ToString();

                        Contact contact = new Contact(id, firstName, lastName, address, city, state, zip, phoneNumber, email);
                        contacts.Add(contact);
                    }
                }
            }

            return contacts;
        }
        public void AddContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Contacts (FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email) VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@State", contact.State);
                command.Parameters.AddWithValue("@Zip", contact.Zip);
                command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                command.Parameters.AddWithValue("@Email", contact.Email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void UpdateContact(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Address = @Address, City = @City, State = @State, Zip = @Zip, PhoneNumber = @PhoneNumber, Email = @Email WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", contact.Id);
                command.Parameters.AddWithValue("@FirstName", contact.FirstName);
                command.Parameters.AddWithValue("@LastName", contact.LastName);
                command.Parameters.AddWithValue("@Address", contact.Address);
                command.Parameters.AddWithValue("@City", contact.City);
                command.Parameters.AddWithValue("@State", contact.State);
                command.Parameters.AddWithValue("@Zip", contact.Zip);
                command.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                command.Parameters.AddWithValue("@Email", contact.Email);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Contact not found.");
                }
                else
                {
                    Console.WriteLine("Contact updated successfully!");
                }
            }
        }

        public void DeleteContact(int contactId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Contacts WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", contactId);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Contact not found.");
                }
                else
                {
                    Console.WriteLine("Contact deleted successfully!");
                }
            }
        }
    }
}
        
    
