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
        


        List<ReservacionModel> listaReservaciones = new List<ReservacionModel>();
        private ConexionBDD conexion = new ConexionBDD();
        SqlCommand cmd = new SqlCommand();

        public List<ReservacionModel> Reservas()
        {
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
                cmd.CommandText = "insert into reservaciones(nombre) values('" + reserva.nombre + "')";
                cmd.CommandText = "insert into reservaciones(fecha) values('" + reserva.fecha + "')";
                cmd.CommandText = "insert into reservaciones(descripcion) values('" + reserva.descripcion + "')";
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
                cmd.CommandText = "update reservaciones set nombre='" + reserva.nombre + "' where reservacion_id=" + reserva.reservacion_id;
                cmd.CommandText = "update reservaciones set fecha='" + reserva.fecha + "' where reservacion_id=" + reserva.reservacion_id;
                cmd.CommandText = "update reservaciones set descripcion='" + reserva.descripcion + "' where reservacion_id=" + reserva.reservacion_id;
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
