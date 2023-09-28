using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Marca
    {
        private CD_Marca objCapaDatos = new CD_Marca();

        public List<Marca> ListarMarcas()
        {
            return objCapaDatos.ListarMarcas();
        }


        public int RegistrarMarcas(Marca obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripción de la marca no puede ser vacía";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.RegistrarMarcas(obj, out mensaje);
            }
            else
            {
                return 0;
            }

        }


        public bool EditarMarcas(Marca obj, out string mensaje)
        {
            mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                mensaje = "La descripción de la marca no puede ser vacía";
            }

            if (string.IsNullOrEmpty(mensaje))
            {
                return objCapaDatos.EditarMarcas(obj, out mensaje);
            }
            else
            {
                return false;
            }
        }


        public bool EliminarMarcas(int id, out string mensaje)
        {
            return objCapaDatos.EliminarMarcas(id, out mensaje);
        }
    }
}
