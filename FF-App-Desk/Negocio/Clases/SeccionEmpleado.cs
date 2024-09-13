using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class SeccionEmpleado
    {
        private static SeccionEmpleado instance;
        private int? ID_Usuario { get; set; }
        private int? ID_Empleado { get; set; }
        
        private Usuarios Usuario { get; set; }
        private Empleados Empleado   {get; set; }

        private SeccionEmpleado()
        {
           
        }

        public static SeccionEmpleado Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SeccionEmpleado();
                }
                return instance;
            }
        }
        public void Loging(int idUsuario, int idEmpleado)
        {
            ID_Usuario = idUsuario;
            ID_Empleado = idEmpleado;
            SetUser();
            SetEmpleado();
        }

        public void Logoff()
        {
            ID_Usuario = null;
            ID_Empleado = null;
            Empleado = null;
            Usuario = null;
        }

        public void SetUser()
        {
            if (ID_Empleado != null && ID_Usuario != null)
            {
                using (FixFastDbEntities db = new FixFastDbEntities()){
                    Usuario = db.Usuarios.FirstOrDefault(sf => sf.id_usuario == ID_Usuario);
                }
            }
        }
        public void SetEmpleado()
        {
            if (ID_Empleado != null && ID_Usuario != null)
            {
                using (FixFastDbEntities db = new FixFastDbEntities())
                {
                    Empleado = db.Empleados.FirstOrDefault(sf => sf.id_empleados == ID_Empleado);
                }
            }
        }

        public Empleados GetEmpleados()
        {
            if (Empleado != null)
            {
                return this.Empleado;
            }
            else
            {
                return null;
            }
        }

        public Usuarios GetUsuario()
        {
            if (Usuario != null)
            {
                return this.Usuario;
            }
            else
            {
                return null;
            }
        }

    }
}

