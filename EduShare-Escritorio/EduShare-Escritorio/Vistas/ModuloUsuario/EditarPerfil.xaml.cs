using EduShare_Escritorio.Logica;
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
    public partial class EditarPerfil : Page
    {
        private Frame _frame;
        public EditarPerfil(Frame frame)
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

        private void RegresarAlPerfil(object sender, MouseButtonEventArgs e)
        {
            _frame.Navigate(new Perfil(_frame));

        }

        private void ActualizarPerfil(object sender, RoutedEventArgs e)
        {
            RegresarBordeOriginal();
            if (ValidarCamposVacios())
            {

                if (VerificarCampos())
                {
                    MostrarMensajePersonalizado("¡Perfil actualizado con éxito!", DialogType.Success);
                    _frame.Navigate(new Perfil(_frame));
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
            brd_NivelEducativo.BorderBrush = verde;
            brd_Institucion.BorderBrush = verde;
            brd_Carrera.BorderBrush = verde;

        }

        public bool VerificarCampos()
        {
            bool nombre = Validador.ValidarNombre(txtb_Nombre.Text);
            bool primerApellido = Validador.ValidarNombre(txtb_PrimerApellido.Text);
            bool segundoApellido = Validador.ValidarSegundoApellido(txtb_SegundoApellido.Text);
            bool usuario = Validador.ValidarUsuario(txtb_Usuario.Text);
            bool correo = Validador.ValidarCorreo(txtb_Correo.Text);

            if (!nombre) brd_Nombre.BorderBrush = Brushes.Red;
            if (!primerApellido) brd_PrimerApellido.BorderBrush = Brushes.Red;
            if (!segundoApellido) brd_SegundoApellido.BorderBrush = Brushes.Red;
            if (!usuario) brd_Usuario.BorderBrush = Brushes.Red;
            if (!correo) brd_Correo.BorderBrush = Brushes.Red;

            return nombre && primerApellido && segundoApellido && correo && usuario;
        }

        public bool ValidarCamposVacios()
        {
            bool nombre = !string.IsNullOrWhiteSpace(txtb_Nombre.Text);
            bool primerApellido = !string.IsNullOrWhiteSpace(txtb_PrimerApellido.Text);
            bool usuario = !string.IsNullOrWhiteSpace(txtb_Usuario.Text);
            bool correo = !string.IsNullOrWhiteSpace(txtb_Correo.Text);

            bool cmbNivelEducativo = cmb_NivelEducativo.SelectedItem != null;
            bool cmbInstitucion = cmb_Institución.SelectedItem != null;
            bool cmbCarrera = cmb_Carrera.SelectedItem != null;



            if (!nombre) brd_Nombre.BorderBrush = Brushes.Red;
            if (!primerApellido) brd_PrimerApellido.BorderBrush = Brushes.Red;
            if (!correo) brd_Correo.BorderBrush = Brushes.Red;
            if (!usuario) brd_Usuario.BorderBrush = Brushes.Red;

            if (!cmbNivelEducativo) brd_NivelEducativo.BorderBrush = Brushes.Red;
            if (!cmbInstitucion) brd_Institucion.BorderBrush = Brushes.Red;
            if (!cmbCarrera) brd_Carrera.BorderBrush = Brushes.Red;

            return nombre && primerApellido && correo && usuario
            && cmbNivelEducativo && cmbInstitucion && cmbCarrera;
        }
    }
}
