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
            Listas.Empresa(ddlEmpresasAcc);
            Listas.Sucursal(ddlSucursalAcc, 1);
            us = new UsuarioSistema(RolID);
            if (!esAdmin)
            {
                if (us.isAdm_Empresa())
                {
                    ddlEmpresasHorario.SelectedValue = EmpresaID;
                    ddlEmpresaArea.SelectedValue = EmpresaID;
                    ddlEmpresaPuesto.SelectedValue = EmpresaID;
                    ddlEmpresasTrab.SelectedValue = EmpresaID;
                    ddlEmpresasAcc.SelectedValue = EmpresaID;
                    Listas.Sucursal(ddlSucursalArea, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalPuesto, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalTrab, Convert.ToInt32(EmpresaID));
                    Listas.Sucursal(ddlSucursalAcc, Convert.ToInt32(EmpresaID));
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
                    ddlEmpresasAcc.Enabled = false;
                }
                else if (us.isAdm_Sucursal())
                {
                    ddlEmpresasHorario.SelectedValue = EmpresaID;
                    ddlEmpresaArea.SelectedValue = EmpresaID;
                    ddlEmpresaPuesto.SelectedValue = EmpresaID;
                    ddlEmpresasTrab.SelectedValue = EmpresaID;
                    ddlEmpresasAcc.SelectedValue = EmpresaID;
                    ddlSucursalArea.SelectedValue = SucursalID;
                    ddlSucursalPuesto.SelectedValue = SucursalID;
                    ddlSucursalTrab.SelectedValue = SucursalID;
                    ddlSucursalAcc.SelectedValue = SucursalID;
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
                    ddlEmpresasAcc.Enabled = false;
                    ddlSucursalArea.Enabled = false;
                    ddlSucursalPuesto.Enabled = false;
                    ddlSucursalTrab.Enabled = false;
                    ddlSucursalAcc.Enabled = false;
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

            string id_empresa = ddlEmpresasHorario.SelectedValue.ToString();
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

            string id_sucursal = ddlSucursalArea.SelectedValue.ToString();
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
                                if (str[pos] == "Ninguna")
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
                                }
                            }
                            pos++;
                        }
                        msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogAreas, "EXITO");
                        ModeloArea.Add_Area(str[0], Convert.ToInt32(id_sucursal), str[1], Convert.ToInt32(str[2]), _nivel, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
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

            string id_sucursal = ddlSucursalPuesto.SelectedValue.ToString();
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
                                if (str[0] != null)
                                {
                                    ModeloPuesto.Add_PuestoTrabajo(str[0], str[1], id_area, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                    msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogPuestos, "EXITO");
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

            string id_sucursal = ddlSucursalTrab.SelectedValue.ToString();
            string id_empresa = ddlEmpresasTrab.SelectedValue.ToString();
            string[] str = new string[19];
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
                                if (pos == 6 || pos == 9 || pos == 10)
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
                                if (pos != 0 && pos != 6 && pos != 9 && pos != 10)
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
                                str[11] = Getter.Ccf_Nombre(str[11]).ToString();
                                str[13] = Getter.Municipio(str[13]).ToString();
                                str[14] = Getter.PuestoTrabajo(str[14], Convert.ToInt32(id_sucursal)).ToString();
                                str[17] = Getter.Horario(str[17], Convert.ToInt32(id_empresa)).ToString();
                                str[18] = Getter.Estatus(str[18], Convert.ToInt32(id_empresa)).ToString();

                                if(!Getter.ValidaCedula(str[0]))
                                {
                                    ModeloTrabajador.Add_Trabajador(str[0], str[1], str[2], str[3], str[4], str[5],
                                                    fecha_nacimiento, str[7], str[8], "''", str[9], str[10], 1,
                                                    Convert.ToInt32(str[11]), str[12], Convert.ToInt32(str[13]),
                                                    Convert.ToInt32(str[14]), str[15], str[16], Convert.ToInt32(str[17]),
                                                    Convert.ToInt32(str[18]), Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                    msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                                    Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "EXITO");
                                }
                                pos = 0;
                            }
                            catch (Exception ex)
                            {
                                //Error en algun dato del registro...
                                pos = 0;
                                msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1);
                                Utilidades1.agregarMensaje(escritor, msj, txtLogsTrab, "ERROR");
                            }

                        }
                        catch (Exception ex1)
                        { 
                            //Error en la linea....
                            pos = 0;
                            msj = DateTime.Now + ": Ocurrio un error al agregar el registro Nro." + (rCnt - 1);
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
            //Listas.Sucursal(ddlSucursalRiesgo, Convert.ToInt32(ddlEmpresasRiesgo.SelectedValue));
        }

        private void btnBuscarRiesgo_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoRiesgos.ShowDialog();
            if (result == DialogResult.OK)
            {
                //txtArchivoRiesgo.Text = ArchivoRiesgos.FileName;
            }
        }

        private void btnCargarRiesgo_Click(object sender, EventArgs e)
        {
            /*if (txtArchivoRiesgo.Text != "")
            {
                string nombreArchivo = CargaArchivos("Riesgos");
                if (nombreArchivo != null)
                    cargaRiesgos(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
            }*/
        }

        private void cargaRiesgos(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string id_sucursal = ddlSucursalTrab.SelectedValue.ToString();
            string id_empresa = ddlEmpresasTrab.SelectedValue.ToString();
            string[] str = new string[13];
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
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        DateTime fecha_nacimiento = DateTime.Today;
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            if (pos == 1)
                            {
                                double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                fecha = DateTime.FromOADate(fecha_n);
                                str[pos] = fecha.ToString();
                            }
                            else
                            {
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            pos++;
                        }

                        #region calculo valor riesgo y prioridad
                        string valor_riesgo = "";
                        string id_prioridad = "";
                        if (str[4] == "Baja")
                        {
                            if (str[5].ToLower() == "ligeramente dañino")
                            {
                                valor_riesgo = "Trivial (T)";
                                id_prioridad = "1";
                            }
                            else if (str[5].ToLower() == "dañino")
                            {
                                valor_riesgo = "Tolerable (TO)";
                                id_prioridad = "1";
                            }
                            else if (str[5].ToLower() == "extremadamente dañino")
                            {
                                valor_riesgo = "Moderado (MO)";
                                id_prioridad = "2";
                            }
                        }
                        else if (str[4] == "Media")
                        {
                            if (str[5].ToLower() == "ligeramente dañino")
                            {
                                valor_riesgo = "Tolerable (TO)";
                                id_prioridad = "1";
                            }
                            else if (str[5].ToLower() == "dañino")
                            {
                                valor_riesgo = "Moderado (MO)";
                                id_prioridad = "2";
                            }
                            else if (str[5].ToLower() == "extremadamente dañino")
                            {
                                valor_riesgo = "Importante (I)";
                                id_prioridad = "3";
                            }
                        }
                        else if (str[4] == "Alta")
                        {
                            if (str[5].ToLower() == "ligeramente dañino")
                            {
                                valor_riesgo = "Moderado (MO)";
                                id_prioridad = "2";
                            }
                            else if (str[5].ToLower() == "dañino")
                            {
                                valor_riesgo = "Importante (I)";
                                id_prioridad = "3";
                            }
                            else if (str[5].ToLower() == "extremadamente dañino")
                            {
                                valor_riesgo = "Intolerable (IN)";
                                id_prioridad = "3";
                            }
                        }
                        #endregion

                        int _id_puesto_trabajo = Getter.PuestoTrabajo(str[0], Convert.ToInt32(id_sucursal));
                        string _fecha_eva = str[1];
                        int _id_responsable = Getter.Usuario(str[2]);
                        string _identificacion_riesgo = str[3];
                        string _probabilidad = str[4];
                        string _severidad = str[5];
                        string _medidas_fuente = str[6];
                        string _medidas_ambiente = str[7];
                        string _medidas_trabajador = str[8];
                        string _estatus = Getter.Estatus(str[9], Convert.ToInt32(id_empresa)).ToString();
                        int _id_factor_riesgo = Getter.FactorRiesgo(str[10]);
                        string _consecuencia = str[11];
                        int idusuario = Getter.Usuario(str[2]);
                        int matriz_riegos = 0;

                        /*ModeloRiesgo.Add_Riesgos(_id_puesto_trabajo, _fecha_eva, _id_responsable, _identificacion_riesgo,
                                                _probabilidad, _severidad, valor_riesgo, Convert.ToInt32(id_prioridad),
                                                _medidas_fuente, _medidas_ambiente, _medidas_trabajador, _estatus,
                                                _id_factor_riesgo, _consecuencia, Convert.ToInt32(id_sucursal), matriz_riegos, Convert.ToInt32(UsuarioID), "Carga Masiva/index.aspx");
                        */
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
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
        }
        #endregion

        #region Accidentes/Incidentes
        private void ddlEmpresasAcc_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalAcc, Convert.ToInt32(ddlEmpresasAcc.SelectedValue));
        }

        private void btnBuscarAcc_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoAcc.ShowDialog();
            if (result == DialogResult.OK)
            {
               txtArchivoAcc.Text = ArchivoAcc.FileName;
            }
        }

        private void btnCargarAcc_Click(object sender, EventArgs e)
        {
            escritor = Utilidades1.abrirEscritor();
            if (txtArchivoAcc.Text != "")
            {
                string nombreArchivo = CargaArchivos("Accidentes");
                if (nombreArchivo != null)
                {
                    msj = DateTime.Now + ": Iniciando carga masiva de Accidentes/Incidentes.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "INFO");
                    cargaAccidentesIncidentes(nombreArchivo);
                }
                    
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
                msj = DateTime.Now + ": No se selecciono ningun Archivo.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "ERROR");
                Utilidades1.cerrarEscritor(escritor);
            }
        }

        private void cargaAccidentesIncidentes(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string id_sucursal = ddlSucursalAcc.SelectedValue.ToString();
            string id_empresa = ddlEmpresasAcc.SelectedValue.ToString();
            int tipo_acci_inci = 1;
       
            string[] accidente = new string[19];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            DateTime? fecha_evento = null;
            DateTime? fecha_muerte = null;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == accidente.Length)
            {
                msj = DateTime.Now + ": La Cantidad de Columnas Coincide.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "INFO");
                if (range.Rows.Count >= 2)
                {
                    msj = DateTime.Now + ": Existen registros para agregar.";
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "INFO");
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {                        
                        msj = DateTime.Now + ": Existen registros para agregar.";
                        Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "INFO");
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            //0: Tipo de Evento
                            if(pos == 0)
                            {
                                string _tipo = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                if (_tipo == "Incidente") tipo_acci_inci = 2;
                            }
                            //1: Fecha del evento, 10: Fecha de Muerte
                            else if (pos == 1 || pos == 12)
                            {
                                if (pos == 1)
                                {
                                    double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                    fecha_evento = DateTime.FromOADate(fecha_n);
                                    accidente[pos] = fecha_evento.ToString();
                                }
                                else
                                {
                                    try
                                    {
                                        double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                        fecha_muerte = DateTime.FromOADate(fecha_n);
                                        accidente[pos] = fecha_muerte.ToString();
                                    }
                                    catch(Exception e)
                                    {
                                        accidente[pos] = "null";
                                    }
                                    
                                }                                
                                
                            }
                            //2: Hora del evento
                            else if (pos == 2)
                            {
                                double numero = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                DateTime hora_acc = DateTime.FromOADate(numero);
                                accidente[pos] = hora_acc.ToString("HH:mm");
                            }
                            //3: Cedula de trabajador, 13: Dias de incapacidad, 14: Dias cargados, 15: Dias perdidos, 16: Dias no perdidos, 17: dias restringidos
                            else if (pos == 3 || pos == 13 || pos == 14 || pos == 15 || pos == 16 || pos == 17)
                            {
                                int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                accidente[pos] = numero.ToString();
                            }
                            else
                            {
                                accidente[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            }
                            pos++;
                        }

                        int id_trabajador = Getter.TrabajadorbyCedula(accidente[3]);
                        int id_puesto_trabajo = Getter.PuestoTrabajo(accidente[5], Convert.ToInt32(id_sucursal));
                        int id_area = Getter.Area_Nombre(accidente[4], Convert.ToInt32(id_sucursal));                        
                        
                        ModeloAccidentes.Add_Accidentes(id_trabajador, id_area, id_puesto_trabajo, accidente[6], accidente[7], accidente[8], accidente[9],
                                                        accidente[10], accidente[11], tipo_acci_inci.ToString(), Convert.ToDateTime(accidente[12]), Convert.ToInt32(accidente[13]), 
                                                        Convert.ToInt32(accidente[14]), Convert.ToInt32(accidente[15]), accidente[16], Convert.ToInt32(accidente[17]), accidente[18], 
                                                        Convert.ToDateTime(accidente[1]), Convert.ToDateTime(accidente[2]), 1, "Carga Masiva/index.aspx");
                        msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                        Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "EXITO");
                        pos = 0;
                    }
                    xlWorkBook.Close(false, Missing.Value, Missing.Value);
                    xlApp.Quit();

                    releaseObject(xlWorkSheet);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);

                    if (error == string.Empty)
                    {
                        MessageBox.Show("Se cargaron los datos de Accidentes/Incidentes con exito.");
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
                    Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "ERROR");
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
                msj = DateTime.Now + ": La cantidad de columnas no coincide con el formato.";
                Utilidades1.agregarMensaje(escritor, msj, txtLogsAcc, "ERROR");
            }
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
                    msj = DateTime.Now + ": Iniciando carga masiva de Areas.";
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
                            desc_socio[0] = Getter.TrabajadorbyCedula(desc_socio[0]).ToString();

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

                            ModeloDescSocio.Add_DescSocio(id_trabajador, lugar_nac, nivel_escol, años_aprob, cabeza_fam,
                                                                 num_hijos, repart_resp, menores_dep, cond_social, mot_despl, tipo_vivienda,
                                                                 serv_pub, sist_seg_soc, reg_afiliacion, nivel_sisben, id_eps, afi_sssp, id_fondo,
                                                                 afi_riesgo, estrato, vivienda, industria, ruido, contaminacion, descripcion, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");

                            id_desc_socio = Getter.MaxDescSocio();
                            msj = DateTime.Now + ": Se agrego el registro Nro." + (rCnt - 1);
                            Utilidades1.agregarMensaje(escritor, msj, txtLogsDesc, "EXITO");
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
    }
}
