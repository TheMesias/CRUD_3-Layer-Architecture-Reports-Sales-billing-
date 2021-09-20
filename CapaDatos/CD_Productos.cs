using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Productos:CD_Conexion
    {
        //private CD_Conexion conexion = new CD_Conexion();
        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar() {
            comando.Connection = AbrirConexion();
            comando.CommandText = "MostrarProductos"; //"Select *from Productos";
            comando.CommandType = CommandType.StoredProcedure;//para procedurede
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CerrarConexion();
            return tabla; 
        }

        public DataTable MostrarAudio() {
            comando.Connection = AbrirConexion();
            comando.CommandText = "MostrarProductosAudio";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CerrarConexion();
            return tabla; 
        }

        public DataTable MostrarVentas() {
            comando.Connection = AbrirConexion();
            comando.CommandText = "MostrarVentas";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            CerrarConexion();
            return tabla;
        }

        public void Insertar(string nombre, string desc, string marca, double precio, int stock) {           
            comando.Connection = AbrirConexion();
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear(); 
        }

        public void InsertarAudio(string nombre, string desc, string marca, double precio, int stock)
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "InsertarProductosAudio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void InsertarVentas(string nombre, string desc, string marca, double total, int cantidad) 
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "InsertarVentas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@total", total);
            comando.Parameters.AddWithValue("@cantidad", cantidad);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(string nombre, string desc, string marca, double precio, int stock, int id) {
            comando.Connection = AbrirConexion();
            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear(); 
        }

        public void EditarAudio(string nombre, string desc, string marca, double precio, int stock, int id)
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "EditarProductosAudio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@desc", desc);
            comando.Parameters.AddWithValue("@marca", marca);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@stock", stock);
            comando.Parameters.AddWithValue("@id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id) {
            comando.Connection = AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear(); 
        }

        public void EliminarAudio(int id)
        {
            comando.Connection = AbrirConexion();
            comando.CommandText = "EliminarProductoAudio";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@idpro", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void EliminarVentas() {
            comando.Connection = AbrirConexion();
            comando.CommandText = "EliminarVentas";
            comando.CommandType = CommandType.StoredProcedure;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

      

        
    }
}
