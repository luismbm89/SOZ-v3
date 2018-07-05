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
    public partial class Compra : Form
    {
        private static DataTable dtVenta = new DataTable();
        public Compra()
        {
            InitializeComponent();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
            dtpVencimiento.Value = DateTime.Now;
            dtVenta = new DataTable();
            dtVenta.Columns.Add("NoSeq", typeof(int));
            dtVenta.Columns.Add("Descripcion", typeof(String));
            dtVenta.Columns.Add("Cantidad", typeof(decimal));
            dtVenta.Columns.Add("Precio", typeof(decimal));
            dtVenta.Columns.Add("Total", typeof(decimal));
            tabControl1.SelectedIndex = 1;
            lblTotalProv.Text =string.Format("Total de Registros: {0}",ConexionSQL.ConsultaUnica("Select count(*) from Proveedor"));
            txtCodigoPro.Text = "1";
            Proveedor();
        }
        private void Proveedor() {
            DataTable proveedor = ConexionSQL.consultaDataTable("Select Cod,Nombre,Contacto,Telefono,Celular,Direccion,Correo,Comentarios,Estado,ROW_NUMBER()over(order by Nombre)NoSeq from Proveedor", "Proveedor");
            DataRow[] dr= proveedor.Select(string.Format("NoSeq = '{0}'",txtCodigoPro.Text));
            txtCodigoPro.Text = dr[0]["NoSeq"].ToString();
            txtCodigoPro.Tag = dr[0]["Cod"].ToString();
            txtComentarioProv.Text = dr[0]["Comentarios"].ToString();
            txtContactoProv.Text = dr[0]["Contacto"].ToString();
            txtDireccionProv.Text = dr[0]["Direccion"].ToString();
            txtEmailProv.Text = dr[0]["Correo"].ToString();
            txtNombreProv.Text = dr[0]["Nombre"].ToString();
            txtTelefonoProv.Text = dr[0]["Telefono"].ToString();
            txtCelProv.Text = dr[0]["Celular"].ToString();
            if (Convert.ToBoolean(dr[0]["Estado"].ToString()))
            {
                rdbHabPro.Checked = true;
            }
            else
            {
                rdbDeshProv.Checked = true;
            }
            cboProveedor.DataSource=ConexionSQL.consultaDataTable("Select Cod,Nombre from Proveedor where Estado=1","Proveedor");
            cboProveedor.DisplayMember = "Nombre";
            cboProveedor.ValueMember = "Cod";
            cboProveedor.Show();
        }

        private void btnFirstProv_Click(object sender, EventArgs e)
        {
            txtCodigoPro.Text = "1";
            Proveedor();
        }

        private void btnAtrasProv_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(txtCodigoPro.Text);
            if (i > 1)
            {
                i--;
            }
            txtCodigoPro.Text = string.Format("{0}", i);
            Proveedor();
        }

        private void btnNextProv_Click(object sender, EventArgs e)
        {

            int i = Convert.ToInt32(txtCodigoPro.Text);
            int total = Convert.ToInt32(ConexionSQL.ConsultaUnica("Select Count(*) from Proveedor"));
            if (i < total)
            {
                i++;
            }
            txtCodigoPro.Text = string.Format("{0}", i);
            Proveedor();
        }

        private void btnLastProv_Click(object sender, EventArgs e)
        {

            int total = Convert.ToInt32(ConexionSQL.ConsultaUnica("Select Count(*) from Proveedor"));
            txtCodigoPro.Text = string.Format("{0}", total);
            Proveedor();
        }

        private void btnNuevoProv_Click(object sender, EventArgs e)
        {
            txtCodigoPro.Text ="";
            txtComentarioProv.Text = "";
            txtContactoProv.Text = "";
            txtDireccionProv.Text = "";
            txtEmailProv.Text = "";
            txtNombreProv.Text = "";
            txtTelefonoProv.Text = "";
            txtCelProv.Text = "";
            txtNombreProv.Focus();
        }

        private void btnGuardarProv_Click(object sender, EventArgs e)
        {
            int flag = Convert.ToInt32(ConexionSQL.ConsultaUnica(string.Format("Select count(*) from Proveedor where Cod='{0}'",txtCodigoPro.Text)));
            string osql = "";
            string mensaje = "",Titulo="";
            if (flag == 0)
            {
                osql = string.Format("insert into Proveedor values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',1)", txtNombreProv.Text, txtContactoProv.Text, txtTelefonoProv.Text, txtCelProv.Text, txtDireccionProv.Text, txtEmailProv.Text, txtComentarioProv.Text);
                mensaje = "Registro insertado correctamente";
                Titulo = "Inserción";
                tabControl1.SelectedIndex = 1;
                lblTotalProv.Text = string.Format("Total de Registros: {0}", ConexionSQL.ConsultaUnica("Select count(*) from Proveedor"));
                txtCodigoPro.Text = "1";
                Proveedor();
            }
            else
            {
                int est = 0;
                if (rdbHabPro.Checked)
                {
                    est = 1;
                }
                osql = string.Format("Update Proveedor set Nombre='{0}',Contacto='{1}',Telefono='{2}',Celular='{3}',Direccion='{4}',Correo='{5}',Comentarios='{6}',Estado='{8}' where Cod={7}", txtNombreProv.Text, txtContactoProv.Text, txtTelefonoProv.Text, txtCelProv.Text, txtDireccionProv.Text, txtEmailProv.Text, txtComentarioProv.Text, txtCodigoPro.Tag, est);
                mensaje = "Registro actualizado correctamente";
                Titulo = "Actualización";
            }
            int i = ConexionSQL.DML(osql);
            if (i > 0) {
                tabControl1.SelectedIndex = 1;
            }
                MessageBox.Show(mensaje,Titulo,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                lblTotalProv.Text = string.Format("Total de Registros: {0}", ConexionSQL.ConsultaUnica("Select count(*) from Proveedor"));
                txtCodigoPro.Text = "1";
                Proveedor();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNumFact.Focus();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string BarCode = txtBarCode.Text;
                string flag = ConexionSQL.ConsultaUnica(string.Format("Select count(*) from Producto where BarCode='{0}'", BarCode));
                if (flag.Equals("1"))
                {
                    //Buscar Producto
                    Producto producto = new Producto();
                    Producto p1 = producto.GetList().Find(x => x.BarCode1 == BarCode);

                    // Get all DataRows where the name is the name you want.
                    IEnumerable<DataRow> rows = dtVenta.Rows.Cast<DataRow>().Where(r => r["Descripcion"].ToString() == p1.Descripcion1);
                    // Loop through the rows and change the name.
                    if (rows.Count() == 0)
                    {
                        dtVenta.Rows.Add(p1.NoSeq1, p1.Descripcion1, "0.0", "0.0", "0.0");
                    }
                    dataGridView1.DataSource = dtVenta;
                    dataGridView1.Show();
                    int n = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
                    for (int i = 0; i < n; i++)
                    {
                        dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                        dataGridView1.Rows[i].Cells[4].ReadOnly = true;
                    }
                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                        txtSubTotal.Text= String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
                    txtTotal.Text = string.Format("{0:c}", Convert.ToDecimal(txtSubTotal.Text) - Convert.ToDecimal(txtDesc.Text) + Convert.ToDecimal(txtIVA.Text));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Escaneo Fallido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal Precio = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value);
            decimal Cantidad = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value);
            dataGridView1.Rows[e.RowIndex].Cells["Total"].Value = (Precio * Cantidad);
            txtSubTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
            txtTotal.Text= string.Format("{0:c}", Convert.ToDecimal(txtSubTotal.Text) - Convert.ToDecimal(txtDesc.Text) + Convert.ToDecimal(txtIVA.Text));
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            txtTotal.Text = string.Format("{0:c}", Convert.ToDecimal(txtSubTotal.Text) - Convert.ToDecimal(txtDesc.Text) + Convert.ToDecimal(txtIVA.Text));
        }

        private void txtIVA_TextChanged(object sender, EventArgs e)
        {

            txtTotal.Text = string.Format("{0:c}", Convert.ToDecimal(txtSubTotal.Text) - Convert.ToDecimal(txtDesc.Text) + Convert.ToDecimal(txtIVA.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string NoSeq = ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0)+1 from Compra");
                string osql = string.Format("set dateformat dmy;insert into Compra values ({0},'{1}','{2}','{3}','{4}','{5}','{6}',{7});", NoSeq, dtpFecha.Value.ToString("dd/MM/yyyy"), dtpVencimiento.Value.ToString("dd/MM/yyyy"), txtNumFact.Text, txtSubTotal.Text, txtDesc.Text, txtIVA.Text, cboProveedor.SelectedValue);
                int i = ConexionSQL.DML(osql);
                int qty = dataGridView1.Rows.Count;
                int contador = 0;
                if (i > 0)
                {
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        string j = ConexionSQL.ConsultaUnica(string.Format("Select isnull(max(NoSeq),0)+1 from DetalleCompra where Compra={0}", NoSeq));
                        osql = string.Format("insert into DetalleCompra values ({0},{1},{2},{3},{4});", j,NoSeq, dr.Cells["NoSeq"].Value, dr.Cells["Cantidad"].Value, dr.Cells["Precio"].Value);
                        i = ConexionSQL.DML(osql);
                        if (i > 0)
                        {
                            contador++;
                        }
                    }
                    if (contador == qty)
                    {
                        MessageBox.Show("Compra procesada satisfactoriamente", "Registro de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
