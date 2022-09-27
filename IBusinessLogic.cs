using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab2
{
    public interface IBusinessLogic
    {
        InvalidFieldError AddEntry(string clue, string answer, int difficulty, string date);
        EntryDeletionError DeleteEntry(Entry entryToBeDeleted);
        EntryEditError EditEntry(Entry entryToBeDeleted, string clue, string answer, int difficulty, string date, int id);
        Entry FindEntry(int id);
        ObservableCollection<Entry> GetEntries();
    }
}