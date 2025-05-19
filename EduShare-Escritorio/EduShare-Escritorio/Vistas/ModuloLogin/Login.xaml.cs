using EduShare_Escritorio.Logica;
using EduShare_Escritorio.Vistas.Menus;
using EduShare_Escritorio.Vistas.ModuloUsuario;
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
    public partial class Login : Page
    {
        public Login()
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

        private void IrARegistrarse(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new RegistrarUsuario();
            this.NavigationService.Navigate(registrarUsuario);
        }

        private void IrARecuperarContraseña(object sender, RoutedEventArgs e)
        {
            RecuperarContraseña recuperarContraseña = new RecuperarContraseña();
            this.NavigationService.Navigate(recuperarContraseña);
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
            txtb_Contraseña.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(pwb_PasswordBox.Password))
            {
                txtb_Contraseña.Visibility = Visibility.Visible;
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txtb_Contraseña.Visibility = string.IsNullOrEmpty(pwb_PasswordBox.Password) ? Visibility.Visible : Visibility.Collapsed;
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

        private void CrearPerfilSingleton()
        {
            var perfil = PerfilSingleton.Instance;

            perfil.IdAcceso = 1;
            perfil.Correo = "cumplidonegrete@gmail.com";
            perfil.NombreUsuario = "Juancho1";
            perfil.IdUsuarioRegistrado = 1;
            perfil.Nombre = "Juan Eduardo";
            perfil.PrimerApellido = "Cumplido";
            perfil.SegundoApellido = "Negrete";
        }


        private void BtnLoginClick(object sender, RoutedEventArgs e)
        {
            RegresarBordeNormal();

            if (VerificarCampos())
            {
                CrearPerfilSingleton();
                NavigationService.Navigate(new MenuPrincipal("Login"));
            }
            else
            {
                MostrarMensajePersonalizado("Por favor, asegúrate de ingresar su correo o nombre de usuario y una contraseña.", DialogType.Warning);
            }

        }




        private bool VerificarCampos()
        {
            bool usuario = !string.IsNullOrWhiteSpace(txtb_Usuario.Text) && txtb_Usuario.Text != "Ingrese su correo o usuario";

            string contraseña = isPasswordVisible ? txt_ContraseñaVisible.Text : pwb_PasswordBox.Password;
            bool contrasenaValida = !string.IsNullOrWhiteSpace(contraseña) && txtb_Contraseña.Text == "Ingrese su contraseña";

            if (!usuario) brd_Usuario.BorderBrush = Brushes.Red;
            if (!contrasenaValida) brd_Contraseña.BorderBrush = Brushes.Red;

            return usuario && contrasenaValida;
        }

        private void RegresarBordeNormal()
        {
            SolidColorBrush verde = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#16b555"));
            brd_Usuario.BorderBrush = verde;
            brd_Contraseña.BorderBrush= verde;
        }
            
    }
}
