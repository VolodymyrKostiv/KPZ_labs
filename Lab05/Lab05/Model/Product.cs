using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Model
{
    [DataContract]
    class Product
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public string Description { get; set; }
        
        [DataMember]
        public int Price { get; set; }
    }
}
