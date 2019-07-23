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
            Listas.Empresa(ddlEmpresasRiesgo);
            Listas.Sucursal(ddlSucursalRiesgo, 1);
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
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
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
                    ddlEmpresasHorario.Enabled = false;
                    ddlEmpresaArea.Enabled = false;
                    ddlEmpresaPuesto.Enabled = false;
                    ddlEmpresasTrab.Enabled = false;
                    ddlSucursalArea.Enabled = false;
                    ddlSucursalPuesto.Enabled = false;
                    ddlSucursalTrab.Enabled = false;
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
            else if (Modulo == "AccInc")
            {
                nombreArchivo = ArchivoAcc.FileName.Split('\\');
                ofdArchivo = ArchivoAcc;
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
            if (txtCargarArea.Text != "")
            {
                string nombreArchivo = CargaArchivos("Areas");
                if(nombreArchivo != null)
                    cargaAreas(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
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
            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(archivoNombre, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == str.Length)
            {
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            if (pos == 0)
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                            else if (pos == 1)
                            {
                                str[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                if (str[pos] == null)
                                {
                                    str[pos] = "0";
                                }
                                else
                                {
                                    int id = Getter.Area_Nombre(str[pos], Convert.ToInt32(id_sucursal));
                                    str[pos] = id.ToString();
                                }
                            }
                            else if (pos == 2)
                            {
                                int nivel = Convert.ToInt32(((range.Cells[rCnt, cCnt] as Range).Value2));
                                str[pos] = "" + nivel;
                            }
                            pos++;
                        }
                        ModeloArea.Add_Area(str[0], Convert.ToInt32(id_sucursal), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]), Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
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
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
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
            if (txtArchivoPuesto.Text != "")
            {
                string nombreArchivo = CargaArchivos("Puestos");
                if (nombreArchivo != null)
                    cargaPuestos(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
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
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
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
                                }
                                pos = 0;
                            }
                            catch (Exception ex)
                            { 
                                //Error
                            }
                            
                        }
                        catch (Exception ex)
                        { 
                            //Error
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
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
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
            if (txtArchivoTrab.Text != "")
            {
                string nombreArchivo = CargaArchivos("Trabajadores");
                if (nombreArchivo != null)
                {
                    _progress_bar = new ProgressBar();
                    backgroundWorker = new BackgroundWorker();
                    _progress_bar.Maximum = 100;
                    _progress_bar.Step = 1;
                    _progress_bar.Value = 0;
                    backgroundWorker.RunWorkerAsync();
                    cargaTrabajadores(nombreArchivo);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
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
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        try
                        {
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
                                }
                                pos = 0;
                            }
                            catch (Exception ex)
                            {
                                //Error en algun dato del registro...
                                pos = 0;
                            }

                        }
                        catch (Exception ex1)
                        { 
                            //Error en la linea....
                            pos = 0;
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
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
        }
        #endregion

        #region Riesgos
        private void ddlEmpresasRiesgo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listas.Sucursal(ddlSucursalRiesgo, Convert.ToInt32(ddlEmpresasRiesgo.SelectedValue));
        }

        private void btnBuscarRiesgo_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoRiesgos.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoRiesgo.Text = ArchivoRiesgos.FileName;
            }
        }

        private void btnCargarRiesgo_Click(object sender, EventArgs e)
        {
            if (txtArchivoRiesgo.Text != "")
            {
                string nombreArchivo = CargaArchivos("Riesgos");
                if (nombreArchivo != null)
                    cargaRiesgos(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
            }
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
            if (txtArchivoAcc.Text != "")
            {
                string nombreArchivo = CargaArchivos("Accidentes");
                if (nombreArchivo != null)
                    cargaAccidentesIncidentes(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
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
            if (ddlModulo.SelectedValue.ToString() == "Incidentes")
            {
                tipo_acci_inci = 2;
            }
            string[] accidente = new string[33];
            string[] testigo = new string[4];
            string[] causa_inmediata = new string[2];
            string[] causa_basica = new string[2];
            string[] compromisos = new string[6];
            int pos = 0;
            int rCnt = 0;
            int cCnt = 0;
            DateTime fecha;
            bool testigos = false;
            bool compromiso = false;
            bool causaInmediatas = false;
            bool causasBasicas = false;
            int cantTestigos = 0;
            int cantCompromisos = 0;
            int cantCausasInme = 0;
            int cantCausasbasi = 0;
            int id_acc_lab = 0;

            xlApp = new Microsoft.Office.Interop.Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(nombreArchivo, 0, true, 5, "", "", true, XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            if (range.Columns.Count == accidente.Length)
            {
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                    {
                        if (!testigos && !compromiso && !causaInmediatas && !causasBasicas)
                        {
                            for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                            {
                                if (pos == 1 || pos == 6)
                                {
                                    double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                    fecha = DateTime.FromOADate(fecha_n);
                                    accidente[pos] = fecha.ToString();
                                }
                                else if (pos == 2 || pos == 7 || pos == 11)
                                {
                                    double numero = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                    DateTime hora1 = DateTime.FromOADate(numero);
                                    accidente[pos] = hora1.ToString("HH:mm");
                                }
                                else if (pos == 3 || pos == 23 || pos == 24 || pos == 25 || pos == 26)
                                {
                                    int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                    accidente[pos] = numero.ToString();
                                    if (pos == 23 && numero > 0) { testigos = true; cantTestigos = numero; }
                                    if (pos == 24 && numero > 0) { causaInmediatas = true; cantCausasInme = numero; }
                                    if (pos == 25 && numero > 0) { causasBasicas = true; cantCausasbasi = numero; }
                                    if (pos == 26 && numero > 0) { compromiso = true; cantCompromisos = numero; }
                                }
                                else
                                {
                                    accidente[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                }
                                pos++;
                            }
                            //INSERT INTO acc_icc_lab
                            int id_trabajador = Getter.TrabajadorbyCedula(accidente[3]);
                            int id_area = Getter.Area_Nombre(accidente[4], Convert.ToInt32(id_sucursal));
                            int id_ips = Getter.IPS(accidente[8]);
                            int id_tipoAccidente = Getter.TipoAccidente(accidente[9], Convert.ToInt32(id_empresa));
                            int id_sitio_accidente = Getter.SitioAccidente(accidente[10], Convert.ToInt32(id_empresa));
                            int id_puesto_trabajo = Getter.PuestoTrabajo(accidente[14], Convert.ToInt32(id_sucursal));
                            int id_agente_lesion = Getter.AgenteLesion(accidente[15], Convert.ToInt32(id_empresa));
                            int id_causa_accidente = Getter.CausaAccidente(accidente[16], Convert.ToInt32(id_empresa));
                            int id_parte_afectada = Getter.ParteCuerpo(accidente[17], Convert.ToInt32(id_empresa));
                            int id_forma_accidente = Getter.FormaAccidente(accidente[18], Convert.ToInt32(id_empresa));

                            /*ModeloAccidentes.Add_Accidentes(tipo_acci_inci, accidente[0], Convert.ToDateTime(accidente[1]), Convert.ToDateTime(accidente[2]), id_trabajador,
                                                                id_area, Convert.ToDateTime(accidente[6]), Convert.ToDateTime(accidente[7]),
                                                                id_ips, id_tipoAccidente, id_sitio_accidente, Convert.ToDateTime(accidente[11]), accidente[12], accidente[13],
                                                                id_puesto_trabajo, id_agente_lesion, id_causa_accidente, id_parte_afectada, id_forma_accidente,
                                                                accidente[19], accidente[20], accidente[21], accidente[22], accidente[27],
                                                                accidente[28], accidente[29], accidente[30], accidente[31], accidente[32], 1, "cargamasiva");*/

                            id_acc_lab = Getter.MaxAccidentes();
                        }
                        else
                        {
                            //Si hay testigos..
                            if (testigos)
                            {
                                for (cCnt = 1; cCnt <= testigo.Length; cCnt++)
                                {
                                    if (pos == 2)
                                    {
                                        int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                        testigo[pos] = numero.ToString();
                                    }
                                    else
                                    {
                                        testigo[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    }
                                    pos++;
                                }
                                //ModeloAccidentes.Add_Testigos(testigo[0], testigo[1], testigo[2], testigo[3], id_acc_lab, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                cantTestigos--;
                                if (cantTestigos == 0) testigos = false;
                            }
                            else if (causaInmediatas)
                            {
                                for (cCnt = 1; cCnt <= causa_inmediata.Length; cCnt++)
                                {
                                    causa_inmediata[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    pos++;
                                }
                                //ModeloAccidentes.Add_Causas_inmediatas(causa_inmediata[0], causa_inmediata[1], id_acc_lab, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                cantCausasInme--;
                                if (cantCausasInme == 0) causaInmediatas = false;
                            }
                            else if (causasBasicas)
                            {
                                for (cCnt = 1; cCnt <= causa_basica.Length; cCnt++)
                                {
                                    causa_basica[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    pos++;
                                }
                                //ModeloAccidentes.Add_Causas_basicas(causa_basica[0], causa_basica[1], id_acc_lab, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                cantCausasbasi--;
                                if (cantCausasbasi == 0) causasBasicas = false;
                            }
                            else if (compromiso)
                            {
                                for (cCnt = 1; cCnt <= compromisos.Length; cCnt++)
                                {
                                    if (pos == 1)
                                    {
                                        double fecha_n = Convert.ToDouble((range.Cells[rCnt, cCnt] as Range).Value2);
                                        fecha = DateTime.FromOADate(fecha_n);
                                        compromisos[pos] = fecha.ToString();
                                    }
                                    else
                                    {
                                        compromisos[pos] = (string)(range.Cells[rCnt, cCnt] as Range).Value2;
                                    }
                                    pos++;
                                }
                               // ModeloAccidentes.Add_Compromisos(compromisos[0], compromisos[1], compromisos[2], compromisos[3], compromisos[4], compromisos[5], id_acc_lab, Convert.ToInt32(UsuarioID), "Carga Masiva/Aplicacion");
                                cantCompromisos--;
                                if (cantCompromisos == 0) compromiso = false;
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
                }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
        }
        #endregion

        #region Descripcion SocioDemografica
        private void btnBuscarDesc_Click(object sender, EventArgs e)
        {
            DialogResult result = ArchivoDesc.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtArchivoDesc.Text = ArchivoDesc.FileName;
            }
        }

        private void btnCargarDesc_Click(object sender, EventArgs e)
        {
            if (txtArchivoDesc.Text != "")
            {
                string nombreArchivo = CargaArchivos("DescSocio");
                if (nombreArchivo != null)
                    cargaDescSocio(nombreArchivo);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un archivo.");
            }
        }

        private void cargaDescSocio(string nombreArchivo)
        {
            Microsoft.Office.Interop.Excel.Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            Range range;
            string error = string.Empty;

            string[] desc_socio = new string[26];
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
                if (range.Rows.Count >= 2)
                {
                    for (rCnt = 2; rCnt <= range.Rows.Count; rCnt++)
                {
                    if (!empleosAnteriores)
                    {
                        for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
                        {
                            if (pos == 1 || pos == 4 || pos == 6 || pos == 8 || pos == 26)
                            {
                                int numero = Convert.ToInt32((range.Cells[rCnt, cCnt] as Range).Value2);
                                desc_socio[pos] = numero.ToString();
                                if (pos == 26 && numero > 0) { empleosAnteriores = true; cantEmpleos = numero; }
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
                    }
                    else
                    {
                        //Si hay testigos..
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
            }

            }
            else
            {
                MessageBox.Show("La cantidad de columnas no coincide con el formato.");
            }
        }
        #endregion
    }
}
