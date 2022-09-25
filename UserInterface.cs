using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
     class UserInterface : IUserInterface
    {
        string clue;
        string answer;
        string difficulty;
        string date;
        IBusinessLogic bl = new BusinessLogic();


        public void DisplayMenu()
        {
            Console.Write(" Menu\n ====\n 1. List Entries\n 2. Add Entry\n" +
                    " 3. Delete Entry\n 4. Edit Entry\n 5. Quit\n Choice: ");
        }

        /*
         * This will check user input to see if it was correct
         * @param string input - userinput that needs to read
         */
        public bool CheckInputErrors(string userInput)
        {
            int convertInput;
            //if userinput is an int then true, if convertinput after being converted is a number from 1 - 5 then true 
            if (int.TryParse(userInput, out convertInput) && (convertInput >= 1 && convertInput <= 5))
            {  
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         * This will excute what the program should do based on userinput 
         * @param string input - userinput that needs to read
         */
        public void InterfaceOption(string input)
        {
            switch (input)
            {
                case "1":
                    Console.WriteLine(" \n Entries\n =======");
                    bl.getAllEntries(); //call to list all the entries
                    break;
                case "2":
                    DisplayAddEntry(2);//displays the correct interface
                    if (bl.CheckEntryInputs(clue, answer, difficulty, date, input))//checks the entry
                    {
                        bl.AddEntry(clue, answer, difficulty, date);//adds it if its correct
                    }
                    break;
                case "3":
                    Console.Write(" Id to Delete: ");
                    string inputId = Console.ReadLine();
                    if (bl.CheckID(inputId, input))//checks to see if the id exists
                    {
                        bl.DeleteEntry(int.Parse(inputId));//parses the id and deletes the correct entry
                    }
                    break;
                case "4":
                    Console.Write(" Id to Edit: ");
                   
                    inputId = Console.ReadLine();
                    if (bl.CheckID(inputId, input))//checks the id
                    {
                        DisplayAddEntry(4);
                        if (bl.CheckEntryInputs(clue, answer, difficulty, date, input))//checks inputs
                        {
                            bl.EditEntry(int.Parse(inputId), clue, answer, difficulty, date);//edits the entry with the givin inputs
                        }
                    }    
                    break;

                case "5":
                    System.Environment.Exit(0);//exits program
                    break;
            }
        }

        void DisplayAddEntry(int entryToDisplay)
        {
            //because AddEntry and EditEntry both have the same interface this will be displayed for both 
            switch (entryToDisplay)
            {
                case 2:
                    Console.WriteLine(" \n Adding Entry\n ==============");
                    break;
                case 4:
                    Console.WriteLine(" \n Editing Entry\n ==============");
                    break;
            }

            Console.Write(" Clue: ");
            clue = Console.ReadLine();
            Console.Write(" \n Answer: ");
            answer = Console.ReadLine();
            Console.Write(" \n Diffculty: ");
            difficulty = Console.ReadLine();
            Console.Write(" \n Date (mm/dd/yyyy): ");
            date = Console.ReadLine(); 
            Console.WriteLine("");
        }
    }
}
