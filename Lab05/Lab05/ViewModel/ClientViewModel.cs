using Lab05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.ViewModel
{
    class ClientViewModel : ViewModelBase
    {
        public Client Client;
        public ClientViewModel(Client client) 
        {
            Client = client;
        }

        public string FirstName
        {
            get { return Client.FirstName; }
            set
            {
                Client.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        public string LastName
        {
            get { return Client.LastName; }
            set
            {
                Client.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        public Gender Gender
        {
            get { return Client.Gender; }
            set
            {
                Client.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
    }
}
