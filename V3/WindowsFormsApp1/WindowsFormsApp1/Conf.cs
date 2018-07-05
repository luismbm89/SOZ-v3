using LibPrintTicket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Conf : Form
    {
        public Conf()
        {
            InitializeComponent();
        }

        private void Conf_Load(object sender, EventArgs e)
        {
            txtEnc1.Text = Properties.Settings.Default.Encabezado1;
            txtEnc2.Text = Properties.Settings.Default.Encabezado2;
            txtEnc3.Text = Properties.Settings.Default.Encabezado3;
            txtEnc4.Text = Properties.Settings.Default.Encabezado4;
            txtEnc5.Text = Properties.Settings.Default.Encabezado5;
            txtServidor.Text = Properties.Settings.Default.Servidor;
            txtCarpetaBck.Text = Properties.Settings.Default.CarpetaRespaldo;
            if (Properties.Settings.Default.Inv)
            {
                rdbSiInv.Checked = true;
            }
            else {
                rdbNoInv.Checked = true;
            }
            txtIV.Text = string.Format("{0}",Properties.Settings.Default.IV);
            txtImpresora.Text =Properties.Settings.Default.Impresora;
            txtSal.Text = Properties.Settings.Default.Saludo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Encabezado1"] = txtEnc1.Text;
            Properties.Settings.Default["Encabezado2"] = txtEnc2.Text;
            Properties.Settings.Default["Encabezado3"] = txtEnc3.Text;
            Properties.Settings.Default["Encabezado4"] = txtEnc4.Text;
            Properties.Settings.Default["Encabezado5"] = txtEnc5.Text;
            Properties.Settings.Default["Impresora"] = txtImpresora.Text;
            Properties.Settings.Default["Servidor"] = txtServidor.Text;
            Properties.Settings.Default["Saludo"] = txtSal.Text;
            Properties.Settings.Default["CarpetaRespaldo"] = txtCarpetaBck.Text;
            Properties.Settings.Default["IV"] = Convert.ToInt32(txtIV.Text);
            if (rdbNoInv.Checked)
            {
                Properties.Settings.Default["Inv"] = false;
            }
            else
            {
                Properties.Settings.Default["Inv"] = true;
            }
            Properties.Settings.Default.Save();
            MessageBox.Show("Configuración guardada exitosamente","Configuración",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }


        private void Print() {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();


            PaperSize psize = new PaperSize("Custom", 750, 2000);



            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 2000;
            pdoc.DefaultPageSettings.PaperSize.Width = 750;
            PrinterSettings printerSettings = new PrinterSettings();
            printerSettings.PrinterName = Properties.Settings.Default.Impresora;
            pdoc.PrinterSettings = printerSettings;
            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);
            pdoc.Print();
        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {

            string Font = "Times New Roman";
            Graphics graphics = e.Graphics;
            int startX = 0;
            int startY = 0;
            int Offset = 0;

            int fontsize = 10;
            graphics.DrawImage(Properties.Resources.logo, startX + 50, startY);
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
            graphics.DrawString(string.Format("Configuración : {0}", DateTime.Now.ToShortDateString()), new Font(Font, 14, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
            Offset = Offset + 20;
            RectangleF Descripcion = new RectangleF(startX, startY + Offset, 320, 80);
            graphics.DrawString(Properties.Settings.Default.CarpetaRespaldo, new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            Offset = Offset + 60;
            Descripcion = new RectangleF(startX, startY + Offset, 320, 60);
            if (rdbNoInv.Checked)
            {

                graphics.DrawString("Sin Control de Inventario", new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            }
            else
            {

                graphics.DrawString("Con Control de Inventario", new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            }
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX, startY + Offset, 320, 60);
            graphics.DrawString(Properties.Settings.Default.Impresora, new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX, startY + Offset, 320, 30);
            graphics.DrawString(String.Format("IVA del {0}%", Properties.Settings.Default.IV), new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            Offset = Offset + 20;
            Descripcion = new RectangleF(startX, startY + Offset, 320, 30);
            graphics.DrawString(String.Format("Servidor BD {0}", Properties.Settings.Default.Servidor), new Font(Font, fontsize, FontStyle.Bold), new SolidBrush(Color.Black), Descripcion);
            Offset = Offset + 40;
            graphics.DrawString(Properties.Settings.Default.Saludo, new Font(Font, 10), new SolidBrush(Color.Black), startX, startY + Offset);

        }
            private void button2_Click(object sender, EventArgs e)
        {/*
            Ticket ticket = new Ticket();
            ticket.HeaderImage = Properties.Resources.logo;
            ticket.AddTotal("Configuración", DateTime.Now.ToShortDateString());
            ticket.AddTotal("Impresora", string.Empty);
            ticket.AddTotal(string.Empty, txtImpresora.Text);
            ticket.AddTotal("Servidor", string.Empty);
            ticket.AddTotal(string.Empty, txtServidor.Text);
            ticket.AddTotal("Imp Venta", string.Empty);
            ticket.AddTotal(string.Empty, txtIV.Text);
            ticket.AddTotal("Encabezado 1", string.Empty);
            ticket.AddTotal(string.Empty, txtEnc1.Text);
            ticket.AddTotal("Encabezado 2", string.Empty);
            ticket.AddTotal(string.Empty, txtEnc2.Text);
            ticket.AddTotal("Encabezado 3", string.Empty);
            ticket.AddTotal(string.Empty, txtEnc3.Text);
            ticket.AddTotal("Encabezado 4", string.Empty);
            ticket.AddTotal(string.Empty, txtEnc4.Text);
            ticket.AddTotal("Encabezado 5", string.Empty);
            ticket.AddTotal(string.Empty, txtEnc5.Text);
            ticket.AddTotal("Carpeta Respaldo", string.Empty);
            ticket.AddTotal(string.Empty, txtCarpetaBck.Text);
            ticket.AddTotal("Saludo", string.Empty);
            ticket.AddTotal(string.Empty, txtSal.Text);
            ticket.AddTotal("Control de Inventario", string.Empty);
            if (rdbNoInv.Checked)
            {
                ticket.AddTotal(string.Empty, "No");
            }
            else
            {
                ticket.AddTotal(string.Empty, "Si");
            }
                ticket.AddTotal("", "");

            ticket.PrintTicket(Properties.Settings.Default.Impresora); //Nombre de la impresora de tickets*/
            Print();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtCarpetaBck.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
