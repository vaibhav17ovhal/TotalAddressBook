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
        public List<Contact> GetContactsByDateRange(DateTime startDate, DateTime endDate)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts WHERE date_added >= @StartDate AND date_added <= @EndDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Address = reader["Address"].ToString(),
                        City = reader["City"].ToString(),
                        State = reader["State"].ToString(),
                        Zip = reader["Zip"].ToString(),
                        PhoneNumber = reader["PhoneNumber"].ToString(),
                        Email = reader["Email"].ToString(),
                        DateAdded = (DateTime)reader["date_added"]
                    };

                    contacts.Add(contact);
                }

                reader.Close();
            }

            return contacts;
        }
        public List<Contact> GetContactsByCity(string city)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts WHERE City = @City";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@City", city);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Address = (string)reader["Address"],
                        City = (string)reader["City"],
                        State = (string)reader["State"],
                        Zip = (string)reader["Zip"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Email = (string)reader["Email"],
                        DateAdded = (DateTime)reader["DateAdded"]
                    };

                    contacts.Add(contact);
                }
            }

            return contacts;
        }

        public int GetContactCountByCity(string city)
        {
            int contactCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT dbo.GetContactCountByCity(@City)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@City", city);

                connection.Open();
                contactCount = (int)command.ExecuteScalar();
            }

            return contactCount;
        }

        public int GetContactCountByState(string state)
        {
            int contactCount = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT dbo.GetContactCountByState(@State)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@State", state);

                connection.Open();
                contactCount = (int)command.ExecuteScalar();
            }

            return contactCount;
        }

        public List<Contact> GetContactsByState(string state)
        {
            List<Contact> contacts = new List<Contact>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Contacts WHERE State = @State";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@State", state);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Contact contact = new Contact
                    {
                        Id = (int)reader["Id"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        Address = (string)reader["Address"],
                        City = (string)reader["City"],
                        State = (string)reader["State"],
                        Zip = (string)reader["Zip"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Email = (string)reader["Email"],
                        DateAdded = (DateTime)reader["DateAdded"]
                    };

                    contacts.Add(contact);
                }
            }

            return contacts;
        }
        public void AddContactToDatabase(Contact contact)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a new transaction
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Insert the contact into the Contacts table
                    string insertContactQuery = "INSERT INTO Contacts (FirstName, LastName, Address, City, State, Zip, PhoneNumber, Email, DateAdded) " +
                        "VALUES (@FirstName, @LastName, @Address, @City, @State, @Zip, @PhoneNumber, @Email, @DateAdded)";
                    SqlCommand insertContactCommand = new SqlCommand(insertContactQuery, connection, transaction);
                    insertContactCommand.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    insertContactCommand.Parameters.AddWithValue("@LastName", contact.LastName);
                    insertContactCommand.Parameters.AddWithValue("@Address", contact.Address);
                    insertContactCommand.Parameters.AddWithValue("@City", contact.City);
                    insertContactCommand.Parameters.AddWithValue("@State", contact.State);
                    insertContactCommand.Parameters.AddWithValue("@Zip", contact.Zip);
                    insertContactCommand.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    insertContactCommand.Parameters.AddWithValue("@Email", contact.Email);
                    insertContactCommand.Parameters.AddWithValue("@DateAdded", contact.DateAdded);
                    insertContactCommand.ExecuteNonQuery();

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction in case of an error
                    transaction.Rollback();
                    throw ex;
                }
            }
        }




    }
}
        
    
