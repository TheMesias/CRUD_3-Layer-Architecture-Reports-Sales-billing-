using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btn_Audio_Click(object sender, EventArgs e)
        {
            FormAudio audio = new FormAudio();
            audio.Show();
            this.Hide(); 
        }

        private void btn_Radio_Click(object sender, EventArgs e)
        {
            Form1 radio = new Form1();
            radio.Show();
            this.Hide(); 
        }

        bool dat = false;
        private void FormInicio_MouseDown(object sender, MouseEventArgs e)
        {
            dat = true; 
        }

        private void FormInicio_MouseUp(object sender, MouseEventArgs e)
        {
            dat = false; 
        }

        private void FormInicio_MouseMove(object sender, MouseEventArgs e)
        {
            if (dat == true)
            {
                this.Location = Cursor.Position;
            }
        }
    }
}
