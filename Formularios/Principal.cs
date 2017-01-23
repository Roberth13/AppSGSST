using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017.Formularios
{
    public partial class Principal : Form
    {
        string UsuarioID = string.Empty;
        CargaMasiva cmObj;
        Listados lsObj;
        

        public Principal()
        {
            InitializeComponent();
        }

        public Principal(string UsuarioID)
        {
            this.UsuarioID = UsuarioID;
            cmObj = new CargaMasiva(UsuarioID);
            lsObj = new Listados(UsuarioID);
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void cargaMasivaOpcion_Click(object sender, EventArgs e)
        {
            if (cmObj.IsDisposed)
            {
                cmObj = new CargaMasiva(UsuarioID);
                
            }
            cmObj.MdiParent = this;
            cmObj.Show();
        }

        private void listadosOpcion_Click(object sender, EventArgs e)
        {
            if (lsObj.IsDisposed)
            {
                lsObj = new Listados(UsuarioID);

            }
            lsObj.MdiParent = this;
            lsObj.Show();
        }

        private void salirOpcion_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
