namespace ODS.Modelo
{
    public static class UsuarioLogueado
    {
        //Calse estatica paara control de datos del usuario logueado en todo el sistema
        public static int IdUsuario { get; set; }
        public static string Usuario { get; set; }
        public static string NombreCompleto { get; set; }
        public static string Correo { get; set; }
        public static string Departamento { get; set; }
        public static string TipoUsuario { get; set; }
        public static string NombreUsuario { get; set; }

        //Metodo para limpiar los datos del usuario
        public static void LimpiarDatos()
        {
            IdUsuario = 0;
            NombreCompleto = string.Empty;
            Correo = string.Empty;
            Departamento = string.Empty;
            TipoUsuario = string.Empty;
            NombreUsuario = string.Empty;
        }
    }


}
