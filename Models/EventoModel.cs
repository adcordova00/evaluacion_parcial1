namespace evaluacion_parcial1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using evaluacion_parcial1.Config;

    class EventoModel
    {
        public int evento_id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        public string ubicacion { get; set; }
        public int cliente_id { get; set; }


        List<EventoModel> listaEventos = new List<EventoModel>();
        private ConexionBDD conexion = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();

        public List<EventoModel> Eventos()
        {
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
                    fecha = Convert.ToDateTime(evento["fecha"]),
                    ubicacion = evento["ubicacion"].ToString(),
                    cliente_id = Convert.ToInt32(evento["cliente_id"]),
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
                fecha = Convert.ToDateTime(lector["fecha"]),
                ubicacion = lector["ubicacion"].ToString(),
                cliente_id = Convert.ToInt32(lector["cliente_id"]),
            };
            conexion.CerrarConexcion();
            return returned_evento;
        }
        public string SaveEvento(EventoModel evento)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "INSERT INTO eventos (nombre, descripcion, fecha, ubicacion) VALUES (@nombre, @descripcion, @fecha, @ubicacion)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", evento.nombre);
                cmd.Parameters.AddWithValue("@descripcion", evento.descripcion);
                cmd.Parameters.AddWithValue("@fecha", evento.fecha);
                cmd.Parameters.AddWithValue("@ubicacion", evento.ubicacion);
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
                cmd.CommandText = "update eventos set nombre='" + evento.nombre + "' where evento_id=" + evento.evento_id;
                cmd.CommandText = "update eventos set descripcion='" + evento.descripcion + "' where evento_id=" + evento.evento_id;
                cmd.CommandText = "update eventos set fecha='" + evento.fecha + "' where evento_id=" + evento.evento_id;
                cmd.CommandText = "update eventos set ubicacion='" + evento.ubicacion + "' where evento_id=" + evento.evento_id;
                cmd.CommandText = "update eventos set cliente_id='" + evento.cliente_id + "' where evento_id=" + evento.evento_id;
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

    }
}
