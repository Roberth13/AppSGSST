namespace GestorSGSST2017.Formularios
{
    partial class Listados
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
            this.tabsListados = new System.Windows.Forms.TabControl();
            this.tabHorarioList = new System.Windows.Forms.TabPage();
            this.dataHorarios = new System.Windows.Forms.DataGridView();
            this.tabAreaList = new System.Windows.Forms.TabPage();
            this.dataGridAreas = new System.Windows.Forms.DataGridView();
            this.tabPuestosList = new System.Windows.Forms.TabPage();
            this.dataGridPuestos = new System.Windows.Forms.DataGridView();
            this.tabTrabajadoresList = new System.Windows.Forms.TabPage();
            this.dataGridTrabajadores = new System.Windows.Forms.DataGridView();
            this.tabDescSocio = new System.Windows.Forms.TabPage();
            this.dataGridDescSocio = new System.Windows.Forms.DataGridView();
            this.tabsListados.SuspendLayout();
            this.tabHorarioList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataHorarios)).BeginInit();
            this.tabAreaList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAreas)).BeginInit();
            this.tabPuestosList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPuestos)).BeginInit();
            this.tabTrabajadoresList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTrabajadores)).BeginInit();
            this.tabDescSocio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDescSocio)).BeginInit();
            this.SuspendLayout();
            // 
            // tabsListados
            // 
            this.tabsListados.AllowDrop = true;
            this.tabsListados.Controls.Add(this.tabHorarioList);
            this.tabsListados.Controls.Add(this.tabAreaList);
            this.tabsListados.Controls.Add(this.tabPuestosList);
            this.tabsListados.Controls.Add(this.tabTrabajadoresList);
            this.tabsListados.Controls.Add(this.tabDescSocio);
            this.tabsListados.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabsListados.Location = new System.Drawing.Point(12, 73);
            this.tabsListados.Name = "tabsListados";
            this.tabsListados.SelectedIndex = 0;
            this.tabsListados.Size = new System.Drawing.Size(1098, 438);
            this.tabsListados.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabsListados.TabIndex = 0;
            // 
            // tabHorarioList
            // 
            this.tabHorarioList.Controls.Add(this.dataHorarios);
            this.tabHorarioList.Location = new System.Drawing.Point(4, 22);
            this.tabHorarioList.Name = "tabHorarioList";
            this.tabHorarioList.Padding = new System.Windows.Forms.Padding(3);
            this.tabHorarioList.Size = new System.Drawing.Size(1090, 412);
            this.tabHorarioList.TabIndex = 0;
            this.tabHorarioList.Text = "Horarios";
            this.tabHorarioList.UseVisualStyleBackColor = true;
            this.tabHorarioList.UseWaitCursor = true;
            // 
            // dataHorarios
            // 
            this.dataHorarios.AllowUserToAddRows = false;
            this.dataHorarios.AllowUserToDeleteRows = false;
            this.dataHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataHorarios.Location = new System.Drawing.Point(0, 0);
            this.dataHorarios.Name = "dataHorarios";
            this.dataHorarios.ReadOnly = true;
            this.dataHorarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataHorarios.Size = new System.Drawing.Size(1090, 412);
            this.dataHorarios.TabIndex = 0;
            this.dataHorarios.UseWaitCursor = true;
            this.dataHorarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataHorarios_CellContentClick);
            // 
            // tabAreaList
            // 
            this.tabAreaList.Controls.Add(this.dataGridAreas);
            this.tabAreaList.Location = new System.Drawing.Point(4, 22);
            this.tabAreaList.Name = "tabAreaList";
            this.tabAreaList.Padding = new System.Windows.Forms.Padding(3);
            this.tabAreaList.Size = new System.Drawing.Size(1090, 412);
            this.tabAreaList.TabIndex = 1;
            this.tabAreaList.Text = "Areas";
            this.tabAreaList.UseVisualStyleBackColor = true;
            this.tabAreaList.UseWaitCursor = true;
            // 
            // dataGridAreas
            // 
            this.dataGridAreas.AllowUserToAddRows = false;
            this.dataGridAreas.AllowUserToDeleteRows = false;
            this.dataGridAreas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAreas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAreas.Location = new System.Drawing.Point(-4, 0);
            this.dataGridAreas.Name = "dataGridAreas";
            this.dataGridAreas.ReadOnly = true;
            this.dataGridAreas.Size = new System.Drawing.Size(1107, 416);
            this.dataGridAreas.TabIndex = 0;
            this.dataGridAreas.UseWaitCursor = true;
            // 
            // tabPuestosList
            // 
            this.tabPuestosList.Controls.Add(this.dataGridPuestos);
            this.tabPuestosList.Location = new System.Drawing.Point(4, 22);
            this.tabPuestosList.Name = "tabPuestosList";
            this.tabPuestosList.Size = new System.Drawing.Size(1090, 412);
            this.tabPuestosList.TabIndex = 2;
            this.tabPuestosList.Text = "Puestos de Trabajo";
            this.tabPuestosList.UseVisualStyleBackColor = true;
            this.tabPuestosList.UseWaitCursor = true;
            // 
            // dataGridPuestos
            // 
            this.dataGridPuestos.AllowUserToAddRows = false;
            this.dataGridPuestos.AllowUserToDeleteRows = false;
            this.dataGridPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPuestos.Location = new System.Drawing.Point(0, 0);
            this.dataGridPuestos.Name = "dataGridPuestos";
            this.dataGridPuestos.ReadOnly = true;
            this.dataGridPuestos.Size = new System.Drawing.Size(1090, 412);
            this.dataGridPuestos.TabIndex = 0;
            this.dataGridPuestos.UseWaitCursor = true;
            // 
            // tabTrabajadoresList
            // 
            this.tabTrabajadoresList.Controls.Add(this.dataGridTrabajadores);
            this.tabTrabajadoresList.Location = new System.Drawing.Point(4, 22);
            this.tabTrabajadoresList.Name = "tabTrabajadoresList";
            this.tabTrabajadoresList.Size = new System.Drawing.Size(1090, 412);
            this.tabTrabajadoresList.TabIndex = 3;
            this.tabTrabajadoresList.Text = "Trabajadores";
            this.tabTrabajadoresList.UseVisualStyleBackColor = true;
            this.tabTrabajadoresList.UseWaitCursor = true;
            // 
            // dataGridTrabajadores
            // 
            this.dataGridTrabajadores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTrabajadores.Location = new System.Drawing.Point(-4, 0);
            this.dataGridTrabajadores.Name = "dataGridTrabajadores";
            this.dataGridTrabajadores.Size = new System.Drawing.Size(1094, 412);
            this.dataGridTrabajadores.TabIndex = 0;
            this.dataGridTrabajadores.UseWaitCursor = true;
            // 
            // tabDescSocio
            // 
            this.tabDescSocio.Controls.Add(this.dataGridDescSocio);
            this.tabDescSocio.Location = new System.Drawing.Point(4, 22);
            this.tabDescSocio.Name = "tabDescSocio";
            this.tabDescSocio.Size = new System.Drawing.Size(1090, 412);
            this.tabDescSocio.TabIndex = 7;
            this.tabDescSocio.Text = "Descripcion SocioDemografica";
            this.tabDescSocio.UseVisualStyleBackColor = true;
            this.tabDescSocio.UseWaitCursor = true;
            // 
            // dataGridDescSocio
            // 
            this.dataGridDescSocio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDescSocio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDescSocio.Location = new System.Drawing.Point(-4, 0);
            this.dataGridDescSocio.Name = "dataGridDescSocio";
            this.dataGridDescSocio.Size = new System.Drawing.Size(1098, 412);
            this.dataGridDescSocio.TabIndex = 1;
            this.dataGridDescSocio.UseWaitCursor = true;
            // 
            // Listados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 523);
            this.Controls.Add(this.tabsListados);
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.Name = "Listados";
            this.Text = "Listados";
            this.UseWaitCursor = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Listados_Load);
            this.tabsListados.ResumeLayout(false);
            this.tabHorarioList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataHorarios)).EndInit();
            this.tabAreaList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAreas)).EndInit();
            this.tabPuestosList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPuestos)).EndInit();
            this.tabTrabajadoresList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTrabajadores)).EndInit();
            this.tabDescSocio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDescSocio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsListados;
        private System.Windows.Forms.TabPage tabHorarioList;
        private System.Windows.Forms.DataGridView dataHorarios;
        private System.Windows.Forms.TabPage tabAreaList;
        private System.Windows.Forms.TabPage tabPuestosList;
        private System.Windows.Forms.TabPage tabTrabajadoresList;
        private System.Windows.Forms.DataGridView dataGridAreas;
        private System.Windows.Forms.DataGridView dataGridPuestos;
        private System.Windows.Forms.DataGridView dataGridTrabajadores;
        private System.Windows.Forms.TabPage tabDescSocio;
        private System.Windows.Forms.DataGridView dataGridDescSocio;
    }
}