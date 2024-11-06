using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Estructuras
{
    public partial class FormMenu : Form
    {
        ImportarTxtControl importarTxtControl;
        TbValorNuevo EditarConstrasena;
        AgregarContrasena agregarContrasena; // Cambiado a minúscula para distinguir
        Form2 form2;
        private int contadorInactividad = 0; // Contador de segundos de inactividad
        private const int tiempoLimite = 60;

        public AgregarContrasena AgregarContrasenaForm { get; private set; } // Renombrado a AgregarContrasenaForm
        public string MasterPassword { get; set; }

        public FormMenu()
        {
            InitializeComponent();
            importarTxtControl = new ImportarTxtControl(this);
            EditarConstrasena = new TbValorNuevo(this);
            AgregarContrasenaForm = new AgregarContrasena(this);

            form2 = new Form2();

            timerInactividad.Interval = 1000;
            timerInactividad.Tick += timerInactividad_Tick; // Asigna el evento Tick al temporizador
            timerInactividad.Start();

            // Asignar eventos para reiniciar el contador de inactividad
            this.KeyPress += new KeyPressEventHandler(ReiniciarContadorInactividad); // Solo tecla presionada

            // Asignar evento Click a todos los botones del formulario
            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Click += new EventHandler(ReiniciarContadorInactividad);
                }
            }
        }

        private void timerInactividad_Tick(object sender, EventArgs e)
        {
            contadorInactividad++; // Incrementa el contador de inactividad cada segundo

            if (contadorInactividad >= tiempoLimite)
            {
                timerInactividad.Stop();
                // Muestra el mensaje y cierra la aplicación
                MessageBox.Show("Por seguridad, la aplicación se cerrará por inactividad.");
                Application.Exit();
            }
        }

        // Método para reiniciar el contador de inactividad
        public void ReiniciarContadorInactividad(object sender, EventArgs e)
        {
            contadorInactividad = 0; // Restablece el contador de inactividad a 0
            if (!timerInactividad.Enabled)
            {
                timerInactividad.Start(); // Reinicia el temporizador si se había detenido
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form2.LoadUserControl(importarTxtControl);
            form2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form2.LoadUserControl(EditarConstrasena);
            form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form2.LoadUserControl(AgregarContrasenaForm); // Usar la nueva propiedad
            form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
