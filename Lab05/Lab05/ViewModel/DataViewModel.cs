using Lab05.Command;
using Lab05.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Lab05.ViewModel
{
    class DataViewModel : BaseViewModel
    {
        public DataViewModel()
        {
            SetControlVisibility = new Command(ControlVisibility);
            AddClient = new AddCommand(ControlAdd);
        }

        public ICommand SetControlVisibility { get; set; }
        public ICommand AddClient { get; set; }

        public void ControlAdd(object args)
        {
            Clients.Add(new Client() { FirstName = "A", LastName = args.ToString(), Gender = Gender.MALE});
        }

        public void ControlVisibility(object args)
        {
            VisibleControl = args.ToString();
        }

        private string _visibleControl = "Clients";
        public string VisibleControl
        {
            get => _visibleControl;
            set
            {
                _visibleControl = value;
                OnPropertyChanged(nameof(VisibleControl));
            }
        }

        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients
        {
            get => _clients; 
            set
            {
                _clients = value;
                OnPropertyChanged(nameof(Clients));
            }
        }

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders 
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products 
        {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
    }
}
