using Microsoft.Maui.Controls;
using Prueba1.ViewModels;

namespace Prueba1.Views
{
    public partial class PurchasePage : ContentPage
    {
        public PurchasePage()
        {
            InitializeComponent();
            BindingContext = App.ServiceProvider.GetService<PurchaseViewModel>();
        }
    }
}
