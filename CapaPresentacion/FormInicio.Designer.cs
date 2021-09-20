
namespace CapaPresentacion
{
    partial class FormInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicio));
            this.btn_Audio = new System.Windows.Forms.PictureBox();
            this.btn_Radio = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Audio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Radio)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Audio
            // 
            this.btn_Audio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Audio.Image = ((System.Drawing.Image)(resources.GetObject("btn_Audio.Image")));
            this.btn_Audio.Location = new System.Drawing.Point(49, 40);
            this.btn_Audio.Name = "btn_Audio";
            this.btn_Audio.Size = new System.Drawing.Size(100, 100);
            this.btn_Audio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Audio.TabIndex = 0;
            this.btn_Audio.TabStop = false;
            this.btn_Audio.Click += new System.EventHandler(this.btn_Audio_Click);
            // 
            // btn_Radio
            // 
            this.btn_Radio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Radio.Image = ((System.Drawing.Image)(resources.GetObject("btn_Radio.Image")));
            this.btn_Radio.Location = new System.Drawing.Point(194, 40);
            this.btn_Radio.Name = "btn_Radio";
            this.btn_Radio.Size = new System.Drawing.Size(100, 100);
            this.btn_Radio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btn_Radio.TabIndex = 1;
            this.btn_Radio.TabStop = false;
            this.btn_Radio.Click += new System.EventHandler(this.btn_Radio_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "AUDIO ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "RADIO";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 212);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Radio);
            this.Controls.Add(this.btn_Audio);
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormInicio_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormInicio_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormInicio_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Audio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Radio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btn_Audio;
        private System.Windows.Forms.PictureBox btn_Radio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}