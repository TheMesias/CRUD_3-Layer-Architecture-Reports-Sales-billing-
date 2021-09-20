using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio; 

namespace CapaPresentacion
{
    public partial class FormAudio : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        private bool Editar = false;
        private bool venta = false; 
        public FormAudio()
        {
            InitializeComponent();
        }

        bool dat = false; 
        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {
            dat = true; 
        }

        private void panelSuperior_MouseUp(object sender, MouseEventArgs e)
        {
            dat = false; 
        }

        private void panelSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            if (dat == true)
            {
                this.Location = Cursor.Position;
            }
        }

        private void btn_radio_Click(object sender, EventArgs e)
        {
            Form1 radio = new Form1();
            radio.Show();
            this.Hide(); 
        }

        private void FormAudio_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarProdAudio();
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarPRodAudio(txt_nombre.Text, txt_descripcion.Text, txt_marca.Text, txt_precio.Text, txt_stock.Text);
                    MessageBox.Show("Se guardo correctamente");
                    MostrarProductos(); //actualizar la lista 
                    Limpiar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProdAudio(txt_nombre.Text, txt_descripcion.Text, txt_marca.Text, txt_precio.Text, txt_stock.Text, idProducto);
                    MessageBox.Show("Se guardo correctamente");
                    MostrarProductos();
                    Limpiar();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar los datos error: " + ex);
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txt_nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txt_marca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txt_descripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txt_precio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txt_stock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que quiere editar");
            }
        }

        private void Limpiar()
        {
            txt_nombre.Clear();
            txt_descripcion.Clear();
            txt_precio.Clear();
            txt_marca.Clear();
            txt_stock.Clear();
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProdAudio(idProducto);
                MessageBox.Show("Se ha eliminado correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("Seleccione la fila que quiere eliminar");
            }
        }


        private void bloc()
        {
            txt_nombre.Enabled = false;
            txt_descripcion.Enabled = false;
            txt_marca.Enabled = false;
            txt_precio.Enabled = false;
        }

        private void debloc()
        {
            txt_nombre.Enabled = true;
            txt_descripcion.Enabled = true;
            txt_marca.Enabled = true;
            txt_precio.Enabled = true;

        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            int stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Stock"].Value.ToString());

            if (dataGridView1.SelectedRows.Count > 0)
            {

                if (stock >= 1)
                {
                    bloc();
                    venta = true;
                    txt_nombre.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                    txt_marca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                    txt_descripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                    txt_precio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                    txt_stock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                    idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                    label5.Text = "Cantidad: ";
                    label4.Text = "Total: ";
                }
                else
                {
                    MessageBox.Show("Prodcuto Agotado");
                }

            }
            else
            {
                MessageBox.Show("Seleccione la fila del producto a comprar");
            }
        }

        private void btn_venta_Click(object sender, EventArgs e)
        {
            if (venta == true)
            {
                try
                {
                    int stock = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Stock"].Value.ToString());
                    int resta = Convert.ToInt32(txt_stock.Text);
                    int entrega = stock - resta;
                    double total = resta * Convert.ToDouble(dataGridView1.CurrentRow.Cells["Precio"].Value.ToString());
        
                    if (entrega >= 0)
                    {
                        objetoCN.EditarProdAudio(txt_nombre.Text, txt_descripcion.Text, txt_marca.Text, txt_precio.Text, entrega.ToString(), idProducto);
                        objetoCN.InsertarVentas(txt_nombre.Text, txt_descripcion.Text, txt_marca.Text, total.ToString(), txt_stock.Text);
                        MessageBox.Show("Se entrego correctamente\nEl total del producto a cobrar es: " + total);
                        MostrarProductos();
                        Limpiar();
                        label5.Text = "Stock: ";
                        label4.Text = "Precio: ";
                        debloc();
                        venta = false;
                    }
                    else
                    {
                        MessageBox.Show("No hay el producto suficiente para completar la orden");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }

        private void btn_report_Click(object sender, EventArgs e)
        {
            FormReporte reporte = new FormReporte();
            reporte.Show();
        }
    }
}
