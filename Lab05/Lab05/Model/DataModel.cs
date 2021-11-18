using System;
using System.Collections.Generic;
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
        public IEnumerable<Order> Orders { get; set; }

        [DataMember]
        public IEnumerable<Product> Products  { get; set; }
    }
}
