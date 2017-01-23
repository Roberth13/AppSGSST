using GestorSGSST2017.ModeloDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017.Clases
{
    class Listas
    {
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        public static void Empresa(ComboBox ddlEmpresa)
        {
            var Consulta = (from c in contexto.empresa
                            select new { c.id_empresa, c.nombre }).ToList();
            ddlEmpresa.ValueMember = "id_empresa";
            ddlEmpresa.DisplayMember = "nombre";
            ddlEmpresa.DataSource = Consulta;
        }

        public static void Sucursal(ComboBox ddlSucursal, int id_empresa)
        {
            var Consulta = (from c in contexto.sucursal.Where(x => x.id_empresa == id_empresa)
                            select new { c.id_sucursal, c.nombre }).ToList();
            ddlSucursal.ValueMember = "id_sucursal";
            ddlSucursal.DisplayMember = "nombre";
            ddlSucursal.DataSource = Consulta;
        }
    }
}
