using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOZ
{
    public partial class Default : System.Web.UI.Page
    {
        private static DataTable Venta=new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Venta = new DataTable();
                Venta.Columns.Add("Descripcion", typeof(string));
                Venta.Columns.Add("Precio", typeof(decimal));
                Venta.Columns.Add("Cantidad", typeof(int));
                Venta.Columns.Add("Total", typeof(decimal));
            }
        }

        protected void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string BarCode = txtBarCode.Text;
                if (!string.IsNullOrEmpty(BarCode) && BarCode.Length == 12)
                {
                    //Buscar Producto
                    Producto producto = new Producto();
                    Producto p1 = producto.GetList().Find(x => x.BarCode1 == BarCode);
                    // Get all DataRows where the name is the name you want.
                    IEnumerable<DataRow> rows = Venta.Rows.Cast<DataRow>().Where(r => r["Descripcion"].ToString() == p1.Descripcion1);
                    // Loop through the rows and change the name.
                    if (rows.Count() > 0)
                    {
                        rows.ToList().ForEach(r => r.SetField("Cantidad", (r.Field<Int32>("Cantidad")) + 1));
                        rows.ToList().ForEach(r => r.SetField("Total", (r.Field<Int32>("Cantidad")) * (r.Field<decimal>("Precio"))));
                    }
                    else {
                       Venta.Rows.Add(p1.Descripcion1, p1.PrecioVenta1.ToString("0.##"), 1, p1.PrecioVenta1.ToString("0.##"));
                    }
                    grvVenta.DataSource = Venta;
                    grvVenta.DataBind();
                    txtBarCode.Text = "";
                    txtBarCode.Focus();
                    txtMonto.Text = string.Format("{0}", Convert.ToDecimal(Venta.Compute("SUM(Total)", string.Empty)).ToString("0.##"));
                }
            }
            catch (Exception ex) {
                txtBarCode.Text = "";
            }
        }
    }
}