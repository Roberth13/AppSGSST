using GestorSGSST2017.Formularios;
using GestorSGSST2017.ModeloDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017
{
    public partial class Ingresar : Form
    {
        string usuario;
        string clave;
        string sErr;

        public Ingresar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Validaciones de Inicio de Sesion.
            usuario = txtUsuario.Text;
            clave = txtClave.Text;
            
            if (usuario != "" || clave != "")
            {
                string ResUsuario = ModeloUsuario.ValidarUsuario(usuario, clave);
                if (ResUsuario != "-1")
                {
                    if (ResUsuario != string.Empty)
                    {
                        string[] aUsuario = ResUsuario.Split('|');
                        string UsuarioID = string.Empty;
                        string RolID = string.Empty;
                        string EmpresaID = string.Empty;
                        string SucursalID = string.Empty;
                        bool esAdmin = false;
                        if (aUsuario.Length == 4)
                        {
                            //1: UsuarioID  2:RolID  3:EmpressaID 4:SucursalID (USUARIO EMPRESA)
                            UsuarioID = aUsuario[0];
                            RolID = aUsuario[1];
                            EmpresaID = aUsuario[2];
                            SucursalID = aUsuario[3];

                        }
                        else if (aUsuario.Length == 2)
                        {
                            //1: UsuarioID  2:RolID (USUARIO ADMINISTRADOR)
                            UsuarioID = aUsuario[0];
                            RolID = aUsuario[1];
                            esAdmin = true;
                        }
                        Principal prinObj = new Principal(UsuarioID, RolID, EmpresaID, SucursalID, esAdmin);
                        this.Hide();
                        prinObj.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contraseña Incorrecta.");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecta.");
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar el nombre de usuario y la clave.");
            }
        }
    }
}
