using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab2
{
    [Serializable]
    class FlatDatabase 
    {
        

        JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public void AddEntry(Dictionary<int, string> entries)
        {

            try
            {
                FileStream file = new FileStream("flatdatabase.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(file);
                string jsonString = JsonSerializer.Serialize(entries, options);

                writer.WriteLine(jsonString);
                writer.Close();
             
            }
            catch (Exception)
            {
                Console.WriteLine("Error with adding entry to database");
            }

        }

    }
}

