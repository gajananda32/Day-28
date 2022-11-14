using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPLProject
{
    public class csvHandler
    {
        public static void ImplementCsvHandeler()
        {
            string importFile = @"C:\Users\Gajanan\source\repos\TPLProject\TPLProject\csvHandler.csv";
            //reading csv file
            using (var reader = new StreamReader(importFile)) 
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
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
            }
        }
    }
}
