using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Categoria
    {
        private CD_Categoria objCapaDatos = new CD_Categoria();

        public List<Categoria> ListarCategorias()
        {
            return objCapaDatos.ListarCategorias();
        }


        public int RegistrarCategorias(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripción de la categoría no puede ser vacía";
            } 

            if (string.IsNullOrEmpty(mensaje))
            {
                    return objCapaDatos.RegistrarCategorias(obj, out mensaje);
            }
            else
            {
                return 0;
            }

        }


        public bool EditarCategorias(Categoria obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripción de la categoría no puede ser vacía";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.EditarCategorias(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool EliminarCategorias(int id, out string mensaje)
        {
            return objCapaDatos.EliminarCategorias(id, out mensaje);
        }
    }
}
