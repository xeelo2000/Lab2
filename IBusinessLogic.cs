using System;

namespace Lab2
{
    interface IBusinessLogic
    {
        bool CheckEntryInputs(string clue, string answer, string difficulty, string date, string input);
        void AddEntry(string clue, string answer, string difficulty, string date);
        void DeleteEntry(int id);
        void EditEntry(int id, string clue, string answer, string difficulty, string date);
        void getAllEntries();
        bool CheckID(string id, string input);
    }
}