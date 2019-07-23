using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloTrabajador
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloTrabajador() { }

        ///<summary>Agrega informacion a la tabla Trabajador</summary>
        ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
        ///<param name="_cedula">cedula del trabajador</param>
        ///<param name="_primer_nombre">primer nombre del trabajador</param>
        ///<param name="_segundo_nombre">segundo nombre del trabajador</param>
        ///<param name="_primer_apellido">primer apellido del trabajador</param>
        ///<param name="_segundo_apellido">segundo apellido del trabajador</param>
        ///<param name="_email">email del trabajador</param>
        ///<param name="_fecha_nacimiento">Fecha de nacimiento del trabajador/param>
        ///<param name="_edo_civil">Edo civil del trabajador</param>
        ///<param name="_sexo">Sexo del trabajador</param>
        ///<param name="_foto">Ruta de la foto del trabajador</param>
        ///<param name="_telefono_casa">telefono de casa  del trabajador</param>
        ///<param name="_telefono_movil">telefono movil  del trabajador</param>
        ///<param name="_activo">estatus del trabajador</param>
        ///<param name="_id_ccf">ccf del trabajador</param>
        ///<param name="_direccion">Direccion del trabajador</param>
        ///<param name="_id_municipio">id del municipio del trabajador</param>
        ///<param name="_id_puesto_trabajo">id del puesto de trabajo del trabajador</param>
        ///<param name="_es_discapacitado">discapacidad del  del trabajador</param>
        ///<param name="_desc_discapacidad">descripcion de la discapacidad del trabajador</param>
        ///<param name="_id_horario">id del horario del trabajador</param>
        ///<param name="_id_estatus_actual">id estatus actual del trabajador</param>
        public static bool Add_Trabajador(string _cedula, string _primer_nombre, string _segundo_nombre, string _primer_apellido,
            string _segundo_apellido, string _email, DateTime _fecha_nacimiento, string _edo_civil, string _sexo, string _foto,
            string _telefono_casa, string _telefono_movil, int _activo, int _id_ccf, string _direccion, int _id_municipio,
            int _id_puesto_trabajo, string _es_discapacitado, string _desc_discapacidad, int _id_horario, int _id_estatus_actual
           , int _usu_bit, string _pagina)
        {
            bool bError = true;

            Tbl_Trabajador nuevo = new Tbl_Trabajador()
            {
                #region codigo
                cedula = _cedula,
                primer_nombre = _primer_nombre,
                segundo_nombre = _segundo_nombre,
                primer_apellido = _primer_apellido,
                segundo_apellido = _segundo_apellido,
                email = _email,
                fecha_nacimiento = _fecha_nacimiento,
                edo_civil = _edo_civil,
                sexo = _sexo,
                foto = _foto,
                telefono_casa = _telefono_casa,
                telefono_movil = _telefono_movil,
                activo = _activo,
                id_ccf = _id_ccf,
                direccion = _direccion,
                id_municipio = _id_municipio,
                id_puesto_trabajo = _id_puesto_trabajo,
                es_discapacitado = _es_discapacitado,
                desc_discapacidad = _desc_discapacidad,
                id_horario = _id_horario,
                id_estatus_actual = _id_estatus_actual
                #endregion
            };

            try
            {
                contexto.Tbl_Trabajador.Add(nuevo);
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
