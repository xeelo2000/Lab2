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
        string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        String filename;
        List<Entry> listEntries;
        private ObservableCollection<Entry> entries = new ObservableCollection<Entry>();
        JsonSerializerOptions options;


        public Database()
        {
            filename = $"{appDataPath}/clues.db";
            String cacheDir = FileSystem.Current.CacheDirectory;
            GetEntries();
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
                // adds the new entry to both the List and ObservableCollection
                listEntries.Add(entry);
                entries.Add(entry);

                // serializes all the current entries and writes it to the file
                string jsonString = JsonSerializer.Serialize(listEntries, options);
                File.WriteAllText(filename, jsonString);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while adding entry: {0}", ioe);
            }
        }

        /// <summary>
        /// This will find the correct entry to modify or delete
        /// </summary>
        /// <param name="id">The id of the entry to be found</param>
        /// <returns></returns>
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
        /// Deletes an entry by removing it from the listEntries, entries, and the file
        /// </summary>
        /// 
        /// <param name="entry">An entry, which is presumed to exist</param>
        public bool DeleteEntry(Entry entry)
        {
            try
            {
                // remove from listEntries and entries
                listEntries.Remove(entry);
                entries.Remove(entry);

                // writes updated listEntries to file (with entry removed)
                string jsonString = JsonSerializer.Serialize(listEntries, options);
                File.WriteAllText(filename, jsonString);
                return true;
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error while deleting entry: {0}", ioe);
            }
            return false;
        }


        /// <summary>
        /// This will take the entry that has been edited and replace with the one in the list
        /// </summary>
        /// <param name="replacementEntry">entry that will replace the entry in the list</param>
        /// <returns></returns>
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
                        File.WriteAllText(filename, jsonString);
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
        /// If a clues.db doesn't exist, create a new file and listEntries and entries will be empty
        /// If a clues.db does exist, read in the file and all its possible entries and populate listEntries and entries
        /// </summary>
        /// <returns>
        /// ObservableCollection<Entry>         the entries variable established at top of file
        /// </returns>
        public ObservableCollection<Entry> GetEntries()
        {
            // If the file doesn't exist, create it and listEntries will be empty
            if (!File.Exists(filename))
            {
                File.CreateText(filename);
                listEntries = new List<Entry>();
                return entries;
            }

            // The file does exist, read it in and populate listEntries with exiting entries
            string jsonString = File.ReadAllText(filename);
            if (jsonString.Length > 0)
            {
                listEntries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
            }

            // populates ObservableCollection with existing entries from the file
            foreach (Entry entry in listEntries)
            {
                entries.Add(entry);
            }

            return entries;
        }
    }
}
