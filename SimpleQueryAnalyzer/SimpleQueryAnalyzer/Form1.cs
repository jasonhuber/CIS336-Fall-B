using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleQueryAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
          //  MessageBox.Show(conn.State.ToString());
        }

        private DataSet GetMeSomeDataIntoDataSet(string sql)
        {
            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Jason\Dropbox\Devry\CIS336\SimpleQueryAnalyzer\SimpleQueryAnalyzer\northwind.mdb;";
            conn.Open();
            System.Data.OleDb.OleDbCommand comm = new System.Data.OleDb.OleDbCommand();
            comm.Connection = conn;
            comm.CommandText = sql;

            System.Data.DataSet ds = new DataSet();
            System.Data.OleDb.OleDbDataAdapter da = new System.Data.OleDb.OleDbDataAdapter();

            da.SelectCommand = comm;
            da.Fill(ds);

            return ds;
            

        }

        private void btnClickMe_Click(object sender, EventArgs e)
        {
            dgDisplay.DataSource = GetMeSomeDataIntoDataSet(txtSQL.Text).Tables[0];
        }
    }
}
