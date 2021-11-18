using Lab05.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Lab05.Serialization
{
    class DataSerializer
    {
        public static void SerializeData(string fileName, DataModel data)
        {
            var binaryFormatter = new DataContractSerializer(typeof(DataModel));
            using (var fileStreamCreate = new FileStream(fileName, FileMode.Create))
            {
                binaryFormatter.WriteObject(fileStreamCreate, data);
            }
        }

        public static DataModel DeserializeItem(string fileName)
        {
            var formatter = new DataContractSerializer(typeof(DataModel));
            using (var fileStreamOpen = new FileStream(fileName, FileMode.Open))
            {
                return formatter.ReadObject(fileStreamOpen) as DataModel;
            }
        }
    }
}
