using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QueryAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void btnGo_Click(object sender, EventArgs e)
      {
          lblError.Text = "";
            //open connection to database

            System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();
            conn.ConnectionString = txtConnString.Text;
            conn.Open();
            // MessageBox.Show(conn.State.ToString());
            //create my command
            System.Data.OleDb.OleDbCommand comm = new System.Data.OleDb.OleDbCommand();
            comm.Connection = conn;
            //send the sql through the command
            comm.CommandText = txtSQL.Text;

            //receive the result into a data container.

            System.Data.OleDb.OleDbDataReader dr;
            try
            {

                if (txtSQL.Text.ToUpper().StartsWith("SELECT"))
                {
                    dr = comm.ExecuteReader();
                    System.Data.DataTable dt = new DataTable();
                    dt.Load(dr);
                    Grid1.AutoGenerateColumns = true;
                    //bind the result to the grid

                    Grid1.DataSource = dt;
                }
                else
                {
                    MessageBox.Show(comm.ExecuteNonQuery().ToString());
                }

            }
            catch (Exception ex)
            {

                lblError.Text = ex.Message;
            }
            finally
            {
                conn.Close();
            
            }

            
       
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtSQL.Text = "";
        }
    }
}
