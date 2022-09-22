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
    public partial class FrmMenu : Form
    {
        public FrmMenu()
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

        MySqlConnection conexion = new MySqlConnection("Server=localhost; database=test1 ; uid= root ; pwd= ");
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string Query = "Select id_user as ID, nom_user as Usuario ,pass_user as Contraseña from usuarios";
                MySqlCommand comando = new MySqlCommand(Query, conexion);
                MySqlDataAdapter adaptador = new MySqlDataAdapter();
                adaptador.SelectCommand = comando;
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);
                dataGridView1.DataSource = tabla;
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conecta{ex}");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string query = "update usuarios set nom_user = @nom_user , pass_user = @pass_user where id_user =@id_user";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@nom_user", txtNombreEliminar.Text);
            comando.Parameters.AddWithValue("@pass_user", txtPassEliminar.Text);
            comando.Parameters.AddWithValue("@id_user", txtIdEliminar.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show($"Usuario {txtNombreEliminar.Text} Actualizado");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                string sql = "insert into usuarios(nom_user,pass_user) values ('" + txtNombreEliminar.Text + "' , '" + txtPassEliminar.Text + "')";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"Usuario {txtNombreEliminar.Text} registrado correctamente");
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
            conexion.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string query = "delete from usuarios where id_user = @id_user";
            conexion.Open();
            MySqlCommand comando = new MySqlCommand(query, conexion);
            comando.Parameters.AddWithValue("@id_user", txtIdEliminar.Text);
            comando.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show($"Usuario {txtNombreEliminar.Text} eliminado");
        }
    }
}
