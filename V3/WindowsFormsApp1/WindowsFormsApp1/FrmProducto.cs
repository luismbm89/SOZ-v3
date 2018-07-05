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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarMarcas();
            CargarCategoria();
            toolStripTextBox1.Focus();
            Limpiar();
        }
        private void CargarInventario(int NoSeq)
        {
            Producto producto = new Producto();
            Producto p1 =
                producto.GetInventory().Find(x => x.NoSeq1 == NoSeq);
            txtEntradas.Text = p1.Entradas.ToString();
            txtSalidas.Text = p1.Salidas.ToString();
            txtSaldo.Text = p1.Saldo.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(ConexionSQL.ConsultaUnica(string.Format("Select Count(*) from Marca where Descripcion='{0}'", textBox1.Text)));
                if (flag == 1)
                {
                    int i = ConexionSQL.DML(string.Format("Update Marca set Estado=1 where Descripcion='{0}'", textBox1.Text));
                    if (i > 0)
                    {
                        CargarMarcas();
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                    {
                        textBox1.Focus();
                    }
                }
                else if (flag == 0)
                {
                    int i = ConexionSQL.DML(string.Format("Insert into Marca values ('{0}',1)", textBox1.Text));
                    if (i > 0)
                    {
                        CargarMarcas();
                        textBox1.Text = "";
                        textBox1.Focus();
                    }
                    else
                    {
                        textBox1.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarMarcas()
        {
            comboBox1.DataSource = ConexionSQL.consultaDataTable("Select * from Marca where Estado=1", "Marca");
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Cod";
            comboBox1.Show();
        }
        private void CargarCategoria()
        {
            comboBox2.DataSource = ConexionSQL.consultaDataTable("Select * from Categoria where Estado=1", "Categoria");
            comboBox2.DisplayMember = "Descripcion";
            comboBox2.ValueMember = "Cod";
            comboBox2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ConexionSQL.DML(string.Format("Update Marca set Estado=0 where Cod='{0}'", comboBox1.SelectedValue));
            if (i > 0)
            {
                CargarMarcas();
                textBox1.Text = "";
                textBox1.Focus();
                    comboBox1.Text = "";
                }
            else
            {
                textBox1.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int flag = Convert.ToInt32(ConexionSQL.ConsultaUnica(string.Format("Select Count(*) from Categoria where Descripcion='{0}'", textBox2.Text)));
                if (flag == 1)
                {
                    int i = ConexionSQL.DML(string.Format("Update Categoria set Estado=1 where Descripcion='{0}'", textBox2.Text));
                    if (i > 0)
                    {
                        CargarCategoria();
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                    else
                    {
                        textBox2.Focus();
                    }
                }
                else if (flag == 0)
                {
                    int i = ConexionSQL.DML(string.Format("Insert into Categoria values ('{0}',1)", textBox2.Text));
                    if (i > 0)
                    {
                        CargarCategoria();
                        textBox2.Text = "";
                        textBox2.Focus();
                    }
                    else
                    {
                        textBox2.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i = ConexionSQL.DML(string.Format("Update Categoria set Estado=0 where Cod='{0}'", comboBox2.SelectedValue));
                if (i > 0)
                {
                    CargarCategoria();
                    textBox2.Text = "";
                    textBox2.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
                comboBox2.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                
                    int flag = Convert.ToInt32(ConexionSQL.ConsultaUnica(string.Format("Select Count(*) from Producto where NoSeq='{0}'", txtNoSeq.Text)));
                    int IVA = 0;
                    int habilitado = 0;
                    if (rdbConIVA.Checked)
                    {
                        IVA = 1;
                    }
                    if (rdbHabilitado.Checked)
                    {
                        habilitado = 1;
                    }
                    if (flag > 0)
                    {

                        int u = ConexionSQL.DML(string.Format("Update Producto set BarCode='{0}',Code='{1}',Descripcion='{2}',Categoria='{3}',Marca='{4}',IVA='{5}',Costo='{6}',PrecioVenta='{7}',Estado={9} where NoSeq='{8}'", txtBarCode.Text, txtCode.Text, txtDescripcion.Text, comboBox2.SelectedValue, comboBox1.SelectedValue, IVA, txtCosto.Text, txtPrecio.Text, txtNoSeq.Text, habilitado));
                        if (u > 0)
                        {
                            MessageBox.Show("Actualización efectuada correctamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                    else
                    {
                    if (ConexionSQL.ConsultaUnica(String.Format("Select count(*) from Producto where BarCode='{0}'", txtBarCode.Text)).Equals("0"))
                {
                        int i = ConexionSQL.DML(string.Format("insert into Producto values ({0},'{1}','{2}','{3}',{4},{5},{6},'{7}','{8}',1)", txtNoSeq.Text, txtBarCode.Text, txtCode.Text, txtDescripcion.Text, comboBox1.SelectedValue, comboBox2.SelectedValue, IVA, txtCosto.Text, txtPrecio.Text));
                        if (i > 0)
                        {
                            MessageBox.Show("Registro efectuado correctamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                    }
                else
                {

                    MessageBox.Show("El Codigo de Barras ya existe", "Codigo de barras duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCode.Focus();
                }
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        private void Limpiar()
        {
            txtNoSeq.Text = ConexionSQL.ConsultaUnica("Select isnull(max(NoSeq),0)+1 from Producto");
            txtBarCode.Focus();
            txtCode.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "";
            rdbConIVA.Checked = false;
            rdbSinIVA.Checked = false;
            rdbHabilitado.Checked = false;
            rdbDeshabilitado.Checked = false;
            txtBarCode.Text = "";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DataTable dt = ConexionSQL.consultaDataTable(string.Format("Select * from Producto where BarCode='{0}'", toolStripTextBox1.Text), "Producto");
            if (dt.Rows.Count > 1)
            {
                MessageBox.Show("Existen muchos artículos para el código digitado", "Artículos con mismo código", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            if (dt.Rows.Count == 1)
            {
                txtBarCode.Text = dt.Rows[0]["BarCode"].ToString();
                txtCode.Text = dt.Rows[0]["Code"].ToString();
                txtCosto.Text = dt.Rows[0]["Costo"].ToString();
                txtDescripcion.Text = dt.Rows[0]["Descripcion"].ToString();
                txtNoSeq.Text = dt.Rows[0]["NoSeq"].ToString();
                txtPrecio.Text = dt.Rows[0]["PrecioVenta"].ToString();
                if (Convert.ToBoolean(dt.Rows[0]["IVA"].ToString()))
                {
                    rdbConIVA.Checked = true;
                }
                else
                {

                    rdbSinIVA.Checked = true;
                }
                if (Convert.ToBoolean(dt.Rows[0]["Estado"].ToString()))
                {
                    rdbHabilitado.Checked = true;
                }
                else
                {

                    rdbDeshabilitado.Checked = true;
                }
                comboBox1.SelectedValue = dt.Rows[0]["Marca"].ToString();
                comboBox2.SelectedValue = dt.Rows[0]["Categoria"].ToString();
                CargarInventario(Convert.ToInt32(txtNoSeq.Text));
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try{ 
            int flag = Convert.ToInt32(ConexionSQL.ConsultaUnica(string.Format("Select Count(*) from Producto where NoSeq='{0}'", txtNoSeq.Text)));
                if (flag > 0)
                {
                    int habilitado = 0;
                    if (rdbHabilitado.Checked)
                    {
                        habilitado = 1;
                    }
                    int u = ConexionSQL.DML(string.Format("Update Producto set Estado={1} where NoSeq='{0}'", txtNoSeq.Text, habilitado));
                    if (u > 0)
                    {
                        MessageBox.Show("Actualizaciön efectuada correctamente", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
