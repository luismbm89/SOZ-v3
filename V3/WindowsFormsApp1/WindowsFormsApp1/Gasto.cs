using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Gasto : Form
    {
        public Gasto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

        }
        protected void CargarGastos()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cod", DataPropertyName = "Cod" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Hora", DataPropertyName = "Hora" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Total", DataPropertyName = "Total" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", DataPropertyName = "Descripcion" });
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Estado", DataPropertyName = "Estado" });
            dataGridView1.DataSource = ConexionSQL.consultaDataTable(string.Format("Select Cod,Convert(varchar(5),Fecha,108)[Hora],Total,Descripcion,Estado from Gasto where Convert(varchar,Fecha,103)='{0}'", dateTimePicker1.Value.ToString("dd/MM/yyyy")), "Gasto");
            var provider = new System.Globalization.CultureInfo("es-CR");

            dataGridView1.Columns["Total"].DefaultCellStyle.FormatProvider = provider;
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Show();
            textBox3.Text = string.Format("{0:c}", ConexionSQL.ConsultaUnica(string.Format("Select isnull(sum(Total),0)[Total] from Gasto where Convert(varchar,Fecha,103)='{0}' and Estado=1", dateTimePicker1.Value.ToString("dd/MM/yyyy"))));

            decimal paga = Convert.ToDecimal(textBox3.Text);
            string formateado = string.Format("{0:C}", paga);
            textBox3.Text = formateado;

        }
        private void Gasto_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
            CargarGastos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NoSeq = ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0)+1 from Gasto");
            if (ConexionSQL.DML(String.Format("insert into Gasto values ({0},default,'{1}','{2}','{3}','{4}',1,default)",NoSeq,textBox4.Text, textBox1.Text, textBox2.Text,textBox5.Text)) > 0)
            {
                CargarGastos();
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4) {
                Boolean flag = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[4].Value);
                if (flag)
                {
                    ConexionSQL.DML(string.Format("Update Gasto set Estado=0 where Cod='{0}'", dataGridView1.Rows[e.RowIndex].Cells[0].Value));
                }
                else
                {
                    ConexionSQL.DML(string.Format("Update Gasto set Estado=1 where Cod='{0}'", dataGridView1.Rows[e.RowIndex].Cells[0].Value));
                }
                CargarGastos();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CargarGastos();
        }
    }
}
