namespace Prueba1
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            ServiceProvider = serviceProvider;
            MainPage = new AppShell();
        }
    }
}






