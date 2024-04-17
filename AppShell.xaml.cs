namespace ChefManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Vistas.VistaLogin), typeof(Vistas.VistaLogin));
            Routing.RegisterRoute(nameof(Vistas.VistaUserRegister), typeof(Vistas.VistaUserRegister));
            Routing.RegisterRoute(nameof(Vistas.RegistroRestaurante), typeof(Vistas.RegistroRestaurante));
            Routing.RegisterRoute(nameof(Vistas.Notas), typeof(Vistas.Notas));
            Routing.RegisterRoute(nameof(Vistas.VistaAdmin), typeof(Vistas.VistaAdmin));
            Routing.RegisterRoute(nameof(Vistas.VistaPrinc), typeof(Vistas.VistaPrinc));
        }
    }
}
