/*
* FILE : DBConnection.cs
* PROJECT : ASQL - Assignment #3
* PROGRAMMER : Matt Warren
* FIRST VERSION : 2016-03-03
* DESCRIPTION :
* This class is used to contain the methods applicable for connecting and transmitting data between tables
*/

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
        //used to connect to a database
        public String connectionString{get; set;}

        //connection to a database
        private OleDbConnection conn { get; set; }

        //command for issuing querys and such
        public OleDbCommand cmd;

        //transaction for issuing querys and such
        public OleDbTransaction transaction;

        //datatable to hold the table data after it is pulled from a database
        public DataTable dataTable;

        //holds the name of the table
        public String table { get; set; }

        
        private bool connected;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBConnection"/> class.
        /// </summary>
        /// <param name="conStr">The connection string for a given database.</param>
        /// <param name="newTable">The table name that will be interacted with.</param>
        public DBConnection(String conStr, String newTable)
        {
            connectionString = conStr;
            table = newTable;
            cmd = new OleDbCommand();
            dataTable = new DataTable();
        }

        /// <summary>
        /// Connects to the database
        /// </summary>
        public void Connect()
        {
            try
            {
                conn = new OleDbConnection(connectionString);
                connected = true;
                cmd.Connection = conn;
                
            }
            catch (Exception)
            {
                connected = false;
            }
        }

        /// <summary>
        /// Loads the table into dataTable if possible.
        /// </summary>
        /// <returns>returnMessage : string with an error message, "" if no error</returns>
        public String GetTable(){
            String returnMessage = "";
            if (connected)
            {
                try
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM [" + table + "]"; //query to run
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    da.Fill(dataTable); //get the data from the database, store in dataTable
                    da.Dispose();
                    conn.Close();
                }
                catch (Exception)
                {
                    returnMessage = "Could not open table.\n";
                }
            }
            return returnMessage;
        }

        /// <summary>
        /// Inserts data from parameters into the table of the class
        /// </summary>
        /// <param name="fromTable">Table to get the data from</param>
        /// <returns>returnMessage : a string that contains error/progress text to update the user on progress</returns>
        public String InsertData(DataTable fromTable)
        {
            int count = 0;
            String query = "";
            String returnMessage = "";
            bool status = true;
            try
            {
                conn.Open();
                this.transaction = this.conn.BeginTransaction();
                this.cmd.Transaction = this.transaction;

                try
                {
                    //loop through each row of the table
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        count = dr.ItemArray.Count();
                        query = "INSERT INTO [" + table + "] VALUES('";
                        //loop through each object of the row
                        foreach (Object o in dr.ItemArray)
                        {
                            count--;
                            query += o.ToString();
                            if (count != 0)
                            {
                                query += "' , '";
                            }
                            else
                            {
                                query += "');";
                            }
                        }

                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();

                    }
                }
                catch (Exception except)
                {

                    status = false;
                    returnMessage += "Error copying a row from the table. \n" + except.Message + "\n";
                    transaction.Rollback();
                    //rollback if there were any issues
                }
                
            }
            catch (Exception excepti)
            {
                status = false;
                returnMessage += "Error opening the connection. \n" + excepti.Message + "\n";
            }
            finally
            {
                if (status)
                {
                    //successful!
                    transaction.Commit();
                    returnMessage += "Data copied successfully. \n";
                }
                conn.Close();
            }
            return returnMessage;
        }
        /// <summary>
        /// Determines whether this instance is connected.
        /// </summary>
        /// <returns></returns>
        public bool IsConnected()
        {
            return connected;
        }


    }
}
