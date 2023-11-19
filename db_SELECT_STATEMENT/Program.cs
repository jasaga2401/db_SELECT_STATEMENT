using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        // Replace with your actual SQL Server connection string
        string connectionString = "Data Source=Amaze\\SQLEXPRESS;Initial Catalog=things_to_do;Integrated Security=True";

        // Create a new SqlConnection using the connection string
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // Open the database connection
                connection.Open();
                Console.WriteLine("Connected to the database.");

                // Define your SQL query
                string sqlQuery = "SELECT * FROM dbo.tbl_items";

                // Create a SqlCommand with the query and the connection
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Execute the query and get a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Check if there are rows in the result set
                        if (reader.HasRows)
                        {
                            // Iterate through the rows and output data
                            while (reader.Read())
                            {
                                // Example: assuming you have a column named "ColumnName"
                                string columnNameValue = reader["name"].ToString();
                                Console.WriteLine($"Value from database: {columnNameValue}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No data found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Ensure the connection is closed, whether an exception occurs or not
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }
    }
}

