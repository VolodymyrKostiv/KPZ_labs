using Lab05.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.ViewModel
{
    class ProductViewModel : ViewModelBase
    {
        public Product Product;
        public ProductViewModel(Product product)
        {
            Product = product;
        }
        public string Name
        {
            get { return Product.Name; }
            set
            {
                Product.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Description
        {
            get { return Product.Description; }
            set
            {
                Product.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public int Price
        {
            get { return Product.Price; }
            set
            {
                Product.Price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
    }
}
