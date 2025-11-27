using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace RegistrosSqlPractica
{
    public class RegistrosBD
    {
        private string ConexionString = @"server=DESKTOP-AF18HF7\SQLEXPRESS;database=Registro;trusted_connection=true;" + "";

        public bool Ok()
        {
            try
            {
                SqlConnection conexion = new SqlConnection(ConexionString);
                conexion.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public List<RegistrosData> Get()
        {
            List<RegistrosData> registrosDatas = new List<RegistrosData>();

            string consulta = "select Id,Nombre,Apellido from Registros";

            using (SqlConnection Conexion = new SqlConnection(ConexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);


                try
                {
                    Conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        RegistrosData oRegistrosData = new RegistrosData();
                        oRegistrosData.Id = reader.GetInt32(0);
                        oRegistrosData.Nombre = reader.GetString(1);
                        oRegistrosData.Apellido = reader.GetString(2);
                        registrosDatas.Add(oRegistrosData);
                    }
                    Conexion.Close();
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }

            }
            return registrosDatas;

        }

        public RegistrosData Get(int? Id)
        {
           

            string consulta = "select Id, Nombre, Apellido from Registros"+ " where Id=@Id";

            using (SqlConnection Conexion = new SqlConnection(ConexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.Parameters.AddWithValue("@Id", Id);

                try
                {
                    Conexion.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                    reader.Read();
                    {
                        RegistrosData oRegistrosData = new RegistrosData();
                        oRegistrosData.Id = reader.GetInt32(0);
                        oRegistrosData.Nombre = reader.GetString(1);
                        oRegistrosData.Apellido = reader.GetString(2);
                        Conexion.Close();
                        reader.Close();
                        return oRegistrosData;
                    }
                    Conexion.Close();
                    reader.Close();

                }
                catch
                {
                    return null;
                }
                
            }
           

        }

        public void Agregar(string Nombre, string Apellido)
        {
            string consulta = "insert into Registros (Nombre, Apellido) values (@Nombre, @Apellido)";

            using (SqlConnection Conexion = new SqlConnection(ConexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.Parameters.AddWithValue("@Nombre", Nombre);
                comando.Parameters.AddWithValue("@Apellido", Apellido);

                try
                {
                    Conexion.Open();
                    comando.ExecuteNonQuery();
                    Conexion.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }

        public void Editar(string Nombre, string Apellido, int Id)
        {
            string consulta = "update Registros set Nombre=@Nombre, Apellido=@Apellido" + " where id=@Id";

            using (SqlConnection Conexion = new SqlConnection(ConexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.Parameters.AddWithValue("@Nombre", Nombre);
                comando.Parameters.AddWithValue("@Apellido", Apellido);
                comando.Parameters.AddWithValue("@Id", Id);

                try
                {
                    Conexion.Open();
                    comando.ExecuteNonQuery();
                    Conexion.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }


        public void Eliminar( int Id)
        {
            string consulta = "delete from Registros" + " where id=@Id";

            using (SqlConnection Conexion = new SqlConnection(ConexionString))
            {
                SqlCommand comando = new SqlCommand(consulta, Conexion);
                comando.Parameters.AddWithValue("@Id", Id);

                try
                {
                    Conexion.Open();
                    comando.ExecuteNonQuery();
                    Conexion.Close();

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }
        }
    }
}

