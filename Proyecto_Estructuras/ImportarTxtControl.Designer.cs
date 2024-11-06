namespace Proyecto_Estructuras
{
    partial class ImportarTxtControl
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTJSON = new System.Windows.Forms.Button();
            this.BTRegresar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.BTImportarContra = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TBRutaArchivos = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(482, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(305, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "IMPORTAR ARCHIVO";
            // 
            // BTJSON
            // 
            this.BTJSON.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BTJSON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTJSON.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTJSON.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTJSON.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTJSON.Location = new System.Drawing.Point(105, 215);
            this.BTJSON.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTJSON.Name = "BTJSON";
            this.BTJSON.Size = new System.Drawing.Size(317, 43);
            this.BTJSON.TabIndex = 2;
            this.BTJSON.Text = "Importar ecnriptado";
            this.BTJSON.UseVisualStyleBackColor = false;
            this.BTJSON.Click += new System.EventHandler(this.BTJSON_Click);
            // 
            // BTRegresar
            // 
            this.BTRegresar.BackColor = System.Drawing.Color.DarkRed;
            this.BTRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTRegresar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTRegresar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.BTRegresar.Location = new System.Drawing.Point(717, 404);
            this.BTRegresar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTRegresar.Name = "BTRegresar";
            this.BTRegresar.Size = new System.Drawing.Size(123, 34);
            this.BTRegresar.TabIndex = 4;
            this.BTRegresar.Text = "Regresar";
            this.BTRegresar.UseVisualStyleBackColor = false;
            this.BTRegresar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(79, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(428, 27);
            this.label3.TabIndex = 16;
            this.label3.Text = "Seleccione el tipo de archivo a subir:";
            // 
            // BTImportarContra
            // 
            this.BTImportarContra.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BTImportarContra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BTImportarContra.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTImportarContra.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTImportarContra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTImportarContra.Location = new System.Drawing.Point(485, 215);
            this.BTImportarContra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BTImportarContra.Name = "BTImportarContra";
            this.BTImportarContra.Size = new System.Drawing.Size(329, 43);
            this.BTImportarContra.TabIndex = 21;
            this.BTImportarContra.Text = "Importar texto plano";
            this.BTImportarContra.UseVisualStyleBackColor = false;
            this.BTImportarContra.Click += new System.EventHandler(this.BTImportarContra_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(79, 317);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 27);
            this.label5.TabIndex = 23;
            this.label5.Text = "Colocar dirección de archivo";
            // 
            // TBRutaArchivos
            // 
            this.TBRutaArchivos.Location = new System.Drawing.Point(84, 362);
            this.TBRutaArchivos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TBRutaArchivos.Name = "TBRutaArchivos";
            this.TBRutaArchivos.Size = new System.Drawing.Size(756, 22);
            this.TBRutaArchivos.TabIndex = 24;
            this.TBRutaArchivos.TextChanged += new System.EventHandler(this.TBRutaArchivos_TextChanged);
            // 
            // ImportarTxtControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Proyecto_Estructuras.Properties.Resources.WhatsApp_Image_2024_11_05_at_8_41_32_PM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.TBRutaArchivos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BTImportarContra);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTRegresar);
            this.Controls.Add(this.BTJSON);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ImportarTxtControl";
            this.Size = new System.Drawing.Size(890, 498);
            this.Load += new System.EventHandler(this.ImportarTxtControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTJSON;
        private System.Windows.Forms.Button BTRegresar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button BTImportarContra;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBRutaArchivos;
    }
}
