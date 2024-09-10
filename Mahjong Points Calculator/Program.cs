// Introduction/Preamble: This is just a simple mahjong scoring calculation program
// Description: This program takes in the parameters, han, fu, if a person is the dealer. 
//              It then displays how much each player[s] should pay the person who has won
// Date: 2024/09/10
//
using System.Runtime.CompilerServices;

bool userDealer;
bool userRon;
int userHan = 0;
int userFu = 0;
int multipleYakuman = -1;
int pointsDealt = 0;

//Asking the user if they are a dealer or not. And if they won with a ron
userDealer =  usefulMethods.getUserInput("Are you the Dealer Or Not [Y/N]");
userRon = usefulMethods.getUserInput("Did you win the game with a Ron [Y/N]");

//Obtaining the amount of fu and Han a user has.
userHan = usefulMethods.getUserInput("How many han is there in the winning hand", 0, 103);



//Check if there is multiple yakuman
if(userHan > 12)
{
    userHan = 13;
    multipleYakuman = usefulMethods.getUserInput("How many Yakuman is there?", -1, 7);
}







Console.ReadKey();

class usefulMethods
{
    //Method for obtaining user's input in a true or false form
    public static bool getUserInput(string question)
    {
        string userInput = "";

        //Loops until Y or N is provided
        while (userInput != "Y" || userInput != "N")
        {
            Console.Clear();
            Console.WriteLine(question);
            userInput = Console.ReadLine() ?? "";
            userInput.ToUpper();
        }

        //Returns True or false
        if (userInput == "Y")
            return true;
        else
            return false;
    }

    public static int getUserInput(string question, int minimum, int maximum)
    {
        int userInput = 0;
        //Asks the user to input the amount of han
        while (userInput > minimum || userInput < maximum)
        {
            Console.Clear();
            Console.WriteLine("question");
            int.TryParse(Console.ReadLine(), out userInput);
        }

        return userInput;
    }
}
