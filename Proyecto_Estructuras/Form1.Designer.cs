namespace Proyecto_Estructuras
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TBContraMaestra = new System.Windows.Forms.TextBox();
            this.BTIngresar = new System.Windows.Forms.Button();
            this.BTCerrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(217, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Contraseña:";
            // 
            // TBContraMaestra
            // 
            this.TBContraMaestra.BackColor = System.Drawing.Color.LightSkyBlue;
            this.TBContraMaestra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBContraMaestra.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBContraMaestra.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TBContraMaestra.Location = new System.Drawing.Point(109, 463);
            this.TBContraMaestra.Margin = new System.Windows.Forms.Padding(4);
            this.TBContraMaestra.Name = "TBContraMaestra";
            this.TBContraMaestra.Size = new System.Drawing.Size(343, 24);
            this.TBContraMaestra.TabIndex = 1;
            this.TBContraMaestra.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BTIngresar
            // 
            this.BTIngresar.BackColor = System.Drawing.Color.SteelBlue;
            this.BTIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTIngresar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTIngresar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BTIngresar.Location = new System.Drawing.Point(109, 519);
            this.BTIngresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTIngresar.Name = "BTIngresar";
            this.BTIngresar.Size = new System.Drawing.Size(343, 34);
            this.BTIngresar.TabIndex = 2;
            this.BTIngresar.Text = "Ingresar";
            this.BTIngresar.UseVisualStyleBackColor = false;
            this.BTIngresar.Click += new System.EventHandler(this.button1_Click);
            // 
            // BTCerrar
            // 
            this.BTCerrar.BackColor = System.Drawing.Color.DarkRed;
            this.BTCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BTCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTCerrar.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCerrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTCerrar.Location = new System.Drawing.Point(457, 12);
            this.BTCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTCerrar.Name = "BTCerrar";
            this.BTCerrar.Size = new System.Drawing.Size(45, 34);
            this.BTCerrar.TabIndex = 3;
            this.BTCerrar.Text = "X";
            this.BTCerrar.UseVisualStyleBackColor = false;
            this.BTCerrar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(173, 340);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "Inicio de Sesión";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.WhatsApp_Image_2024_11_05_at_8_16_00_PM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(568, 633);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BTCerrar);
            this.Controls.Add(this.BTIngresar);
            this.Controls.Add(this.TBContraMaestra);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBContraMaestra;
        private System.Windows.Forms.Button BTIngresar;
        private System.Windows.Forms.Button BTCerrar;
        private System.Windows.Forms.Label label2;
    }
}

