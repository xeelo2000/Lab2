using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Lab2
{
    public class Entry : ObservableObject
    {
        public String clue { get; set; }
        public String answer { get; set; }
        public int difficulty { get; set; }
        public String date { get; set; }
        public int id { get; set; }

        public Entry()
        {

        }

        /// <summary>
        /// Compares one Entry's id with another
        /// </summary>
        /// <param name="other">The Entry that is gonna be compared</param>
        /// <returns>
        /// True        the id's are equal
        /// False       the id's aren't equal
        /// </returns>
        public bool Equals(Entry other)
        {
            return id == other.id;
        }
    }
}

