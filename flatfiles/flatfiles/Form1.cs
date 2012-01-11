using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace flatfiles
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //var jason = new Array(){"jason,huber,d99006529,jasonhuber@gmail.com"}
            string students = "jason,huber,d99006529,jasonhuber@gmail.com";

            string[] arrStudent = students.Split(new char[]{','});
            for (int i = 0; i < arrStudent.Length; i++)
            {
                MessageBox.Show(arrStudent[i]);
            }

        }
    }
}
