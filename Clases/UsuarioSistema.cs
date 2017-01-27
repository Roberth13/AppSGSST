using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.Clases
{
    class UsuarioSistema
    {
        string Rol = string.Empty;
        public UsuarioSistema(string _Rol)
        {
            Rol = _Rol;
        }

        public bool isAdm_Grupoli()
        {
            if (Rol == "1")
            {
                return true;
            }
            return false;
        }
        public bool isAdm_Empresa()
        {
            if (Rol == "2")
            {
                return true;
            }
            return false;
        }
        public bool isAdm_Sucursal()
        {
            if (Rol == "3")
            {
                return true;
            }
            return false;
        }
        public bool isAdmEmp_DptoSeg()
        {
            if (Rol == "4")
            {
                return true;
            }
            return false;
        }
        public bool isAdmEmp_DptoSalud()
        {
            if (Rol == "6")
            {
                return true;
            }
            return false;
        }
        public bool isAdm_SucSeg()
        {
            if (Rol == "5")
            {
                return true;
            }
            return false;
        }
        public bool isAdm_SucSalud()
        {
            if (Rol == "7")
            {
                return true;
            }
            return false;
        }
        public bool isResponsable()
        {
            if (Rol == "8")
            {
                return true;
            }
            return false;
        }
    }
}
