using Microsoft.Maui.Controls;
using Prueba1.ViewModels;

namespace Prueba1.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService<MainPageViewModel>();
        }
    }
}
