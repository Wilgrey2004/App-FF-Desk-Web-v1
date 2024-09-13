using DB;
using MaterialSkin;
using MaterialSkin.Controls;
using Negocio;
using System;
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
    public partial class Form1 : MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {


        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            UsuariosLogica usl = new UsuariosLogica();

            if (usl.CrearUsuario(NombreTxt.Text, Apellido1Txt.Text, Apellido2Txt.Text, GeneroCom.Text, CorreoTxt.Text, PassTxt.Text))
            {
                MessageBox.Show("usuario Creado!!!");
            }
            else
            {
                MessageBox.Show("usuario no creado...");
            }
        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            UsuariosLogica usl = new UsuariosLogica();
            int IDUsuario = usl.Loging(CorreoUserLog.Text, PassUserlog.Text).Item1;
            if (IDUsuario > 0){
                int IdEmpleado = usl.Loging(CorreoUserLog.Text, PassUserlog.Text).Item2;
                
                Gestion gs = new Gestion();
                gs.ID_Usuario = IDUsuario;
                gs.ID_empleado = IdEmpleado;
                MessageBox.Show($"Bienvenido!!!");
                
                this.Visible = false;
                gs.ShowDialog();
                this.Visible = true;
            
            }else{
                MessageBox.Show("A Ocurrido un Error..");
            }

        }
    }
}
