using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Giris : Form
    {
        Xml x = new Xml();
        public Giris()
        {
            InitializeComponent();
        }

        private void btnXml_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Xml File |*.xml";
            if(fd.ShowDialog()==DialogResult.OK)
            {
                x.connectionstring = fd.FileName;
                Form1 f1 = new Form1(x);
                this.Opacity = 0;
                f1.Show();
            }

        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
