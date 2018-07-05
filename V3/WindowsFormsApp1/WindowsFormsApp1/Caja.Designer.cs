namespace WindowsFormsApp1
{
    partial class Caja
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caja));
            this.txtApertura = new System.Windows.Forms.TextBox();
            this.txtCierre = new System.Windows.Forms.TextBox();
            this.btnApertura = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txt50000 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt20000 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt10000 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt5000 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt2000 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt1000 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt25 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt50 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt100 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt500 = new System.Windows.Forms.TextBox();
            this.txtVentas = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtGastos = new System.Windows.Forms.TextBox();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.Total = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtEfectivo = new System.Windows.Forms.TextBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtApertura
            // 
            this.txtApertura.BackColor = System.Drawing.Color.Black;
            this.txtApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApertura.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtApertura.Location = new System.Drawing.Point(12, 45);
            this.txtApertura.Name = "txtApertura";
            this.txtApertura.Size = new System.Drawing.Size(444, 83);
            this.txtApertura.TabIndex = 11;
            this.txtApertura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtApertura.TextChanged += new System.EventHandler(this.txtApertura_TextChanged);
            // 
            // txtCierre
            // 
            this.txtCierre.BackColor = System.Drawing.Color.Black;
            this.txtCierre.Enabled = false;
            this.txtCierre.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCierre.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtCierre.Location = new System.Drawing.Point(12, 180);
            this.txtCierre.Name = "txtCierre";
            this.txtCierre.Size = new System.Drawing.Size(444, 83);
            this.txtCierre.TabIndex = 12;
            this.txtCierre.Text = "0";
            this.txtCierre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnApertura
            // 
            this.btnApertura.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnApertura.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApertura.Location = new System.Drawing.Point(12, 134);
            this.btnApertura.Name = "btnApertura";
            this.btnApertura.Size = new System.Drawing.Size(146, 40);
            this.btnApertura.TabIndex = 23;
            this.btnApertura.Text = "Realizar Apertura";
            this.btnApertura.UseVisualStyleBackColor = false;
            this.btnApertura.Click += new System.EventHandler(this.btnApertura_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 282);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(129, 40);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Realizar Cierre";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txt50000
            // 
            this.txt50000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt50000.Location = new System.Drawing.Point(552, 12);
            this.txt50000.Name = "txt50000";
            this.txt50000.Size = new System.Drawing.Size(136, 30);
            this.txt50000.TabIndex = 25;
            this.txt50000.Tag = "50000";
            this.txt50000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(487, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "₡ 50 000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(487, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "₡ 20 000";
            // 
            // txt20000
            // 
            this.txt20000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt20000.Location = new System.Drawing.Point(552, 54);
            this.txt20000.Name = "txt20000";
            this.txt20000.Size = new System.Drawing.Size(136, 30);
            this.txt20000.TabIndex = 27;
            this.txt20000.Tag = "20000";
            this.txt20000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(487, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "₡ 10 000";
            // 
            // txt10000
            // 
            this.txt10000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt10000.Location = new System.Drawing.Point(552, 101);
            this.txt10000.Name = "txt10000";
            this.txt10000.Size = new System.Drawing.Size(136, 30);
            this.txt10000.TabIndex = 29;
            this.txt10000.Tag = "10000";
            this.txt10000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(487, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "₡  5 000";
            // 
            // txt5000
            // 
            this.txt5000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5000.Location = new System.Drawing.Point(552, 148);
            this.txt5000.Name = "txt5000";
            this.txt5000.Size = new System.Drawing.Size(136, 30);
            this.txt5000.TabIndex = 31;
            this.txt5000.Tag = "5000";
            this.txt5000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(487, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "₡  2 000";
            // 
            // txt2000
            // 
            this.txt2000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2000.Location = new System.Drawing.Point(552, 190);
            this.txt2000.Name = "txt2000";
            this.txt2000.Size = new System.Drawing.Size(136, 30);
            this.txt2000.TabIndex = 33;
            this.txt2000.Tag = "2000";
            this.txt2000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(487, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "₡  1 000";
            // 
            // txt1000
            // 
            this.txt1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1000.Location = new System.Drawing.Point(552, 226);
            this.txt1000.Name = "txt1000";
            this.txt1000.Size = new System.Drawing.Size(136, 30);
            this.txt1000.TabIndex = 35;
            this.txt1000.Tag = "1000";
            this.txt1000.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(722, 243);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 48;
            this.label7.Text = "₡      5";
            // 
            // txt5
            // 
            this.txt5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt5.Location = new System.Drawing.Point(787, 226);
            this.txt5.Name = "txt5";
            this.txt5.Size = new System.Drawing.Size(136, 30);
            this.txt5.TabIndex = 47;
            this.txt5.Tag = "5";
            this.txt5.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(722, 207);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "₡     10";
            // 
            // txt10
            // 
            this.txt10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt10.Location = new System.Drawing.Point(787, 190);
            this.txt10.Name = "txt10";
            this.txt10.Size = new System.Drawing.Size(136, 30);
            this.txt10.TabIndex = 45;
            this.txt10.Tag = "10";
            this.txt10.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(722, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 44;
            this.label9.Text = "₡     25";
            // 
            // txt25
            // 
            this.txt25.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt25.Location = new System.Drawing.Point(787, 148);
            this.txt25.Name = "txt25";
            this.txt25.Size = new System.Drawing.Size(136, 30);
            this.txt25.TabIndex = 43;
            this.txt25.Tag = "25";
            this.txt25.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(722, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "₡     50";
            // 
            // txt50
            // 
            this.txt50.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt50.Location = new System.Drawing.Point(787, 101);
            this.txt50.Name = "txt50";
            this.txt50.Size = new System.Drawing.Size(136, 30);
            this.txt50.TabIndex = 41;
            this.txt50.Tag = "50";
            this.txt50.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(722, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "₡    100";
            // 
            // txt100
            // 
            this.txt100.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt100.Location = new System.Drawing.Point(787, 54);
            this.txt100.Name = "txt100";
            this.txt100.Size = new System.Drawing.Size(136, 30);
            this.txt100.TabIndex = 39;
            this.txt100.Tag = "100";
            this.txt100.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(722, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "₡    500";
            // 
            // txt500
            // 
            this.txt500.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt500.Location = new System.Drawing.Point(787, 12);
            this.txt500.Name = "txt500";
            this.txt500.Size = new System.Drawing.Size(136, 30);
            this.txt500.TabIndex = 37;
            this.txt500.Tag = "500";
            this.txt500.TextChanged += new System.EventHandler(this.txt50000_TextChanged);
            // 
            // txtVentas
            // 
            this.txtVentas.BackColor = System.Drawing.Color.Black;
            this.txtVentas.Enabled = false;
            this.txtVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtVentas.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtVentas.Location = new System.Drawing.Point(173, 282);
            this.txtVentas.Name = "txtVentas";
            this.txtVentas.Size = new System.Drawing.Size(228, 45);
            this.txtVentas.TabIndex = 49;
            this.txtVentas.Text = "0";
            this.txtVentas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(170, 266);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 50;
            this.label13.Text = "Ventas";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(436, 266);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 52;
            this.label14.Text = "Gastos";
            // 
            // txtGastos
            // 
            this.txtGastos.BackColor = System.Drawing.Color.Black;
            this.txtGastos.Enabled = false;
            this.txtGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtGastos.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtGastos.Location = new System.Drawing.Point(439, 282);
            this.txtGastos.Name = "txtGastos";
            this.txtGastos.Size = new System.Drawing.Size(216, 45);
            this.txtGastos.TabIndex = 51;
            this.txtGastos.Text = "0";
            this.txtGastos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.Black;
            this.txtFecha.Enabled = false;
            this.txtFecha.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtFecha.Location = new System.Drawing.Point(12, 13);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(110, 20);
            this.txtFecha.TabIndex = 53;
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.Total.Location = new System.Drawing.Point(688, 266);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(36, 13);
            this.Total.TabIndex = 55;
            this.Total.Text = "Total";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.Black;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtTotal.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtTotal.Location = new System.Drawing.Point(691, 282);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(232, 45);
            this.txtTotal.TabIndex = 54;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label15.Location = new System.Drawing.Point(170, 330);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 13);
            this.label15.TabIndex = 56;
            this.label15.Text = "Efectivo";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(418, 330);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 13);
            this.label16.TabIndex = 57;
            this.label16.Text = "Tarjeta";
            // 
            // txtEfectivo
            // 
            this.txtEfectivo.BackColor = System.Drawing.Color.Black;
            this.txtEfectivo.Enabled = false;
            this.txtEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtEfectivo.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtEfectivo.Location = new System.Drawing.Point(173, 346);
            this.txtEfectivo.Name = "txtEfectivo";
            this.txtEfectivo.Size = new System.Drawing.Size(228, 45);
            this.txtEfectivo.TabIndex = 58;
            this.txtEfectivo.Text = "0";
            this.txtEfectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.BackColor = System.Drawing.Color.Black;
            this.txtTarjeta.Enabled = false;
            this.txtTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.txtTarjeta.ForeColor = System.Drawing.Color.PaleGreen;
            this.txtTarjeta.Location = new System.Drawing.Point(422, 346);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(228, 45);
            this.txtTarjeta.TabIndex = 59;
            this.txtTarjeta.Text = "0";
            this.txtTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 399);
            this.Controls.Add(this.txtTarjeta);
            this.Controls.Add(this.txtEfectivo);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtGastos);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtVentas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt25);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt50);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt100);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txt500);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt1000);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt2000);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt5000);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt10000);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt20000);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt50000);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnApertura);
            this.Controls.Add(this.txtCierre);
            this.Controls.Add(this.txtApertura);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Caja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtApertura;
        private System.Windows.Forms.TextBox txtCierre;
        private System.Windows.Forms.Button btnApertura;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txt50000;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt20000;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt10000;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt5000;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt2000;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt1000;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt25;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt50;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt100;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt500;
        private System.Windows.Forms.TextBox txtVentas;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtGastos;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtEfectivo;
        private System.Windows.Forms.TextBox txtTarjeta;
    }
}