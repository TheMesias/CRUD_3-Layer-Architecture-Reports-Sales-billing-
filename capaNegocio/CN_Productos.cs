using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos; 

namespace capaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objetoCD = new CD_Productos();
        UserD userD = new UserD(); 
        public DataTable MostrarProd() {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }

        public DataTable MostrarProdAudio() {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarAudio();
            return tabla;
        }

        public DataTable MostrarVentas() {
            DataTable tabla = new DataTable();
            tabla = objetoCD.MostrarVentas();
            return tabla;
        }
        public bool LoginUser(string user, string pass) {
            return userD.Login(user, pass); 
        }

        public void InsertarPRod(string nombre, string desc, string marca, string precio, string stock){
            objetoCD.Insertar(nombre, desc, marca,Convert.ToDouble(precio),Convert.ToInt32(stock)); 
        }

        public void InsertarPRodAudio(string nombre, string desc, string marca, string precio, string stock)
        {
            objetoCD.InsertarAudio(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }

        public void InsertarVentas(string nombre, string desc, string marca, string total, string cantidad)
        {
            objetoCD.InsertarVentas(nombre, desc, marca, Convert.ToDouble(total), Convert.ToInt32(cantidad));
        }
        public void EditarProd(string nombre, string desc, string marca, string precio, string stock, string id) {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EditarProdAudio(string nombre, string desc, string marca, string precio, string stock, string id)
        {
            objetoCD.EditarAudio(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock), Convert.ToInt32(id));
        }

        public void EliminarProd(string id) {
            objetoCD.Eliminar(Convert.ToInt32(id)); 
        }

        public void EliminarProdAudio(string id)
        {
            objetoCD.EliminarAudio(Convert.ToInt32(id));
        }

        public void EliminarVentas() {
            objetoCD.EliminarVentas();
        }

       

    }
}
