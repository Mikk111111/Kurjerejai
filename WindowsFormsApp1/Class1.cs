using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    internal class Class1
    {
        
        // User information
        public static int UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserSurname { get; set; }
        public static string UserEmail { get; set; }
        public static string UserPhoneNumber { get; set; }
        public static string UserStreet { get; set; }

        // The generated code (e.g., GUID or custom string)
        public static string GeneratedCode { get; set; }

        // Method to push the user data to the database
        public static void PushDataToDatabase()
        {
            // Connection string (you can read this from a file as well if needed)
            string ConnectionString = "Server=sql7.freesqldatabase.com;Database=sql7747669;Uid=sql7747669;Pwd=suHFe6f92Y;Port=3306;";


            try
            {
                // Create the connection to the database
                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL query to insert the data into the database
                    string query = "INSERT INTO Users (Name, Surname, Email, PhoneNumber, Street, GeneratedCode) " +
                                   "VALUES (@Name, @Surname, @Email, @PhoneNumber, @Street, @GeneratedCode)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Name", UserName);
                        command.Parameters.AddWithValue("@Surname", UserSurname);
                        command.Parameters.AddWithValue("@Email", UserEmail);
                        command.Parameters.AddWithValue("@PhoneNumber", UserPhoneNumber);
                        command.Parameters.AddWithValue("@Street", UserStreet);
                        command.Parameters.AddWithValue("@GeneratedCode", GeneratedCode);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }

                // If everything goes well, display a success message
                Console.WriteLine("Data saved successfully!");
            }
            catch (MySqlException mysqlEx)
            {
                // Catch MySQL specific errors
                Console.WriteLine($"MySQL Error: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Catch general errors
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        public static void PrintClass1Data()
        {
            // Print out all stored data for debugging purposes
            Console.WriteLine("Class1 Data:");
            Console.WriteLine($"Name: {UserName}");
            Console.WriteLine($"Surname: {UserSurname}");
            Console.WriteLine($"Email: {UserEmail}");
            Console.WriteLine($"Phone Number: {UserPhoneNumber}");
            Console.WriteLine($"Street: {UserStreet}");
        }
    }
}
