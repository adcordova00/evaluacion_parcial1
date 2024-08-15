namespace evaluacion_parcial1.Config
{
    using System.Data.SqlClient;
    using System.Data;
    class ConexionBDD
    {
        private SqlConnection connection = new SqlConnection("Server=DESKTOP-KA0EPGU\\SQLEXPRESS;database=Eventos;uid=sa;pwd=1234");

        public SqlConnection AbrirConexion()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
        public SqlConnection CerrarConexcion()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
            return connection;
        }
    }
}
