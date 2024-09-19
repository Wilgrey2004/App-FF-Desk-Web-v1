using DB;
using MaterialSkin;
using MaterialSkin.Controls;
using Negocio.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vista
{
    public partial class Gestion : MaterialForm
    {
        public int ID_empleado;
        public int ID_Usuario;
        private SeccionEmpleado  _SeccionEmpleado;
        private Usuarios US_seccion;
        private Empleados Em_Seccion;
        public Gestion()
        {
            if (ID_empleado > 0 && ID_Usuario > 0) {
                _SeccionEmpleado.Loging(ID_Usuario,ID_empleado);
                US_seccion = _SeccionEmpleado.GetUsuario();
                Em_Seccion = _SeccionEmpleado.GetEmpleados();
            }

            
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private List<Usuarios> ObtenerInfoUsuarios()
        {
            using (FixFastDbEntities db = new FixFastDbEntities())
            {
                List<Usuarios> lista = db.Usuarios.ToList();

                return lista;
            }
        }

        private void ActualizarTablas()
        {
            MyDataUsers.DataSource = ObtenerInfoUsuarios();
            MyDataUsers.Columns["clientes"].Visible = false;
            MyDataUsers.Columns["Empleados"].Visible = false;
           
        }
        private void Gestion_Load(object sender, EventArgs e)
        {
            ActualizarTablas();
        }

        private void MyDataUsers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(".");
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void materialComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void materialCard1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
