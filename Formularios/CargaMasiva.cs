using GestorSGSST2017.Clases;
using GestorSGSST2017.ModeloDB;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017.Formularios
{
    public partial class CargaMasiva : Form
    {
        string UsuarioID;
        UsuarioSistema us;
        ProgressBar _progress_bar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private string RolID;
        private string EmpresaID;
        private string SucursalID;
        private bool esAdmin;
        string msj = string.Empty;
        StreamWriter escritor;

        private void Calculate(int i)
        {
            double pow = Math.Pow(i, i);
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var backgroundWorker = sender as BackgroundWorker;
            for (int j = 0; j < 100000; j++)
            {
                Calculate(j);
                backgroundWorker.ReportProgress((j * 100) / 100000);
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _progress_bar.Value = e.ProgressPercentage;
        }

        #region Inicializacion
        public CargaMasiva()
        {
            InitializeComponent();
            UbicacionCentral();
        }

        public CargaMasiva(string UsuarioID, string RolID, string EmpresaID, string SucursalID, bool esAdmin)
        {
            // TODO: Complete member initialization
            this.UsuarioID = UsuarioID;
            this.RolID = RolID;
            this.EmpresaID = EmpresaID;
            this.SucursalID = SucursalID;
            this.esAdmin = esAdmin;

            InitializeComponent();
            UbicacionCentral();
        }

        public void UbicacionCentral()
        {
            tabsCargaMasiva.Location = new System.Drawing.Point(
            this.ClientSize.Width / 2 - tabsCargaMasiva.Size.Width / 2,
            this.ClientSize.Height / 2 - tabsCargaMasiva.Size.Height / 2);
            tabsCargaMasiva.Anchor = AnchorStyles.None;
            //El Usuario es Administrador..
            Listas.Empresa(ddlEmpresasHorario);
            Listas.Empresa(ddlEmpresaArea);
            Listas.Sucursal(ddlSucursalArea, 1);
            Listas.Empresa(ddlEmpresaPuesto);
            Listas.Sucursal(ddlSucursalPuesto, 1);
            Listas.Empresa(ddlEmpresasTrab);
            Listas.Sucursal(ddlSucursalTrab, 1);
            Listas.Empresa(ddlEmpresasRiesgos);
            Listas.Sucursal(ddlSucursalRiesgos, 1);
            us = new UsuarioSistema(RolID);
            if (!esAdmin)
            {
                if (us.isAdm_Empresa())
                {
                    ddlEmpresasHorario.SelectedValue = EmpresaID;
                    ddlEmpresaArea.SelectedValue = EmpresaID;
                    ddlEmpresaPuesto.SelectedValue = EmpresaID;
                    ddlEmpresasTrab.SelectedValue = EmpresaID;
                    ddlEmpresasRiesgos.SelectedValue = EmpresaID;
                    Listas.Sucursal(ddlSucursalArea, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalPuesto, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalTrab, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalRiesgos, Convert.ToInt32(EmpresaID));
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
                    ddlEmpresasRiesgos.Enabled = false;
                }
                else if (us.isAdm_Sucursal())
                {
                    ddlEmpresasHorario.SelectedValue = EmpresaID;
                    ddlEmpresaArea.SelectedValue = EmpresaID;
                    ddlEmpresaPuesto.SelectedValue = EmpresaID;
                    ddlEmpresasTrab.SelectedValue = EmpresaID;
                    ddlSucursalArea.SelectedValue = SucursalID;
                    ddlSucursalPuesto.SelectedValue = SucursalID;
                    ddlSucursalTrab.SelectedValue = SucursalID;
                    ddlSucursalRiesgos.SelectedValue = SucursalID;
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
                    ddlSucursalArea.Enabled = false;
                    ddlSucursalPuesto.Enabled = false;
                    ddlSucursalTrab.Enabled = false;
                    ddlSucursalRiesgos.Enabled = false;
                }
            }
            
        }

        private void CargaMasiva_Load(object sender, EventArgs e)
        {

        }
        
        #endregion

        #region Carga de Horarios
        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoHorarios.Text != "")
            {
                string nombreArchivo = CargaArchivos("Horarios");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Horarios.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "INFO");
                    cargaHorarios(nombreArchivo);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void cargaHorarios(string archivoNombre)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;
            string id_empresa = "";
            if (us.isAdm_Empresa())
            {
                id_empresa = EmpresaID;
            }
            else if (us.isAdm_Sucursal())
            {
                id_empresa = EmpresaID;
            }
            else
            {
                id_empresa = ddlEmpresasHorario.SelectedValue.ToString();
            }
            string[] str = new string[3];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(archivoNombre, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        msj = DateTime.Now + ": Agregando el registro Nro." +(rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "INFO");
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {                            
                            if (pos == 1 || pos == 2)
                            {
                                double numero = 0;
                                try
                                {
                                    numero = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                    DateTime hora1 = DateTime.FromOADate(numero);
                                    str[pos] = hora1.ToString("HH:mm");
                                }
                                catch (Exception ex)
                                {
                                    msj = DateTime.Now + ": Error al convertir el valor."+str[pos]+" a formato de Horas.";
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                                }     
                            }
                            else
                            {
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            pos++;
                        }
                        if (str[0].Length > 0)
                        {
                            if (str[0].Length < 50)
                            {
                                if (str[1] != null)
                                {                                    
                                    if (str[2] != null)
                                    {
                                        ModeloHorario.Add_Horario(str[0], str[1], str[2], Convert.ToInt32(id_empresa), Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                        msj = DateTime.Now + ": Se agrego el registro Nro." +(rCnt - 1);
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "EXITO");
                                    }
                                    else
                                    {
                                        msj = DateTime.Now + ": La fecha final no es valida." + cCnt;
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                                    }
                                }
                                else
                                {
                                    msj = DateTime.Now + ": La fecha inicial no es valida." + cCnt;
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                                }
                            }
                            else
                            {
                                msj = DateTime.Now + ": El nombre del Horario es muy largo ." + cCnt;
                                Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                            }
                        }
                        else 
                        {
                            msj = DateTime.Now + ": El nombre del Horario es muy corto ." + cCnt;
                            Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                        }
                        
                        pos = 0;
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de los horarios con exito.");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La Cantidad de Columnas No Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }

        private void limpiarCampos()
        {
            txtArchivoHorarios.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoHorarios.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoHorarios.Text = ArchivoHorarios.FileName;
            }
        }

        #endregion

        #region Release
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        private string CargaArchivos(string Modulo)
        {
            string[] nombreArchivo;
            string archivoNombre = string.Empty;
            string fullpath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);
            DirectoryInfo df = new DirectoryInfo(fullpath + @"\Archivos\");
            FileInfo fi;
            if (!df.Exists)
            {
                DirectoryInfo di = Directory.CreateDirectory(fullpath + @"\Archivos\");
            }
            fullpath = fullpath + "/Archivos/";
            OpenFileDialog ofdArchivo = null;
            if (Modulo == "Horarios")
            {
                nombreArchivo = ArchivoHorarios.FileName.Split('\\');
                ofdArchivo = ArchivoHorarios;
            }
            else if (Modulo == "Areas")
            {
                nombreArchivo = ArchivoAreas.FileName.Split('\\');
                ofdArchivo = ArchivoAreas;
            }
            else if (Modulo == "Puestos")
            {
                nombreArchivo = ArchivoPuestos.FileName.Split('\\');
                ofdArchivo = ArchivoPuestos;
            }
            else if (Modulo == "Trabajadores")
            {
                nombreArchivo = ArchivoTrabajadores.FileName.Split('\\');
                ofdArchivo = ArchivoTrabajadores;
            }
            else if (Modulo == "Riesgos")
            {
                nombreArchivo = ArchivoRiesgos.FileName.Split('\\');
                ofdArchivo = ArchivoRiesgos;
            }
            else if (Modulo == "Accidentes")
            {
                nombreArchivo = ArchivoAcc.FileName.Split('\\');
                ofdArchivo = ArchivoAcc;
            }
            else if (Modulo == "DescSocio")
            {
                nombreArchivo = ArchivoAcc.FileName.Split('\\');
                ofdArchivo = ArchivoDesc;
            }

            foreach (string archivo in ofdArchivo.FileNames)
            {
                nombreArchivo = archivo.Split('\\');
                archivoNombre = fullpath + nombreArchivo[nombreArchivo.Length - 1];
                if (File.Exists(archivoNombre))
                {
                    File.Delete(archivoNombre);
                }
                File.Copy(archivo, archivoNombre);
            }
            fi = new FileInfo(archivoNombre);
            if (Utilidades1.isExcel(fi.Extension))
            {
                return archivoNombre;
            }
            else
            {
                msj = DateTime.Now + ": La extension del Archivo no es Valida.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogHorarios, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
                MessageBox.Show("Error: La extension del Archivo no es Valida.");
                fi.Delete();
                return null;
            }
        }
        #endregion

        #region Areas
        private void ddlEmpresaArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalArea, Convert.ToInt32(ddlEmpresaArea.SelectedValue));
        }       

        private void btnCargarArea_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtCargarArea.Text != "")
            {
                string nombreArchivo = CargaArchivos("Areas");
                if(nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Areas.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "INFO");
                    cargaAreas(nombreArchivo);
                }
                    
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void cargaAreas(string archivoNombre)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string id_sucursal = "";
            if (us.isAdm_Empresa())
            {
                id_sucursal = ddlSucursalArea.SelectedValue.ToString();
            }
            else if (us.isAdm_Sucursal())
            {
                id_sucursal = SucursalID;
            }
            else
            {
                id_sucursal = ddlSucursalArea.SelectedValue.ToString();
            }
            string[] str = new string[3];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            int _nivel = 1;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(archivoNombre, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        msj = DateTime.Now + ": Agregando el registro Nro." + (rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "INFO");
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            if (pos == 0 || pos == 1)
                            {
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            else if (pos == 2)
                            {
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                               /* if (str[pos] == "Ninguna")
                                {
                                    str[pos] = "0";
                                    _nivel = 1;
                                }
                                else
                                {
                                    int id = Getter.Area_Nombre(str[pos], Convert.ToInt32(id_sucursal));
                                    int nivel = Getter.Area_Nivel_Nombre(str[pos], Convert.ToInt32(id_sucursal));
                                    _nivel = nivel + 1;
                                    str[pos] = id.ToString();
                                }*/
                            }
                            pos++;
                        }
                        if (str[2] == "Ninguna")
                        {
                            str[2] = "0";
                            _nivel = 1;
                            ModeloArea.Add_Area(str[0], Convert.ToInt32(id_sucursal), str[1], Convert.ToInt32(str[2]), _nivel, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                            msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                            Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "EXITO");
                        }
                        else
                        {
                            int id_area = Getter.Area_Nombre(str[2], Convert.ToInt32(id_sucursal));
                            if(id_area > 0)
                            {
                                int nivel = Getter.Area_Nivel_Nombre(str[2], Convert.ToInt32(id_sucursal));
                                _nivel = nivel + 1;
                                str[2] = id_area.ToString();
                                ModeloArea.Add_Area(str[0], Convert.ToInt32(id_sucursal), str[1], Convert.ToInt32(str[2]), _nivel, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "EXITO");
                            }
                            else
                            {
                                msj = DateTime.Now + ": El area "+ str[2] +" no existe para la sucursal seleccionada.";
                                Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "EXITO");
                            }
                        }                      
                       
                        pos = 0;
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de las Areas con exito.");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La Cantidad de Columnas No Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }

        private void btnBuscarArea_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoAreas.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtCargarArea.Text = ArchivoAreas.FileName;
            }
        }

        #endregion

        #region puestos de trabajo
        private void btnBuscarPuesto_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoPuestos.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoPuesto.Text = ArchivoPuestos.FileName;
            }
        }

        private void btnCargarPuesto_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoPuesto.Text != "")
            {
                string nombreArchivo = CargaArchivos("Puestos");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Puestos de Trabajo.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "INFO");
                    cargaPuestos(nombreArchivo);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void cargaPuestos(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string id_sucursal = "";
            if (us.isAdm_Empresa())
            {
                id_sucursal = ddlEmpresaPuesto.SelectedValue.ToString();
            }
            else if (us.isAdm_Sucursal())
            {
                id_sucursal = SucursalID;
            }
            else
            {
                id_sucursal = ddlSucursalPuesto.SelectedValue.ToString();
            }
            string[] str = new string[3];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        msj = DateTime.Now + ": Agregando el registro Nro." + (rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "INFO");
                        try
                        {
                            for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                            {                                
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                if (pos == 2)
                                {
                                    str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                }
                                pos++;
                            }
                            try
                            {
                                int id_area = Getter.Area_Nombre(str[2], Convert.ToInt32(id_sucursal));
                                if(id_area > 0)
                                {
                                    if (str[0] != null)
                                    {
                                        ModeloPuesto.Add_PuestoTrabajo(str[0], str[1], id_area, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                        msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "EXITO");
                                    }
                                    else
                                    {
                                        msj = DateTime.Now + ": El nombre del puesto de trabajo no  puede estar vacio";
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                                    }
                                }
                                else
                                {
                                    msj = DateTime.Now + ": El area " +str[2]+" no se encuentra en el sistema";
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                                }
                                
                                pos = 0;
                            }
                            catch (Exception ex)
                            {
                                msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1);
                                Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                            }
                            
                        }
                        catch (Exception ex)
                        {
                            msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1);
                            Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                        }
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de los Puestos de Trabajo con exito.");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La Cantidad de Columnas No Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }

        private void ddlEmpresaPuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalPuesto, Convert.ToInt32(ddlEmpresaPuesto.SelectedValue));
        }
        #endregion

        #region Trabajadores
        private void ddlEmpresasTrab_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalTrab, Convert.ToInt32(ddlEmpresasTrab.SelectedValue));
        }

        private void btnBuscarTrab_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoTrabajadores.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoTrab.Text = ArchivoTrabajadores.FileName;
            }
        }

        private void btnCargarTrab_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoTrab.Text != "")
            {
                string nombreArchivo = CargaArchivos("Trabajadores");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Trabajadores.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "INFO");
                    cargaTrabajadores(nombreArchivo);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }

        }

        private void cargaTrabajadores(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;
            int id_ccf = 0;
            int id_puesto = 0;
            int id_horario = 0;
            int id_municipio = 0;

            string id_sucursal = "";
            string id_empresa = "";
            if (us.isAdm_Empresa())
            {
                id_sucursal = ddlSucursalTrab.SelectedValue.ToString();
                id_empresa = EmpresaID;
            }
            else if (us.isAdm_Sucursal())
            {
                id_sucursal = SucursalID;
                id_empresa = EmpresaID;
            }
            else
            {
                id_sucursal = ddlSucursalTrab.SelectedValue.ToString();
                id_empresa = ddlEmpresasTrab.SelectedValue.ToString();
            }

            string[] str = new string[15];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        try
                        {
                            msj = DateTime.Now + ": Agregando el registro Nro." + (rCnt - 1);
                            Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "INFO");
                            DateTime fecha_nacimiento = DateTime.Today;
                            for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                            {
                                if (pos == 0)
                                {
                                    int cedula = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                    str[pos] = cedula.ToString();
                                }
                                else if (pos == 6 || pos == 9 || pos == 10)
                                {
                                    double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);                                   
                                    if (pos == 6)
                                    {
                                        fecha_nacimiento = DateTime.FromOADate(fecha_n);
                                    }
                                    else
                                    {
                                        str[pos] = fecha_n.ToString();
                                    }
                                }
                                else 
                                {
                                    string cadena = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    if (cadena == null)
                                        cadena = "''";
                                    str[pos] = cadena;
                                }
                                pos++;
                            }

                            try
                            {
                                id_ccf = Getter.Ccf_Nombre(str[11]);
                                id_municipio = Getter.Municipio(str[12]);
                                id_puesto = Getter.PuestoTrabajo(str[13], Convert.ToInt32(id_sucursal));
                                id_horario = Getter.Horario(str[14], Convert.ToInt32(id_empresa));

                                if(!Getter.ValidaCedula(str[0]))
                                {
                                    if(id_ccf > 0)
                                    {
                                        if(id_municipio > 0)
                                        {
                                            if(id_puesto > 0)
                                            {
                                                if(id_horario > 0)
                                                {
                                                    ModeloTrabajador.Add_Trabajador(str[0], str[1], str[2], str[3], str[4], str[5],
                                                    fecha_nacimiento, str[7], str[8], "'foto'", str[9], str[10], 1,
                                                    Convert.ToInt32(str[11]), Convert.ToInt32(str[12]),
                                                    Convert.ToInt32(str[13]), Convert.ToInt32(str[14]),
                                                    Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");

                                                    msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "EXITO");
                                                }
                                                else
                                                {
                                                    msj = DateTime.Now + ": El Horario:" + str[14] + " no pertenece a la empresa seleccionada.";
                                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                                    msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                                }
                                            }
                                            else
                                            {
                                                msj = DateTime.Now + ": El Puesto de trabajo:" + str[13] + " no pertenece a la sucursal seleccionada.";
                                                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                                msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                            }
                                        }
                                        else
                                        {
                                            msj = DateTime.Now + ": El Municipio:" + str[12] + " no se encuentra registrado en el sistema.";
                                            Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                            msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                            Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                        }
                                    }
                                    else
                                    {
                                        msj = DateTime.Now + ": El CCF:" + str[11] + " no se encuentra registrada en el sistema.";
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                        msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                    }                                    
                                }
                                else
                                {
                                    msj = DateTime.Now + ": La cédula de trabajador:"+ str[0] +" ya se encuentra registrada en el sistema.";
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                    msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                                }
                                pos = 0;
                            }
                            catch (Exception ex)
                            {
                                //Error en algun dato del registro...
                                pos = 0;
                                msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1)+ "ERROR: "+ex.Message;
                                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                            }

                        }
                        catch (Exception ex1)
                        { 
                            //Error en la linea....
                            pos = 0;
                            msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1) + "ERROR: " + ex1.Message;
                            Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                        }
                                               

                        
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de los Trabajadores con exito.");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La Cantidad de Columnas No Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }
        #endregion

        #region Riesgos
        private void ddlEmpresasRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalRiesgos, Convert.ToInt32(ddlEmpresasRiesgos.SelectedValue));
        }

        private void btnBuscarRiesgo_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoRiesgos.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoRiesgos.Text = ArchivoRiesgos.FileName;
            }
        }

        private void btnCargarRiesgo_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoRiesgos.Text != "")
            {
                string nombreArchivo = CargaArchivos("Riesgos");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Riesgos.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "INFO");
                    cargaRiesgos(nombreArchivo);
                }                    
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void cargaRiesgos(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string id_sucursal = "";
            string id_empresa = "";
            if (us.isAdm_Empresa())
            {
                id_sucursal = ddlSucursalRiesgos.SelectedValue.ToString();
                id_empresa = EmpresaID;
            }
            else if (us.isAdm_Sucursal())
            {
                id_sucursal = SucursalID;
                id_empresa = EmpresaID;
            }
            else
            {
                id_sucursal = ddlSucursalTrab.SelectedValue.ToString();
                id_empresa = ddlEmpresasTrab.SelectedValue.ToString();
            }
            string[] str = new string[7];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            DateTime fecha;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        msj = DateTime.Now + ": Agregando el registro Nro." + (rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "INFO");
                        DateTime fecha_nacimiento = DateTime.Today;
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            pos++;
                        }

                        int _id_puesto_trabajo = Getter.PuestoTrabajo(str[0], Convert.ToInt32(id_sucursal));
                        if(_id_puesto_trabajo > 0)
                        {
                            int _id_tipo_peligro = Getter.Tipo_Riesgo(str[1]);
                            if(_id_tipo_peligro > 0)
                            {
                                int _id_factor_riesgo = Getter.Factor_Riesgo(str[2], _id_tipo_peligro);
                                if(_id_factor_riesgo > 0)
                                {
                                    string efecto_posible = str[3];
                                    string tiempo_exposicion = str[4];
                                    string medidas = str[5];
                                    string observaciones = str[6];
                                    int idusuario = Getter.Usuario(str[2]);
                                    ModeloRiesgo.Add_Identificacion_peligro(medidas, observaciones, Convert.ToInt32(UsuarioID), "Carga Masiva/index.aspx");
                                    int id_identificacion_peligro = Getter.Max_IdentificacionPeligro();
                                    ModeloRiesgo.Add_Identificacion_puesto(id_identificacion_peligro, _id_puesto_trabajo, Convert.ToInt32(UsuarioID), "Carga Masiva/index.aspx");
                                    int id_factor_riesgo = Getter.Max_Factor_Riesgo();
                                    ModeloRiesgo.Add_Factor_identificacion(id_factor_riesgo, id_identificacion_peligro, medidas, tiempo_exposicion, Convert.ToInt32(UsuarioID), "Carga Masiva/index.aspx");
                                    msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "EXITO");
                                }
                                else
                                {
                                    msj = DateTime.Now + ": El Factor de riesgo " + str[2] + " no pertenece al tipo de peligro "+str[1];
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                                }
                            }
                            else
                            {
                                msj = DateTime.Now + ": El Tipo de peligro " + str[1] + " no se encuentra registrado.";
                                Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                            }
                        }
                        else
                        {
                            msj = DateTime.Now + ": El puesto de trabajo "+str[0]+" no pertenece a la sucursal seleccionada.";
                            Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                        }
                        pos = 0;
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de los Puestos de Trabajo con exito.");
                        msj = DateTime.Now + ": Se cargaron los datos de los Puestos de Trabajo con exito.";
                        Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "EXITO");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                        msj = DateTime.Now + ": Error " + error;
                        Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La cantidad de columnas no coincide con el formato.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogRiesgos, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }
        #endregion

        #region Descripcion SocioDemografica
        private void btnCargarDesc_Click_1(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoDesc.Text != "")
            {
                string nombreArchivo = CargaArchivos("DescSocio");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Descripcion SocioDemografica.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "INFO");
                    cargaDescSocio(nombreArchivo);
                }                    
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void btnBuscarDesc_Click_1(object sender, EventArgs e)
        {
            DialogResult result = ArchivoDesc.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoDesc.Text = ArchivoDesc.FileName;
            }
        }


        private void cargaDescSocio(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string[] desc_socio = new string[25];
            string[] empleos = new string[6];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            DateTime fecha;
            bool empleosAnteriores = false;
            int cantEmpleos = 0;
            int id_desc_socio = 0;
            Boolean siAgrego = false;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == desc_socio.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        if (!empleosAnteriores)
                        {
                            msj = DateTime.Now + ": Agregando el registro Nro." + (rCnt - 1);
                            Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "INFO");
                            for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                            {
                                if (pos == 0 || pos == 3 || pos == 5 || pos == 7 || pos == 24)
                                {
                                    int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                    desc_socio[pos] = numero.ToString();
                                    if (pos == 24 && numero > 0) { empleosAnteriores = true; cantEmpleos = numero; }
                                }
                                else
                                {
                                    desc_socio[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                }
                                pos++;
                            }

                            //INSERT INTO desc_socio
                            int id_trabajador = Getter.TrabajadorbyCedula(desc_socio[0]);                       
                            //desc_socio[0] = Getter.TrabajadorbyCedula(desc_socio[0]).ToString();

                            string lugar_nac = desc_socio[1];
                            string nivel_escol = desc_socio[2];
                            string años_aprob = desc_socio[3];
                            string cabeza_fam = desc_socio[4];
                            string num_hijos = desc_socio[5];
                            string repart_resp = desc_socio[6];
                            string menores_dep = desc_socio[7];
                            string cond_social = desc_socio[8];
                            string mot_despl = desc_socio[9];
                            string tipo_vivienda = desc_socio[10];
                            string serv_pub = desc_socio[11];
                            string sist_seg_soc = desc_socio[17];
                            string reg_afiliacion = desc_socio[18];
                            string nivel_sisben = desc_socio[19];
                            int id_eps = Convert.ToInt32(Getter.Eps(desc_socio[20]));
                            string afi_sssp = desc_socio[21];
                            int id_fondo = Convert.ToInt32(Getter.Afp(desc_socio[22]));
                            string afi_riesgo = desc_socio[23];
                            string estrato = desc_socio[24];
                            string vivienda = desc_socio[12];
                            string industria = desc_socio[13];
                            string ruido = desc_socio[13];
                            string contaminacion = desc_socio[15];
                            string descripcion = desc_socio[16];

                            if(id_trabajador > 0)
                            {
                                if(id_eps > 0)
                                {
                                    if(id_fondo > 0)
                                    {
                                        ModeloDescSocio.Add_DescSocio(id_trabajador, lugar_nac, nivel_escol, años_aprob, cabeza_fam,
                                                                 num_hijos, repart_resp, menores_dep, cond_social, mot_despl, tipo_vivienda,
                                                                 serv_pub, sist_seg_soc, reg_afiliacion, nivel_sisben, id_eps, afi_sssp, id_fondo,
                                                                 afi_riesgo, estrato, vivienda, industria, ruido, contaminacion, descripcion, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                        siAgrego = true;
                                        id_desc_socio = Getter.MaxDescSocio();
                                        msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "EXITO");
                                    }
                                    else
                                    {
                                        msj = DateTime.Now + ": El Fondo:" + desc_socio[22] + " no se encuentra registrado en el sistema.";
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                        msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                        Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                        siAgrego = false;
                                    }
                                }
                                else
                                {
                                    msj = DateTime.Now + ": La EPS:" + desc_socio[20] + " no se encuentra registrada en el sistema.";
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                    msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                    siAgrego = false;
                                }
                            }
                            else
                            {
                                msj = DateTime.Now + ": El Trabajador de cedula:" + desc_socio[0] + " no se encuentra registrado en el sistema.";
                                Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                msj = DateTime.Now + ": No se agrego el registro Nro." + (rCnt - 1);
                                Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                                siAgrego = false;
                            }
                            
                        }
                        else
                        {
                            if (empleosAnteriores)
                            {
                                for (cCnt = 1; cCnt <= empleos.Length; cCnt++)
                                {
                                    if (pos == 3 || pos == 4)
                                    {
                                        int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                        empleos[pos] = numero.ToString();
                                    }
                                    else
                                    {
                                        empleos[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    }
                                    pos++;
                                }
                                if(siAgrego)
                                    ModeloDescSocio.Add_EmpleoAnteriores(empleos[0], empleos[1], empleos[2], empleos[3], empleos[4], empleos[5], id_desc_socio, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");

                                cantEmpleos--;
                                if (cantEmpleos == 0) empleosAnteriores = false;
                            }
                        }
                        pos = 0;
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de las Descripcion con exito.");
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error: " + error);
                    }
                }
                else
                {
                    MessageBox.Show("El archivo no contiene registros para cargar.");
                    msj = DateTime.Now + ": El archivo no contiene registros para cargar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
                }
            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La Cantidad de Columnas No Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "ERROR");
            }
            Utilidades1.cerrarEscritor(escritor);
        }
        #endregion

        private void ddlSucursalRiesgos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
