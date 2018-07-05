using LibPrintTicket;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Caja : Form
    {
        public Caja()
        {
            InitializeComponent();
        }

        private void txt50000_TextChanged(object sender, EventArgs e)
        {
            txtCierre.Text=string.Format("{0:c}",Cierre());
        }
        public Decimal Cierre() {
            Decimal monto = 0.00m;
            foreach (Control ctrl in this.Controls) {
                if (ctrl is TextBox) {
                    int denom;
                    bool isNum = int.TryParse(ctrl.Name.Replace("txt",""), out denom);
                    if (isNum&&ctrl.Text.Length>0)
                    {
                        decimal denominacion = Convert.ToDecimal(ctrl.Tag);
                        decimal qty = Convert.ToDecimal(ctrl.Text);
                        monto += (denominacion * qty);
                    }
                        }

            }
            return monto;

        }

        private void Caja_Load(object sender, EventArgs e)
        {
            try
            {
                txtCierre.Text = String.Format("{0:c}", 0.0m);
                Decimal apertura = 0.0m;
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                DataTable dt = ConexionSQL.consultaDataTable(String.Format("Select isnull(MontoApertura,0)[MontoApertura],NoSeq from Caja where Convert(varchar,FechaApertura,103)='{0}' and FechaApertura=FechaCierre and Estado=0", DateTime.Now.ToString("dd/MM/yyyy")), "Caja");
                if (dt.Rows.Count > 0) {
                  apertura = Convert.ToDecimal(dt.Rows[0][0].ToString());
                    this.Text = "Caja N° " + dt.Rows[0][1].ToString();
                    this.txtApertura.Tag = dt.Rows[0][1].ToString();
                }
                txtApertura.Text = String.Format("{0:c}",apertura);
                if (apertura>0)
                {
                    txt50000.Focus();
                    txtApertura.Enabled = false;
                    btnApertura.Visible = false;
                }
                else
                {
                    txtApertura.Focus();
                }
                CargarMontos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al cargar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarMontos() {
            StringBuilder str = new StringBuilder();
            str.Append("Select *,[Venta]-[Gasto] [Total] from (");
            str.Append(" Select sum(Gasto)[Gasto],sum(Venta)[Venta] from (");
            str.Append(string.Format(" Select isnull(sum(Total),0)[Venta],0[Gasto] from Venta where convert(varchar,Fecha,103)='{0}' and Estado=0", txtFecha.Text));
            str.Append(" union all");
            str.Append(string.Format(" Select 0,isnull(sum(Total),0)[Gasto] from Gasto where convert(varchar,Fecha,103)='{0}' and Estado=1 and Flag=0", txtFecha.Text));
            str.Append(" )a");
            str.Append(" )b");
            DataTable dt=ConexionSQL.consultaDataTable(str.ToString(), "DetalleCaja");
            if (dt.Rows.Count > 0)
            {
                txtGastos.Text = String.Format("{0:c}", Convert.ToDecimal(dt.Rows[0][0].ToString()));
                txtVentas.Text = String.Format("{0:c}", Convert.ToDecimal(dt.Rows[0][1].ToString()));
                txtTotal.Text = String.Format("{0:c}", Convert.ToDecimal(dt.Rows[0][2].ToString()));
                dt = ConexionSQL.consultaDataTable(string.Format("Select isnull(sum(Total),0)[Venta] from Venta where convert(varchar,Fecha,103)='{0}' and Estado=0 and TipoPago='Efectivo'", txtFecha.Text), "Efectivo");
                txtEfectivo.Text = String.Format("{0:c}", Convert.ToDecimal(dt.Rows[0][0].ToString()));
                dt = ConexionSQL.consultaDataTable(string.Format("Select isnull(sum(Total),0)[Venta] from Venta where convert(varchar,Fecha,103)='{0}' and Estado=0 and TipoPago='Tarjeta'", txtFecha.Text), "Tarjeta");
                txtTarjeta.Text = String.Format("{0:c}", Convert.ToDecimal(dt.Rows[0][0].ToString()));
            }
            else
            {
                txtGastos.Text = String.Format("{0:c}", 0.0m);
                txtVentas.Text = String.Format("{0:c}", 0.0m);
                txtTotal.Text = String.Format("{0:c}", 0.0m);
                txtTarjeta.Text = String.Format("{0:c}", 0.0m);
                txtEfectivo.Text = String.Format("{0:c}", 0.0m);
            }
        }
        private void btnApertura_Click(object sender, EventArgs e)
        {
            try
            {
                string NoCa = ConexionSQL.ConsultaUnica("Select isnull(max(NoSeq),0)+1 NoSeq from Caja");
                int i = ConexionSQL.DML(string.Format("insert into Caja values({1},default,default,default,'{0}',default,0)", txtApertura.Text,NoCa));
                if (i > 0)
                {
                    MessageBox.Show("Apertura realizada con éxito", "Apertura de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    decimal Apertura = decimal.Parse(txtApertura.Text,
    NumberStyles.AllowCurrencySymbol |
    NumberStyles.AllowThousands |
    NumberStyles.AllowDecimalPoint);
                    txtApertura.Text = String.Format("{0:c}", Apertura);
                    txtApertura.Enabled = false;
                    btnApertura.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Apertura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        



        private void btnCancelar_Click(object sender, EventArgs e)
        {
            /*  try
              {
                  if (txtApertura.Text.Length > 0)
              {
                  decimal Apertura = decimal.Parse(txtApertura.Text,
      NumberStyles.AllowCurrencySymbol |
      NumberStyles.AllowThousands |
      NumberStyles.AllowDecimalPoint);
                  decimal Cierre = decimal.Parse(txtCierre.Text,
      NumberStyles.AllowCurrencySymbol |
      NumberStyles.AllowThousands |
      NumberStyles.AllowDecimalPoint);
                  decimal Saldo = Cierre - Apertura;
                  if (Saldo > 0)
                  {
                      MessageBox.Show(string.Format("{0:c}", Saldo), "Saldo positivo al cierre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  }
                  if (Saldo == 0)
                  {
                      MessageBox.Show(string.Format("{0:c}", Saldo), "Saldo neutro al cierre", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                  }
                  if (Saldo < 0)
                  {
                      MessageBox.Show(string.Format("{0:c}", Saldo), "Saldo negativo al cierre", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                  }
                  int i = ConexionSQL.DML(String.Format("Update Caja  set FechaCierre=default, MontoCierre='{1}',Estado=1 where Convert(varchar,Fecha,103)='{0}' and NoSeq in (Select max(NoSeq) from Caja where Convert(varchar,Fecha,103)='{0}') and Estado=0", DateTime.Now.ToShortDateString(),txtCierre.Text));
                  if (i > 0)
                  {
                      MessageBox.Show("Cierre efectuado con éxito", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          ImprimirCierre("1");
                  }
              }
          }
              catch (Exception ex)
              {
                  MessageBox.Show(ex.Message, "Error de Apertura", MessageBoxButtons.OK, MessageBoxIcon.Error);
              }*/
            int i = ConexionSQL.DML(String.Format("Update caja set MontoCierre='{0}',FechaCierre=default,Estado=1 where NoSeq='{1}'",Cierre(),txtApertura.Tag));
            if (i > 0)
            {
                int j = ConexionSQL.DML("Update Venta set Estado=1 where Fecha<=getdate()");
                int k = ConexionSQL.DML("Update Gasto set Flag=1 where Fecha<=getdate()");
                MessageBox.Show("Cierre de Caja efectuado correctamente","Cierre de caja",MessageBoxButtons.OK,MessageBoxIcon.Information);
            ImprimirCierre(txtApertura.Tag.ToString());
            }

        }

        private void txtApertura_TextChanged(object sender, EventArgs e)
        {

        }
        protected void ImprimirCierre(string Cierre) {
            try
            {
                StringBuilder str = new StringBuilder();
                str.Append("Select *,[Venta]-[Gasto] [Total] from (");
                str.Append(" Select sum(Gasto)[Gasto],sum(Venta)[Venta] from (");
                str.Append(string.Format(" Select isnull(sum(Total),0)[Venta],0[Gasto] from Venta where convert(varchar,Fecha,103)='{0}' and Estado=0", txtFecha.Text));
                str.Append(" union all");
                str.Append(string.Format(" Select 0,isnull(sum(Total),0)[Gasto] from Gasto where convert(varchar,Fecha,103)='{0}' and Estado=1 and flag=0", txtFecha.Text));
                str.Append(" )a");
                str.Append(" )b");
                DataTable dt = ConexionSQL.consultaDataTable(str.ToString(), "DetalleCaja");
                decimal venta = Convert.ToDecimal(dt.Rows[0][1].ToString());
                decimal gasto = Convert.ToDecimal(dt.Rows[0][0].ToString());
                Ticket ticket = new Ticket();
                ticket.HeaderImage = Properties.Resources.logo;
                ticket.AddHeaderLine(Properties.Settings.Default.Encabezado1);
                ticket.AddHeaderLine(Properties.Settings.Default.Encabezado2);
                ticket.AddHeaderLine(Properties.Settings.Default.Encabezado3);
                ticket.AddHeaderLine(Properties.Settings.Default.Encabezado4);
                ticket.AddHeaderLine(Properties.Settings.Default.Encabezado5);
                ticket.AddSubHeaderLine(String.Format("Cierre # {0}", Cierre));
                ticket.AddTotal("Apertura de Caja", string.Empty);
                ticket.AddTotal(string.Empty, txtApertura.Text);
                ticket.AddTotal(string.Empty, string.Empty);
                ticket.AddTotal("Total Ventas", txtVentas.Text);
                ticket.AddTotal("Total Gastos", txtGastos.Text);
                ticket.AddTotal(string.Empty, string.Empty);
                ticket.AddTotal("Venta Neta", Convert.ToString(string.Format("{0:c}", venta - gasto)));
                ticket.AddTotal(string.Empty, string.Empty);
                ticket.AddItem("Desglose de Caja", string.Empty, string.Empty);
                ticket.AddItem(string.Empty, string.Empty, string.Empty);
                ticket.AddTotal("Efectivo", string.Empty);
                dt = ConexionSQL.consultaDataTable("Select isnull(sum(Total),0)[Total] from Venta where TipoPago='Tarjeta' and Fecha <=getdate()", "Tarjeta");
                decimal Tarjeta = Convert.ToDecimal(dt.Rows[0][0].ToString());
                ticket.AddTotal(string.Empty, txtCierre.Text);
                ticket.AddTotal("Tarjeta", string.Empty);
                ticket.AddTotal(string.Empty, string.Format("{0:c}", Tarjeta));
                ticket.AddTotal("", "");
                ticket.AddItem("Billetes", string.Empty, string.Empty);
                ticket.AddItem(txt50000.Text, label1.Text, string.Format("{0:c}", Convert.ToInt32(txt50000.Text) * 50000));
                ticket.AddItem(txt20000.Text, label2.Text, string.Format("{0:c}", Convert.ToInt32(txt20000.Text) * 20000));
                ticket.AddItem(txt10000.Text, label3.Text, string.Format("{0:c}", Convert.ToInt32(txt10000.Text) * 10000));
                ticket.AddItem(txt5000.Text, label4.Text, string.Format("{0:c}", Convert.ToInt32(txt5000.Text) * 5000));
                ticket.AddItem(txt2000.Text, label5.Text, string.Format("{0:c}", Convert.ToInt32(txt2000.Text) * 2000));
                ticket.AddItem(txt1000.Text, label6.Text, string.Format("{0:c}", Convert.ToInt32(txt1000.Text) * 1000));
                ticket.AddItem(string.Empty, string.Empty, string.Empty);
                ticket.AddItem("Monedas", string.Empty, string.Empty);
                ticket.AddItem(txt500.Text, label12.Text, string.Format("{0:c}", Convert.ToInt32(txt500.Text) * 500));
                ticket.AddItem(txt100.Text, label11.Text, string.Format("{0:c}", Convert.ToInt32(txt100.Text) * 100));
                ticket.AddItem(txt50.Text, label10.Text, string.Format("{0:c}", Convert.ToInt32(txt50.Text) * 50));
                ticket.AddItem(txt25.Text, label9.Text, string.Format("{0:c}", Convert.ToInt32(txt25.Text) * 25));
                ticket.AddItem(txt10.Text, label8.Text, string.Format("{0:c}", Convert.ToInt32(txt10.Text) * 10));
                ticket.AddItem(txt5.Text, label7.Text, string.Format("{0:c}", Convert.ToInt32(txt5.Text) * 5));
                ticket.AddTotal("", "");
                ticket.PrintTicket(Properties.Settings.Default.Impresora); //Nombre de la impresora de tickets
            }
            catch (Exception ex) {
                //
            }
        }
    }
}
