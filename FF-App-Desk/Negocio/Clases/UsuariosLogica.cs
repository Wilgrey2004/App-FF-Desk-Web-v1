using DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public class UsuariosLogica
    {
        public  (int IDUsuario,int IDEmpleado) Loging(string email,string pass)
        {
            int idEmpleado = 0;
            int idUser = 0;
            using (FixFastDbEntities db = new FixFastDbEntities())
            {
                Usuarios user = db.Usuarios.FirstOrDefault(sf => sf.email == email);

                if(user != null)
                {
                    if (user.password == pass)
                    {
                        if (user.Tipo_User == "1")
                        {
                            using(FixFastDbEntities db2 = new FixFastDbEntities())
                            {
                                Empleados _idEmpleado = db2.Empleados.FirstOrDefault(fs=> fs.id_Usuario == user.id_usuario);
                                
                                

                                if (int.TryParse(_idEmpleado.id_empleados.ToString(), out idEmpleado))
                                {
                                    if (_idEmpleado != null)
                                    {
                                        idUser = user.id_usuario;
                                        return (idUser, idEmpleado);
                                    }
                                }
  
                                MessageBox.Show("Ocurrio un Error");
                                return (0, 0);
                            }
                            
                        }else
                        {
                            MessageBox.Show($"El Usuario ${user.email} No es Un Administrador...");
                            return (0,0);
                        }
                        //return (true,user);
                    
                    }else {
                    
                        return (0,0);
                    
                    }
                }


                return (0,0);
            }
        }
        public  bool CrearUsuario(string name, string lastName1, string lastName2, string sexo, string email, string password)
        {
            using (FixFastDbEntities db = new FixFastDbEntities())
            {
                //Verificar si el email ya existe
                if (db.Usuarios.Any(u => u.email == email))
                {
                    MessageBox.Show("El email ya existe");
                    return false;
                }

                // Crear un nuevo usuario
                Usuarios usuario = new Usuarios
                {
                    name = name,
                    last_name1 = lastName1,
                    last_name2 = lastName2,
                    //sexo = sexo,
                    //Tipo_User = "1",
                    email = email,
                    password = password
                };

                switch (sexo)
                {
                    case "Hombre":
                        usuario.sexo = "H";
                        break;
                    case "Mujer":
                        usuario.sexo = "M";
                        break;
                    case "Otros":
                        usuario.sexo = "O";
                        break;
                    default:
                        usuario.sexo = "O";
                        break;
                }
                // Agregar el usuario a la base de datos
                db.Usuarios.Add(usuario);

                // Guardar los cambios
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el usuario: " + ex.Message);
                    return false;
                }
            }


        }


        // Método para actualizar un usuario
        public bool ActualizarUsuario(int idUsuario, string name, string lastName1, string lastName2, string sexo, string email, string password)
        {
            using (FixFastDbEntities db = new FixFastDbEntities())
            {
                // Buscar el usuario por id
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                // Verificar si el usuario existe
                if (usuario == null)
                {
                    MessageBox.Show("El usuario no existe");
                    return false;
                }

                // Actualizar los datos del usuario
                usuario.name = name;
                usuario.last_name1 = lastName1;
                usuario.last_name2 = lastName2;
                
                usuario.email = email;
                usuario.password = password;

                switch (sexo)
                {
                    case "Hombre":
                        usuario.sexo = "H";
                        break;
                    case "Mujer":
                        usuario.sexo = "M";
                        break;
                    case "Otros":
                        usuario.sexo = "O";
                        break;
                    default:
                        usuario.sexo = "O";
                        break;
                }
                // Guardar los cambios
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el usuario: " + ex.Message);
                    return false;
                }
            }
        }

        // Método para eliminar un usuario
        public bool EliminarUsuario(int idUsuario)
        {
            using (FixFastDbEntities db = new FixFastDbEntities())
            {
                // Buscar el usuario por id
                Usuarios usuario = db.Usuarios.FirstOrDefault(u => u.id_usuario == idUsuario);

                // Verificar si el usuario existe
                if (usuario == null)
                {
                    MessageBox.Show("El usuario no existe");
                    return false;
                }

                // Eliminar el usuario
                db.Usuarios.Remove(usuario);

                // Guardar los cambios
                try
                {
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
