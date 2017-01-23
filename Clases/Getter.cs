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
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        ///<summary>devuelve el id del area por su nombre</summary>
        public static int Area_Nombre(string nombre)
        {
            var consulta = new area();
            consulta = contexto.area.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_area;
        }

        ///<summary>devuelve el id del area por su nombre y sucursal</summary>
        public static int Area_Nombre(string nombre, int id_sucursal)
        {
            var consulta = new area();
            consulta = contexto.area.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.id_sucursal == id_sucursal).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_area;
        }

        ///<summary>devuelve el id del ccf por su nombre</summary>
        public static int Ccf_Nombre(string nombre)
        {
            var consulta = new ccf();
            consulta = contexto.ccf.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_ccf;
        }

        ///<summary>devuelve el id del municipio por su nombre</summary>
        public static int Municipio(string nombre)
        {
            var consulta = new municipio();
            consulta = contexto.municipio.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_municipio;
        }

        ///<summary>devuelve el id del puesto de trabajo por su nombre y sucursal</summary>
        public static int PuestoTrabajo(string nombre, int _id_sucursal)
        {
            var consulta = new puesto_trabajo();
            consulta = contexto.puesto_trabajo.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.area.id_sucursal == _id_sucursal).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_puesto_trabajo;
        }

        ///<summary>devuelve el id del horario por su nombre y empresa</summary>
        public static int Horario(string nombre, int _id_empresa)
        {
            var consulta = new horario();
            consulta = contexto.horario.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.empresa.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_horario;
        }

        ///<summary>devuelve el id del estatus por su nombre y empresa</summary>
        public static int Estatus(string nombre, int _id_empresa)
        {
            var consulta = new estatus();
            consulta = contexto.estatus.Where(x => x.nombre.ToUpper() == nombre.ToUpper() && x.empresa.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_estatus;
        }

        ///<summary>devuelve el id del usuario por su nombre completo</summary>
        public static int Usuario(string nombre)
        {
            var consulta = new usuario();
            consulta = contexto.usuario.Where(x =>  x.login.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_usuario;
        }

        ///<summary>devuelve el id del factor de riesgo por su nombre</summary>
        public static int FactorRiesgo(string nombre)
        {
            var consulta = new factor_riesgo();
            consulta = contexto.factor_riesgo.Where(x => x.nombre.ToUpper() == nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_factor_riesgo;
        }

        ///<summary>devuelve el id del trabajador por su numero de cedula</summary>
        public static int TrabajadorbyCedula(string _cedula)
        {
            var consulta = new trabajador();
            consulta = contexto.trabajador.Where(x => x.cedula == _cedula).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_trabajador;
        }

        ///<summary>devuelve el id del IPS por el nombre del beneficiario</summary>
        public static int IPS(string _beneficiario)
        {
            var consulta = new ips();
            consulta = contexto.ips.Where(x => x.beneficiario.ToUpper() == _beneficiario.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_ips;
        }

        ///<summary>devuelve el id del Tipo de accidente por el nombre y empresa</summary>
        public static int TipoAccidente(string _nombre, int _id_empresa)
        {
            var consulta = new tipo_accidente();
            consulta = contexto.tipo_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_tipo_acc;
        }

        ///<summary>devuelve el id del sitio del accidente por el nombre y empresa</summary>
        public static int SitioAccidente(string _nombre, int _id_empresa)
        {
            var consulta = new sitio_accidente();
            consulta = contexto.sitio_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_sitio_acc;
        }

        ///<summary>devuelve el id del agente de lesion por el nombre y empresa</summary>
        public static int AgenteLesion(string _nombre, int _id_empresa)
        {
            var consulta = new agente_lesion();
            consulta = contexto.agente_lesion.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_agente_lesion;
        }

        ///<summary>devuelve el id de la Causa del Accidente por el nombre y empresa</summary>
        public static int CausaAccidente(string _nombre, int _id_empresa)
        {
            var consulta = new causa_accidente();
            consulta = contexto.causa_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_causa_acc;
        }

        ///<summary>devuelve el id de la parte del cuerpo por el nombre y empresa</summary>
        public static int ParteCuerpo(string _nombre, int _id_empresa)
        {
            var consulta = new parte_cuerpo();
            consulta = contexto.parte_cuerpo.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_parte_cuerpo;
        }

        ///<summary>devuelve el id de la forma del accidente por el nombre y empresa</summary>
        public static int FormaAccidente(string _nombre, int _id_empresa)
        {
            var consulta = new forma_accidente();
            consulta = contexto.forma_accidente.Where(x => x.nombre.ToUpper() == _nombre.ToUpper() && x.id_empresa == _id_empresa).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_forma_acc;
        }

        ///<summary>devuelve el id de la EPS por el nombre</summary>
        public static int Eps(string _nombre)
        {
            var consulta = new eps();
            consulta = contexto.eps.Where(x => x.nombre.ToUpper() == _nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_eps;
        }

        ///<summary>devuelve el id de la AFP por el nombre</summary>
        public static int Afp(string _nombre)
        {
            var consulta = new afp();
            consulta = contexto.afp.Where(x => x.nombre.ToUpper() == _nombre.ToUpper()).SingleOrDefault();
            if (consulta == null)
                return 0;
            else
                return consulta.id_afp;
        }

        ///<sumary>Devuelve el ultimo ID de la tabla accidentes</sumary>
        public static int MaxAccidentes()
        {
            var consulta = new acc_inc_lab();
            int id = contexto.acc_inc_lab.Max(x => x.id_acc_lab);
            return id;
        }

        ///<sumary>Devuelve el ultimo ID de la tabla desc_socio</sumary>
        public static int MaxDescSocio()
        {
            var consulta = new desc_socio();
            int id = contexto.desc_socio.Max(x => x.id_desc_socio);
            return id;
        }

        public static bool ValidaCedula(string _cedula)
        {
            var consulta = new trabajador();
            consulta = contexto.trabajador.Where(x => x.cedula == _cedula).SingleOrDefault();
            if (consulta == null)
                return false;
            else
                return true;
        }
    }
}
