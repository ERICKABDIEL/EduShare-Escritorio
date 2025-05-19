using System;

namespace EduShare_Escritorio.Logica
{
    public class PerfilSingleton
    {
        private static readonly PerfilSingleton _instanciaSingleton = new PerfilSingleton();

        private PerfilSingleton() { }

        public static PerfilSingleton Instance => _instanciaSingleton;

        public int IdAcceso { get; set; }
        public string Correo { get; set; }
        public string NombreUsuario { get; set; }
        public int IdUsuarioRegistrado { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }

        public byte[] FotoPerfilBinaria { get; set; }

         public void Reset()
        {
            IdAcceso = 0;
            Correo = null;
            NombreUsuario = null;
            IdUsuarioRegistrado = 0;
            Nombre = null;
            PrimerApellido = null;
            SegundoApellido = null;
            FotoPerfilBinaria = null;
        }
    }
}
