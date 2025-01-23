using GamerWorld.Views;

namespace GamerWorld
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            // Register routes
            Routing.RegisterRoute(nameof(Section1), typeof(Section1));
            Routing.RegisterRoute(nameof(Section2), typeof(Section2));
            Routing.RegisterRoute(nameof(Section3), typeof(Section3));
            Routing.RegisterRoute(nameof(Section4), typeof(Section4));
            Routing.RegisterRoute(nameof(Section5), typeof(Section5));
            Routing.RegisterRoute(nameof(Section6), typeof(Section6));
            Routing.RegisterRoute(nameof(Section7), typeof(Section7));
        }
    }
}
