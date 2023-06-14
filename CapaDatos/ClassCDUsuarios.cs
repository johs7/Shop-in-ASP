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

        public int Registrar(ClassUsuario obj,out string Mensaje)
        {
            int idautogenerado = 0;
            Mensaje = string.Empty;
            try
            {
                using(SqlConnection oconexion=new SqlConnection(ClassConexion.cn))
                {
                    SqlCommand cmd=new SqlCommand("sp_RegistrarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado",SqlDbType.Int).Direction=ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje",SqlDbType.VarChar,500).Direction=ParameterDirection.Output;
                    cmd.CommandType=CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value.ToString());
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }

            }
            catch(Exception ex)
            {
                idautogenerado = 0;
                Mensaje = ex.Message;
            }
            return idautogenerado;
        }
        public bool Editar(ClassUsuario obj,string Mensaje)
        {
            bool resultado = false;
            Mensaje = string.Empty;
            try
            {
                using(SqlConnection oconexion=new SqlConnection(ClassConexion.cn))
                {
                    SqlCommand cmd=new SqlCommand("sp_EditarUsuario", oconexion);
                    cmd.Parameters.AddWithValue("IdUsuario", obj.IdUsuario);
                    cmd.Parameters.AddWithValue("Nombres", obj.Nombres);
                    cmd.Parameters.AddWithValue("Apellidos", obj.Apellidos);
                    cmd.Parameters.AddWithValue("Correo", obj.Correo);
                    cmd.Parameters.AddWithValue("Clave", obj.Clave);
                    cmd.Parameters.AddWithValue("Activo", obj.Activo);
                    cmd.Parameters.Add("Resultado",SqlDbType.Int).Direction=ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje",SqlDbType.VarChar,500).Direction=ParameterDirection.Output;
                    cmd.CommandType=CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value.ToString());
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }   
            }
            catch(Exception ex)
            {
                resultado = false;
                Mensaje = ex.Message;
            }
            return resultado;
        }
    }
}
