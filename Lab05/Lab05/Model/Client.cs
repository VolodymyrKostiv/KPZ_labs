using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Model
{
    [DataContract]
    class Client
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public Gender Gender { get; set; }
    }
    [DataContract]
    enum Gender
    {
        [EnumMember]
        MALE = 0,
        [EnumMember]
        FEMALE = 1,
        [EnumMember]
        IL_2_STURMOVIK = 2,
    }
}
