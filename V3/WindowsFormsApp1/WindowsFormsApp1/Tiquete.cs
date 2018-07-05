using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Tiquete
    {
        PrintDocument pdoc = null;
        int ticketNo;
        DateTime TicketDate;
        String Cliente,cancela,vuelto,tipoPago,voucher;
        float Amount,discount,iva,total;
        DataTable productos;

        public int TicketNo
        {
            //set the person name
            set { this.ticketNo = value; }
            //get the person name 
            get { return this.ticketNo; }
        }
        public DateTime ticketDate
        {
            //set the person name
            set { this.TicketDate = value; }
            //get the person name 
            get { return this.TicketDate; }
        }

        
        public float amount
        {
            //set the person name
            set { this.Amount = value; }
            //get the person name 
            get { return this.Amount; }
        }
        public string Cliente1 { get => Cliente; set => Cliente = value; }
        public DataTable Productos { get => productos; set => productos = value; }
        public float Discount { get => discount; set => discount = value; }
        public float Iva { get => iva; set => iva = value; }
        public float Total { get => total; set => total = value; }
        public string Cancela { get => cancela; set => cancela = value; }
        public string Vuelto { get => vuelto; set => vuelto = value; }
        public string TipoPago { get => tipoPago; set => tipoPago = value; }
        public string Voucher { get => voucher; set => voucher = value; }

        public Tiquete()
        {

        }
        public Tiquete(int ticketNo, DateTime TicketDate, float Amount, float discount, float iva, float total, String pCliente, String pCancela, String pVuelto,String pTipoPago,String pVoucher, DataTable pProductos)
        {
            this.ticketNo = ticketNo;
            this.TicketDate = TicketDate;
            this.Amount = Amount;
            this.Discount = discount;
            this.Iva = iva;
            this.Total = total;
            this.Cliente1 = pCliente;
            this.Cancela = pCancela;
            this.Vuelto = pVuelto;
            this.Productos = pProductos;
            TipoPago = pTipoPago;
            Voucher = pVoucher;
        }
        public void print()
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("Custom", 750, 2000);
            //ps.DefaultPageSettings.PaperSize = psize;



            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 2000;
            pdoc.DefaultPageSettings.PaperSize.Width = 750;
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.PrinterName = Properties.Settings.Default.Impresora;
            pdoc.PrinterSettings = printerSettings;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            /* DialogResult result = pd.ShowDialog();
             if (result == DialogResult.OK)
             {
                 PrintPreviewDialog pp = new PrintPreviewDialog();
                 pp.Document = pdoc;
                 result = pp.ShowDialog();
                 if (result == DialogResult.OK)
                 {
                     pdoc.Print();
                 }
             }
             */
            pdoc.Print();
         //   pdoc.Print();

        }
        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            string Font = "Times New Roman";
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 0;
            int startY = 0;
            int Offset = 0;
            graphics.DrawImage(Properties.Resources.logo, startX+50, startY);
            Offset = Offset + 85;
            graphics.DrawString(Properties.Settings.Default.Encabezado1, new Font(Font, 14), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(Properties.Settings.Default.Encabezado2, new Font(Font, 12), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(Properties.Settings.Default.Encabezado3, new Font(Font, 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(Properties.Settings.Default.Encabezado4, new Font(Font, 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(Properties.Settings.Default.Encabezado5, new Font(Font, 9), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(string.Format("Recibo #: {0}", this.TicketNo), new Font(Font, 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(string.Format("Fecha Hora : {0}", this.ticketDate), new Font(Font, 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            graphics.DrawString(string.Format("Cliente : {0}", this.Cliente1), new Font(Font, 8), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            if (TipoPago.Equals("Tarjeta"))
            {
                graphics.DrawString(string.Format("Tipo Pago:{1} - Voucher: {0}", this.Voucher, this.TipoPago), new Font(Font, 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }
            else
            {
                graphics.DrawString(string.Format("TipoPago : {0}", this.TipoPago), new Font(Font, 8), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset = Offset + 20;
            }
            String underLine = "--------------------------------------------------------";
            graphics.DrawString(underLine, new Font(Font, 10), new SolidBrush(Color.Black), startX, startY + Offset);
            int fontsize = 10;
            Offset = Offset + 30;
            RectangleF Cantidad = new RectangleF(startX, startY + Offset, 40, 30);
            RectangleF Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 30);
            RectangleF Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 30);
            graphics.DrawString("Cant", new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Cantidad);
            graphics.DrawString("Descripción", new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            graphics.DrawString("Precio", new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Precio);
            Offset = Offset + 20;
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Far;
            sf.Alignment = StringAlignment.Far;
            StringFormat qty = new StringFormat();
            qty.LineAlignment = StringAlignment.Center;
            qty.Alignment = StringAlignment.Center;
            foreach (DataRow dr in Productos.Rows)
            {
                int caracteres = dr["Descripcion"].ToString().Length;
                decimal iva2 = Convert.ToDecimal(dr["IVA"].ToString());
                int alto = 30;
                if (caracteres <= 22)
                {
                    alto = 20;
                }
                Cantidad = new RectangleF(startX, startY + Offset, 40, alto);
                Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, alto);
                Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, alto);
                graphics.DrawString(String.Format("{0}", dr["Cantidad"].ToString()), new Font(Font, fontsize), new SolidBrush(Color.Black), Cantidad, qty);
                if (iva2 > 0)
                {
                    graphics.DrawString(String.Format("{0}*", dr["Descripcion"].ToString()), new Font(Font, fontsize), new SolidBrush(Color.Black), Descripcion);
                }
                else
                {
                    graphics.DrawString(String.Format("{0}", dr["Descripcion"].ToString()), new Font(Font, fontsize), new SolidBrush(Color.Black), Descripcion);
                }
                graphics.DrawString(String.Format("{0:c}", Convert.ToDecimal(dr["Precio"].ToString())), new Font(Font, fontsize), new SolidBrush(Color.Black), Precio,sf);
                Offset = Offset + alto;
            }
            String Grosstotal = string.Format("SubTotal = {0:c}", this.amount);
            String Disc = string.Format("Descuento = {0:c}", this.Discount);
            String IVA = string.Format("{0:c}", this.Iva);
            String Total1 = string.Format("Total = {0:c}", this.Total);

           // Offset = Offset + 20;
            underLine = "--------------------------------------------------------";
            graphics.DrawString(underLine, new Font(Font, 10), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("Sub-Total", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(Grosstotal, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("Descuento", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(Disc, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("IVA", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(IVA, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("Total", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(Total1, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 30;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("Cancela", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(Cancela, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX + Cantidad.Width, startY + Offset, 200, 20);
            Precio = new RectangleF(startX + Descripcion.Width, startY + Offset, 80, 20);
            graphics.DrawString("Vuelto", new Font(Font, 10, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion, qty);
            graphics.DrawString(Vuelto, new Font(Font, 10), new SolidBrush(Color.Black), Precio, sf);
            Offset = Offset + 40;
            graphics.DrawString(Properties.Settings.Default.Saludo, new Font(Font,10), new SolidBrush(Color.Black), startX, startY + Offset);
        }
    }
}
