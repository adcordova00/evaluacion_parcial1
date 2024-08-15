namespace evaluacion_parcial1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using evaluacion_parcial1.Config;
    using System.Windows.Forms;

    class EventoModel
    {
        public int evento_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string ubicacion { get; set; }
        public DateTime fecha { get; set; }

        private ConexionBDD conexion = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();

        public List<EventoModel> Eventos()
        {
            List<EventoModel> listaEventos = new List<EventoModel>();
            string cadena = "select *  from eventos";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexion.AbrirConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            foreach (DataRow evento in tabla.Rows)
            {
                EventoModel nuevoevento = new EventoModel
                {
                    evento_id = Convert.ToInt32(evento["evento_id"]),
                    nombre = evento["nombre"].ToString(),
                    descripcion = evento["descripcion"].ToString(),
                    ubicacion = evento["ubicacion"].ToString(),
                    fecha = Convert.ToDateTime(evento["fecha"]),
                };
                listaEventos.Add(nuevoevento);
            }

            conexion.CerrarConexcion();
            return listaEventos;
        }
        public EventoModel Evento(EventoModel evento)
        {
            string cadena = "select * from eventos where evento_id=" + evento.evento_id;
            cmd = new SqlCommand(cadena, conexion.AbrirConexion());
            SqlDataReader lector = cmd.ExecuteReader();

            lector.Read();
            EventoModel returned_evento = new EventoModel
            {
                evento_id = Convert.ToInt32(lector["evento_id"]),
                nombre = lector["nombre"].ToString(),
                descripcion = lector["descripcion"].ToString(),
                ubicacion = lector["ubicacion"].ToString(),
                fecha = Convert.ToDateTime(lector["fecha"]),
            };
            conexion.CerrarConexcion();
            return returned_evento;
        }
        public string SaveEvento(EventoModel evento)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "INSERT INTO eventos (nombre, descripcion, ubicacion, fecha) VALUES (@nombre, @descripcion, @ubicacion, @fecha)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", evento.nombre);
                cmd.Parameters.AddWithValue("@descripcion", evento.descripcion);
                cmd.Parameters.AddWithValue("@ubicacion", evento.ubicacion);
                cmd.Parameters.AddWithValue("@fecha", evento.fecha);
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
        public string UpdateEvento(EventoModel evento)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "UPDATE eventos SET nombre = @nombre, descripcion = @descripcion, ubicacion = @ubicacion, fecha = @fecha WHERE evento_id = @evento_id";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", evento.nombre);
                cmd.Parameters.AddWithValue("@descripcion", evento.descripcion);
                cmd.Parameters.AddWithValue("@ubicacion", evento.ubicacion);
                cmd.Parameters.AddWithValue("@fecha", evento.fecha);
                cmd.Parameters.AddWithValue("@evento_id", evento.evento_id);
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
        public string DeleteEvento(EventoModel evento)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "delete from eventos where evento_id =" + evento.evento_id;
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

        public List<EventoModel> ObtenerEventos()
        {
            List<EventoModel> eventosBox = new List<EventoModel>();

            try
            {
                string query = "SELECT evento_id, nombre FROM eventos";
                SqlCommand cmd = new SqlCommand(query, conexion.AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EventoModel evento = new EventoModel
                    {
                        evento_id = Convert.ToInt32(reader["evento_id"]),
                        nombre = reader["nombre"].ToString()
                    };
                    eventosBox.Add(evento);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los eventos: " + ex.Message);
            }
            finally
            {
                conexion.CerrarConexcion();
            }

            return eventosBox;
        }

    }
}
