using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_Estructuras.AgregarContrasena;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto_Estructuras
{
    public partial class TbValorNuevo : UserControl
    {
        FormMenu formMenu;



        public CripRSA rsa = new CripRSA();
        private int selectedId = -1; // Variable para almacenar el ID seleccionado
        public TbValorNuevo(FormMenu formMenu)
        {
            InitializeComponent();
            this.formMenu = formMenu;

            foreach (Control control in this.Controls)
            {
                // Especificar el namespace completo para Button
                if (control is System.Windows.Forms.Button)
                {
                    control.Click += new EventHandler(formMenu.ReiniciarContadorInactividad);
                }
            }

            LlenarListView();

            lvBuscarId.SelectedIndexChanged += lvBuscarId_SelectedIndexChanged;
        }



        private void button3_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);
            formMenu.Show();
            this.ParentForm.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

            // Validación de la nueva contraseña maestra
            string nueva = TBNuevaContraMaestra.Text;

            // Verificar si el campo está vacío o si la nueva contraseña no cumple con los requisitos
            

            // Si la validación pasa, actualizar la contraseña maestra en el FormMenu
            formMenu.MasterPassword = nueva; // Actualizar la contraseña maestra en FormMenu
            formMenu.AgregarContrasenaForm.MasterPassword = nueva; // Asegurarse de que esta propiedad también se actualice

            // Mostrar mensaje de éxito
            MessageBox.Show("La contraseña maestra se actualizó correctamente.");

            // Limpiar el campo de texto de la nueva contraseña maestra
            TBNuevaContraMaestra.Text = string.Empty; // Limpiar el campo

        }

        private void button2_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

            if (string.IsNullOrWhiteSpace(TBValorViejo.Text))
            {
                MessageBox.Show("El campo 'Valor Viejo' es obligatorio.");
                return;
            }
            if (string.IsNullOrWhiteSpace(TBNuevoValor.Text))
            {
                MessageBox.Show("El campo 'Nuevo Valor' es obligatorio.");
                return;
            }
            if (TBNuevoValor.Text.Length < 8 && TBValorViejo.Text.ToLower() == "contrasena")
            {
                MessageBox.Show("La nueva contraseña debe tener al menos 8 caracteres.");
                return;
            }

            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(TBBuscarId.Text) ||
                string.IsNullOrWhiteSpace(TBValorViejo.Text) ||
                string.IsNullOrWhiteSpace(TBNuevoValor.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return; // Salir del método si hay campos vacíos
            }

            // Obtener el ID a buscar
            if (!int.TryParse(TBBuscarId.Text, out int buscarId))
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
                return; // Salir si el ID no es válido
            }

            // Buscar el sitio en el diccionario usando el ID
            if (GlobalData.SitiosData.TryGetValue(buscarId, out var sitio))
            {
                // Definir el nombre del campo que se desea actualizar
                string campoAActualizar = TBValorViejo.Text.ToLower();
                string viejoValor = "";

                // Obtener la propiedad a modificar usando reflexión
                var propertyInfo = typeof(SitioInfo).GetProperty(campoAActualizar,
                                      System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                // Verificar si la propiedad existe
                if (propertyInfo != null && propertyInfo.CanWrite)
                {
                    // Obtener el valor antiguo del campo
                    viejoValor = propertyInfo.GetValue(sitio)?.ToString() ?? string.Empty;

                    // Verificar si el campo es "contraseña" y, si es así, encriptar el nuevo valor
                    string nuevoValor = TBNuevoValor.Text;
                    if (campoAActualizar.ToLower() == "contrasena")
                    {
                        nuevoValor = rsa.Encriptar(TBNuevoValor.Text); // Encriptar el nuevo valor
                    }

                    // Actualizar el valor del campo
                    propertyInfo.SetValue(sitio, nuevoValor);

                    // Actualizar la fecha de actualización
                    sitio.FechaActualizacion = DateTime.UtcNow;

                    // Mostrar mensaje de éxito con los valores antiguos y nuevos
                    MessageBox.Show($"El campo '{campoAActualizar}' se modificó de '{viejoValor}' a '{propertyInfo.GetValue(sitio)}'.");
                }
                else
                {
                    MessageBox.Show("Campo no válido para actualizar.");
                    return; // Salir si el campo no es válido
                }

                // Limpiar los campos después de la actualización
                TBBuscarId.Text = string.Empty;
                TBNuevoValor.Text = string.Empty;
                TBValorViejo.Text = string.Empty;
                return;
            }

            // Si no se encuentra el ID
            MessageBox.Show($"No se encontró ningún sitio con ID: {buscarId}");
        }




        private void TBNuevaContraMaestra_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void BTBuscarArchivo_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);
            // Obtener el ID ingresado por el usuario
            if (!int.TryParse(TBBuscarId.Text, out int buscarId))
            {
                MessageBox.Show("Por favor, ingresa un ID válido.");
                return;
            }

            // Obtener el nombre del campo que se desea buscar y pasarlo a minúsculas
            string campoBuscar = TBBuscarArchivo.Text.ToLower();

            // Buscar el sitio en el diccionario usando el ID
            if (GlobalData.SitiosData.TryGetValue(buscarId, out var sitio))
            {
                // Usar reflexión para obtener la propiedad a buscar
                var propertyInfo = typeof(SitioInfo).GetProperty(campoBuscar,
                                         System.Reflection.BindingFlags.IgnoreCase | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

                // Verificar si la propiedad existe y puede leerse
                if (propertyInfo != null && propertyInfo.CanRead)
                {
                    // Obtener el valor del campo especificado
                    string valorCampo = propertyInfo.GetValue(sitio)?.ToString() ?? "No encontrado";

                    if (campoBuscar.ToLower() == "contrasena")
                    {
                        //Desencriptar contraseña
                        string contraDesencriptada = rsa.Desencriptar(valorCampo);
                        MessageBox.Show($"Valor de '{campoBuscar}' para el ID {buscarId}: {contraDesencriptada}");
                    }
                    else
                    {
                        // Mostrar el resultado al usuario
                        MessageBox.Show($"Valor de '{campoBuscar}' para el ID {buscarId}: {valorCampo}");
                    }
                }
                else
                {
                    MessageBox.Show("Campo no válido. Asegúrate de que el nombre del campo es correcto.");
                }
            }
            else
            {
                MessageBox.Show("ID no encontrado en los datos.");
            }
        }

        private void TBBuscarId_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBValorViejo_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBNuevoValor_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBEscribirIdBuscar_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBBuscarArchivo_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void LlenarListView()
        {
            
        }

        private void lvBuscarId_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            formMenu.ReiniciarContadorInactividad(sender, e);

            if (lvBuscarId.SelectedItems.Count > 0)
            {
                string selectedText = lvBuscarId.SelectedItems[0].Text;
                string[] parts = selectedText.Split('|');

                if (int.TryParse(parts[0].Trim(), out int selectedId))
                {
                    // Asignar el ID seleccionado al TextBox de ID
                    TBBuscarId.Text = selectedId.ToString();
                    
                    // Mostrar la información del sitio una sola vez
                    MostrarInformacionSitio(selectedId);
                }
            }

        }

        private void MostrarInformacionSitio(int id)
        {
            if (GlobalData.SitiosData.TryGetValue(id, out var sitio))
            {
                StringBuilder informacion = new StringBuilder();
                informacion.AppendLine($"ID: {sitio.Id}");
                informacion.AppendLine($"Nombre Sitio: {sitio.NombreSitio}");
                informacion.AppendLine($"Usuario: {sitio.Usuario}");
                informacion.AppendLine($"Contraseña: {rsa.Desencriptar(sitio.Contrasena)}"); // Desencriptar la contraseña
                informacion.AppendLine($"URL: {sitio.URL}");
                informacion.AppendLine($"Notas: {sitio.Notas}");
                informacion.AppendLine($"Etiquetas: {sitio.Etiquetas}");
                informacion.AppendLine($"Fecha Guardado: {sitio.FechaGuardado}");
                informacion.AppendLine($"Fecha Actualización: {sitio.FechaActualizacion}");
                informacion.AppendLine($"Fecha Vencimiento: {sitio.FechaVencimiento}");

                MessageBox.Show(informacion.ToString(), "Información del Sitio");
            }
            else
            {
                MessageBox.Show("No se encontró información para el sitio seleccionado.");
            }
        }

        private void btnCargarContras_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

            lvBuscarId.Items.Clear();

            // Verifica si el ListView ya tiene columnas definidas
            if (lvBuscarId.Columns.Count == 0)
            {
                // Configura el ListView para mostrar encabezados y columnas en modo Details.
                lvBuscarId.View = View.Details;
                lvBuscarId.Columns.Add("ID", 100, HorizontalAlignment.Left);
                lvBuscarId.Columns.Add("Nombre del Sitio", 200, HorizontalAlignment.Left);
            }

            // Agrega los elementos como filas con subelementos
            foreach (var sitioInfo in GlobalData.SitiosData)
            {
                ListViewItem item = new ListViewItem(sitioInfo.Key.ToString());  // ID
                item.SubItems.Add(sitioInfo.Value.NombreSitio);  // Nombre del Sitio
                lvBuscarId.Items.Add(item);
            }



        }



        private void TBEscribirIdBuscar_TextChanged_1(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        public void GuardarDatosComoJson(List<int> idsSeleccionados, string filePath)
        {
            var entradas = new List<Dictionary<string, object>>();

            foreach (KeyValuePair<int, SitioInfo> contraseñaReg in GlobalData.SitiosData)
            {
                if (idsSeleccionados.Contains(contraseñaReg.Key)) // Verificar si el ID está en la lista seleccionada
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
                {"expiration_date", contraseñaReg.Value.FechaVencimiento}
            };

                    entradas.Add(datosJson);
                }
            }

            // Verificar si se encontraron registros para exportar
            if (entradas.Count == 0)
            {
                MessageBox.Show("No se encontraron registros para los IDs seleccionados.");
                return;
            }

            // Guardar el listado de entradas en formato JSON
            File.WriteAllText(filePath, JsonSerializer.Serialize(entradas, new JsonSerializerOptions { WriteIndented = true }));
        }

        private void BTExportar_Click(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

            if (string.IsNullOrWhiteSpace(TBcualesIDS.Text))
            {
                MessageBox.Show("Por favor, ingresa los IDs en el campo antes de exportar.");
                return; // Salir del método si el campo está vacío
            }

            // Verificar si el campo de la contraseña igual está vacío o no coincide
            if (string.IsNullOrWhiteSpace(TBContraIgual.Text) || TBContraIgual.Text != formMenu.MasterPassword)
            {
                MessageBox.Show("La contraseña maestra no coincide. Asegúrese de que las contraseñas sean iguales.");
                return; // Salir del método si la contraseña no es válida
            }

            // Obtener los IDs de TBcualesIDS, separados por comas
            string[] idsString = TBcualesIDS.Text.Split(',');
            List<int> idsSeleccionados = new List<int>();

            foreach (var id in idsString)
            {
                if (int.TryParse(id.Trim(), out int idVal))
                {
                    idsSeleccionados.Add(idVal); // Agregar ID a la lista de IDs seleccionados
                }
            }

            // Si no se ha ingresado ningún ID válido
            if (idsSeleccionados.Count == 0)
            {
                MessageBox.Show("No se ha ingresado ningún ID válido.");
                return;
            }

            // Ruta temporal para guardar el archivo JSON
            string jsonFilePath = Path.GetTempFileName();
            GuardarDatosComoJson(idsSeleccionados, jsonFilePath); // Generar el archivo JSON temporal solo con los IDs seleccionados

            // Leer el contenido del archivo JSON
            byte[] plainTextBytes = File.ReadAllBytes(jsonFilePath);

            // Convertir la contraseña maestra a una clave DES de 8 bytes
            byte[] desKey = Encoding.UTF8.GetBytes(formMenu.MasterPassword.PadRight(8).Substring(0, 8)); // DES requiere una clave de 8 bytes

            // Encriptar el contenido del archivo JSON
            byte[] encryptedBytes = DES.Encrypt(plainTextBytes, desKey);

            // Ruta de destino para el archivo encriptado
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
            TBContraIgual.Text = string.Empty;
        }

        private void TBcualesIDS_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }

        private void TBContraIgual_TextChanged(object sender, EventArgs e)
        {
            formMenu.ReiniciarContadorInactividad(sender, e);

        }
    }
}