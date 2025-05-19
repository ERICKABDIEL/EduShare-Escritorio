using EduShare_Escritorio.Vistas.Menus;
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
using static EduShare_Escritorio.Vistas.VentanaEmergentePersonalizada;

namespace EduShare_Escritorio.Vistas.ModuloLogin
{
    public partial class VerificarCodigo : Page
    {
        public VerificarCodigo()
        {
            InitializeComponent();
        }

        private void MostrarMensajePersonalizado(string message, DialogType type)
        {
            var dialog = new VentanaEmergentePersonalizada(message, type);
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void RegresarAlMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.NavigationService.Navigate(menuPrincipal);
        }

        private void RegresarLogin(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.NavigationService.Navigate(login);
        }

        private void UserIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtb_Codigo.Text == "Código de Verificación")
            {
                txtb_Codigo.Text = "";
                txtb_Codigo.Foreground = Brushes.Black;
            }
        }

        private void UserIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtb_Codigo.Text))
            {
                txtb_Codigo.Text = "Código de Verificación";
                txtb_Codigo.Foreground = Brushes.Gray;
            }
        }

        private void VerificarCodigoEntrante(object sender, RoutedEventArgs e)
        {
            string codigo = txtb_Codigo.Text.Trim();

            if (string.IsNullOrEmpty(codigo) || codigo == "Código de Verificación")
            {
                MostrarMensajePersonalizado("¡Campos vacíos!\r\nPor favor, ingrese el código de verificación que se le envio", DialogType.Warning);
            }
            else
            {
                RestablecerContraseña restablecerContraseña = new RestablecerContraseña();
                this.NavigationService.Navigate(restablecerContraseña);
            }
        }
    }
}
