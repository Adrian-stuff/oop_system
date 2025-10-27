using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace oop_backend
{
    
    public class Database
    {
        

        private readonly string connectionString;

        public Database()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "lap-2158\adrian";    
            builder.InitialCatalog = "oop_db";
            builder.IntegratedSecurity = true;        // Use Windows Authentication

            // builder.UserID = "YourUsername";
            // builder.Password = "YourPassword";

            builder.ConnectTimeout = 30;

            this.connectionString = builder.ConnectionString;
        }
        public string RegisterUser(UserData userData)
        {
            this.ExecuteQueryScalar(@"");
            return "User registered successfully";
        }
       
        public object? ExecuteQueryScalar(string query)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        object result = command.ExecuteScalar();

                        return result;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Database Error executing query '{query}': {ex.Message}");
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        return null;
                    }
                }
            }
        }

        public DataTable? GetDataTable(string query)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }

                        return dataTable;
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine($"Database Error executing query '{query}': {ex.Message}");
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                        return null;
                    }
                }
            }
        }
    }
}