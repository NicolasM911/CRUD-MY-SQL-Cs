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
    }
}
