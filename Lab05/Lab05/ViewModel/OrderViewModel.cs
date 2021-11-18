using Lab05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.ViewModel
{
    class OrderViewModel : ViewModelBase
    {
        public Order Order;
        public OrderViewModel(Order order)
        {
            Order = order;
        }

        public Client OrderClient
        {
            get { return Order.OrderClient; }
            set
            {
                Order.OrderClient = value;
                OnPropertyChanged(nameof(OrderClient));
            }
        }

        public Product OrderProduct
        {
            get { return Order.OrderProduct; }
            set
            {
                Order.OrderProduct = value;
                OnPropertyChanged(nameof(OrderProduct));
            }
        }

        public int ProductAmount
        {
            get { return Order.ProductAmount; }
            set
            {
                Order.ProductAmount = value;
                OnPropertyChanged(nameof(ProductAmount));
            }
        }

        public int TotalPrice
        {
            get { return Order.TotalPrice; }
            set
            {
                Order.TotalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public DateTime OrderDateTime 
        {
            get { return Order.OrderDateTime; } 
            set
            {
                Order.OrderDateTime = value;
                OnPropertyChanged(nameof(OrderDateTime));
            }
        }
    }
}
