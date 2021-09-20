using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio; 

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_usuario.Text != "")
            {
                if (txt_contrasena.Text != "")
                {
                    CN_Productos user = new CN_Productos();
                    var validarLogin = user.LoginUser(txt_usuario.Text, txt_contrasena.Text);
                    if (validarLogin == true)
                    {
                        FormInicio mainMenu = new FormInicio();
                        mainMenu.Show();
                        mainMenu.FormClosed += Logout; 
                        this.Hide();
                    }
                    else {
                        msgError("Usuario o contraseña incorrectos");
                        txt_contrasena.Clear();
                        txt_contrasena.Focus(); 
                    }
                }
                else {
                    msgError("INGRESE SU CONTRASENIA"); 
                }
            }
            else {
                msgError("INGRESE SU USUARIO"); 
            }
        }

        private void msgError(string msg) {
            lblError.Text = msg;
            lblError.Visible = true; 
        }

        private void lblError_Click(object sender, EventArgs e)
        {

        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void Logout(object sender, FormClosedEventArgs e) {
            txt_contrasena.Clear();
            txt_usuario.Clear();
            lblError.Visible = false;
            this.Show();
            txt_usuario.Focus(); 
        }
    }
}
