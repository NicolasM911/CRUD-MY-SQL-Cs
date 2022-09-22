using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crdud_mysql
{
    public partial class FrmLogin : Form
    {
        // realizar conexion}
        MySqlConnection conexion = new MySqlConnection("Server=localhost; database=test1 ; uid= root ; pwd= ");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string user, pass;
            user = txtUser.Text;
            pass = txtPass.Text;
            try
            {
                conexion.Open();
                string Query = "Select nom_user,pass_user from usuarios where nom_user = '" + user + "' ";
                MySqlCommand comando = new MySqlCommand(Query, conexion);
                MySqlDataReader read = comando.ExecuteReader();
                if (read.Read())
                {
                    this.Hide();
                    MessageBox.Show("Bienvenido: " + user);
                    FrmMenu f1 = new FrmMenu();
                    f1.Show();
                }
                else
                {
                    MessageBox.Show("No existe este usuario: " + user);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conecta{ex}");
            }
            conexion.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"
Gracias por visitarnos
Creado por Nicolás Mahecha Pérez
Modelamiento de Bases de Datos 2022
");
            Application.Exit();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            FrmRegistro f2 = new FrmRegistro();
            f2.Show();
            this.Hide();
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Ingrese su usuario";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtUser.Text = "Ingrese su contraseña";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Ingrese su usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Ingrese su contraseña")
            {
                txtPass.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }
    }
}
