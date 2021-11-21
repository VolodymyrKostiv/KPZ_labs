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
                new Client() { FirstName = "Joe",       LastName = "Biden",         Gender = Gender.MALE },
                new Client() { FirstName = "Haruhi",    LastName = "Suzumiya",      Gender = Gender.FEMALE},
                new Client() { FirstName = "Billy",     LastName = "Herrington",    Gender = Gender.MALE},
                new Client() { FirstName = "Ellen",     LastName = "Page",          Gender = Gender.IL_2_STURMOVIK },
                new Client() { FirstName = "Sasuke",    LastName = "Uchiha",        Gender = Gender.MALE },
                new Client() { FirstName = "Edward",    LastName = "Elric",         Gender = Gender.MALE},
                new Client() { FirstName = "Asuka",     LastName = "Soryu",         Gender = Gender.FEMALE},
                new Client() { FirstName = "Giorno",    LastName = "Giovanna",      Gender = Gender.MALE },
                new Client() { FirstName = "Light",     LastName = "Yagami",        Gender = Gender.MALE},
                new Client() { FirstName = "Robert",    LastName = "Speedwagon",    Gender = Gender.MALE },
                new Client() { FirstName = "Misato ",   LastName = "Katsuragi",     Gender = Gender.FEMALE},
            };

            Products = new List<Product>()
            {
                new Product() { Name = "KOHLER K-596-VS", Price = 82, Description = "An innovative fit for a variety of kitchens" },
                new Product() { Name = "KOHLER  K-15160-CP", Price = 248, Description = "Offering quality and style" },
                new Product() { Name = "1", Price = 1, Description = "Summer has come and passed"},
                new Product() { Name = "2", Price = 1, Description = "The innocent can never last " },
                new Product() { Name = "3", Price = 1, Description = "Wake me up when September ends" },
                new Product() { Name = "4", Price = 1, Description = "Like my fathers come to pass" },
                new Product() { Name = "5", Price = 1, Description = "Seven years has gone so fast" },
                new Product() { Name = "6", Price = 1, Description = "Wake me up when September ends" },
                new Product() { Name = "7", Price = 1, Description = "Here comes the rain again" },
                new Product() { Name = "8", Price = 1, Description = "Falling from the stars" },
                new Product() { Name = "9", Price = 1, Description = "Drenched in my pain again" },
                new Product() { Name = "10", Price = 1, Description = "Becoming who we are" },
                new Product() { Name = "11", Price = 1, Description = "As my memory rests" },
                new Product() { Name = "12", Price = 1, Description = "But never forgets what I lost" },
                new Product() { Name = "13", Price = 1, Description = "Wake me up when September ends" },
                new Product() { Name = "14", Price = 1, Description = "Summer has come and passed" },
                new Product() { Name = "15", Price = 1, Description = "The innocent can never last" },
                new Product() { Name = "16", Price = 1, Description = "Wake me up when September ends" },
            };

            Orders = new List<Order>()
            { 
                new Order() { OrderClient = Clients.ElementAt(0), OrderProduct = Products.ElementAt(0), 
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(1), OrderProduct = Products.ElementAt(0),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(3), OrderProduct = Products.ElementAt(2),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() { OrderClient = Clients.ElementAt(4), OrderProduct = Products.ElementAt(3),
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(7), OrderProduct = Products.ElementAt(4),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(6), OrderProduct = Products.ElementAt(5),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() { OrderClient = Clients.ElementAt(2), OrderProduct = Products.ElementAt(6),
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(9), OrderProduct = Products.ElementAt(7),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(5), OrderProduct = Products.ElementAt(8),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() { OrderClient = Clients.ElementAt(3), OrderProduct = Products.ElementAt(9),
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(4), OrderProduct = Products.ElementAt(10),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(1), OrderProduct = Products.ElementAt(11),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() {OrderClient = Clients.ElementAt(3), OrderProduct = Products.ElementAt(12),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() { OrderClient = Clients.ElementAt(5), OrderProduct = Products.ElementAt(13),
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(8), OrderProduct = Products.ElementAt(14),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(7), OrderProduct = Products.ElementAt(15),
                    ProductAmount = 31, OrderDateTime = new DateTime(2020, 6, 12) },
                new Order() { OrderClient = Clients.ElementAt(4), OrderProduct = Products.ElementAt(0),
                    ProductAmount = 1, OrderDateTime = new DateTime(2021, 12, 1) },
                new Order() { OrderClient = Clients.ElementAt(0), OrderProduct = Products.ElementAt(1),
                    ProductAmount = 100, OrderDateTime = new DateTime(2007, 8, 10) },
                new Order() {OrderClient = Clients.ElementAt(1), OrderProduct = Products.ElementAt(2),
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
