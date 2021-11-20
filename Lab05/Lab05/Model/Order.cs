using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Model
{
    [DataContract]
    class Order
    {
        [DataMember]
        public Client OrderClient { get; set; }

        [DataMember]
        public Product OrderProduct { get; set; }

        [DataMember]
        public int ProductAmount { get; set; }

        [DataMember]
        public int TotalPrice { get; set; }

        [DataMember]
        public DateTime OrderDateTime { get; set; }

        public void CalculatePrice()
        {
            TotalPrice = OrderProduct.Price * ProductAmount;
        }
    }
}
