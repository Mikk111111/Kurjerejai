using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Mail;
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

                // After successfully saving, send the email
                SendEmail();
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

        // Method to send an email
        private static void SendEmail()
        {
            try
            {
                // SMTP Configuration
                string smtpServer = "smtp.office365.com";
                int smtpPort = 587;
                string smtpEmail = "Kurjerejai4@outlook.com";
                string smtpPassword = "hhyU3sfEHeDJp4N";

                // Email content
                string subject = "Welcome to Our Service!";
                string body = $@"
                Dear {UserName} {UserSurname},

                Thank you for choosing our drone services. Your unique access code is:

                *** {GeneratedCode} ***

                Please use this code to track your drone services or access exclusive features.

                Here are the details you provided:

                - Name: {UserName}
                - Surname: {UserSurname}
                - Email: {UserEmail}
                - Phone Number: {UserPhoneNumber}
                - Street: {UserStreet}

                If any of these details are incorrect or if you have any questions, feel free to contact us.

                Thank you again for trusting us with your drone needs. We are thrilled to have you as our valued customer!

                Best regards,  
                Kurjerejai4
                ";

                // Create and send the email
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(smtpEmail);
                    mail.To.Add(UserEmail);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false;

                    using (var smtp = new SmtpClient(smtpServer, smtpPort))
                    {
                        smtp.Credentials = new System.Net.NetworkCredential(smtpEmail, smtpPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

                // Email sent successfully
                Console.WriteLine("Email sent successfully to " + UserEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
            }
        }

        // Method to print out all stored data for debugging purposes
        public static void PrintClass1Data()
        {
            Console.WriteLine("Class1 Data:");
            Console.WriteLine($"Name: {UserName}");
            Console.WriteLine($"Surname: {UserSurname}");
            Console.WriteLine($"Email: {UserEmail}");
            Console.WriteLine($"Phone Number: {UserPhoneNumber}");
            Console.WriteLine($"Street: {UserStreet}");
        }
    }
}
