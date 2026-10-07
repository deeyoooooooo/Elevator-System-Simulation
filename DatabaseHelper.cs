using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace DatabaseHelper
{
    // DBHelper class: demonstrates OOP principles (Encapsulation, Abstraction)
    // Acts as middleware between UI (Form1) and database
    public class DBHelper
    {
        // -----------------------------
        // Encapsulated connection string
        // Supports default local SQL Server setup or optional override
        // -----------------------------
        private readonly string _connectionString;

        // -----------------------------
        // Constructor
        // Abstraction: DBHelper hides connection details from UI
        // -----------------------------
        public DBHelper(string? connectionString = null)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString)
                ? @"Server=DIYA\SQLEXPRESS; Database=elevator_control; Trusted_Connection=True; TrustServerCertificate=True;"
                : connectionString;
        }

        
        private SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // -----------------------------
        // Test DB connection
        // DBMS: Connection
        // Validation: catches errors
        // Data flow: UI -> DBHelper -> SQL Server
        // -----------------------------
        public void TestConnection()
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    MessageBox.Show("✅ Database connection successful!"); // feedback
                }
            }
            catch (SqlException ex)
            {
                // SQL-specific errors
                MessageBox.Show("❌ SQL connection error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // General errors
                MessageBox.Show("❌ Connection error: " + ex.Message);
            }
        }

        // -----------------------------
        // Core private helper for log insertion
        // DBMS: Create operation
        // Validation: Parameterized query prevents SQL injection
        // -----------------------------
        private void InsertLogCore(SqlConnection openConnection, string eventDescription)
        {
            const string query = "INSERT INTO Logs (LogTime, EventDescription) VALUES (@time, @event)";
            using (SqlCommand cmd = new SqlCommand(query, openConnection))
            {
                cmd.Parameters.Add(new SqlParameter("@time", SqlDbType.DateTime2) { Value = DateTime.Now });
                cmd.Parameters.Add(new SqlParameter("@event", SqlDbType.NVarChar, 4000) { Value = eventDescription ?? string.Empty });
                cmd.ExecuteNonQuery(); // Execute DB insert
            }
        }

        // -----------------------------
        // Public method to insert log (CRUD: Create)
        // Middleware: separates UI from DB details
        // Data flow: Form1 -> DBHelper -> Database
        // -----------------------------
        public void InsertLog(string eventDescription)
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    InsertLogCore(conn, eventDescription);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ SQL error inserting log: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error inserting log: " + ex.Message);
            }
        }

        // -----------------------------
        // Retrieve recent logs (CRUD: Read)
        // Used to populate UI grid
        // Data flow: Database -> DataTable -> UI
        // Validation: silent catch avoids crashing UI
        // -----------------------------
        public DataTable GetRecentLogs(int top = 100)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    string query = top > 0
                        ? $"SELECT TOP ({top}) LogTime, EventDescription FROM Logs ORDER BY LogTime DESC"
                        : "SELECT LogTime, EventDescription FROM Logs ORDER BY LogTime DESC";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(table); // populate DataTable
                    }
                }
            }
            catch (Exception)
            {
                // Silent handling: UI continues working
            }

            return table;
        }

        // -----------------------------
        // Delete all log entries (CRUD: Delete)
        // Validation: catches DB errors
        // -----------------------------
        public void ClearLogs()
        {
            try
            {
                using (SqlConnection conn = CreateConnection())
                {
                    conn.Open();
                    const string query = "DELETE FROM Logs";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery(); // delete all logs
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("❌ SQL error clearing logs: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Error clearing logs: " + ex.Message);
            }
        }
    }
}
