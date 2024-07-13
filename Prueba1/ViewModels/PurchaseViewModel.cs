using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Prueba1.Models;
using Prueba1.Services;

namespace Prueba1.ViewModels
{
    public class PurchaseViewModel : BindableObject
    {
        private readonly IApiService _apiService;
        private string _ticketQuantity;
        private string _holderName;
        private string _holderId;
        private string _creditCardNumber;
        private string _cardCode;
        private string _expirationDate;
        private EventoDetalle _selectedEvent;
        private double _totalAmount;

        public ObservableCollection<EventoDetalle> Events { get; }

        public EventoDetalle SelectedEvent
        {
            get => _selectedEvent;
            set
            {
                _selectedEvent = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public string TicketQuantity
        {
            get => _ticketQuantity;
            set
            {
                _ticketQuantity = value;
                OnPropertyChanged();
                CalculateTotalAmount();
            }
        }

        public string HolderName
        {
            get => _holderName;
            set
            {
                _holderName = value;
                OnPropertyChanged();
            }
        }

        public string HolderId
        {
            get => _holderId;
            set
            {
                _holderId = value;
                OnPropertyChanged();
            }
        }

        public string CreditCardNumber
        {
            get => _creditCardNumber;
            set
            {
                _creditCardNumber = value;
                OnPropertyChanged();
            }
        }

        public string CardCode
        {
            get => _cardCode;
            set
            {
                _cardCode = value;
                OnPropertyChanged();
            }
        }

        public string ExpirationDate
        {
            get => _expirationDate;
            set
            {
                _expirationDate = value;
                OnPropertyChanged();
            }
        }

        public double TotalAmount
        {
            get => _totalAmount;
            private set
            {
                _totalAmount = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmPurchaseCommand { get; }
        public ICommand NavigateBackCommand { get; }

        public PurchaseViewModel(IApiService apiService)
        {
            _apiService = apiService;
            ConfirmPurchaseCommand = new Command(OnConfirmPurchase);
            NavigateBackCommand = new Command(OnNavigateBack);

            Events = new ObservableCollection<EventoDetalle>();

            LoadEvents();
        }

        private async void LoadEvents()
        {
            var events = await _apiService.GetDetailEventsAsync();
            foreach (var eventItem in events)
            {
                Events.Add(eventItem);
            }
        }

        private void CalculateTotalAmount()
        {
            if (int.TryParse(TicketQuantity, out int quantity) && SelectedEvent != null)
            {
                TotalAmount = quantity * (double)SelectedEvent.TicketPrice;
            }
            else
            {
                TotalAmount = 0;
            }
        }

        private async void OnConfirmPurchase()
        {
            var purchase = new Compra
            {
                HolderName = HolderName,
                HolderId = HolderId,
                TicketQuantity = int.Parse(TicketQuantity),
                TotalAmount = (decimal)TotalAmount,
                EventName = SelectedEvent.EventName,
                CreditCardNumber = CreditCardNumber,
                CardCode = CardCode,
                ExpirationDate = DateTime.ParseExact(ExpirationDate, "MM/yy", null)
            };

            await _apiService.PostPurchaseAsync(purchase);

            // Mostrar mensaje de confirmación
            await Application.Current.MainPage.DisplayAlert("Compra Confirmada", "La compra se ha realizado exitosamente.", "OK");

            // Limpiar campos después de la compra
            HolderName = string.Empty;
            HolderId = string.Empty;
            TicketQuantity = string.Empty;
            CreditCardNumber = string.Empty;
            CardCode = string.Empty;
            ExpirationDate = string.Empty;
            SelectedEvent = null;
            TotalAmount = 0;

        }


        private void OnNavigateBack()
        {
            // Implementar la navegación de regreso
        }
    }
}
