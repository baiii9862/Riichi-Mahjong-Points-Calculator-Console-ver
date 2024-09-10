// Introduction/Preamble: This is just a simple mahjong scoring calculation program
// Description: This program takes in the parameters, han, fu, if a person is the dealer. 
//              It then displays how much each player[s] should pay the person who has won
// Date: 2024/09/10
//
using System.Numerics;
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

while (true)
{
    //Check if there is multiple yakuman
    if (userHan > 12)
    {
        userHan = 13;
        multipleYakuman = usefulMethods.getUserInput("How many Yakuman is there?", -1, 7);
    }

    if (userHan < 5)
    {
        int fuMinimum = 0;

        if (userRon)
            fuMinimum = 25;
        else
            fuMinimum = 20;

        userFu = usefulMethods.getUserInput("How many fu is there in the winning hand", fuMinimum, 110);

        //Rounding up the user's fu to nearest 10 if not 25 fu
        if (userFu != 25)
            userFu = (int)Math.Round((double)userFu / 10) * 10;

        //Checking for mangan
        if ((userFu > 30) && (userHan == 4) || (userFu > 60) && (userHan == 3))
        {
            userHan = 5;
            userFu = 0;
        }
    }



    //Basic calculations for dealer
    //Formula for dealer points calculation is
    // fu * 2^(2 x han)
    // Mangans and up
    if (userFu == 0)
    {
        //Switch cases for anything over 5 han
        switch (userHan)
        {
            case 5:
                pointsDealt = 12000;
                break;
            case 6:
            case 7:
                pointsDealt = 18000;
                break;
            case 8:
            case 9:
            case 10:
                pointsDealt = 24000;
                break;
            case 11:
            case 12:
                pointsDealt = 36000;
                break;
            case 13:
                pointsDealt = 48000;
                break;
        }
    }
    else
    {
        //Calculating base points
        pointsDealt = userFu * (int)Math.Pow(2, (2 + userHan));
        //Obtaining the amount of points dealt
        pointsDealt = pointsDealt * 6;

        //Rounding the number up to the nearest 100
        pointsDealt = (int)Math.Ceiling((double)pointsDealt / 100) * 100;
    }


    Console.WriteLine(pointsDealt);
    Console.ReadKey();
}



class usefulMethods
{
    //Method for obtaining user's input in a true or false form
    public static bool getUserInput(string question)
    {
        string userInput = "";

        //Loops until Y or N is provided
        while (userInput != "Y" && userInput != "N")
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
        int userInput = -1;
        //Asks the user to input the amount of han
        while (userInput < minimum || userInput > maximum)
        {
            Console.Clear();
            Console.WriteLine(question);
            int.TryParse(Console.ReadLine(), out userInput);
        }

        return userInput;
    }
}
