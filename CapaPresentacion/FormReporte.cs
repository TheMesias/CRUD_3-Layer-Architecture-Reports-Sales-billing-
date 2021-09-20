using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaNegocio;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace CapaPresentacion
{
    public partial class FormReporte : Form
    {
        CN_Productos objetoCN = new CN_Productos();

        
        public FormReporte()
        {
            InitializeComponent();
            MostrarProductos();
        }

        private void MostrarProductos()
        {
            CN_Productos objeto = new CN_Productos();
            dataGridView1.DataSource = objeto.MostrarVentas();
            
        }

        private void btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            objetoCN.EliminarVentas();
            MostrarProductos();
        }

        public void exportarPdf(DataGridView dgw, string Filename) {
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable pdfPTable = new PdfPTable(dgw.Columns.Count);
            pdfPTable.DefaultCell.Padding = 3;
            pdfPTable.WidthPercentage = 100;
            pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL); 

            foreach(DataGridViewColumn column in dgw.Columns){
                PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                //cell.BackgroundColor = new iTextSharp.Color(240, 240, 240);
            }
        }
        private void btn_Pdf_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf)|*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("No se puede guardar " + ex);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try {
                            PdfPTable pTable = new PdfPTable(dataGridView1.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;
                            foreach (DataGridViewColumn col in dataGridView1.Columns) {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell); 
                            }
                            foreach (DataGridViewRow viewRow in dataGridView1.Rows) {
                                foreach (DataGridViewCell dcell in viewRow.Cells) {
                                    pTable.AddCell(dcell.Value.ToString()); 
                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create)) {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                fileStream.Close(); 
                            }

                            MessageBox.Show("Archivo guardado Extisomante", "info"); 
                        } catch (Exception ex){
                            MessageBox.Show("Error mientras se exportaba archivo" + ex.Message);
                        }
                    }
                }
            }
            else {
                MessageBox.Show("No se ha encontrado", "info");
            }
        }
    }
}
