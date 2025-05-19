using EduShare_Escritorio.Logica;
using EduShare_Escritorio.Vistas.Menus;
using EduShare_Escritorio.Vistas.ModuloLogin;
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

namespace EduShare_Escritorio.Vistas.ModuloUsuario
{
    public partial class RegistrarUsuario : Page
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
        }
        private void MostrarMensajePersonalizado(string message, DialogType type)
        {
            var dialog = new VentanaEmergentePersonalizada(message, type);
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void BtnRegistrar(object sender, RoutedEventArgs e)
        {
            string hashedPassword = Hasher.hashToSHA2(txtb_Contraseña.Text);
            RegresarBordeOriginal();
            if (ValidarCamposVacios())
            {
                
                if (VerificarCampos())
                {
                    MostrarMensajePersonalizado("¡Registro exitoso!\r\nAhora puedes disfrutar de todo lo que EduShare tiene para ofrecer. ¡Bienvenido a la comunidad!", DialogType.Success);
                    Login login = new Login();
                    this.NavigationService.Navigate(login);
                }
                else
                {
                    MostrarMensajePersonalizado("La información de algunos campos es incorrecto, por favor verifique e intentelo de nuevo.", DialogType.Warning);
                }
            }
            else
            {
                MostrarMensajePersonalizado("Por favor, llena todos los campos que se solicitan", DialogType.Warning);
            }

          
        }

        public void RegresarBordeOriginal()
        {
            SolidColorBrush verde = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#16b555"));
            brd_Nombre.BorderBrush = verde;
            brd_PrimerApellido.BorderBrush = verde;
            brd_SegundoApellido.BorderBrush = verde;
            brd_Correo.BorderBrush = verde;
            brd_Usuario.BorderBrush = verde;
            brd_Contraseña.BorderBrush = verde;
            brd_NivelEducativo.BorderBrush = verde;
            brd_Institucion.BorderBrush = verde;
            brd_Carrera.BorderBrush = verde;

        }

        public bool VerificarCampos()
        {
            bool nombre = Validador.ValidarNombre(txtb_Nombre.Text);
            bool primerApellido = Validador.ValidarNombre(txtb_PrimerApellido.Text);
            bool segundoApellido = Validador.ValidarSegundoApellido(txtb_SegundoApellido.Text);
            bool correo = Validador.ValidarCorreo(txtb_Correo.Text);
            bool usuario = Validador.ValidarUsuario(txtb_Usuario.Text);
            string contraseña = isPasswordVisible ? txt_ContraseñaVisible.Text : pwb_PasswordBox.Password;
            bool contrasenaValida = Validador.ValidarContraseña(contraseña);

            if (!nombre) brd_Nombre.BorderBrush = Brushes.Red;
            if (!primerApellido) brd_PrimerApellido.BorderBrush = Brushes.Red;
            if (!segundoApellido) brd_SegundoApellido.BorderBrush = Brushes.Red;
            if (!correo) brd_Correo.BorderBrush = Brushes.Red;
            if (!usuario) brd_Usuario.BorderBrush = Brushes.Red;
            if (!contrasenaValida) brd_Contraseña.BorderBrush = Brushes.Red;

            return nombre && primerApellido && segundoApellido && correo && usuario && contrasenaValida;
        }

        public bool ValidarCamposVacios()
        {
            bool nombre = !string.IsNullOrWhiteSpace(txtb_Nombre.Text);
            bool primerApellido = !string.IsNullOrWhiteSpace(txtb_PrimerApellido.Text);
            bool usuario = !string.IsNullOrWhiteSpace(txtb_Usuario.Text);
            bool correo = !string.IsNullOrWhiteSpace(txtb_Correo.Text);

            string contraseña = isPasswordVisible ? txt_ContraseñaVisible.Text : pwb_PasswordBox.Password;
            bool contrasenaValida = !string.IsNullOrWhiteSpace(contraseña);

            bool cmbNivelEducativo = cmb_NivelEducativo.SelectedItem != null;
            bool cmbInstitucion = cmb_Institución.SelectedItem != null;
            bool cmbCarrera = cmb_Carrera.SelectedItem != null;



            if (!nombre) brd_Nombre.BorderBrush = Brushes.Red;
            if (!primerApellido) brd_PrimerApellido.BorderBrush = Brushes.Red;
            if (!correo) brd_Correo.BorderBrush = Brushes.Red;
            if (!usuario) brd_Usuario.BorderBrush = Brushes.Red;
            if (!contrasenaValida) brd_Contraseña.BorderBrush = Brushes.Red;

            if (!cmbNivelEducativo) brd_NivelEducativo.BorderBrush = Brushes.Red;
            if (!cmbInstitucion) brd_Institucion.BorderBrush = Brushes.Red;
            if (!cmbCarrera) brd_Carrera.BorderBrush = Brushes.Red;

            return nombre && primerApellido && correo && usuario && contrasenaValida
            && cmbNivelEducativo && cmbInstitucion && cmbCarrera;
        }

        private void RegresarAlMenuPrincipal(object sender, MouseButtonEventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.NavigationService.Navigate(menuPrincipal);
        }

        private void IrAlLogin(object sender, MouseButtonEventArgs e)
        {
            Login login = new Login();
            this.NavigationService.Navigate(login);
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

    }
}
