using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        Xml x = new Xml();
        SqlConnection cn;
        String connecion;
        public Form1(Xml x)
        {
            this.x = x;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(x.connectionstring.ToString());
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("//appSettings/app");

            foreach (XmlNode node in nodes)
            {
                connecion=node.Attributes["value"].Value;
            }

            cn = new SqlConnection(connecion);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_executiontime", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds, "CUSTOMER");
            dataGridView1.DataSource = ds.Tables[0];
            DataGridViewColumn column = dataGridView1.Columns[6];
            column.Width = 1000;

        }

        private void btnRunnigQuery_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
