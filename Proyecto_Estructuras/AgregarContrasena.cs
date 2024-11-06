using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Linq;

namespace Proyecto_Estructuras
{
    public partial class AgregarContrasena : UserControl
    {
        FormMenu formMenu;
        public static class GlobalData
        {
            public static Dictionary<int, SitioInfo> SitiosData { get; set; } = new Dictionary<int, SitioInfo>();
            public static int CurrentId { get; set; } = 1; // Para gestionar el ID actual
        }

        // Propiedad para almacenar la contraseña maestra
        public string MasterPassword { get; set; }

        public CripRSA rsa = new CripRSA();


        public AgregarContrasena(FormMenu formMenu)
        {
            InitializeComponent();
            this.formMenu = formMenu;

            foreach (Control control in this.Controls)
            {
                if (control is Button)
                {
                    control.Click += new EventHandler(formMenu.ReiniciarContadorInactividad);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);
            formMenu.Show();
            this.ParentForm.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

            if (string.IsNullOrWhiteSpace(TBNombreSitio.Text))
            {
                MessageBox.Show("El campo 'Nombre del sitio' es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBContradatos.Text))
            {
                MessageBox.Show("El campo 'Contraseña' es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBURL.Text) || !Uri.IsWellFormedUriString(TBURL.Text, UriKind.Absolute))
            {
                MessageBox.Show("El campo 'URL' es obligatorio y debe tener un formato válido.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBUsuario.Text))
            {
                MessageBox.Show("El campo 'Usuario' es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBNotas.Text))
            {
                MessageBox.Show("El campo 'Notas' es obligatorio.");
                return;
            }
            if (!EsContraseñaValida(TBContradatos.Text))
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres y contener:\n- Una letra mayúscula (A-Z)\n- Una letra minúscula (a-z)\n- Un número (0-9)\n- Un carácter especial (como !@#$%^&*())");
                return;
            }

            // Verificar formato de correo en Extra2 (opcional)
            if (!string.IsNullOrWhiteSpace(TBCorreo.Text) && !IsValidEmail(TBCorreo.Text))
            {
                MessageBox.Show("El campo 'Correo' no tiene un formato válido.");
                return;
            }

            // Validación de campos vacíos en AgregarContrasena
            if (string.IsNullOrWhiteSpace(TBNombreSitio.Text) ||
                string.IsNullOrWhiteSpace(TBContradatos.Text) ||
                string.IsNullOrWhiteSpace(TBURL.Text) ||
                string.IsNullOrWhiteSpace(TBUsuario.Text) ||
                string.IsNullOrWhiteSpace(TBNotas.Text))
            {
                MessageBox.Show("Debe llenar los campos esceniales: Nombre del sitio, Contraseña, URL, Usuario y Notas adic");
                return;
            }

            //Encriptar valor contraseña con RSA
            string contraEncriptada = rsa.Encriptar(TBContradatos.Text);

            // Crear y almacenar la información en el diccionario
            var nuevoSitio = new SitioInfo
            {
                Id = GlobalData.CurrentId,
                NombreSitio = TBNombreSitio.Text,
                Extra1 = TBTipoCuenta.Text,
                Contrasena = contraEncriptada,
                URL = TBURL.Text,
                Extra2 = TBCorreo.Text,
                Extra3 = TBCel.Text,
                Etiquetas = TBEtiquetas.Text,
                Usuario = TBUsuario.Text,
                Notas = TBNotas.Text,
                Imagen = TBImagen.Text,
                Extra4 = TBPerro.Text,
                Extra5 = TBPadre.Text,
                FechaGuardado = DateTime.UtcNow,
                FechaActualizacion = DateTime.UtcNow,
                FechaVencimiento = DateTime.UtcNow.AddMonths(6)
            };

            
            if (GlobalData.SitiosData.ContainsKey(GlobalData.CurrentId))
            {
                int indexMax = GlobalData.SitiosData.Keys.Max() + 1;
                GlobalData.SitiosData[indexMax] = nuevoSitio;
            }
            else
            {
                // Guardar en el diccionario usando CurrentId como clave
                GlobalData.SitiosData[GlobalData.CurrentId] = nuevoSitio;
                GlobalData.CurrentId++; // Incrementa el ID para el siguiente elemento

            }

            MessageBox.Show("Información guardada con éxito.");
            LimpiarCampos();
        }

        private bool EsContraseñaValida(string contraseña)
        {
            // La contraseña debe tener al menos 8 caracteres, una mayúscula, una minúscula, un número y un carácter especial
            var regex = new System.Text.RegularExpressions.Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^&*()]).{8,}$");
            return regex.IsMatch(contraseña);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private void LimpiarCampos()
        {
            TBNombreSitio.Text = "";
            TBTipoCuenta.Text = "";
            TBContradatos.Text = "";
            TBURL.Text = "";
            TBCorreo.Text = "";
            TBCel.Text = "";
            TBEtiquetas.Text = "";
            TBUsuario.Text = "";
            TBNotas.Text = "";
            TBImagen.Text = "";
            TBPerro.Text = "";
            TBPadre.Text = "";
        }

        public void GuardarDatosComoJson(string filePath)
        {

            var entradas = new List<Dictionary<string, object>>();

            foreach(KeyValuePair<int, SitioInfo> contraseñaReg in GlobalData.SitiosData)
            {
                Dictionary<string, object> datosJson = new Dictionary<string, object>
                {
                    {"id", contraseñaReg.Key},
                    {"site_name", contraseñaReg.Value.NombreSitio},
                    {"username", contraseñaReg.Value.Usuario},
                    {"password", contraseñaReg.Value.Contrasena},
                    {"url", contraseñaReg.Value.URL},
                    {"notes", contraseñaReg.Value.Notas},
                    {"extra_fields",  new Dictionary<string, string>
                        {
                            {"extra1", $"Respuesta: {contraseñaReg.Value.Extra1}"},
                            {"extra2", $"Respuesta: {contraseñaReg.Value.Extra2}"},
                            {"extra3", $"Respuesta: {contraseñaReg.Value.Extra3}"},
                            {"extra4", $"Respuesta: {contraseñaReg.Value.Extra4}"},
                            {"extra5", $"Respuesta: {contraseñaReg.Value.Extra5}"}

                        }
                    },
                    {"tags", new List<string> {contraseñaReg.Value.Etiquetas}},
                    {"creation_date", contraseñaReg.Value.FechaGuardado},
                    {"update_date", contraseñaReg.Value.FechaActualizacion},
                    {"expiration_date", contraseñaReg.Value.FechaVencimiento},
                    {"icon", contraseñaReg.Value.Imagen}

                };

                entradas.Add(datosJson);
 
            }

            var data = new Dictionary<string, object>
            {
                {"entries", entradas}
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }
        

        private void BTExportar_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);
            // Verificar si el campo de la contraseña igual está vacío o no coincide

            // Ruta temporal para guardar el archivo JSON
            string jsonFilePath = Path.GetTempFileName();
            GuardarDatosComoJson(jsonFilePath); // Generar el archivo JSON temporal

            // Leer el contenido del archivo JSON
            byte[] plainTextBytes = File.ReadAllBytes(jsonFilePath);

            // Convertir la contraseña maestra a una clave DES de 8 bytes
            byte[] desKey = Encoding.UTF8.GetBytes(MasterPassword.PadRight(8).Substring(0, 8)); // DES requiere una clave de 8 bytes

            // Encriptar el contenido del archivo JSON
            byte[] encryptedBytes = DES.Encrypt(plainTextBytes, desKey);

            // Ruta de destino para el archivo encriptado, esto creo que se puede eliminar 
            string documentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string rutaEncriptado = Path.Combine(documentos, "encriptado.enc");
            File.WriteAllBytes(rutaEncriptado, encryptedBytes);

            MessageBox.Show("Datos exportados exitosamente en formato JSON encriptado.");

            // Desencriptar los datos encriptados
            byte[] decryptedBytes = DES.Decrypt(encryptedBytes, desKey);

            // Ruta de destino para el archivo desencriptado
            string decryptedFilePath = Path.Combine(documentos, "desencriptado.txt");
            File.WriteAllBytes(decryptedFilePath, decryptedBytes);

            MessageBox.Show("Datos desencriptados y guardados en formato JSON.");

            // Limpiar el campo de texto de la contraseña
        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void TBContraIgual_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBUsuario_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBImagen_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBTipoCuenta_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBContradatos_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBPerro_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBCorreo_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBURL_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBPadre_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBNombreSitio_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBCel_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBEtiquetas_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBNotas_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }

    public class SitioInfo
    {
        public int Id { get; set; } // 0
        public string NombreSitio { get; set; } // 1 
        public string Extra1 { get; set; }
        public string Contrasena { get; set; } // 3
        public string URL { get; set; } // 4
        public string Extra2 { get; set; }
        public string Extra3 { get; set; }
        public string Etiquetas { get; set; } // 10
        public string Usuario { get; set; } // 2
        public string Notas { get; set; } // 5
        public string Imagen { get; set; } // 6
        public string Extra4 { get; set; } 
        public string Extra5 { get; set; } 
        public DateTime FechaGuardado { get; set; } // 7
        public DateTime FechaActualizacion { get; set; } // 8
        public DateTime FechaVencimiento { get; set; } // 9
    }
}





