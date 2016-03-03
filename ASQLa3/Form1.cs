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

        public String fromTable;
        public String fromConnectionString;

        public String toTable;
        public String toConnectionString;

        public DBConnection sourceConnection;
        public DBConnection destConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnTransferClick(object sender, EventArgs e)
        {
            fromTable = txtFromTable.Text;
            toTable = txtToTable.Text;

            String errorStr = String.Empty;
            String msg1 = String.Empty;
            String msg2 = String.Empty;
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
                msg1 = sourceConnection.GetTable();
                if (msg1.Length == 0)
                {
                    msg2 = destConnection.InsertData(sourceConnection.dataTable);
                }
                lblErrorMessage.Text = msg1 + msg2;
            }
        }




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

        private void btnFromDatabase_Click(object sender, EventArgs e)
        {
            fromConnectionString = BuildConnectionString();
        }

        private void btnToDatabase_Click(object sender, EventArgs e)
        {
            toConnectionString = BuildConnectionString();
        }
    }
}
