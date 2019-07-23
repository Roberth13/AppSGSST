using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloDescSocio
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloDescSocio() { }

        ///<summary>Agrega un registro a la tabla DescSocio</summary>
        public static bool Add_DescSocio(int id_trabajador, string lugar_nac, string nivel_escol, string años_aprob, string cabeza_fam,
            string num_hijos, string repart_resp, string menores_dep, string cond_social, string mot_despl, string tipo_vivienda,
            string serv_pub, string sist_seg_soc, string reg_afiliacion, string nivel_sisben, int id_eps, string afi_sssp, int id_fondo,
            string afi_riesgo, string estrato, string vivienda, string industria, string ruido, string contaminacion,
            string descripcion, int _usu_bit, string _pagina)
        {
            bool bError = true;

            Tbl_Desc_socio nuevo = new Tbl_Desc_socio()
            {
                id_trabajador = id_trabajador,
                lugar_nac = lugar_nac,
                nivel_escolaridad = nivel_escol,
                años_aprob = años_aprob,
                cabeza_fam = cabeza_fam,
                num_hijos = num_hijos,
                repart_resp = repart_resp,
                menores_dep = menores_dep,
                cond_social = cond_social,
                mot_despl = mot_despl,
                tipo_vivienda = tipo_vivienda,
                serv_pub = serv_pub,
                sist_seg_soc = sist_seg_soc,
                reg_afiliacion = reg_afiliacion,
                nivel_sisben = nivel_sisben,
                id_eps = id_eps,
                afi_sssp = afi_sssp,
                id_afp = id_fondo,
                afi_riesgo = afi_riesgo,
                estrato = estrato,
                vivienda = vivienda,
                industria = industria,
                ruido = ruido,
                contaminacion = contaminacion,
                descripcion = descripcion
            };

            try
            {
                contexto.Tbl_Desc_socio.Add(nuevo);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                bError = false;
                bError = false;
            }
            if (bError)
            {
                ModeloBitacora.Add_Registro(DateTime.Now, _usu_bit, 1, _pagina, Convert.ToString(nuevo.ToString()));
            }
            return bError;
        }

        ///<summary>Agrega un registro de empleos Anteriores</summary>
        public static bool Add_EmpleoAnteriores(string empresa, string area, string cargo, string años, string meses, string enfermedades,
            int id_desc_socio, int _usu_bit, string _pagina)
        {
            bool bError = true;

            Tbl_Empleo_anterior nuevo = new Tbl_Empleo_anterior()
            {
                empresa = empresa,
                area = area,
                cargo = cargo,
                años = años,
                meses = meses,
                enfermedades = enfermedades,
                id_desc_socio = id_desc_socio
            };

            try
            {
                contexto.Tbl_Empleo_anterior.Add(nuevo);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                bError = false;
            }
            if (bError)
            {
                ModeloBitacora.Add_Registro(DateTime.Now, _usu_bit, 1, _pagina, Convert.ToString(nuevo.ToString()));
            }
            return bError;
        }
    }
}
