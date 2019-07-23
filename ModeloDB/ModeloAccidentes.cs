using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloAccidentes
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloAccidentes() { }

        /*public static bool Add_Accidentes(int tipo, string grado, DateTime fecha_inv, DateTime hora_inv, int id_trabajador, int id_area,
        DateTime fecha_acc, DateTime hora_acc, int id_ips, int id_tipo_acc, int id_sit_acc, DateTime tiem_prev, string breve_desc,
        string desc_hechos, int id_puesto, int id_age_les, int id_prod_acc, int id_part_cuerpo, int id_form_acc,
        string eve_sim, string cuenta_mat, string cont_mat, string per_pres_acc, string sit_noclaras, string enc_sst,
        string int_copasst, string brigadista, string jefe_inme, string prof_salud_ocu, int _usu_bit, string _pagina)
        {
            bool bError = true;

            acc_inc_lab nuevo = new acc_inc_lab()
            {
                #region codigo
                tipo_acci_inci = tipo,
                grado = grado,
                fecha_inv = fecha_inv,
                hora_inv = hora_inv,
                id_trabajador = id_trabajador,
                id_area = id_area,
                fecha_acc = fecha_acc,
                hora_acc = hora_acc,
                id_ips = id_ips,
                id_tipo_acc = id_tipo_acc,
                id_sitio_acc = id_sit_acc,
                tiempo_prev_lab = tiem_prev,
                breve_desc = breve_desc,
                desc_hechos = desc_hechos,
                id_puesto_trabajo = id_puesto,
                id_agente_lesion = id_age_les,
                id_causa_accidente = id_prod_acc,
                id_parte_cuerpo = id_part_cuerpo,
                id_forma_acc = id_form_acc,
                eventos_similar = eve_sim,
                cuenta_matriz_riesgos = cuenta_mat,
                contemplado_matriz = cont_mat,
                personas_presenciaron_accidente = per_pres_acc,
                situaciones_noclaras = sit_noclaras,
                encargado_sst = enc_sst,
                integrante_copasst = int_copasst,
                brigadista = brigadista,
                jefe_inmediato = jefe_inme,
                prof_salud_ocu = prof_salud_ocu
                #endregion
            };

            try
            {
                contexto.acc_inc_lab.Add(nuevo);
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

        public static bool Add_Testigos(string nombre, string apellido, string cedula, string declaracion, int id_acc_lab
        , int _usu_bit, string _pagina)
        {
            bool bError = true;

            testigos nuevo = new testigos()
            {
                nombre = nombre,
                apellido = apellido,
                cedula = cedula,
                declaracion = declaracion,
                id_acc_lab = id_acc_lab
            };

            try
            {
                contexto.testigos.Add(nuevo);
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

        public static bool Add_Causas_inmediatas(string CondiciónSubestandar, string ActosSubestandar, int id_acc_lab,
        int _usu_bit, string _pagina)
        {
            bool bError = true;

            causas_inmediatas nuevo = new causas_inmediatas()
            {
                condicion_subestandar = CondiciónSubestandar,
                actos_subestandar = ActosSubestandar,
                id_acc_lab = id_acc_lab
            };

            try
            {
                contexto.causas_inmediatas.Add(nuevo);
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

        public static bool Add_Causas_basicas(string FactoresTrabajo, string FactoresPersonales,
        int id_acc_lab, int _usu_bit, string _pagina)
        {
            bool bError = true;

            causas_basicas nuevo = new causas_basicas()
            {
                factores_trabajo = FactoresTrabajo,
                factores_personales = FactoresPersonales,
                id_acc_lab = id_acc_lab
            };

            try
            {
                contexto.causas_basicas.Add(nuevo);
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


        public static bool Add_Compromisos(string CtrlMedInt, string FechaImplementacion, string Fuente, string Medio,
        string Persona, string Responsable, int id_acc_lab, int _usu_bit, string _pagina)
        {
            bool bError = true;

            compromisos nuevo = new compromisos()
            {
                controles = CtrlMedInt,
                fecha_implementacion = Convert.ToDateTime(FechaImplementacion),
                fuente = Fuente,
                medio = Medio,
                persona = Persona,
                responsable = Responsable,
                id_acc_lab = id_acc_lab
            };

            try
            {
                contexto.compromisos.Add(nuevo);
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
        }*/

    }
}
