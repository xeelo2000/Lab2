using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab2
{
    
    class BusinessLogic : IBusinessLogic
    {
        int id;//incremeting the id based on entries being entered 
        public static Dictionary<int, string> entries = new Dictionary<int, string>(); //entries will be stored 
        IFlatDatabase fd = new FlatDatabase();
        


        /*
         * This will print out an error message 
         * @param string input - userinput that needs to read
         */
        void ErrorEntry(string input)
        {
            switch (input)
            {
                case "2":
                    Console.WriteLine(" Error While Adding Entry: ");
                    break;
                case "3":
                    Console.WriteLine(" Error While Deleting: ");
                    break;
                case "4":
                    Console.WriteLine(" Error While Editing: ");
                    break;
            }
        }

        /*
         * This will check each string the user input when trying to add an entry to see if it was correct
         * @param 
         * string clue 
         * string answer 
         * string difficulty 
         * DateTime date 
         * string input
         */
        public bool CheckEntryInputs(string clue, string answer, string difficulty, string date, string input)//need to consider datetime/white space
        {
            //Console.WriteLine(Regex.IsMatch(clue, @"^[a-zA-Z]+$"));
            if  (clue.Length < 0 && clue.Length > 201 || clue.Equals(""))//can clues be numbers?
            {
                ErrorEntry(input);
                Console.WriteLine(" InvalidClueLength\n");
                return false;
            }
            if (answer.Length <= 0 && answer.Length > 26 || answer.Equals(""))//can answers be numbers?
            {
                ErrorEntry(input);
                Console.WriteLine(" InvalidAnswerLength\n");
                return false;
            }
            if ((!difficulty.Equals("0")) && (!difficulty.Equals("1")) && (!difficulty.Equals("2")))
            {
                ErrorEntry(input);
                Console.WriteLine(" InvalidDifficulty\n");
                return false;
            }
            if (!DateTime.TryParse(date, out DateTime result))
            {
                ErrorEntry(input);
                Console.WriteLine(" InvalidDate\n");
                return false;
            }//need another if here 
            else
            {
                return true;
            }
        }


        /*
         * converts the string input into a int 
         * @param string input - userinput that needs to read
         * string id - id the user wants to edit
         * 
         * return bool
         */
        public bool CheckID(string id, string input)
        {
            if(int.TryParse(id, out int convertID) && GetId(convertID))
            {
                return true;
            }
            else
            {
                ErrorEntry(input);
                Console.WriteLine(" NoEntryFound\n");
                return false;
            }
        }

        //this will add the entry into the list 
        //@param string clue, string answer, string difficulty, string date
        public void AddEntry(string clue, string answer, string difficulty, string date)
        {
            id++;
            entries.Add(id, clue + ", " + answer + ", " + difficulty + ", " + date.ToString());
            fd.AddEntry(entries);
        }

        //delete the entry with the desired ID
        //@param int id - which id to delete
        public void DeleteEntry(int id)
        {
            entries.Remove(id);
            fd.AddEntry(entries);
            
        }

        //edit the entry with the desired ID
        //@param int id, string clue, string answer, string difficulty, string date 
        public void EditEntry(int id, string clue, string answer, string difficulty, string date)
        {
            Dictionary<int, string> editEntry = new Dictionary<int, string>();
            

            entries[id] = (clue + ", " + answer + ", " + difficulty + ", " + date.ToString());
            fd.AddEntry(entries);
             
        }

        //retreives all the entries and writes it to the UI
        public void getAllEntries()
        {
            foreach (KeyValuePair<int, string> entry in entries)
            {
                Console.WriteLine("{0}. {1}", entry.Key, entry.Value);
            }
            Console.WriteLine("");
            
        }


        //checks to see if the entry exists using the id
        //returns bool
        public bool GetId(int id)
        {
            return entries.ContainsKey(id);
        }
    }
}
