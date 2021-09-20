using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=DESKTOP-CD6TPPE\\SQLEXPRESS;DataBase= Practica;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion; 
        }

        public SqlConnection CerrarConexion() {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion; 
        }
    }
}
