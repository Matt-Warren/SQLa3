using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;

namespace ASQLa3
{
    public class DBConnection
    {
        public String connectionString{get; set;}
        private OleDbConnection conn { get; set; }

        public OleDbCommand cmd;

        public OleDbTransaction transaction;

        public DataTable dataTable;

        public String table { get; set; }

        private bool connected;

        public DBConnection(String conStr, String newTable)
        {
            connectionString = conStr;
            table = newTable;
            cmd = new OleDbCommand();
            dataTable = new DataTable();
        }

        public void Connect()
        {
            try
            {
                conn = new OleDbConnection(connectionString);
                connected = true;
                cmd.Connection = conn;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to create a database connection. \n{0}", ex.Message);
                connected = false;
            }
        }


        public void GetTable(){
            cmd.CommandText = "SELECT * FROM " + table;
            conn.Open();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dataTable);
            da.Dispose();
            conn.Close();
        }

        public void CreateTable(String tableName)
        {
            dataTable.

        }

        public void InsertData()
        {

        }

        public bool IsConnected()
        {
            return connected;
        }


    }
}
