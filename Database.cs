using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Collections.ObjectModel;
//using Android.Graphics;

// https://www.dotnetperls.com/serialize-list
// https://www.daveoncsharp.com/2009/07/xml-serialization-of-collections/


namespace Lab2
{
    public class Database : IDatabase
    {
        private ObservableCollection<Entry> entries = new ObservableCollection<Entry>();
        JsonSerializerOptions options;

        public Database()
        {
            entries.Add(new Entry("Fragrant conifger", "CEDAR", 1, "9/20/2022", 1));
            entries.Add(new Entry("Hit, as with snowballs", "PELT", 3, "9/20/2022", 2));

            // TODO: delete below?
            options = new JsonSerializerOptions { WriteIndented = true };
        }

        /// <summary>
        /// Adds an entry to the entries variable
        /// </summary>
        /// <param name="entry">the new entry to be added</param>
        public void AddEntry(Entry entry)
        {
            try
            {
                entries.Add(entry);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while adding entry: {0}", ioe);
            }
        }

        // TODO: delete?
        public Entry FindEntry(int id)
        {
            foreach (Entry entry in entries)
            {
                if (entry.Id == id)
                {
                    return entry;
                }
            }
            return null;
        }

        /// <summary>
        /// Deletes an entry 
        /// </summary>
        /// 
        /// <param name="entry">An entry, which is presumed to exist</param>
        public bool DeleteEntry(Entry entry)
        {
            try
            {
                // TODO
                //entries.RemoveAt();
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while deleting entry: {0}", ioe);
            }
            return false;
        }

        // TODO: delete and replace with EditEntry()?
        public bool ReplaceEntry(Entry replacementEntry)
        {
            foreach (Entry entry in entries) // iterate through entries until we find the Entry in question
            {
                if (entry.Id == replacementEntry.Id) // found it
                {
                    entry.Answer = replacementEntry.Answer;
                    entry.Clue = replacementEntry.Clue;
                    entry.Difficulty = replacementEntry.Difficulty;
                    entry.Date = replacementEntry.Date;         // change it then write it out

                    try
                    {
                        string jsonString = JsonSerializer.Serialize(entries, options);
                        //File.WriteAllText(filename, jsonString);
                        return true;
                    }
                    catch (IOException ioe)
                    {
                        Console.WriteLine("Error while replacing entry: {0}", ioe);
                    }

                }
            }
            return false;
        }


        /// <summary>
        /// Will get all the entries that exist in the ObservableCollection
        /// </summary>
        /// <returns>
        /// ObservableCollection<Entry>         the entries variable established at top of file
        /// </returns>
        public ObservableCollection<Entry> GetEntries()
        {
            return entries;
        }
    }
}
