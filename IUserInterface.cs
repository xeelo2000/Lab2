using System;

namespace Lab2
{
     interface IUserInterface
    {
        void InterfaceOption(string input);
        bool CheckInputErrors(string userInput);
        void DisplayMenu();
    }
}