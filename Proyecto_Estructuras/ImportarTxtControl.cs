using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_Estructuras.AgregarContrasena;

namespace Proyecto_Estructuras
{
    public partial class ImportarTxtControl : UserControl
    {

        FormMenu formMenu;
        public ImportarTxtControl(FormMenu formMenu)
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



        private void BTJSON_Click(object sender, EventArgs e)
        {

            formMenu.ReiniciarContadorInactividad(sender, e);
            // Verificar que el TextBox no esté vacío
            if (string.IsNullOrWhiteSpace(TBRutaArchivos.Text))
            {
                MessageBox.Show("Por favor, ingresa la ruta del archivo encriptado (.enc).");
                return;
            }

            string rutaArchivoEncriptado = TBRutaArchivos.Text;

            try
            {
                // Verificar si el archivo encriptado existe
                if (!System.IO.File.Exists(rutaArchivoEncriptado))
                {
                    MessageBox.Show($"El archivo especificado no existe en la ruta: {rutaArchivoEncriptado}");
                    return;
                }

                // Leer el contenido del archivo encriptado
                byte[] encryptedBytes = System.IO.File.ReadAllBytes(rutaArchivoEncriptado);

                // Obtener la contraseña maestra
                string masterPassword = formMenu.MasterPassword;

                // Convertir la contraseña maestra a una clave DES de 8 bytes
                byte[] desKey = Encoding.UTF8.GetBytes(masterPassword.PadRight(8).Substring(0, 8)); // DES requiere una clave de 8 bytes

                // Llamada al método de desencriptación
                byte[] decryptedBytes = DES.Decrypt(encryptedBytes, desKey);

                // Guardar el archivo desencriptado como .txt
                string rutaArchivoDesencriptado = System.IO.Path.ChangeExtension(rutaArchivoEncriptado, ".txt");
                System.IO.File.WriteAllBytes(rutaArchivoDesencriptado, decryptedBytes);

                // Leer el contenido del archivo desencriptado como texto
                string jsonContent = System.IO.File.ReadAllText(rutaArchivoDesencriptado);

                if (jsonContent != null)
                {
                    // Actualizar el diccionario global con los datos deserializados
                    JObject jsonObject = JObject.Parse(jsonContent);

                    //Extraer solo las entradas (entries)
                    JArray contraseñasReg = (JArray)jsonObject["entries"];

                    //Generar objeto tipo 
                    foreach (var contraseña in contraseñasReg)
                    {
                        SitioInfo contraNueva = new SitioInfo();

                        contraNueva.Id = int.Parse(contraseña["id"].ToString());
                        contraNueva.NombreSitio = contraseña["site_name"].ToString();
                        contraNueva.Usuario = contraseña["username"].ToString();
                        contraNueva.Contrasena = contraseña["password"].ToString();
                        contraNueva.URL = contraseña["url"].ToString();
                        contraNueva.Notas = contraseña["notes"].ToString();
                        contraNueva.Imagen = contraseña["icon"].ToString();
                        contraNueva.FechaGuardado = (DateTime)contraseña["creation_date"];
                        contraNueva.FechaVencimiento = (DateTime)contraseña["expiration_date"];
                        contraNueva.FechaActualizacion = (DateTime)contraseña["update_date"];

                        JObject extras = (JObject)contraseña["extra_fields"];

                        contraNueva.Extra1 = extras["extra1"].ToString();
                        contraNueva.Extra2 = extras["extra2"].ToString();
                        contraNueva.Extra3 = extras["extra3"].ToString();
                        contraNueva.Extra4 = extras["extra4"].ToString();
                        contraNueva.Extra5 = extras["extra5"].ToString();

                        JArray etiquetas = (JArray)contraseña["tags"];
                        contraNueva.Etiquetas = etiquetas.First().ToString();

                        if (!GlobalData.SitiosData.ContainsKey(contraNueva.Id))
                        {
                            GlobalData.SitiosData.Add(contraNueva.Id, contraNueva);
                        }
                        else
                        {
                            int indexMax = GlobalData.SitiosData.Keys.Max();
                            contraNueva.Id = indexMax + 1;
                            GlobalData.SitiosData.Add(contraNueva.Id, contraNueva);
                            MessageBox.Show($"Puesto que el ID de la contraseña ingresada ya existe se ha generado un nuevo ID para la nueva contraseña: {contraNueva.Id}");
                        }

                    }

                    // Mensaje de éxito
                    MessageBox.Show($"Archivo desencriptado y datos actualizados exitosamente. Guardado en: {rutaArchivoDesencriptado}");
                }
            }

            catch (System.IO.IOException ioEx)
            {
                // Manejo de excepciones de entrada/salida
                MessageBox.Show($"Error de entrada/salida: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException authEx)
            {
                // Manejo de excepciones de permisos
                MessageBox.Show($"Permiso denegado: {authEx.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void BTImportarContra_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);
            // Verificar que el TextBox no esté vacío
            if (string.IsNullOrWhiteSpace(TBRutaArchivos.Text))
            {
                MessageBox.Show("Por favor, ingresa la ruta del archivo de texto (.txt).");
                return;
            }

            string rutaArchivoTexto = TBRutaArchivos.Text;

            try
            {
                // Verificar si el archivo de texto existe
                if (!System.IO.File.Exists(rutaArchivoTexto))
                {
                    MessageBox.Show($"El archivo especificado no existe en la ruta: {rutaArchivoTexto}");
                    return;
                }

                // Leer el contenido del archivo de texto
                string textContent = System.IO.File.ReadAllText(rutaArchivoTexto);

                
                if (textContent != null)
                {
                    // Actualizar el diccionario global con los datos deserializados
                    JObject jsonObject = JObject.Parse(textContent);

                    //Extraer solo las entradas (entries)
                    JArray contraseñasReg = (JArray)jsonObject["entries"];

                    //Generar objeto tipo 
                    foreach(var contraseña in contraseñasReg)
                    {
                        SitioInfo contraNueva = new SitioInfo();

                        contraNueva.Id = int.Parse(contraseña["id"].ToString());
                        contraNueva.NombreSitio = contraseña["site_name"].ToString();
                        contraNueva.Usuario = contraseña["username"].ToString();
                        contraNueva.Contrasena = contraseña["password"].ToString(); 
                        contraNueva.URL = contraseña["url"].ToString();
                        contraNueva.Notas = contraseña["notes"].ToString();
                        contraNueva.Imagen = contraseña["icon"].ToString();
                        contraNueva.FechaGuardado = (DateTime)contraseña["creation_date"];
                        contraNueva.FechaVencimiento = (DateTime)contraseña["expiration_date"];
                        contraNueva.FechaActualizacion = (DateTime)contraseña["update_date"];

                        JObject extras = (JObject)contraseña["extra_fields"];

                        contraNueva.Extra1 = extras["extra1"].ToString();
                        contraNueva.Extra2 = extras["extra2"].ToString();
                        contraNueva.Extra3 = extras["extra3"].ToString();
                        contraNueva.Extra4 = extras["extra4"].ToString();
                        contraNueva.Extra5 = extras["extra5"].ToString();

                        JArray etiquetas = (JArray)contraseña["tags"];
                        contraNueva.Etiquetas = etiquetas.First().ToString();


                        if (!GlobalData.SitiosData.ContainsKey(contraNueva.Id))
                        {
                            GlobalData.SitiosData.Add(contraNueva.Id, contraNueva);
                        }
                        else
                        {
                            int indexMax = GlobalData.SitiosData.Keys.Max();
                            contraNueva.Id = indexMax + 1;
                            GlobalData.SitiosData.Add(contraNueva.Id, contraNueva);
                            MessageBox.Show($"Puesto que el ID de la contraseña ingresada ya existe se ha generado un nuevo ID para la nueva contraseña: {contraNueva.Id}");
                        }
                    }

                    MessageBox.Show($"Las contraseñas encontradas en el archivo txt {rutaArchivoTexto} han sido almacenadas con éxito");
                    MessageBox.Show($"Contraseñas registradas: {GlobalData.SitiosData.Count}");
                }
                else
                {
                    MessageBox.Show("El archivo de texto no contiene datos válidos en formato JSON.");
                    return;
                }

                // Obtener la contraseña maestra
                string masterPassword = formMenu.MasterPassword;

                // Convertir la contraseña maestra a una clave DES de 8 bytes
                byte[] desKey = Encoding.UTF8.GetBytes(masterPassword.PadRight(8).Substring(0, 8)); // DES requiere una clave de 8 bytes

                // Convertir el contenido de texto a bytes
                byte[] textBytes = Encoding.UTF8.GetBytes(textContent);

                // Llamada al método de encriptación
                byte[] encryptedBytes = DES.Encrypt(textBytes, desKey);

                // Guardar el archivo encriptado como .enc
                string rutaArchivoEncriptado = System.IO.Path.ChangeExtension(rutaArchivoTexto, ".enc");
                System.IO.File.WriteAllBytes(rutaArchivoEncriptado, encryptedBytes);

                // Mensaje de éxito
                MessageBox.Show($"Archivo encriptado exitosamente y datos cargados en el sistema. Guardado en: {rutaArchivoEncriptado}");
            }
            catch (System.IO.IOException ioEx)
            {
                // Manejo de excepciones de entrada/salida
                MessageBox.Show($"Error de entrada/salida: {ioEx.Message}");
            }
            catch (UnauthorizedAccessException authEx)
            {
                // Manejo de excepciones de permisos
                MessageBox.Show($"Permiso denegado: {authEx.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de excepciones generales
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }


        private void BTExportarContra_Click(object sender, EventArgs e)
        {

        }

        private void TBRutaArchivos_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void ImportarTxtControl_Load(object sender, EventArgs e)
        {

        }
    }
}
