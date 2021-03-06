﻿using GestorSGSST2017.ModeloDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017.Clases
{
    class Tabla
    {
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        public Tabla() { }

        public static void Horarios(DataGridView _gridView)
        {
            var query = (
                from H in contexto.horario
                select new 
                {
                    Nombre = H.nombre,
                    Inicio = H.fecha_inicio,
                    Fin = H.fecha_fin,
                    Empresa = H.empresa.nombre
                }).ToList();
            _gridView.DataSource = query;
        }

        public static void Areas(DataGridView _gridView)
        {
            var query = (
                from AR in contexto.area
                select new 
                {
                    ID = AR.id_area,
                    Nombre = AR.nombre,
                    AreaPadre = AR.id_area_padre == 0 ? "Ninguno" : (from AR1 in contexto.area where AR1.id_area == AR.id_area_padre select AR1.nombre).FirstOrDefault(),
                    Nivel1 = AR.nivel == 1 ? "" + AR.nivel : "---",
                    Nivel2 = AR.nivel == 2 ? "" + AR.nivel : "---",
                    Nivel3 = AR.nivel == 3 ? "" + AR.nivel : "---",
                    Nivel4 = AR.nivel == 4 ? "" + AR.nivel : "---",
                    Nivel = AR.nivel,
                    Empresa = AR.sucursal.empresa.nombre,
                    Sucursal = (from EM in contexto.sucursal where EM.id_sucursal == AR.id_sucursal select EM.nombre).FirstOrDefault(),
                    NumTrab = (from TB in contexto.trabajador where TB.puesto_trabajo.id_area == AR.id_area select TB.id_trabajador).Count()
                }
            ).ToList();
            _gridView.DataSource = query;
        }

        public static void Trabajadores(DataGridView _gridView)
        {
            var query = (
                from CT in contexto.trabajador
                join ES in contexto.estatus on CT.id_estatus_actual equals ES.id_estatus
                orderby CT.id_trabajador ascending
                select new
                {
                    ID = CT.id_trabajador,
                    Cedula = CT.cedula,
                    Nombres = CT.primer_nombre + " " + CT.segundo_nombre,
                    Apellidos = CT.primer_apellido + " " + CT.segundo_apellido,
                    Area = CT.puesto_trabajo.area.nombre,
                    Estatus = CT.id_estatus_actual == 0 ? "Sin estatus" : "" + ES.nombre,
                    Empresa = CT.puesto_trabajo.area.sucursal.empresa.nombre,                    
                    Sucursal = CT.puesto_trabajo.area.sucursal.nombre
                }).ToList();
            _gridView.DataSource = query;
        }

        public static void Puestos(DataGridView _gridView)
        {
            var query = (
                from CT in contexto.puesto_trabajo
                select new
                {
                    ID = CT.id_puesto_trabajo,
                    Nombre = CT.nombre,
                    Descripcion = CT.descripcion,
                    Empresa = CT.area.sucursal.empresa.nombre,
                    Area = CT.area.nombre,
                    NumTrabajadores = (from TB in contexto.trabajador where TB.id_puesto_trabajo == CT.id_puesto_trabajo select TB.id_trabajador).Count(),
                    Sucursal = CT.area.sucursal.nombre
                }).ToList();
            _gridView.DataSource = query;
        }

        public static void Riesgos(DataGridView _gridView)
        {
            var query = (
                from RS in contexto.riesgos
                select new
                {
                    ID = RS.id_riesgos,
                    FechaEvaluacion = RS.fecha_eva,                    
                    Empresa = RS.sucursal.empresa.nombre,
                    PuestoTrabajo = RS.puesto_trabajo.nombre,
                    Identificacion = RS.identificacion_riesgo,
                    Probabilidad = RS.probabilidad,
                    Severidad = RS.severidad,
                    ValorRiesgo = RS.valor_riesgo,
                    Prioridad = RS.prioridad.nombre,
                    Estatus = RS.estatus,
                    Medidas = ((RS.medidas_ambiente == "" && RS.medidas_fuente == "" && RS.medidas_trabajador == "") ? "Sin Medidas" : "Con Medidas")
                }).ToList();
            _gridView.DataSource = query;
        }

        public static void AccidentesIncidentes(DataGridView _gridView, int _tipo)
        {
            var query = (
                from AC in contexto.acc_inc_lab
                where AC.tipo_acci_inci == _tipo
                select new
                {
                    ID = AC.id_acc_lab,
                    FechaAccidente = AC.fecha_acc,
                    Trabajador = AC.trabajador.primer_nombre + " " + AC.trabajador.primer_apellido,
                    Area = AC.area.nombre != "0" ? "Ninguna" : " " + AC.area.nombre,
                    Empresa = AC.trabajador.puesto_trabajo.area.sucursal.empresa.nombre,
                    DocumentoEscaneado = AC.documento_escaneado,
                    Consulta = AC.num_consultas != "" ? "Con Consulta" : "Sin Consulta",
                    DocumentoComunicado = AC.documento_comunicado
                }).ToList();
            _gridView.DataSource = query;
        }

        public static void DescSocio(DataGridView _gridView)
        {
            var query = (
                from DS in contexto.desc_socio
                select new
                {
                    Cedula = DS.trabajador.cedula,
                    Trabajador = DS.trabajador.primer_nombre + " " + DS.trabajador.primer_apellido,
                    ID_DescSocio = DS.id_desc_socio,
                    Empresa = DS.trabajador.puesto_trabajo.area.sucursal.empresa.nombre                    
                }).ToList();
            _gridView.DataSource = query;
        }

    }
}
