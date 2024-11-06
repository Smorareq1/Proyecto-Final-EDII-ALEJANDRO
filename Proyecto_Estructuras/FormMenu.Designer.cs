namespace Proyecto_Estructuras
{
    partial class FormMenu
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Button BTEditarContras;
            this.button5 = new System.Windows.Forms.Button();
            this.BTAgregarContras = new System.Windows.Forms.Button();
            this.BTImportar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerInactividad = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            BTEditarContras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BTEditarContras
            // 
            BTEditarContras.BackColor = System.Drawing.Color.SteelBlue;
            BTEditarContras.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.editarArchivo;
            BTEditarContras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            BTEditarContras.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            BTEditarContras.ForeColor = System.Drawing.Color.AliceBlue;
            BTEditarContras.Location = new System.Drawing.Point(520, 181);
            BTEditarContras.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            BTEditarContras.Name = "BTEditarContras";
            BTEditarContras.Size = new System.Drawing.Size(66, 63);
            BTEditarContras.TabIndex = 9;
            BTEditarContras.Text = ">";
            BTEditarContras.UseVisualStyleBackColor = false;
            BTEditarContras.Click += new System.EventHandler(this.button3_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkRed;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button5.Cursor = System.Windows.Forms.Cursors.Default;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button5.Location = new System.Drawing.Point(637, 13);
            this.button5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(45, 34);
            this.button5.TabIndex = 6;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // BTAgregarContras
            // 
            this.BTAgregarContras.BackColor = System.Drawing.Color.Transparent;
            this.BTAgregarContras.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.contrasena;
            this.BTAgregarContras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTAgregarContras.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTAgregarContras.ForeColor = System.Drawing.Color.AliceBlue;
            this.BTAgregarContras.Location = new System.Drawing.Point(520, 281);
            this.BTAgregarContras.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BTAgregarContras.Name = "BTAgregarContras";
            this.BTAgregarContras.Size = new System.Drawing.Size(66, 62);
            this.BTAgregarContras.TabIndex = 10;
            this.BTAgregarContras.Text = ">";
            this.BTAgregarContras.UseVisualStyleBackColor = false;
            this.BTAgregarContras.Click += new System.EventHandler(this.button4_Click);
            // 
            // BTImportar
            // 
            this.BTImportar.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BTImportar.BackColor = System.Drawing.Color.Transparent;
            this.BTImportar.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.ImportarArchivo;
            this.BTImportar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTImportar.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTImportar.ForeColor = System.Drawing.Color.AliceBlue;
            this.BTImportar.Location = new System.Drawing.Point(520, 77);
            this.BTImportar.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.BTImportar.Name = "BTImportar";
            this.BTImportar.Size = new System.Drawing.Size(66, 62);
            this.BTImportar.TabIndex = 8;
            this.BTImportar.Text = ">";
            this.BTImportar.UseVisualStyleBackColor = false;
            this.BTImportar.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.AliceBlue;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label2.Location = new System.Drawing.Point(73, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(437, 86);
            this.label2.TabIndex = 12;
            this.label2.Text = "EDICIÓN DE ARCHIVOS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.AliceBlue;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label3.Location = new System.Drawing.Point(114, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(396, 86);
            this.label3.TabIndex = 13;
            this.label3.Text = "AGREGAR CONTRASEÑAS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerInactividad
            // 
            this.timerInactividad.Enabled = true;
            this.timerInactividad.Interval = 1000;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(63, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(433, 81);
            this.label1.TabIndex = 11;
            this.label1.Text = "IMPORTAR ARCHIVO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.WhatsApp_Image_2024_11_05_at_8_26_49_PM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(696, 441);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.BTAgregarContras);
            this.Controls.Add(BTEditarContras);
            this.Controls.Add(this.BTImportar);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button BTAgregarContras;
        private System.Windows.Forms.Button BTImportar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerInactividad;
        private System.Windows.Forms.Label label1;
    }
}