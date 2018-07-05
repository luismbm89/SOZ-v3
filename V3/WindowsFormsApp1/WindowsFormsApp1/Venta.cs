using LibPrintTicket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Venta : Form
    {
        private static decimal qty = 0.0m;
        private DataTable dtVenta = new DataTable();
        public Venta()
        {
            InitializeComponent();
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
           dtVenta = new DataTable();
            dtVenta.Columns.Add("NoSeq", typeof(int));
            dtVenta.Columns.Add("Codigo", typeof(string));
            dtVenta.Columns.Add("Descripcion", typeof(string));
            dtVenta.Columns.Add("Cantidad", typeof(decimal));
            dtVenta.Columns.Add("Precio", typeof(decimal));
            dtVenta.Columns.Add("Descuento", typeof(decimal));
            dtVenta.Columns.Add("IVA", typeof(decimal));
            dtVenta.Columns.Add("Total", typeof(decimal));
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string BarCode = txtCodigo.Text;
                string flag = ConexionSQL.ConsultaUnica(string.Format("Select count(*) from Producto where BarCode='{0}'", BarCode));
                if (flag.Equals("1"))
                {
                    //Buscar Producto
                    Producto producto = new Producto();
                    Producto p1 = producto.GetList().Find(x => x.BarCode1 == BarCode);
                    // Get all DataRows where the name is the name you want.
                    IEnumerable<DataRow> rows = dtVenta.Rows.Cast<DataRow>().Where(r => r["Descripcion"].ToString() == p1.Descripcion1);
                    // Loop through the rows and change the name.
                    if (rows.Count() > 0)
                    {
                        Producto p = new Producto();
                        Producto p2 =
                            p.GetInventory().Find(x => x.NoSeq1 == p1.NoSeq1);
                        DataRow[] dr = dtVenta.Select(string.Format("NoSeq = '{0}'", p1.NoSeq1));
                        decimal Cantidad= Convert.ToDecimal(dr[0]["Cantidad"].ToString());

                        if (Properties.Settings.Default.Inv)
                        {
                            if (Cantidad < p2.Saldo)
                            {
                                rows.ToList().ForEach(r => r.SetField("Cantidad", (r.Field<decimal>("Cantidad")) + 1));
                                rows.ToList().ForEach(r => r.SetField("Descuento", (r.Field<decimal>("Cantidad")) * ((p2.PrecioVenta1 * Convert.ToInt32(textBox1.Text)) / 100)));
                                if (p2.IV1)
                                {
                                    rows.ToList().ForEach(r => r.SetField("IVA", (((r.Field<decimal>("Cantidad") * p2.PrecioVenta1) - r.Field<decimal>("Descuento")) * Properties.Settings.Default.IV) / 100));
                                }
                                else
                                {
                                    rows.ToList().ForEach(r => r.SetField("IVA", 0));
                                }
                                rows.ToList().ForEach(r => r.SetField("Total", (((r.Field<decimal>("Cantidad")) * (r.Field<decimal>("Precio"))) - r.Field<decimal>("Descuento")) + r.Field<decimal>("IVA")));
                            }
                            else
                            {
                                MessageBox.Show("Inventario Insuficiente", "Inventario Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else {
                            rows.ToList().ForEach(r => r.SetField("Cantidad", (r.Field<decimal>("Cantidad")) + 1));
                            rows.ToList().ForEach(r => r.SetField("Descuento", (r.Field<decimal>("Cantidad")) * ((p1.PrecioVenta1 * Convert.ToInt32(textBox1.Text)) / 100)));
                            if (p1.IV1)
                            {
                                rows.ToList().ForEach(r => r.SetField("IVA", (((r.Field<decimal>("Cantidad") * p1.PrecioVenta1) - r.Field<decimal>("Descuento")) * Properties.Settings.Default.IV) / 100));
                            }
                            else
                            {
                                rows.ToList().ForEach(r => r.SetField("IVA", 0));
                            }
                            rows.ToList().ForEach(r => r.SetField("Total", (((r.Field<decimal>("Cantidad")) * (r.Field<decimal>("Precio"))) - r.Field<decimal>("Descuento")) + r.Field<decimal>("IVA")));
                        }
                    }
                    else
                    {
                        Producto p = new Producto();
                        Producto p2 =
                            p.GetInventory().Find(x => x.NoSeq1 == p1.NoSeq1);
                        decimal Cantidad = 1m;
                        if (Properties.Settings.Default.Inv)
                        {
                            if (Cantidad < p2.Saldo)
                            {
                                decimal Desc = (p1.PrecioVenta1 * Convert.ToInt32(textBox1.Text)) / 100;
                                decimal IVA = ((p1.PrecioVenta1 - Desc) * Properties.Settings.Default.IV) / 100;
                                if (!p1.IV1)
                                { IVA = 0.0m; }
                                decimal Total = p1.PrecioVenta1 - Desc + IVA;
                                dtVenta.Rows.Add(p1.NoSeq1, p1.Code1, p1.Descripcion1, 1, p1.PrecioVenta1.ToString("0.##"), Desc, string.Format("{0}", IVA), (Total).ToString("0.##"));
                            }
                            else
                            {
                                MessageBox.Show("Inventario Insuficiente", "Inventario Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            }
                        }
                        else
                        {
                            decimal Desc = (p1.PrecioVenta1 * Convert.ToInt32(textBox1.Text)) / 100;
                            decimal IVA = ((p1.PrecioVenta1 - Desc) * Properties.Settings.Default.IV) / 100;
                            if (!p1.IV1)
                            { IVA = 0.0m; }
                            decimal Total = p1.PrecioVenta1 - Desc + IVA;
                            dtVenta.Rows.Add(p1.NoSeq1, p1.Code1, p1.Descripcion1, 1, p1.PrecioVenta1.ToString("0.##"), Desc, string.Format("{0}", IVA), (Total).ToString("0.##"));
                        }
                    }
                    grvVenta.DataSource = dtVenta;
                    grvVenta.Show();
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    if (dtVenta.Rows.Count > 0)
                    {
                        txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
                        var provider = new System.Globalization.CultureInfo("es-CR");

                        grvVenta.Columns["Precio"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Precio"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["Descuento"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Descuento"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["IVA"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["IVA"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["Total"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Total"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        int n = Convert.ToInt32(grvVenta.Rows.Count.ToString());
                        for (int i = 0; i < n-1; i++)
                        {
                            if (Convert.ToInt32(grvVenta.Rows[i].Cells[0].Value) == 166)
                            {
                                grvVenta.Rows[i].Cells[0].ReadOnly = true;
                                grvVenta.Rows[i].Cells[1].ReadOnly = true;
                                grvVenta.Rows[i].Cells["Descripcion"].ReadOnly = false;
                                grvVenta.Rows[i].Cells["Precio"].ReadOnly = false;
                                grvVenta.Rows[i].Cells["IVA"].ReadOnly = false;
                                grvVenta.Rows[i].Cells["Descuento"].ReadOnly = false;
                                grvVenta.Rows[i].Cells[7].ReadOnly = true;
                            }
                            else {
                                grvVenta.Rows[i].Cells[0].ReadOnly = true;
                                grvVenta.Rows[i].Cells[1].ReadOnly = true;
                                grvVenta.Rows[i].Cells[2].ReadOnly = true;
                                grvVenta.Rows[i].Cells[4].ReadOnly = true;
                                grvVenta.Rows[i].Cells[5].ReadOnly = true;
                                grvVenta.Rows[i].Cells[6].ReadOnly = true;
                                grvVenta.Rows[i].Cells[7].ReadOnly = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = ex.Message;
            }
        }

        private void grvVenta_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                decimal Descuento= Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Descuento"].Value);
                decimal Precio = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Precio"].Value);
                decimal Cantidad = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Cantidad"].Value);
                decimal Total= Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Total"].Value);
                int NoSeq= Convert.ToInt32(grvVenta.Rows[e.RowIndex].Cells["NoSeq"].Value);
                if (NoSeq != 166)
                {
                    Producto producto = new Producto();
                    Producto p1 =
                        producto.GetInventory().Find(x => x.NoSeq1 == NoSeq);
                    int Porc = 0;
                    if (Properties.Settings.Default.Inv)
                    {
                        if (Cantidad < p1.Saldo)
                        {
                            if (Descuento > 0)
                            {
                                Porc = Convert.ToInt32(Total / Descuento);
                            }
                            decimal Desc = ((Precio * Cantidad) * Porc) / 100;
                            decimal Total1 = (Precio * Cantidad);
                            decimal IVA = ((Total1 - Desc) * Properties.Settings.Default.IV) / 100;
                            grvVenta.Rows[e.RowIndex].Cells["Descuento"].Value = Desc;


                            Producto pa = new Producto();
                            Producto pb = pa.GetList().Find(x => x.NoSeq1 == NoSeq);
                            if (pb.IV1)
                            {
                                grvVenta.Rows[e.RowIndex].Cells["IVA"].Value = IVA;
                                grvVenta.Rows[e.RowIndex].Cells["Total"].Value = Total1 - Desc + IVA;
                            }
                            else
                            {

                                grvVenta.Rows[e.RowIndex].Cells["IVA"].Value = 0;
                                grvVenta.Rows[e.RowIndex].Cells["Total"].Value = Total1 - Desc + 0;
                            }
                            txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
                            var provider = new CultureInfo("es-CR");

                            grvVenta.Columns["Precio"].DefaultCellStyle.FormatProvider = provider;
                            grvVenta.Columns["Precio"].DefaultCellStyle.Format = "C2";
                            grvVenta.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grvVenta.Columns["Descuento"].DefaultCellStyle.FormatProvider = provider;
                            grvVenta.Columns["Descuento"].DefaultCellStyle.Format = "C2";
                            grvVenta.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grvVenta.Columns["IVA"].DefaultCellStyle.FormatProvider = provider;
                            grvVenta.Columns["IVA"].DefaultCellStyle.Format = "C2";
                            grvVenta.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                            grvVenta.Columns["Total"].DefaultCellStyle.FormatProvider = provider;
                            grvVenta.Columns["Total"].DefaultCellStyle.Format = "C2";
                            grvVenta.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else
                        {
                            grvVenta.Rows[e.RowIndex].Cells["Cantidad"].Value = qty;
                            MessageBox.Show("Inventario insuficiente", "Inventario Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        if (Descuento > 0)
                        {
                            Porc = Convert.ToInt32(Total / Descuento);
                        }
                        decimal Desc = ((Precio * Cantidad) * Porc) / 100;
                        decimal Total1 = (Precio * Cantidad);
                        decimal IVA = ((Total1 - Desc) * Properties.Settings.Default.IV) / 100;
                        grvVenta.Rows[e.RowIndex].Cells["Descuento"].Value = Desc;

                        Producto pa = new Producto();
                        Producto pb = pa.GetList().Find(x => x.NoSeq1 == NoSeq);
                        if (pb.IV1)
                        {
                            grvVenta.Rows[e.RowIndex].Cells["IVA"].Value = IVA;
                            grvVenta.Rows[e.RowIndex].Cells["Total"].Value = Total1 - Desc + IVA;
                        }
                        else {

                            grvVenta.Rows[e.RowIndex].Cells["IVA"].Value = 0;
                            grvVenta.Rows[e.RowIndex].Cells["Total"].Value = Total1 - Desc + 0;
                        }
                        txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
                        var provider = new CultureInfo("es-CR");

                        grvVenta.Columns["Precio"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Precio"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["Descuento"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Descuento"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["IVA"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["IVA"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        grvVenta.Columns["Total"].DefaultCellStyle.FormatProvider = provider;
                        grvVenta.Columns["Total"].DefaultCellStyle.Format = "C2";
                        grvVenta.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
                else {

                    var provider = new CultureInfo("es-CR");
                    decimal Descuento2 = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Descuento"].Value);
                    decimal IVA2 = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["IVA"].Value);
                    decimal Precio2 = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Precio"].Value);
                    decimal Cantidad2 = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Cantidad"].Value);
                    grvVenta.Columns["Total"].DefaultCellStyle.FormatProvider = provider;
                    grvVenta.Columns["Total"].DefaultCellStyle.Format = "C2";
                    grvVenta.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    grvVenta.Rows[e.RowIndex].Cells["Total"].Value = (Precio2 * Cantidad2)-Descuento2 + IVA2;
                    txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)));
                }
            }
            catch (Exception ex)
            {
//
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal paga = Convert.ToDecimal(txtCancela.Text);
                decimal total = Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty));
                if (paga >= total)
                {
                    string formateado = string.Format("{0:C}", paga);
                    txtCancela.Text = formateado;
                    txtVuelto.Text = string.Format("{0:C}", paga - total);
                }
                else
                {
                    txtVuelto.Text = string.Format("{0:C}", paga - total);
                }
            }
            catch (Exception) {
                //
            }
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea cancelar la venta en curso?", "Cancelar", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                txtCodigo.Focus();
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvVenta.Rows.Count > 0&&txtCancela.Text.Length>0&&(txtCancela.Text.Length)>0)
                {
                    string osql = "";
                    decimal Descuento = Convert.ToDecimal(dtVenta.Compute("SUM(Descuento)", string.Empty));
                    decimal IV = Convert.ToDecimal(dtVenta.Compute("SUM(IVA)", string.Empty));
                    decimal total = Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty));
                    decimal SubTotal = total-IV+Descuento;
                    string cod = ConexionSQL.ConsultaUnica("Select isnull(max(Cod),0)+1 from Venta");
                    bool flag = false;
                    if (radioButton2.Checked && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(txtCliente.Text))
                    {
                        osql = string.Format("insert into Venta(Cod, Cliente, SubTotal,Descuento,IVA,TipoPago, Referencia) values({0}, '{1}', '{2}','{3}','{4}', '{5}', '{6}')", cod, txtCliente.Text, SubTotal,Descuento,IV, radioButton2.Text,textBox2.Text);
                        flag = true;
                    }
                    if (radioButton1.Checked && !string.IsNullOrEmpty(txtCliente.Text))
                    {
                        osql = string.Format("insert into Venta(Cod,Cliente,SubTotal,Descuento,IVA,TipoPago) values ({0}, '{1}', '{2}','{3}','{4}', '{5}')", cod, txtCliente.Text, SubTotal, Descuento, IV, radioButton1.Text);
                        flag = true;
                    }
                    if (flag)
                    {
                        int i = ConexionSQL.DML(osql);
                        if (i > 0)
                        {
                            if (DetalleVenta(cod) == grvVenta.Rows.Count)
                            {
                            MessageBox.Show("Venta realizada con exito", "Venta Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // PrintTicket(cod,false);
                                // PrintTicket(cod,true);
                                Prueba(cod);
                                Limpiar();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error", "Venta Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor valide todos los campos", "Información de Venta Incompleta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No puede realizar una venta sin productos que facturar", "Venta Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            { 
                    MessageBox.Show(ex.Message, "Venta Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void Prueba(String Cod) {
            string NoSeq = ConexionSQL.ConsultaUnica(string.Format("Select NoSeq from (Select Cod,ROW_NUMBER() over(partition by convert(varchar,Fecha,103)order by Cod asc)NoSeq  from Venta)a where Cod='{0}'",Cod));
            decimal Descuento = Convert.ToDecimal(dtVenta.Compute("SUM(Descuento)", string.Empty));
            decimal IV = Convert.ToDecimal(dtVenta.Compute("SUM(IVA)", string.Empty));
            decimal total = Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty));
            decimal SubTotal = total - IV + Descuento;
            Tiquete tkt = new Tiquete();
            tkt.TicketNo = int.Parse(NoSeq);
            tkt.Discount = float.Parse(Descuento.ToString());
            tkt.Iva = float.Parse(IV.ToString());
            tkt.Total = float.Parse(total.ToString());
            tkt.ticketDate = DateTime.Now;
            tkt.Cancela = txtCancela.Text;
            tkt.Vuelto = txtVuelto.Text;
            tkt.Voucher = textBox2.Text;
            if (radioButton1.Checked)
            {
                tkt.TipoPago = radioButton1.Text;
            }
            else {
                tkt.TipoPago = radioButton2.Text;
            }
            tkt.Productos = dtVenta;
            tkt.amount = float.Parse(SubTotal.ToString());
            tkt.Cliente1 = txtCliente.Text;
            tkt.print();
        }

        protected void PrintTicket(string NoVenta,bool copia)
        {
            decimal Descuento = Convert.ToDecimal(dtVenta.Compute("SUM(Descuento)", string.Empty));
            decimal IV = Convert.ToDecimal(dtVenta.Compute("SUM(IVA)", string.Empty));
            decimal total = Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty));
            decimal SubTotal = total - IV + Descuento;
            Ticket ticket = new Ticket();
            ticket.HeaderImage= Properties.Resources.logo;
            ticket.AddHeaderLine(Properties.Settings.Default.Encabezado1);
            ticket.AddHeaderLine(Properties.Settings.Default.Encabezado2);
            ticket.AddHeaderLine(Properties.Settings.Default.Encabezado3);
            ticket.AddHeaderLine(Properties.Settings.Default.Encabezado4);
            ticket.AddHeaderLine(Properties.Settings.Default.Encabezado5);
            if (copia)
            {
                ticket.AddSubHeaderLine(String.Format("Ticket # {0} -- COPIA --", NoVenta));
            }
            else
            {
                ticket.AddSubHeaderLine(String.Format("Ticket # {0}", NoVenta));
            }
            ticket.AddSubHeaderLine(string.Format("Cliente: {0}", txtCliente.Text));
            ticket.AddSubHeaderLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());

            for (int i = 0; i < grvVenta.Rows.Count; i++)
            {
                Decimal Descuento1 = Convert.ToDecimal(grvVenta.Rows[i].Cells["Descuento"].Value.ToString());
                Decimal total1 = Convert.ToDecimal(grvVenta.Rows[i].Cells["Total"].Value.ToString());
                Decimal iva1 = Convert.ToDecimal(grvVenta.Rows[i].Cells["IVA"].Value.ToString());
                Decimal Qty = Convert.ToDecimal(grvVenta.Rows[i].Cells["Cantidad"].Value.ToString());
                decimal Precio = Convert.ToDecimal(grvVenta.Rows[i].Cells["Precio"].Value.ToString());
                string iv = "*";
                if (iva1 == 0) { iv = ""; }
                String Desc = string.Format("{0} {1}",grvVenta.Rows[i].Cells["Descripcion"].Value.ToString(),iv);
                ticket.AddItem(string.Format("{0}", Qty), Desc, string.Format("{0:c}",Precio));
                //ticket.AddItem(string.Empty, "       Desc", string.Format("{0:c}", Descuento1 * -1));
                //ticket.AddItem(string.Empty, "       IVA", string.Format("{0:c}", iva1));
            }

            ticket.FontSize = 8;
            ticket.AddTotal("SUB-TOTAL", string.Format("{0:c}", SubTotal));
            ticket.AddTotal("Descuento", string.Format("{0:c}", Descuento*-1));
            ticket.AddTotal("IVA", string.Format("{0:c}",IV));
            ticket.AddTotal("TOTAL", string.Format("{0:c}",total));
            ticket.AddTotal("", "");
            ticket.AddTotal("RECIBIDO", txtCancela.Text);
            ticket.AddTotal("CAMBIO", txtVuelto.Text);
            ticket.AddTotal("", "");
            if (radioButton1.Checked)
            {
                ticket.AddTotal(("Forma de Pago"), radioButton1.Text);
            }
            else
            {
                ticket.AddTotal(("Forma de Pago"), String.Format("{0}", radioButton2.Text));
                ticket.AddTotal(("Voucher"), String.Format("{0}",textBox2.Text));
            }
            ticket.AddTotal("", "");

            ticket.AddFooterLine(Properties.Settings.Default.Saludo);
            ticket.AddFooterLine("");
            ticket.PrintTicket(Properties.Settings.Default.Impresora); //Nombre de la impresora de tickets

        }
        private Int32 DetalleVenta(string NoVenta)
        {
            Decimal TotalIVA = 0.0m;
            string str = "";
            int cont = 0;
            for (int i = 0; i < grvVenta.Rows.Count; i++)
            {
                decimal IVA;
                if (Convert.ToBoolean(grvVenta.Rows[i].Cells["IVA"].Value)) {
                    IVA = Convert.ToDecimal(grvVenta.Rows[i].Cells["IVA"].Value);
                } else {
                    IVA = 0.0m;
                }
                TotalIVA += IVA;
                string cod = ConexionSQL.ConsultaUnica(string.Format("Select isnull(max(Cod),0)+1 from DetalleVenta where Venta={0}",NoVenta));
                str = string.Format(@"Insert into DetalleVenta(Cod,Venta,Producto,Descripcion,Cantidad,Precio,IVA,Descuento,Fecha,Estado) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',default,1)", cod,NoVenta, grvVenta.Rows[i].Cells["NoSeq"].Value, grvVenta.Rows[i].Cells["Descripcion"].Value, grvVenta.Rows[i].Cells["Cantidad"].Value, grvVenta.Rows[i].Cells["Precio"].Value, grvVenta.Rows[i].Cells["IVA"].Value, grvVenta.Rows[i].Cells["Descuento"].Value);
                try
                {
                    if (ConexionSQL.DML(str) > 0) {
                        cont++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            return cont;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            switch (radioButton2.Checked) {
                case true:
                label5.Visible = true;
                textBox2.Visible = true;
                    txtCancela.Text = string.Format("{0}", txtTotal.Text);
                    txtVuelto.Text = string.Format("{0:c}",0.00m);
                    txtCancela.Enabled = false;
                    textBox2.Focus();
                    break;
                case false:
                    label5.Visible = false;
                    textBox2.Visible = false;
                    txtCancela.Text = "";
                    txtCancela.Enabled = true;
                    txtVuelto.Text = "";
                    txtCancela.Focus();
                    break;
            } 
        }
        protected void Limpiar() {
            txtCancela.Text = "";
            txtCliente.Text = "Contado";
            txtCodigo.Text = "";
            txtTotal.Text = "";
            txtVuelto.Text = "";
            grvVenta.Columns.Clear();
            radioButton2.Checked = false;
            radioButton1.Checked = false;
            dtVenta = new DataTable();
            dtVenta.Columns.Add("NoSeq", typeof(int));
            dtVenta.Columns.Add("Codigo", typeof(string));
            dtVenta.Columns.Add("Descripcion", typeof(string));
            dtVenta.Columns.Add("Cantidad", typeof(decimal));
            dtVenta.Columns.Add("Precio", typeof(decimal));
            dtVenta.Columns.Add("Descuento", typeof(decimal));
            dtVenta.Columns.Add("IVA", typeof(decimal));
            dtVenta.Columns.Add("Total", typeof(decimal));
            grvVenta.DataSource = dtVenta;
            grvVenta.Show();
            txtCodigo.Focus();
        }

        private void grvVenta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    grvVenta.Rows.RemoveAt(e.RowIndex);
                    txtCodigo.Focus();
                    if (grvVenta.Rows.Count > 1)
                    {
                        txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)) - ((Convert.ToDecimal(dtVenta.Compute("SUM(Total)", string.Empty)) * (Convert.ToInt32(textBox1.Text))) / 100));
                    }
                    else
                    {

                        txtTotal.Text = String.Format(CultureInfo.CreateSpecificCulture("es-CR"), "{0:C2}", Convert.ToDecimal(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grvVenta_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                qty = Convert.ToDecimal(grvVenta.Rows[e.RowIndex].Cells["Cantidad"].Value);
            }
            catch (Exception) { }
        }
    }
}
