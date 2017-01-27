using GestorSGSST2017.Clases;
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
    public partial class Listados : Form
    {
        string UsuarioID = string.Empty;
        private string RolID;
        private string EmpresaID;
        private string SucursalID;
        private bool esAdmin;
        public Listados()
        {
            InitializeComponent();
        }
        public Listados(string UsuarioID)
        {
            InitializeComponent();
            this.UsuarioID = UsuarioID;
        }

        public Listados(string UsuarioID, string RolID, string EmpresaID, string SucursalID, bool esAdmin)
        {
            // TODO: Complete member initialization
            this.UsuarioID = UsuarioID;
            this.RolID = RolID;
            this.EmpresaID = EmpresaID;
            this.SucursalID = SucursalID;
            this.esAdmin = esAdmin;
        }

        public void UbicacionCentral()
        {
            tabsListados.Location = new System.Drawing.Point(
            this.ClientSize.Width / 2 - tabsListados.Size.Width / 2,
            this.ClientSize.Height / 2 - tabsListados.Size.Height / 2);
            tabsListados.Anchor = AnchorStyles.None;
        }

        public void cargarData() 
        {
            Tabla.Horarios(dataHorarios);
            Tabla.Areas(dataGridAreas);
            Tabla.Trabajadores(dataGridTrabajadores);
            Tabla.Puestos(dataGridPuestos);
            Tabla.Riesgos(dataGridRiesgos);
            Tabla.AccidentesIncidentes(dataGridAccidentes, 1);
            Tabla.AccidentesIncidentes(dataGridIncidentes, 2);
            Tabla.DescSocio(dataGridDescSocio);
        }

        private void Listados_Load(object sender, EventArgs e)
        {
            UbicacionCentral();
            cargarData();
        }

        private void dataHorarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
