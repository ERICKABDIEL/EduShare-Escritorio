using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EduShare_Escritorio.Logica
{
    public static class Validador
    {
        private static Regex _regexContraseña = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?])[^ ]{8,}$", RegexOptions.None, TimeSpan.FromMilliseconds(1000));
        private static Regex _regexUsuario = new Regex("^[A-Za-zñÑ0-9_]{5,50}$", RegexOptions.None, TimeSpan.FromMilliseconds(1000));
       private static Regex _regexCorreo = new Regex(@"^[a-zA-Z0-9](?!.*[.-]{2})[a-zA-Z0-9.-]*[a-zA-Z0-9]@[a-zA-Z0-9](?!.*[.-]{2})[a-zA-Z0-9.-]*\.[a-zA-Z]{2,}$", RegexOptions.None, TimeSpan.FromMilliseconds(1000));


        public static bool ValidarExpresionRegular(string dato, Regex expresion)
        {
            bool esValido = false;
            try
            {
                esValido = expresion.IsMatch(dato);
            }
            catch (RegexMatchTimeoutException)
            {
                esValido = false;
            }
            return esValido;
        }

        public static bool ValidarContraseña(string contraseña)
        {
            bool esValido = false;
            string contraseñaLimpia = Regex.Replace(contraseña.Trim(), @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(500));
            if (!string.IsNullOrWhiteSpace(contraseñaLimpia) && ValidarExpresionRegular(contraseñaLimpia, _regexContraseña))
            {
                esValido = true;
            }
            return esValido;
        }

        public static bool ValidarNombre(string nombre)
        {
            bool esValido = false;
            string regexNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ'’]+\s?[A-Za-zÁÉÍÓÚáéíóúÑñ'’\s]*$";

            string nombreLimpio = Regex.Replace(nombre.Trim(), @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(500));

            if (!string.IsNullOrWhiteSpace(nombreLimpio) && Regex.IsMatch(nombreLimpio, regexNombre))
            {
                esValido = true;
            }

            return esValido;
        }

        public static bool ValidarCorreo(string correo)
        {
            bool esValido = false;
            string correoLimpio = Regex.Replace(correo.Trim(), @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(500));
            if (!string.IsNullOrWhiteSpace(correoLimpio) && correoLimpio.Length < 254 && ValidarExpresionRegular(correoLimpio, _regexCorreo))
            {
                esValido = true;
            }
            return esValido;
        }

        public static bool ValidarSegundoApellido(string segundoApellido)
        {
            if (string.IsNullOrWhiteSpace(segundoApellido))
                return true;

            string regexNombre = @"^[A-Za-zÁÉÍÓÚáéíóúÑñ'’]+\s?[A-Za-zÁÉÍÓÚáéíóúÑñ'’\s]*$";
            string apellidoLimpio = Regex.Replace(segundoApellido.Trim(), @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(500));

            return Regex.IsMatch(apellidoLimpio, regexNombre);
        }


        public static bool ValidarUsuario(string usuario)
        {
            bool esValido = false;
            string usuarioLimpio = Regex.Replace(usuario.Trim(), @"\s+", " ", RegexOptions.None, TimeSpan.FromMilliseconds(500));
            if (!string.IsNullOrWhiteSpace(usuarioLimpio))
            {
                esValido = true;
            }
            return esValido;
        }
    }
}
