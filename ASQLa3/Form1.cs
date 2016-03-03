/*
* FILE : Form1.cs
* PROJECT : ASQL - Assignment #3
* PROGRAMMER : Matt Warren
* FIRST VERSION : 2016-03-03
* DESCRIPTION :
* This file is used for the general UI and used mainly to call functions from the DBConnection.cs
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSDASC;
using ADODB;

namespace ASQLa3
{
    public partial class Form1 : Form
    {

        public String fromTable;                //name of table to get data from
        public String fromConnectionString;     //connection string for the database to get data from

        public String toTable;                  //name of table to put data in
        public String toConnectionString;       //connection string for the database to put data in

        public DBConnection sourceConnection;   //connection for the source data
        public DBConnection destConnection;     //connection for the destination data

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Button to start the data transmission
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnTransferClick(object sender, EventArgs e)
        {
            //get table names
            fromTable = txtFromTable.Text; 
            toTable = txtToTable.Text;

            String errorStr = String.Empty;
            String msg1 = String.Empty;
            String msg2 = String.Empty;
            
            //defaulted 
            fromConnectionString = "Provider=SQLOLEDB.1;Password=Conestoga1;Persist Security Info=True;User ID=sa;Initial Catalog=NORTHWND;Data Source=.\\SQLEXPRESS";
            toConnectionString = "Provider=SQLOLEDB.1;Password=Conestoga1;Persist Security Info=True;User ID=sa;Initial Catalog=NORTHWND;Data Source=.\\SQLEXPRESS";

            if (fromConnectionString == null || toConnectionString == null)
            {
                //NEED to set both dbs
                errorStr += "Need to set both connection strings before starting the transfer.\n";
            }
            if (fromTable == "")
            {
                errorStr += "Need to specify the starting table to copy from.\n";
            }
            if (errorStr != String.Empty)
            {
                //if errors, print them
                lblErrorMessage.Text = errorStr;
            }
            else
            {
                //connect here
                lblErrorMessage.Text = "Connecting and grabbing source table.";
                sourceConnection = new DBConnection(fromConnectionString, fromTable);
                destConnection = new DBConnection(toConnectionString, ((toTable==String.Empty)?fromTable:toTable) );
                try
                {
                    sourceConnection.Connect();
                    destConnection.Connect();
                    lblErrorMessage.Text = "Connected. Starting to copy data.";
                }
                catch (Exception exception)
                {
                    lblErrorMessage.Text = "Connecting failed. " + exception.Message;
                }
                //get the source table, msg1 will be "" if successful
                msg1 = sourceConnection.GetTable();
                if (msg1.Length == 0)
                {
                    //start the insert, msg2 will be "" if successful
                    msg2 = destConnection.InsertData(sourceConnection.dataTable);
                }
                lblErrorMessage.Text = msg1 + msg2;
            }
        }



        /// <summary>
        /// Builds the connection string.
        /// </summary>
        /// <returns></returns>
        private String BuildConnectionString()
        {
            String strConnString = "";
            object _con = null;
            MSDASC.DataLinks _link = new MSDASC.DataLinks();
            _con = _link.PromptNew();
            if (_con == null) return string.Empty;
            strConnString = ((ADODB.Connection)_con).ConnectionString;
            return strConnString;
        }

        /// <summary>
        /// Handles the Click event of the btnFromDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnFromDatabase_Click(object sender, EventArgs e)
        {
            fromConnectionString = BuildConnectionString();
        }

        /// <summary>
        /// Handles the Click event of the btnToDatabase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnToDatabase_Click(object sender, EventArgs e)
        {
            toConnectionString = BuildConnectionString();
        }
    }
}
