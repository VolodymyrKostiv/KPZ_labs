using Lab05.Model;
using System;

namespace Lab05.ViewModel
{
    class OrderViewModel : BaseViewModel
    {
        private Client _client;
        public Client OrderClient
        {
            get { return _client; }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(OrderClient));
            }
        }

        private Product _product;
        public Product OrderProduct
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(OrderProduct));
            }
        }

        private int _amount;
        public int ProductAmount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(ProductAmount));
            }
        }

        private int _totalPrice;
        public int TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private DateTime _dateTime;
        public DateTime OrderDateTime 
        {
            get { return _dateTime; } 
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(OrderDateTime));
            }
        }
    }
}
