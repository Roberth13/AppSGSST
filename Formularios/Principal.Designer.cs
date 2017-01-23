namespace GestorSGSST2017.Formularios
{
    partial class Principal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.opcionModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.cargaMasivaOpcion = new System.Windows.Forms.ToolStripMenuItem();
            this.listadosOpcion = new System.Windows.Forms.ToolStripMenuItem();
            this.opcionOpciones = new System.Windows.Forms.ToolStripMenuItem();
            this.salirOpcion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionModulos,
            this.opcionOpciones});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(576, 24);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // opcionModulos
            // 
            this.opcionModulos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargaMasivaOpcion,
            this.listadosOpcion});
            this.opcionModulos.Name = "opcionModulos";
            this.opcionModulos.Size = new System.Drawing.Size(66, 20);
            this.opcionModulos.Text = "Modulos";
            // 
            // cargaMasivaOpcion
            // 
            this.cargaMasivaOpcion.Name = "cargaMasivaOpcion";
            this.cargaMasivaOpcion.Size = new System.Drawing.Size(145, 22);
            this.cargaMasivaOpcion.Text = "Carga Masiva";
            this.cargaMasivaOpcion.Click += new System.EventHandler(this.cargaMasivaOpcion_Click);
            // 
            // listadosOpcion
            // 
            this.listadosOpcion.Name = "listadosOpcion";
            this.listadosOpcion.Size = new System.Drawing.Size(145, 22);
            this.listadosOpcion.Text = "Listados";
            this.listadosOpcion.Click += new System.EventHandler(this.listadosOpcion_Click);
            // 
            // opcionOpciones
            // 
            this.opcionOpciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirOpcion});
            this.opcionOpciones.Name = "opcionOpciones";
            this.opcionOpciones.Size = new System.Drawing.Size(69, 20);
            this.opcionOpciones.Text = "Opciones";
            // 
            // salirOpcion
            // 
            this.salirOpcion.Name = "salirOpcion";
            this.salirOpcion.Size = new System.Drawing.Size(152, 22);
            this.salirOpcion.Text = "Salir";
            this.salirOpcion.Click += new System.EventHandler(this.salirOpcion_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 397);
            this.Controls.Add(this.menuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem opcionModulos;
        private System.Windows.Forms.ToolStripMenuItem cargaMasivaOpcion;
        private System.Windows.Forms.ToolStripMenuItem listadosOpcion;
        private System.Windows.Forms.ToolStripMenuItem opcionOpciones;
        private System.Windows.Forms.ToolStripMenuItem salirOpcion;
    }
}