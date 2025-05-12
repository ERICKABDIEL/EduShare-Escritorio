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

namespace EduShare_Escritorio.Vistas
{
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void RegresarAlMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.NavigationService.Navigate(menuPrincipal);
        }

        private void UserIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtb_Usuario.Text == "Ingrese su correo o usuario")
            {
                txtb_Usuario.Text = "";
                txtb_Usuario.Foreground = Brushes.Black;
            }
        }

        private void UserIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtb_Usuario.Text))
            {
                txtb_Usuario.Text = "Ingrese su correo o usuario";
                txtb_Usuario.Foreground = Brushes.Gray;
            }
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            psw_Contraseña.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwb_PasswordBox.Password))
            {
                psw_Contraseña.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            psw_Contraseña.Visibility = string.IsNullOrEmpty(pwb_PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
        }
        private bool isPasswordVisible = false;

        private void ActivarDesactivarVisibilidad(object sender, MouseButtonEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txt_ContraseñaVisible.Text = pwb_PasswordBox.Password;
                txt_ContraseñaVisible.Visibility = Visibility.Visible;
                pwb_PasswordBox.Visibility = Visibility.Collapsed;
            }
            else
            {
                pwb_PasswordBox.Password = txt_ContraseñaVisible.Text;
                pwb_PasswordBox.Visibility = Visibility.Visible;
                txt_ContraseñaVisible.Visibility = Visibility.Collapsed;
            }
        }

        private void VisiblePassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isPasswordVisible)
            {
                pwb_PasswordBox.Password = txt_ContraseñaVisible.Text;
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
