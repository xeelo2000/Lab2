using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab2
{
    public interface IDatabase
    {
        void AddEntry(Entry entry);
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        bool ReplaceEntry(Entry replacementEntry);
    }
}