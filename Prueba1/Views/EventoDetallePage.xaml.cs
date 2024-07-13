using Microsoft.Maui.Controls;
using Prueba1.ViewModels;

namespace Prueba1.Views
{
    public partial class EventoDetallePage : ContentPage
    {
        public EventoDetallePage()
        {
            InitializeComponent();
            BindingContext = new EventoDetalleViewModel();
        }
    }
}
