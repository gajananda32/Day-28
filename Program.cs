using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using CsvHelper;

namespace AddbUC15
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImpementJson();
        }  
        public static void ImpementJson()
        {
            string importFile= @"C:\Users\Gajanan\source\repos\TPLProject\TPLProject\csvHandler.csv";
            string exportFile= @"C:\Users\Gajanan\source\repos\TPLProject\TPLProject\AddressData.json";
            using (var reader =new StreamReader(importFile))
            using(var csv=new CsvReader(reader ,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecord<AddressData>().ToList();
                foreach(AddressData addressData in records)
                {
                    Console.WriteLine(addressData.FirstName);
                    Console.WriteLine(addressData.LastName);
                    Console.WriteLine(addressData.Address);
                    Console.WriteLine(addressData.city);
                    Console.WriteLine(addressData.state);
                    Console.WriteLine(addressData.code);
                }
                JsonSerializer serializer = new JsonSerializer();
                using (StreamWriter sw=new StreamWriter(exportFile ))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, records);
                }
            }
        }
        
    }
}
