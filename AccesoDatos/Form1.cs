using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AccesoDatos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLServer sqlserver = new SQLServer();
            sqlserver.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySQL mySQL = new MySQL();
            mySQL.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
