using EduShare_Escritorio.Logica;
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
    public partial class RestablecerContraseña : Page
    {
        private bool _isPasswordVisible1 = false;
        private bool _isPasswordVisible2 = false;

        public RestablecerContraseña()
        {
            InitializeComponent();
        }

        private void MostrarMensajePersonalizado(string message, DialogType type)
        {
            var dialog = new VentanaEmergentePersonalizada(message, type);
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private bool ValidarEntrada()
        {
            string contraseña = pwb_Contraseña.Password;
            string confirmarContraseña = pwb_ConfirmarContraseña.Password;
            bool esValido = true;

            if (string.IsNullOrWhiteSpace(contraseña) || string.IsNullOrWhiteSpace(confirmarContraseña))
            {
                MostrarMensajePersonalizado("¡Campos vacíos!\r\nPor favor, complete ambos campos de contraseña.", DialogType.Warning);
                esValido = false;
            }
            else if (contraseña != confirmarContraseña)
            {
                MostrarMensajePersonalizado("Las contraseñas no coinciden. Por favor, verifíquelas.", DialogType.Warning);
                esValido = false;
            }
            else if (!Validador.ValidarContraseña(contraseña))
            {
                MostrarMensajePersonalizado("La contraseña no cumple con los requisitos especificados arriba", DialogType.Warning);

                esValido = false;
            }
            return esValido;
        }


        private void CambiarContraseña(object sender, RoutedEventArgs e)
        {
            if (ValidarEntrada())
            {
                MostrarMensajePersonalizado("¡Éxito!\r\nContraseña restablecida correctamente, ya podrá iniciar sesión", DialogType.Warning);
                Login login = new Login();
                this.NavigationService.Navigate(login);
            }

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

        
        private void PasswordBoxGotFocus1(object sender, RoutedEventArgs e)
        {
            txtb_Contraseña.Visibility = Visibility.Collapsed;
        }

        private void PasswordBoxLostFocus1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwb_Contraseña.Password))
            {
                txtb_Contraseña.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBoxGotFocus2(object sender, RoutedEventArgs e)
        {
            txtb_ConfirmarContraseña.Visibility = Visibility.Collapsed;
        }

        private void PasswordBoxLostFocus2(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwb_ConfirmarContraseña.Password))
            {
                txtb_ConfirmarContraseña.Visibility = Visibility.Visible;
            }
        }

        private void ContraseñaCambiada1(object sender, RoutedEventArgs e)
        {
            txtb_Contraseña.Visibility = string.IsNullOrEmpty(pwb_Contraseña.Password) ? Visibility.Visible : Visibility.Collapsed;
        }


        private void ContraseñaCambiada2(object sender, RoutedEventArgs e)
        {
            txtb_ConfirmarContraseña.Visibility = string.IsNullOrEmpty(pwb_ConfirmarContraseña.Password) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void ActivarDesactivarVisibilidad1(object sender, MouseButtonEventArgs e)
        {
            _isPasswordVisible1 = !_isPasswordVisible1;

            if (_isPasswordVisible1)
            {
                txt_ContraseñaVisible.Text = pwb_Contraseña.Password;
                txt_ContraseñaVisible.Visibility = Visibility.Visible;
                pwb_Contraseña.Visibility = Visibility.Collapsed;
            }
            else
            {
                pwb_Contraseña.Password = txt_ContraseñaVisible.Text;
                pwb_Contraseña.Visibility = Visibility.Visible;
                txt_ContraseñaVisible.Visibility = Visibility.Collapsed;
            }
        }

        private void ActivarDesactivarVisibilidad2(object sender, MouseButtonEventArgs e)
        {
            _isPasswordVisible2 = !_isPasswordVisible2;

            if (_isPasswordVisible2)
            {
                txt_ConfirmarContraseñaVisible.Text = pwb_ConfirmarContraseña.Password;
                txt_ConfirmarContraseñaVisible.Visibility = Visibility.Visible;
                pwb_ConfirmarContraseña.Visibility = Visibility.Collapsed;
            }
            else
            {
                pwb_ConfirmarContraseña.Password = txt_ConfirmarContraseñaVisible.Text;
                pwb_ConfirmarContraseña.Visibility = Visibility.Visible;
                txt_ConfirmarContraseñaVisible.Visibility = Visibility.Collapsed;
            }
        }

        private void VisiblePasswordTextChanged1(object sender, TextChangedEventArgs e)
        {
            if (_isPasswordVisible1)
            {
                pwb_Contraseña.Password = txt_ContraseñaVisible.Text;
            }
        }

        private void VisiblePasswordTextChanged2(object sender, TextChangedEventArgs e)
        {
            if (_isPasswordVisible2)
            {
                pwb_ConfirmarContraseña.Password = txt_ConfirmarContraseñaVisible.Text;
            }
        }

    }
}
