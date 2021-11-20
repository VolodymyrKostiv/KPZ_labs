using Lab05.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Model
{
    [DataContract]
    class DataModel
    {
        [DataMember]
        public IEnumerable<Client> Clients { get; set; }

        [DataMember]
        public IEnumerable<Product> Products  { get; set; }

        [DataMember]
        public IEnumerable<Order> Orders { get; set; }

        public static string DataPath = "lab05.dat";

        public DataModel()
        {
            #region DataInit
            Clients = new List<Client>()
            {
                new Client() { FirstName = "Joe", LastName = "Biden", Gender = Gender.MALE },
                new Client() { FirstName = "Haruhi", LastName = "Suzumiya", Gender = Gender.FEMALE},
                new Client() { FirstName = "Billy", LastName = "Herrington", Gender = Gender.MALE},
                new Client() { FirstName = "Ellen", LastName = "Page", Gender = Gender.IL_2_STURMOVIK },
            };

            Products = new List<Product>()
            {
                new Product() { Name = "KOHLER K-596-VS", Description = "An innovative fit for a variety " +
                "of kitchens", Price = 82 },
                new Product() { Name = "KOHLER  K-15160-CP", Description = "Offering quality and style", Price = 248 }
            };

            Orders = new List<Order>()
            { 
                new Order() { OrderClient = Clients.ElementAt(0), OrderProduct = Products.ElementAt(0), 
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(1), OrderProduct = Products.ElementAt(0),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(3), OrderProduct = Products.ElementAt(1),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
            };

            foreach (Order order in Orders)
            {
                order.CalculatePrice();
            }
            #endregion
        }

        public static DataModel Load()
        {
            if (File.Exists(DataPath))
            {
                return DataSerializer.DeserializeItem(DataPath);
            }
            else
            {
                return new DataModel();
            }
        }

        public void Save()
        {
            DataSerializer.SerializeData(DataPath, this);
        }
    }
}
