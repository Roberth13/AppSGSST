using GestorSGSST2017.ModeloDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.Clases
{
    class Getter
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        ///<summary>devuelve el id del area por su nombre</summary>
        public static int Area_Nombre(string nombre)
        {
            var consulta = new Tbl_Area();
            consulta = contexto.Tbl_Area.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_area;
        }

        ///<summary>devuelve el id del area por su nombre y sucursal</summary>
        public static int Area_Nombre(string nombre, int id_sucursal)
        {
            var consulta = new Tbl_Area();
            consulta = contexto.Tbl_Area.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.id_sucursal == id_sucursal).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_area;
        }

        ///<summary>devuelve el id del ccf por su nombre</summary>
        public static int Ccf_Nombre(string nombre)
        {
            var consulta = new Tbl_Ccf();
            consulta = contexto.Tbl_Ccf.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_ccf;
        }

        ///<summary>devuelve el id del municipio por su nombre</summary>
        public static int Municipio(string nombre)
        {
            var consulta = new Tbl_Municipio();
            consulta = contexto.Tbl_Municipio.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_municipio;
        }

        ///<summary>devuelve el id del puesto de trabajo por su nombre y sucursal</summary>
        public static int PuestoTrabajo(string nombre, int _id_sucursal)
        {
            var consulta = new Tbl_Puesto_trabajo();
            consulta = contexto.Tbl_Puesto_trabajo.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.Tbl_Area.id_sucursal == _id_sucursal).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_puesto_trabajo;
        }

        ///<summary>devuelve el id del horario por su nombre y empresa</summary>
        public static int Horario(string nombre, int _id_empresa)
        {
            var consulta = new Tbl_Horario();
            consulta = contexto.Tbl_Horario.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.Tbl_Empresa.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_horario;
        }

        ///<summary>devuelve el id del estatus por su nombre y empresa</summary>
        public static int Estatus(string nombre, int _id_empresa)
        {
            var consulta = new Tbl_Estatus();
            consulta = contexto.Tbl_Estatus.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.Tbl_Empresa.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_estatus;
        }

        ///<summary>devuelve el id del usuario por su nombre completo</summary>
        public static int Usuario(string nombre)
        {
            var consulta = new Tbl_Usuario();
            consulta = contexto.Tbl_Usuario.Where(x =>  x.login.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_usuario;
        }

        ///<summary>devuelve el id del factor de riesgo por su nombre</summary>
        public static int FactorRiesgo(string nombre)
        {
            var consulta = new Tbl_Factor_riesgo();
            consulta = contexto.Tbl_Factor_riesgo.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_factor_riesgo;
        }

        ///<summary>devuelve el id del trabajador por su numero de cedula</summary>
        public static int TrabajadorbyCedula(string _cedula)
        {
            var consulta = new Tbl_Trabajador();
            consulta = contexto.Tbl_Trabajador.Where(x => x.cedula == _cedula).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_trabajador;
        }

        ///<summary>devuelve el id del puesto de trabajo de un empleado </summary>
        public static int PuestobyTrabajador(int _id_trabajador)
        {
            var consulta = new Tbl_Trabajador();
            consulta = contexto.Tbl_Trabajador.Where(x => x.id_trabajador == _id_trabajador).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_puesto_trabajo;
        }

        ///<summary>devuelve el id del puesto de trabajo de un empleado </summary>
        public static int AreabyPuesto(int _id_puesto)
        {
            var consulta = new Tbl_Puesto_trabajo();
            consulta = contexto.Tbl_Puesto_trabajo.Where(x => x.id_puesto_trabajo == _id_puesto).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_area;
        }

        ///<summary>devuelve el id del IPS por el nombre del beneficiario</summary>
        public static int IPS(string _beneficiario)
        {
            var consulta = new Tbl_Ips();
            consulta = contexto.Tbl_Ips.Where(x => x.beneficiario.ToUpper() == _beneficiario.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_ips;
        }

        ///<summary>devuelve el id del Tipo de accidente por el nombre y empresa</summary>
        public static int TipoAccidente(string _nombre, int _id_empresa)
        {
            /*var consulta = new acc();
            consulta = contexto.tipo_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_tipo_acc;*/
            return 0;
        }

        ///<summary>devuelve el id del sitio del accidente por el nombre y empresa</summary>
        public static int SitioAccidente(string _nombre, int _id_empresa)
        {
            /*var consulta = new sitio_accidente();
            consulta = contexto.sitio_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_sitio_acc;*/

            return 0;
        }

        ///<summary>devuelve el id del agente de lesion por el nombre y empresa</summary>
        public static int AgenteLesion(string _nombre, int _id_empresa)
        {
            /*var consulta = new agente_lesion();
            consulta = contexto.agente_lesion.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_agente_lesion;*/
            return 0;
        }

        ///<summary>devuelve el id de la Causa del Accidente por el nombre y empresa</summary>
        public static int CausaAccidente(string _nombre, int _id_empresa)
        {
            /*var consulta = new causa_accidente();
            consulta = contexto.causa_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_causa_acc;*/
            return 0;
        }

        ///<summary>devuelve el id de la parte del cuerpo por el nombre y empresa</summary>
        public static int ParteCuerpo(string _nombre, int _id_empresa)
        {
            /*var consulta = new parte_cuerpo();
            consulta = contexto.parte_cuerpo.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_parte_cuerpo;*/
            return 0;
        }

        ///<summary>devuelve el id de la forma del accidente por el nombre y empresa</summary>
        public static int FormaAccidente(string _nombre, int _id_empresa)
        {
            /*var consulta = new forma_accidente();
            consulta = contexto.forma_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_forma_acc;*/
            return 0;
        }

        ///<summary>devuelve el id de la EPS por el nombre</summary>
        public static int Eps(string _nombre)
        {
            var consulta = new Tbl_Eps();
            consulta = contexto.Tbl_Eps.Where(x => x.nombre.ToUpper() == _nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_eps;
        }

        ///<summary>devuelve el id de la AFP por el nombre</summary>
        public static int Afp(string _nombre)
        {
            var consulta = new Tbl_Afp();
            consulta = contexto.Tbl_Afp.Where(x => x.nombre.ToUpper() == _nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_afp;
        }

        ///<sumary>Devuelve el ultimo ID de la tabla accidentes</sumary>
        public static int MaxAccidentes()
        {
            /*var consulta = new acc_inc_lab();
            int id = contexto.acc_inc_lab.Max(x => x.id_acc_lab);
            return id;*/
            return 0;
        }

        ///<sumary>Devuelve el ultimo ID de la tabla desc_socio</sumary>
        public static int MaxDescSocio()
        {
            var consulta = new Tbl_Desc_socio();
            int id = contexto.Tbl_Desc_socio.Max(x => x.id_desc_socio);
            return id;
        }

        public static bool ValidaCedula(string _cedula)
        {
            var consulta = new Tbl_Trabajador();
            consulta = contexto.Tbl_Trabajador.Where(x => x.cedula == _cedula).SingleOrDefault();
            if (consulta == null)
                return false;
            else
                return true;
        }
    }
}
