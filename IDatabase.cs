using System.Collections.ObjectModel;

namespace Lab2
{
    public interface IDatabase
    {
        ObservableCollection<Entry> GetEntries();

        void AddEntry(Entry entry);
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        bool ReplaceEntry(Entry replacementEntry);
    }
}