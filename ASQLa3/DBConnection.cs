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
            catch (Exception)
            {
                connected = false;
            }
        }


        public String GetTable(){
            String returnMessage = "";
            try
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM [" + table + "]";
                
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dataTable);
                da.Dispose();
                conn.Close();
            }
            catch(Exception){
                returnMessage = "Could not open table.\n";
            }
            return returnMessage;
        }


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
                    foreach (DataRow dr in fromTable.Rows)
                    {
                        count = dr.ItemArray.Count();
                        query = "INSERT INTO [" + table + "] VALUES('";
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
                    transaction.Commit();
                    returnMessage += "Data copied successfully. \n";
                }
                conn.Close();
            }
            return returnMessage;
        }

        public bool IsConnected()
        {
            return connected;
        }


    }
}
