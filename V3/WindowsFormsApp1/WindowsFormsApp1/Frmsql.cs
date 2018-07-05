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
    public partial class Frmsql : Form
    {
        public Frmsql()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ConexionSQL.DML(textBox1.Text);
                textBox1.Text += string.Format(" Registros afectados ({0})", i);
            }
            catch (Exception ex) {

                textBox1.Text = string.Format("{0}", ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = ConexionSQL.consultaDataTable(textBox1.Text,"Consulta");
            dataGridView1.Show();
        }
            catch (Exception ex) {

                textBox1.Text = string.Format("{0}", ex.Message);
    }
}
    }
}
