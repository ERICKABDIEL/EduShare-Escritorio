using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EduShare_Escritorio.Logica;
using log4net.Repository.Hierarchy;
using Microsoft.Win32;
using static EduShare_Escritorio.Vistas.VentanaEmergentePersonalizada;


namespace EduShare_Escritorio.Vistas.ModuloUsuario
{
    public partial class Perfil : Page
    {
        private Frame _frame;
        public Perfil(Frame frame)
        {
            InitializeComponent();
            _frame = frame;
        }

        private void MostrarMensajePersonalizado(string message, DialogType type)
        {
            var dialog = new VentanaEmergentePersonalizada(message, type);
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void CambiarImagen(object sender, MouseButtonEventArgs e)
        {
            LoggerManager logger = new LoggerManager(this.GetType());
            OpenFileDialog dialogo = new OpenFileDialog
            {
                Title = "Selecciona una imagen de perfil",
                Filter = "Imágenes (*.png;*.jpg)|*.png;*.jpg",
                Multiselect = false
            };

            bool? resultado = dialogo.ShowDialog();

            if (resultado == true)
            {
                FileInfo archivo = new FileInfo(dialogo.FileName);
                if (archivo.Length > 5 * 1024 * 1024)
                {
                    MostrarMensajePersonalizado("¡Tamaño excedido!\r\nLa imagen debe ser menor a 5 MB.", DialogType.Warning);
                    return;
                }

                try
                {
                    BitmapImage nuevaImagen = new BitmapImage();
                    nuevaImagen.BeginInit();
                    nuevaImagen.UriSource = new Uri(archivo.FullName);
                    nuevaImagen.CacheOption = BitmapCacheOption.OnLoad;
                    nuevaImagen.EndInit();

                    img_FotoPerfil.ImageSource = nuevaImagen;
                }
                catch (Exception ex)
                {
                    MostrarMensajePersonalizado("Error al cargar imagen", DialogType.Warning);
                    logger.LogFatal(ex);
                }
            }
        }

        private void Editar(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new EditarPerfil(_frame));
        }
    }
}
