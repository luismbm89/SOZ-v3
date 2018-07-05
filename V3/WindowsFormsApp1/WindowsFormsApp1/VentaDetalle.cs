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
    public partial class VentaDetalle : Form
    {
        public VentaDetalle()
        {
            InitializeComponent();
        }

        private void VentaDetalle_Load(object sender, EventArgs e)
        {
            txtNumero.Text = ConexionSQL.ConsultaUnica("Select isnull(min(Cod),0) from Venta");
            CargarVenta(txtNumero.Text);
            toolStripLabel1.Text = string.Format(" de {0}", ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0) from Venta"));

        }
        private void CargarVenta(string noVenta)
        {
            dataGridView1.DataSource = ConexionSQL.consultaDataTable(string.Format("Select NoSeq,Code,Descripcion,Cantidad,Precio,SubTotal,IVA,Descuento,Total from VwDetalle where Venta={0}", noVenta), "VwDetalle");
            dataGridView1.Show();
            DataTable dt = ConexionSQL.consultaDataTable(string.Format("Select Fecha,Cliente,SubTotal,Descuento,IVA,Total,TipoPago,Referencia from Venta where Cod='{0}'",noVenta), "Venta");
            txtCliente.Text = dt.Rows[0]["Cliente"].ToString();
            txtDescuento.Text = string.Format("{0:c}",Convert.ToDecimal(dt.Rows[0]["Descuento"].ToString()));
            txtFormadePago.Text = dt.Rows[0]["TipoPago"].ToString();
            txtIV.Text = string.Format("{0:c}", Convert.ToDecimal(dt.Rows[0]["IVA"].ToString()));
            txtTotal.Text = string.Format("{0:c}", Convert.ToDecimal(dt.Rows[0]["Total"].ToString()));
            txtSubTotal.Text = string.Format("{0:c}", Convert.ToDecimal(dt.Rows[0]["SubTotal"].ToString()));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            txtNumero.Text = ConexionSQL.ConsultaUnica("Select isnull(min(Cod),0) from Venta");
            CargarVenta(txtNumero.Text);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            txtNumero.Text = ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0) from Venta");
            CargarVenta(txtNumero.Text);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        { int NoVenta = Convert.ToInt32(txtNumero.Text);
            if (NoVenta > 1) {
                NoVenta--;
                txtNumero.Text = NoVenta.ToString();
                CargarVenta(txtNumero.Text);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            int NoVenta = Convert.ToInt32(txtNumero.Text);
            int max= Convert.ToInt32(ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0) from Venta"));
            if (NoVenta < max)
            {
                NoVenta++;
                txtNumero.Text = NoVenta.ToString();
                CargarVenta(txtNumero.Text);
            }
        }
    }
}
