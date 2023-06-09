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
    public class ClassCDUsuarios
    {
        public List<ClassUsuario> Listar()
        {
            List<ClassUsuario> Lista = new List<ClassUsuario>();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(ClassConexion.cn))
                {
                    string query= "select * from usuario";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr=cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                          Lista.Add(
                              new ClassUsuario()
                              {
                              IdUsuario = Convert.ToInt32(dr["IdUsuario"].ToString()),
                              Nombres = dr["Nombres"].ToString(),
                              Apellidos = dr["Apellidos"].ToString(),
                              Correo = dr["Correo"].ToString(),
                              Clave = dr["Clave"].ToString(),
                              Reestablecer = Convert.ToBoolean(dr["Reestablecer"].ToString()),
                              Activo = Convert.ToBoolean(dr["Activo"].ToString()),
                          }
                              );
                        }   
                    }
                } 
            }
            catch
            {
                Lista=new List<ClassUsuario>();
            }
            return Lista;
        }
    }
}
