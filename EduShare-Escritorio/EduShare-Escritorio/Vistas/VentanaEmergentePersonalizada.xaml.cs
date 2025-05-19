using System;
using System.Collections.Generic;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EduShare_Escritorio.Vistas
{
    public partial class VentanaEmergentePersonalizada : Window
    {
        public bool? ConfirmacionUsuario { get; private set; }

        public enum DialogType
        {
            Success,
            Error,
            Warning,
            Confirmation
        }

        public VentanaEmergentePersonalizada(string mensaje, DialogType tipo)
        {
            InitializeComponent();
            txtb_Mensaje.Text = mensaje;
            EstablecerEstilo(tipo);
        }

        private void EstablecerEstilo(DialogType tipo)
        {
            switch (tipo)
            {
                case DialogType.Success:
                   
                    img_Icono.Source = new BitmapImage(new Uri("/Imagenes/Iconos/Exitoso.png", UriKind.Relative));
                    break;
                case DialogType.Warning:
                 
                    img_Icono.Source = new BitmapImage(new Uri("/Imagenes/Iconos/Alerta.png", UriKind.Relative));
                    break;

                case DialogType.Error:
                    
                    img_Icono.Source = new BitmapImage(new Uri("/Imagenes/Iconos/Error.png", UriKind.Relative));
                    break;
                case DialogType.Confirmation:
                   
                    img_Icono.Source = new BitmapImage(new Uri("/Imagenes/Iconos/Pregunta.png", UriKind.Relative));
                    brd_BotonSi.Visibility = Visibility.Visible;
                    brd_BotonNo.Visibility = Visibility.Visible;
                    brd_BotonAceptar.Visibility = Visibility.Collapsed;
                    break;
            }
        }



        private void Cerrar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Aceptar(object sender, RoutedEventArgs e)
        {
            ConfirmacionUsuario = true;
            this.DialogResult = true;
            this.Close();
        }

        private void Cancelar(object sender, RoutedEventArgs e)
        {
            ConfirmacionUsuario = false;
            this.DialogResult = false;
            this.Close();
        }

    }
}
