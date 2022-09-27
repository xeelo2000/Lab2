using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lab2
{
    /// <summary>
    /// Corresponding messages for InvalidFieldError
    /// </summary>
    public enum InvalidFieldError
    {
        InvalidClueLength,
        InvalidAnswerLength,
        InvalidDifficulty,
        InvalidDate,
        NoError
    }

    /// <summary>
    /// Corresponding messages for an error dealing with deletion
    /// </summary>
    public enum EntryDeletionError
    {
        EntryNotFound,
        DBDeletionError,
        NoError
    }

    /// <summary>
    /// Corresponding messages for an error dealing with edit
    /// </summary>
    public enum EntryEditError
    {
        EntryNotFound,
        InvalidFieldError,
        DBEditError,
        NoError
    }

    public class BusinessLogic : IBusinessLogic
    {
        const int MAX_CLUE_LENGTH = 250;
        const int MAX_ANSWER_LENGTH = 21;
        const int MAX_DIFFICULTY = 5;
        int latestId = 0;

        IDatabase db;

        /// <summary>
        /// Constructor for a BusinessLogic Object
        /// </summary>
        public BusinessLogic()
        {
            db = new Database();
        }

        /// <summary>
        /// Calls the database's GetEntries() to pass onto the MainPage
        /// </summary>
        /// <returns>ObservableCollection<Entry>       the entries that exist in the database</returns>
        public ObservableCollection<Entry> GetEntries()
        {
            return db.GetEntries();
        }

        public Entry FindEntry(int id)
        {
            return db.FindEntry(id);
        }

        /// <summary>
        /// Checks to see if user input meets the integrity of an Entry object
        /// </summary>
        /// <param name="clue">clue that the entry will have</param>
        /// <param name="answer">answer that the entry will have</param>
        /// <param name="difficulty">difficulty that the entry will have</param>
        /// <param name="date">date that the entry will have</param>
        /// <returns>InvalidFieldError      returns the corresponding error message, none if there are no issues</returns>
        private InvalidFieldError CheckEntryFields(string clue, string answer, int difficulty, string date)
        {
            if (clue == null || clue.Length < 1 || clue.Length > MAX_CLUE_LENGTH)
            {
                return InvalidFieldError.InvalidClueLength;
            }
            if (answer == null || answer.Length < 1 || answer.Length > MAX_ANSWER_LENGTH)
            {
                return InvalidFieldError.InvalidAnswerLength;
            }
            if (difficulty < 1 || difficulty > MAX_DIFFICULTY)
            {
                return InvalidFieldError.InvalidDifficulty;
            }

            return InvalidFieldError.NoError;
        }

        /// <summary>
        /// Adds an entry to the database, otherwise returns proper error message
        /// </summary>
        /// <param name="clue"></param>
        /// <param name="answer"></param>
        /// <param name="difficulty"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public InvalidFieldError AddEntry(string clue, string answer, int difficulty, string date)
        {

            var result = CheckEntryFields(clue, answer, difficulty, date);

            // if there was an error with one of the inputs, return the error
            if (result != InvalidFieldError.NoError)
            {
                return result;
            }

            // there was no error with any put, create an entry object and add it to the db
            Entry entry = new Entry(clue, answer, difficulty, date, ++latestId);
            db.AddEntry(entry);
            return InvalidFieldError.NoError;
        }


        /// <summary>
        /// Deletes an entry from the database
        /// </summary>
        /// <param name="entryToBeDeleted">the entry to be deleted</param>
        /// <returns>EntryDeletionError      returns the corresponding error message, none if there are no issues</returns>
        public EntryDeletionError DeleteEntry(Entry entryToBeDeleted)
        {
            var entry = db.FindEntry(entryToBeDeleted.Id);

            if (entry != null)
            {
                bool success = db.DeleteEntry(entry);
                if (success)
                {
                    return EntryDeletionError.NoError;

                }
                else
                {
                    return EntryDeletionError.DBDeletionError;
                }
            }
            else
            {
                return EntryDeletionError.EntryNotFound;
            }
        }

        /// <summary>
        /// Edits an entry that exists in the database
        /// </summary>
        /// <param name="entryToBeEdited">entry that will be edited</param>
        /// <param name="clue">clue that will replace the clue for entryToBeEdit</param>
        /// <param name="answer">answer that will replace the answer for entryToBeEdit</param>
        /// <param name="difficulty">difficulty that will replace the difficulty for entryToBeEdit</param>
        /// <param name="date">date that will replace the date for entryToBeEdit</param>
        /// <param name="id"></param>
        /// <returns>EntryEditError         returns the corresponding error message, none if there are no issues</returns>
        public EntryEditError EditEntry(Entry entryToBeEdited, string clue, string answer, int difficulty, string date, int id)
        {

            var fieldCheck = CheckEntryFields(clue, answer, difficulty, date);
            if (fieldCheck != InvalidFieldError.NoError)
            {
                return EntryEditError.InvalidFieldError;
            }

            var entry = db.FindEntry(id);
            entry.Clue = clue;
            entry.Answer = answer;
            entry.Difficulty = difficulty;
            entry.Date = date;

            bool success = db.ReplaceEntry(entry);
            if (!success)
            {
                return EntryEditError.DBEditError;
            }

            return EntryEditError.NoError;
        }
    }
}
