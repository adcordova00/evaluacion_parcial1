namespace evaluacion_parcial1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using evaluacion_parcial1.Config;
    using System.Windows.Forms;

    class ClienteModel
    {
        public int cliente_id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string telefono { get; set; }


        List<ClienteModel> listaClientes = new List<ClienteModel>();
        private ConexionBDD conexion = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();
        public List<ClienteModel> Clientes()
        { 
            string cadena = "select * from clientes";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexion.AbrirConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            foreach (DataRow cliente in tabla.Rows)
            {
                ClienteModel nuevocliente = new ClienteModel
                {
                    cliente_id = Convert.ToInt32(cliente["cliente_id"]),
                    nombre = cliente["nombre"].ToString(),
                    apellido = cliente["apellido"].ToString(),
                    email = cliente["email"].ToString(),
                    telefono = cliente["telefono"].ToString(),
                };
                listaClientes.Add(nuevocliente);
            }

            conexion.CerrarConexcion();
            return listaClientes;
        }
        public ClienteModel Cliente(ClienteModel cliente)
        { 
            string cadena = "select * from clientes where cliente_id=" + cliente.cliente_id;
            cmd = new SqlCommand(cadena, conexion.AbrirConexion());
            SqlDataReader lector = cmd.ExecuteReader();

            lector.Read();
            ClienteModel returned_cliente = new ClienteModel
            {
                cliente_id = Convert.ToInt32(lector["cliente_id"]),
                nombre = lector["nombre"].ToString(),
                apellido = lector["apellido"].ToString(),
                email = lector["email"].ToString(),
                telefono = lector["telefono"].ToString(),
            };
            conexion.CerrarConexcion();
            return returned_cliente;
        }
        public string SaveCliente(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "INSERT INTO clientes (nombre, apellido, email, telefono) VALUES (@nombre, @apellido, @email, @telefono)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@email", cliente.email);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception ex)
            {
                return "erorr: " + ex.Message;
            }
            finally
            {
                conexion.CerrarConexcion();
            }
        }
        public string UpdateCliente(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "UPDATE clientes SET nombre = @nombre, apellido = @apellido, email = @email, telefono = @telefono WHERE cliente_id = @cliente_id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", cliente.nombre);
                cmd.Parameters.AddWithValue("@apellido", cliente.apellido);
                cmd.Parameters.AddWithValue("@correo", cliente.email);
                cmd.Parameters.AddWithValue("@telefono", cliente.telefono);
                cmd.Parameters.AddWithValue("@cliente_id", cliente.cliente_id);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception ex)
            {
                return "erorr: " + ex.Message;
            }
            finally
            {
                conexion.CerrarConexcion();
            }
        }
        public string DeleteCliente(ClienteModel cliente)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "DELETE FROM clientes WHERE cliente_id = @cliente_id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@cliente_id", cliente.cliente_id);
                cmd.ExecuteNonQuery();
                return "ok";
            }
            catch (Exception ex)
            {
                return "erorr: " + ex.Message;
            }
            finally
            {
                conexion.CerrarConexcion();
            }
        }
    }
}
