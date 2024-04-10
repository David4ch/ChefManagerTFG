namespace ChefManager
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Vistas.VistaLogin), typeof(Vistas.VistaLogin));
            Routing.RegisterRoute(nameof(Vistas.VistaRegister), typeof(Vistas.VistaRegister));
            Routing.RegisterRoute(nameof(Vistas.Notas), typeof(Vistas.Notas));
        }
    }
}
