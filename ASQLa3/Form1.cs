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
        public String fromUsername;
        public String fromPassword;
        public String fromDatabase;
        public String fromTable;
        public String fromConnectionString;

        public String toUsername;
        public String toPassword;
        public String toDatabase;
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

            if (fromConnectionString == null || toConnectionString == null)
            {
                //NEED to set both dbs
                errorStr += "Need to set both connection strings before starting the transfer.";
            }
            if (fromTable == "")
            {
                errorStr += "\nNeed to specify the starting table to copy from.";
            }
            if (errorStr != String.Empty)
            {
                MessageBox.Show(errorStr);
            }
            else
            {
                //connect here
                sourceConnection = new DBConnection(fromConnectionString, fromTable);
                destConnection = new DBConnection(toConnectionString, ((toTable==String.Empty)?fromTable:toTable) );
                sourceConnection.Connect();

                sourceConnection.GetTable();

                destConnection.InsertData();

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
