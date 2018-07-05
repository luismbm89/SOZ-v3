using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                ApplicationDeployment cd = ApplicationDeployment.CurrentDeployment;
                int major = cd.CurrentVersion.Major;
                int minor = cd.CurrentVersion.Minor;
                int build = cd.CurrentVersion.Build;
                int revision = cd.CurrentVersion.Revision;
                // show publish version in title or About box...
                toolStripLabel1.Text = string.Format("{0}.{1}.{2}.{3}", major, minor, build, revision);
            }
            catch (Exception ex) {
                toolStripLabel1.Text = "1.0.0.74"; }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea cerrar la aplicacion?", "Finalizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Desea cerrar la aplicacion?", "Finalizar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BackupDatabase(false);
            Caja caja = new Caja();
            caja.MdiParent = this;
            caja.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

            string x = Interaction.InputBox("Por favor digite la contraseña para acceder a este módulo", "Acceso Restringido", "", 10, 10);
            if (x.Equals("Empagro2017"))
            {
                Frmsql sql = new Frmsql();
                sql.MdiParent = this;
                sql.Show();
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        { DataTable dt = ConexionSQL.consultaDataTable(String.Format("Select isnull(MontoApertura,0)[MontoApertura],NoSeq from Caja where Convert(varchar,FechaApertura,103)='{0}' and FechaApertura=FechaCierre and Estado=0", DateTime.Now.ToString("dd/MM/yyyy")), "Caja");
            if (dt.Rows.Count > 0)
            {
                Gasto gasto = new Gasto();
            gasto.MdiParent = this;
            gasto.Show();
            }
            else
            {
                MessageBox.Show("Debe realizar la apertura de caja", "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            venta.MdiParent = this;
            venta.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                switch (toolStripButton8.Text)
                {
                    case "Desconectado":
                        if (ConexionSQL.ConexionBD().State == ConnectionState.Open)
                        {
                            toolStripButton8.Image = Properties.Resources.connected;
                            toolStripButton8.Text = "Conectado";
                        }
                        break;
                    case "Conectado":
                        toolStripButton8.Image = Properties.Resources.disconnected;
                        toolStripButton8.Text = "Desconectado";
                        break;
                }
            }
            catch (Exception ex) {
                toolStripLabel1.Text = ex.Message;
            }
        }

        private void nuevaVentaToolStripMenuItem_Click(object sender, EventArgs e)
        { DataTable dt = ConexionSQL.consultaDataTable(String.Format("Select isnull(MontoApertura,0)[MontoApertura],NoSeq from Caja where Convert(varchar,FechaApertura,103)='{0}' and FechaApertura=FechaCierre and Estado=0", DateTime.Now.ToString("dd/MM/yyyy")), "Caja");
            if (dt.Rows.Count > 0)
            {
                Venta venta = new Venta();
                venta.MdiParent = this;
                venta.Show();
            }
            else
            {
                MessageBox.Show("Debe realizar la apertura de caja", "Apertura de caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            Conf conf = new Conf();
            conf.MdiParent = this;
            conf.Show();
        }

        private void detalleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string numero = ConexionSQL.ConsultaUnica("Select isnull(min(Cod),0) from Venta");
            if (numero.Equals("0"))
            {
                MessageBox.Show("No se ha realizado ninguna venta", "Sin registro de ventas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                VentaDetalle vd = new VentaDetalle();
                vd.MdiParent = this;
                vd.Show();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FrmProducto producto = new FrmProducto();
            producto.MdiParent = this;
            producto.Show();
        }

        private void toolStripButton7_Click_1(object sender, EventArgs e)
        {
            Compra compra = new Compra();
            compra.MdiParent = this;
            compra.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            try
            {
                BackupDatabase(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BackupDatabase(bool msg)

        {

            string sConnect = ConexionSQL.ConexionBD().ConnectionString;

            string dbName;


            using (SqlConnection cnn = new SqlConnection(sConnect))

            {

                cnn.Open();

                dbName = cnn.Database.ToString();


                ServerConnection sc = new ServerConnection(cnn);

                Server sv = new Server(sc);


                // Check that I'm connected to the user instance

                //MessageBox.Show(sv.InstanceName.ToString());


                // Create backup device item for the backup
                if (!File.Exists(String.Format(@"{1}\{0}.bak", DateTime.Now.ToString("ddMMyyyy_hhmm"), Properties.Settings.Default.CarpetaRespaldo)))
                {
                    BackupDeviceItem bdi = new BackupDeviceItem(String.Format(@"{1}\{0}.bak", DateTime.Now.ToString("ddMMyyyy_hhmm"), Properties.Settings.Default.CarpetaRespaldo), DeviceType.File);


                    // Create the backup informaton

                    Backup bk = new Backup();

                    bk.Devices.Add(bdi);

                    bk.Action = BackupActionType.Database;

                    bk.BackupSetDescription = string.Format("Respaldo SOZ_BD del {0}", DateTime.Now.ToLongDateString());

                    bk.BackupSetName = bdi.Name;

                    bk.Database = dbName;
                    bk.BackupSetName = "SOZ_BD";

                    bk.LogTruncation = BackupTruncateLogType.Truncate;
                    bk.PercentComplete += new PercentCompleteEventHandler(backup_PercentComplete);
                    bk.Complete +=
                        new Microsoft.SqlServer.Management.Common.ServerMessageEventHandler
                        (backup_Complete);

                    // Run the backup

                    bk.SqlBackup(sv);
                    if (msg)
                    {
                        MessageBox.Show("Respaldo Realizado con éxito", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    toolStripProgressBar1.Value = 0;
                }
                else
                {
                    if (msg)
                    {
                        MessageBox.Show("Ya existe un respaldo, por favor espere un minuto mas para volver a intentar", "Respaldo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        //The event handlers
       void backup_Complete
            (object sender, Microsoft.SqlServer.Management.Common.ServerMessageEventArgs e)
        {
                
            toolStripProgressBar1.Value = (100);
        }
        void backup_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            toolStripProgressBar1.Value = (e.Percent);
        }

        }

    }
}
