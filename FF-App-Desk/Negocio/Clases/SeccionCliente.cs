using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Negocio.Clases
{
    public class SeccionCliente : ISecciones
    {
        private static SeccionCliente instance;
        private int? ID_Usuario { get; set; }
        private int? ID_Cliente { get; set; }

        private SeccionCliente()
        {
            
        }

        public static SeccionCliente Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SeccionCliente();
                }
                return instance;
            }
        }
        public void Loging(int idUsuario, int idCliente)
        {
            ID_Usuario = idUsuario; 
            ID_Cliente = idCliente;
            
        }

        public void Logoff()
        {
            ID_Usuario = null;
            ID_Cliente = null;
            
        }
    }
}
