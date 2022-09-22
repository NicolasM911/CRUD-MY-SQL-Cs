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
    public partial class FrmRegistro : Form
    {
        // realizar conexion}
        MySqlConnection conexion = new MySqlConnection("Server=localhost; database=test1 ; uid= root ; pwd= ");
        public FrmRegistro()
        {
            InitializeComponent();
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string sql = "insert into usuarios(nom_user,pass_user) values ('" + txtNewUser.Text + "' , '" + txtNewPass.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Usuario {txtNewUser.Text} registrado correctamente");
                    this.Hide();
                    FrmLogin f1 = new FrmLogin();
                    f1.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al conectar{ex}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al instertar: {ex}");
            }
        }
    }
}
