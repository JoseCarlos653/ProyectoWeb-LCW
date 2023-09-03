using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Usuarios
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.conn))
                {
                    string query = "SELECT IdUsuario, Nombres, Apellidos, Correo, Clave, Reestablecer, Activo FROM USUARIO";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;
                    conexion.Open();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while (dr.Read()) {
                            listaUsuarios.Add(
                                new Usuario()
                                {
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    Nombres = dr["Nombres"].ToString(),
                                    Apellidos = dr["Apellidos"].ToString(),
                                    Correo = dr["Correo"].ToString(),
                                    Clave = dr["Clave"].ToString(),
                                    Reestablecer = Convert.ToBoolean(dr["Reestablecer"]),
                                    Activo = Convert.ToBoolean(dr["Activo"]),
                                }

                                );
                        }
                    }

                }
            }
            catch (Exception)
            {
                listaUsuarios = new List<Usuario>();
            }
            return listaUsuarios;
        }
    }
}
