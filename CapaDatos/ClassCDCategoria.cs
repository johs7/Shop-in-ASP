using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class ClassCDCategoria
    {
        public List<ClassCategoria> Listar()
        {
            List<ClassCategoria> Lista = new List<ClassCategoria>();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(ClassConexion.cn))
                {
                    string query = "select * from category";
                    SqlCommand cmd = new SqlCommand(query, oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(
                                new ClassCategoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["Idcategoria"].ToString()),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"].ToString()),
                                }
                                );
                        }
                    }
                }
            }
            catch
            {
                Lista = new List<ClassCategoria>();
            }
            return Lista;
        }
    }
}
