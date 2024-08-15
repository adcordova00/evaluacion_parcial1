namespace evaluacion_parcial1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Data;
    using evaluacion_parcial1.Config;
    class ReservacionModel
    {
        public int reservacion_id { get; set; }
        public string nombre { get; set; }
        public int cliente_id { get; set; }
        public int evento_id { get; set; }
        public DateTime fecha { get; set; }
        public string descripcion { get; set; }
        

        private ConexionBDD conexion = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();

        public List<ReservacionModel> Reservas()
        {
            List<ReservacionModel> listaReservaciones = new List<ReservacionModel>();
            string cadena = "select *  from reservaciones";
            SqlDataAdapter adapter = new SqlDataAdapter(cadena, conexion.AbrirConexion());
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            foreach (DataRow reservacion in tabla.Rows)
            {
                ReservacionModel nuevareserva = new ReservacionModel
                {
                    reservacion_id = Convert.ToInt32(reservacion["reservacion_id"]),
                    nombre = reservacion["nombre"].ToString(),
                    cliente_id = Convert.ToInt32(reservacion["cliente_id"]),
                    evento_id = Convert.ToInt32(reservacion["evento_id"]),
                    fecha = Convert.ToDateTime(reservacion["fecha"]),
                    descripcion = reservacion["descripcion"].ToString(),

                };
                listaReservaciones.Add(nuevareserva);
            }

            conexion.CerrarConexcion();
            return listaReservaciones;
        }
        public ReservacionModel Reserva(ReservacionModel reserva)
        {
            string cadena = "select * from reservaciones where reservacion_id=" + reserva.reservacion_id;
            cmd = new SqlCommand(cadena, conexion.AbrirConexion());
            SqlDataReader lector = cmd.ExecuteReader();

            lector.Read();
            ReservacionModel returned_reserva = new ReservacionModel
            {
                reservacion_id = Convert.ToInt32(lector["reservacion_id"]),
                nombre = lector["nombre"].ToString(),
                cliente_id = Convert.ToInt32(lector["cliente_id"]),
                evento_id = Convert.ToInt32(lector["evento_id"]),
                fecha = Convert.ToDateTime(lector["fecha"]),
                descripcion = lector["descripcion"].ToString(),
            };
            conexion.CerrarConexcion();
            return returned_reserva;
        }
        public string SaveReserva(ReservacionModel reserva)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "INSERT INTO reservaciones (nombre, cliente_id, evento_id, fecha, descripcion) VALUES (@nombre, @cliente_id, @evento_id, @fecha, @descripcion)";

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", reserva.nombre);
                cmd.Parameters.AddWithValue("@cliente_id", reserva.cliente_id);
                cmd.Parameters.AddWithValue("@evento_id", reserva.evento_id);
                cmd.Parameters.AddWithValue("@fecha", reserva.fecha);
                cmd.Parameters.AddWithValue("@descripcion", reserva.descripcion);
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
        public string UpdateReserva(ReservacionModel reserva)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "UPDATE reservaciones SET nombre = @nombre, cliente_id = @cliente_id, evento_id = @evento_id, fecha = @fecha, descripcion = @descripcion WHERE reservacion_id = @reservacion_id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nombre", reserva.nombre);
                cmd.Parameters.AddWithValue("@cliente_id", reserva.cliente_id);
                cmd.Parameters.AddWithValue("@evento_id", reserva.evento_id);
                cmd.Parameters.AddWithValue("@fecha", reserva.fecha);
                cmd.Parameters.AddWithValue("@descripcion", reserva.descripcion);
                cmd.Parameters.AddWithValue("@reservacion_id", reserva.reservacion_id);
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
        public string DeleteReserva(ReservacionModel reserva)
        {
            try
            {
                cmd.Connection = conexion.AbrirConexion();
                cmd.CommandText = "delete from reservaciones where reservacion_id =" + reserva.reservacion_id;
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
