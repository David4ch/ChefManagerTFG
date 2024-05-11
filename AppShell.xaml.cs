namespace ChefManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Vistas.VistaLogin), typeof(Vistas.VistaLogin));
            Routing.RegisterRoute(nameof(Vistas.RegistroUser), typeof(Vistas.RegistroUser));
            Routing.RegisterRoute(nameof(Vistas.RegistroRestaurante), typeof(Vistas.RegistroRestaurante));
            Routing.RegisterRoute(nameof(Vistas.Notas), typeof(Vistas.Notas));
            Routing.RegisterRoute(nameof(Vistas.VistaAdmin), typeof(Vistas.VistaAdmin));
            Routing.RegisterRoute(nameof(Vistas.VistaPrinc), typeof(Vistas.VistaPrinc));
            Routing.RegisterRoute(nameof(Vistas.MainPage.AgregarNota), typeof(Vistas.MainPage.AgregarNota));
            Routing.RegisterRoute(nameof(Vistas.MainPage.VerNota), typeof(Vistas.MainPage.VerNota));
            Routing.RegisterRoute(nameof(Vistas.Proveedores), typeof(Vistas.Proveedores));
            Routing.RegisterRoute(nameof(Vistas.MainPage.Proveedores.AgregarProveedor), typeof(Vistas.MainPage.Proveedores.AgregarProveedor));
        }
    }
}
