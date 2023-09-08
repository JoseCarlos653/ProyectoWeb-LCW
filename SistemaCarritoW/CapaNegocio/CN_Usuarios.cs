using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios objCapaDatos = new CD_Usuarios();

        public List<Usuario> ListarUsuarios ()
        {
            return objCapaDatos.ListarUsuarios();
        }

        public int RegistrarUsuarios(Usuario obj, out string mensaje) 
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres)) {
                mensaje = "El nombre del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "El apellido del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(mensaje))
            {

                string clave = "contraseñatemporal123";

                obj.Clave = CN_Recursos.ConvertirSha256(clave);

                return objCapaDatos.RegistrarUsuarios(obj, out mensaje);
            }
            else {
                return 0;
            }
            
        }


        public bool EditarUsuarios(Usuario obj, out string mensaje) 
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                mensaje = "El nombre del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                mensaje = "El apellido del usuario no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                mensaje = "El correo del usuario no puede ser vacío";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.EditarUsuarios(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool EliminarUsuarios(int id, out string mensaje) 
        {
            return objCapaDatos.EliminarUsuarios(id, out mensaje);
        }
    }
}
