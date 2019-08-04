namespace GestorSGSST2017.Formularios
{
    partial class CargaMasiva
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
            this.ArchivoHorarios = new System.Windows.Forms.OpenFileDialog();
            this.ArchivoAreas = new System.Windows.Forms.OpenFileDialog();
            this.ArchivoPuestos = new System.Windows.Forms.OpenFileDialog();
            this.ArchivoTrabajadores = new System.Windows.Forms.OpenFileDialog();
            this.ArchivoRiesgos = new System.Windows.Forms.OpenFileDialog();
            this.ArchivoAcc = new System.Windows.Forms.OpenFileDialog();
            this.tabTrabajadores = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.ddlSucursalTrab = new System.Windows.Forms.ComboBox();
            this.btnBuscarTrab = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtArchivoTrab = new System.Windows.Forms.TextBox();
            this.btnCargarTrab = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.ddlEmpresasTrab = new System.Windows.Forms.ComboBox();
            this.tabPuestos = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlSucursalPuesto = new System.Windows.Forms.ComboBox();
            this.btnBuscarPuesto = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtArchivoPuesto = new System.Windows.Forms.TextBox();
            this.btnCargarPuesto = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlEmpresaPuesto = new System.Windows.Forms.ComboBox();
            this.tabAreas = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlSucursalArea = new System.Windows.Forms.ComboBox();
            this.btnBuscarArea = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCargarArea = new System.Windows.Forms.TextBox();
            this.btnCargarArea = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.ddlEmpresaArea = new System.Windows.Forms.ComboBox();
            this.tabHorarios = new System.Windows.Forms.TabPage();
            this.txtLogHorarios = new System.Windows.Forms.RichTextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtArchivoHorarios = new System.Windows.Forms.TextBox();
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlEmpresasHorario = new System.Windows.Forms.ComboBox();
            this.tabsCargaMasiva = new System.Windows.Forms.TabControl();
            this.ArchivoDesc = new System.Windows.Forms.OpenFileDialog();
            this.txtLogAreas = new System.Windows.Forms.RichTextBox();
            this.txtLogPuestos = new System.Windows.Forms.RichTextBox();
            this.txtLogsTrab = new System.Windows.Forms.RichTextBox();
            this.tabTrabajadores.SuspendLayout();
            this.tabPuestos.SuspendLayout();
            this.tabAreas.SuspendLayout();
            this.tabHorarios.SuspendLayout();
            this.tabsCargaMasiva.SuspendLayout();
            this.SuspendLayout();
            // 
            // ArchivoHorarios
            // 
            this.ArchivoHorarios.FileName = "ofdArchivo";
            // 
            // ArchivoAreas
            // 
            this.ArchivoAreas.FileName = "ArchivoAreas";
            // 
            // ArchivoPuestos
            // 
            this.ArchivoPuestos.FileName = "ArchivoPuestos";
            // 
            // ArchivoTrabajadores
            // 
            this.ArchivoTrabajadores.FileName = "openFileDialog1";
            // 
            // ArchivoRiesgos
            // 
            this.ArchivoRiesgos.FileName = "openFileDialog1";
            // 
            // ArchivoAcc
            // 
            this.ArchivoAcc.FileName = "openFileDialog1";
            // 
            // tabTrabajadores
            // 
            this.tabTrabajadores.Controls.Add(this.txtLogsTrab);
            this.tabTrabajadores.Controls.Add(this.label9);
            this.tabTrabajadores.Controls.Add(this.ddlSucursalTrab);
            this.tabTrabajadores.Controls.Add(this.btnBuscarTrab);
            this.tabTrabajadores.Controls.Add(this.label10);
            this.tabTrabajadores.Controls.Add(this.txtArchivoTrab);
            this.tabTrabajadores.Controls.Add(this.btnCargarTrab);
            this.tabTrabajadores.Controls.Add(this.label11);
            this.tabTrabajadores.Controls.Add(this.ddlEmpresasTrab);
            this.tabTrabajadores.Location = new System.Drawing.Point(4, 22);
            this.tabTrabajadores.Name = "tabTrabajadores";
            this.tabTrabajadores.Size = new System.Drawing.Size(700, 346);
            this.tabTrabajadores.TabIndex = 3;
            this.tabTrabajadores.Text = "Trabajadores";
            this.tabTrabajadores.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(156, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 29;
            this.label9.Text = "Seleccione la Sucursal";
            // 
            // ddlSucursalTrab
            // 
            this.ddlSucursalTrab.FormattingEnabled = true;
            this.ddlSucursalTrab.Location = new System.Drawing.Point(277, 92);
            this.ddlSucursalTrab.Name = "ddlSucursalTrab";
            this.ddlSucursalTrab.Size = new System.Drawing.Size(204, 21);
            this.ddlSucursalTrab.TabIndex = 28;
            // 
            // btnBuscarTrab
            // 
            this.btnBuscarTrab.Location = new System.Drawing.Point(496, 145);
            this.btnBuscarTrab.Name = "btnBuscarTrab";
            this.btnBuscarTrab.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarTrab.TabIndex = 27;
            this.btnBuscarTrab.Text = "Buscar";
            this.btnBuscarTrab.UseVisualStyleBackColor = true;
            this.btnBuscarTrab.Click += new System.EventHandler(this.btnBuscarTrab_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(126, 155);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "Seleccione el Archivo (Excel)";
            // 
            // txtArchivoTrab
            // 
            this.txtArchivoTrab.Location = new System.Drawing.Point(277, 148);
            this.txtArchivoTrab.Name = "txtArchivoTrab";
            this.txtArchivoTrab.Size = new System.Drawing.Size(204, 20);
            this.txtArchivoTrab.TabIndex = 25;
            // 
            // btnCargarTrab
            // 
            this.btnCargarTrab.Location = new System.Drawing.Point(300, 174);
            this.btnCargarTrab.Name = "btnCargarTrab";
            this.btnCargarTrab.Size = new System.Drawing.Size(133, 45);
            this.btnCargarTrab.TabIndex = 24;
            this.btnCargarTrab.Text = "Cargar Trabajadores";
            this.btnCargarTrab.UseVisualStyleBackColor = true;
            this.btnCargarTrab.Click += new System.EventHandler(this.btnCargarTrab_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(156, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(115, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Seleccione la Empresa";
            // 
            // ddlEmpresasTrab
            // 
            this.ddlEmpresasTrab.FormattingEnabled = true;
            this.ddlEmpresasTrab.Location = new System.Drawing.Point(277, 37);
            this.ddlEmpresasTrab.Name = "ddlEmpresasTrab";
            this.ddlEmpresasTrab.Size = new System.Drawing.Size(204, 21);
            this.ddlEmpresasTrab.TabIndex = 22;
            this.ddlEmpresasTrab.SelectedIndexChanged += new System.EventHandler(this.ddlEmpresasTrab_SelectedIndexChanged);
            // 
            // tabPuestos
            // 
            this.tabPuestos.Controls.Add(this.txtLogPuestos);
            this.tabPuestos.Controls.Add(this.label6);
            this.tabPuestos.Controls.Add(this.ddlSucursalPuesto);
            this.tabPuestos.Controls.Add(this.btnBuscarPuesto);
            this.tabPuestos.Controls.Add(this.label7);
            this.tabPuestos.Controls.Add(this.txtArchivoPuesto);
            this.tabPuestos.Controls.Add(this.btnCargarPuesto);
            this.tabPuestos.Controls.Add(this.label8);
            this.tabPuestos.Controls.Add(this.ddlEmpresaPuesto);
            this.tabPuestos.Location = new System.Drawing.Point(4, 22);
            this.tabPuestos.Name = "tabPuestos";
            this.tabPuestos.Size = new System.Drawing.Size(700, 346);
            this.tabPuestos.TabIndex = 2;
            this.tabPuestos.Text = "Puestos de Trabajo";
            this.tabPuestos.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(151, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Seleccione la Sucursal";
            // 
            // ddlSucursalPuesto
            // 
            this.ddlSucursalPuesto.FormattingEnabled = true;
            this.ddlSucursalPuesto.Location = new System.Drawing.Point(272, 93);
            this.ddlSucursalPuesto.Name = "ddlSucursalPuesto";
            this.ddlSucursalPuesto.Size = new System.Drawing.Size(204, 21);
            this.ddlSucursalPuesto.TabIndex = 20;
            // 
            // btnBuscarPuesto
            // 
            this.btnBuscarPuesto.Location = new System.Drawing.Point(491, 146);
            this.btnBuscarPuesto.Name = "btnBuscarPuesto";
            this.btnBuscarPuesto.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarPuesto.TabIndex = 19;
            this.btnBuscarPuesto.Text = "Buscar";
            this.btnBuscarPuesto.UseVisualStyleBackColor = true;
            this.btnBuscarPuesto.Click += new System.EventHandler(this.btnBuscarPuesto_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(121, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Seleccione el Archivo (Excel)";
            // 
            // txtArchivoPuesto
            // 
            this.txtArchivoPuesto.Location = new System.Drawing.Point(272, 149);
            this.txtArchivoPuesto.Name = "txtArchivoPuesto";
            this.txtArchivoPuesto.Size = new System.Drawing.Size(204, 20);
            this.txtArchivoPuesto.TabIndex = 17;
            // 
            // btnCargarPuesto
            // 
            this.btnCargarPuesto.Location = new System.Drawing.Point(307, 176);
            this.btnCargarPuesto.Name = "btnCargarPuesto";
            this.btnCargarPuesto.Size = new System.Drawing.Size(133, 45);
            this.btnCargarPuesto.TabIndex = 16;
            this.btnCargarPuesto.Text = "Cargar Puestos";
            this.btnCargarPuesto.UseVisualStyleBackColor = true;
            this.btnCargarPuesto.Click += new System.EventHandler(this.btnCargarPuesto_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(151, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Seleccione la Empresa";
            // 
            // ddlEmpresaPuesto
            // 
            this.ddlEmpresaPuesto.FormattingEnabled = true;
            this.ddlEmpresaPuesto.Location = new System.Drawing.Point(272, 38);
            this.ddlEmpresaPuesto.Name = "ddlEmpresaPuesto";
            this.ddlEmpresaPuesto.Size = new System.Drawing.Size(204, 21);
            this.ddlEmpresaPuesto.TabIndex = 14;
            this.ddlEmpresaPuesto.SelectedIndexChanged += new System.EventHandler(this.ddlEmpresaPuesto_SelectedIndexChanged);
            // 
            // tabAreas
            // 
            this.tabAreas.Controls.Add(this.txtLogAreas);
            this.tabAreas.Controls.Add(this.label5);
            this.tabAreas.Controls.Add(this.ddlSucursalArea);
            this.tabAreas.Controls.Add(this.btnBuscarArea);
            this.tabAreas.Controls.Add(this.label3);
            this.tabAreas.Controls.Add(this.txtCargarArea);
            this.tabAreas.Controls.Add(this.btnCargarArea);
            this.tabAreas.Controls.Add(this.label4);
            this.tabAreas.Controls.Add(this.ddlEmpresaArea);
            this.tabAreas.Location = new System.Drawing.Point(4, 22);
            this.tabAreas.Name = "tabAreas";
            this.tabAreas.Padding = new System.Windows.Forms.Padding(3);
            this.tabAreas.Size = new System.Drawing.Size(700, 346);
            this.tabAreas.TabIndex = 1;
            this.tabAreas.Text = "Areas";
            this.tabAreas.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Seleccione la Sucursal";
            // 
            // ddlSucursalArea
            // 
            this.ddlSucursalArea.FormattingEnabled = true;
            this.ddlSucursalArea.Location = new System.Drawing.Point(262, 78);
            this.ddlSucursalArea.Name = "ddlSucursalArea";
            this.ddlSucursalArea.Size = new System.Drawing.Size(204, 21);
            this.ddlSucursalArea.TabIndex = 12;
            // 
            // btnBuscarArea
            // 
            this.btnBuscarArea.Location = new System.Drawing.Point(481, 131);
            this.btnBuscarArea.Name = "btnBuscarArea";
            this.btnBuscarArea.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarArea.TabIndex = 11;
            this.btnBuscarArea.Text = "Buscar";
            this.btnBuscarArea.UseVisualStyleBackColor = true;
            this.btnBuscarArea.Click += new System.EventHandler(this.btnBuscarArea_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Seleccione el Archivo (Excel)";
            // 
            // txtCargarArea
            // 
            this.txtCargarArea.Location = new System.Drawing.Point(262, 134);
            this.txtCargarArea.Name = "txtCargarArea";
            this.txtCargarArea.Size = new System.Drawing.Size(204, 20);
            this.txtCargarArea.TabIndex = 9;
            // 
            // btnCargarArea
            // 
            this.btnCargarArea.Location = new System.Drawing.Point(301, 162);
            this.btnCargarArea.Name = "btnCargarArea";
            this.btnCargarArea.Size = new System.Drawing.Size(133, 45);
            this.btnCargarArea.TabIndex = 8;
            this.btnCargarArea.Text = "Cargar Areas";
            this.btnCargarArea.UseVisualStyleBackColor = true;
            this.btnCargarArea.Click += new System.EventHandler(this.btnCargarArea_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Seleccione la Empresa";
            // 
            // ddlEmpresaArea
            // 
            this.ddlEmpresaArea.FormattingEnabled = true;
            this.ddlEmpresaArea.Location = new System.Drawing.Point(262, 23);
            this.ddlEmpresaArea.Name = "ddlEmpresaArea";
            this.ddlEmpresaArea.Size = new System.Drawing.Size(204, 21);
            this.ddlEmpresaArea.TabIndex = 6;
            this.ddlEmpresaArea.SelectedIndexChanged += new System.EventHandler(this.ddlEmpresaArea_SelectedIndexChanged);
            // 
            // tabHorarios
            // 
            this.tabHorarios.Controls.Add(this.txtLogHorarios);
            this.tabHorarios.Controls.Add(this.btnBuscar);
            this.tabHorarios.Controls.Add(this.label2);
            this.tabHorarios.Controls.Add(this.txtArchivoHorarios);
            this.tabHorarios.Controls.Add(this.btnCargarArchivo);
            this.tabHorarios.Controls.Add(this.label1);
            this.tabHorarios.Controls.Add(this.ddlEmpresasHorario);
            this.tabHorarios.Location = new System.Drawing.Point(4, 22);
            this.tabHorarios.Name = "tabHorarios";
            this.tabHorarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorarios.Size = new System.Drawing.Size(700, 346);
            this.tabHorarios.TabIndex = 0;
            this.tabHorarios.Text = "Horarios";
            this.tabHorarios.UseVisualStyleBackColor = true;
            // 
            // txtLogHorarios
            // 
            this.txtLogHorarios.Location = new System.Drawing.Point(92, 219);
            this.txtLogHorarios.Name = "txtLogHorarios";
            this.txtLogHorarios.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLogHorarios.Size = new System.Drawing.Size(491, 96);
            this.txtLogHorarios.TabIndex = 6;
            this.txtLogHorarios.Text = "";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(459, 112);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 5;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione el Archivo (Excel)";
            // 
            // txtArchivoHorarios
            // 
            this.txtArchivoHorarios.Location = new System.Drawing.Point(240, 115);
            this.txtArchivoHorarios.Name = "txtArchivoHorarios";
            this.txtArchivoHorarios.Size = new System.Drawing.Size(204, 20);
            this.txtArchivoHorarios.TabIndex = 3;
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(276, 156);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(133, 45);
            this.btnCargarArchivo.TabIndex = 2;
            this.btnCargarArchivo.Text = "Cargar Horarios";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione la Empresa";
            // 
            // ddlEmpresasHorario
            // 
            this.ddlEmpresasHorario.FormattingEnabled = true;
            this.ddlEmpresasHorario.Location = new System.Drawing.Point(240, 65);
            this.ddlEmpresasHorario.Name = "ddlEmpresasHorario";
            this.ddlEmpresasHorario.Size = new System.Drawing.Size(204, 21);
            this.ddlEmpresasHorario.TabIndex = 0;
            // 
            // tabsCargaMasiva
            // 
            this.tabsCargaMasiva.Controls.Add(this.tabHorarios);
            this.tabsCargaMasiva.Controls.Add(this.tabAreas);
            this.tabsCargaMasiva.Controls.Add(this.tabPuestos);
            this.tabsCargaMasiva.Controls.Add(this.tabTrabajadores);
            this.tabsCargaMasiva.Location = new System.Drawing.Point(12, 58);
            this.tabsCargaMasiva.Name = "tabsCargaMasiva";
            this.tabsCargaMasiva.SelectedIndex = 0;
            this.tabsCargaMasiva.Size = new System.Drawing.Size(708, 372);
            this.tabsCargaMasiva.TabIndex = 1;
            // 
            // ArchivoDesc
            // 
            this.ArchivoDesc.FileName = "openFileDialog1";
            // 
            // txtLogAreas
            // 
            this.txtLogAreas.Location = new System.Drawing.Point(114, 213);
            this.txtLogAreas.Name = "txtLogAreas";
            this.txtLogAreas.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLogAreas.Size = new System.Drawing.Size(491, 110);
            this.txtLogAreas.TabIndex = 14;
            this.txtLogAreas.Text = "";
            // 
            // txtLogPuestos
            // 
            this.txtLogPuestos.Location = new System.Drawing.Point(124, 227);
            this.txtLogPuestos.Name = "txtLogPuestos";
            this.txtLogPuestos.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLogPuestos.Size = new System.Drawing.Size(491, 98);
            this.txtLogPuestos.TabIndex = 22;
            this.txtLogPuestos.Text = "";
            // 
            // txtLogsTrab
            // 
            this.txtLogsTrab.Location = new System.Drawing.Point(111, 225);
            this.txtLogsTrab.Name = "txtLogsTrab";
            this.txtLogsTrab.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.txtLogsTrab.Size = new System.Drawing.Size(491, 105);
            this.txtLogsTrab.TabIndex = 30;
            this.txtLogsTrab.Text = "";
            // 
            // CargaMasiva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 480);
            this.Controls.Add(this.tabsCargaMasiva);
            this.Name = "CargaMasiva";
            this.Text = "Carga Masiva SGSST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CargaMasiva_Load);
            this.tabTrabajadores.ResumeLayout(false);
            this.tabTrabajadores.PerformLayout();
            this.tabPuestos.ResumeLayout(false);
            this.tabPuestos.PerformLayout();
            this.tabAreas.ResumeLayout(false);
            this.tabAreas.PerformLayout();
            this.tabHorarios.ResumeLayout(false);
            this.tabHorarios.PerformLayout();
            this.tabsCargaMasiva.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ArchivoHorarios;
        private System.Windows.Forms.OpenFileDialog ArchivoAreas;
        private System.Windows.Forms.OpenFileDialog ArchivoPuestos;
        private System.Windows.Forms.OpenFileDialog ArchivoTrabajadores;
        private System.Windows.Forms.OpenFileDialog ArchivoRiesgos;
        private System.Windows.Forms.OpenFileDialog ArchivoAcc;
        private System.Windows.Forms.TabPage tabTrabajadores;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox ddlSucursalTrab;
        private System.Windows.Forms.Button btnBuscarTrab;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtArchivoTrab;
        private System.Windows.Forms.Button btnCargarTrab;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox ddlEmpresasTrab;
        private System.Windows.Forms.TabPage tabPuestos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlSucursalPuesto;
        private System.Windows.Forms.Button btnBuscarPuesto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtArchivoPuesto;
        private System.Windows.Forms.Button btnCargarPuesto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox ddlEmpresaPuesto;
        private System.Windows.Forms.TabPage tabAreas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlSucursalArea;
        private System.Windows.Forms.Button btnBuscarArea;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCargarArea;
        private System.Windows.Forms.Button btnCargarArea;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ddlEmpresaArea;
        private System.Windows.Forms.TabPage tabHorarios;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtArchivoHorarios;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlEmpresasHorario;
        private System.Windows.Forms.TabControl tabsCargaMasiva;
        private System.Windows.Forms.OpenFileDialog ArchivoDesc;
        private System.Windows.Forms.RichTextBox txtLogHorarios;
        private System.Windows.Forms.RichTextBox txtLogAreas;
        private System.Windows.Forms.RichTextBox txtLogPuestos;
        private System.Windows.Forms.RichTextBox txtLogsTrab;
    }
}