// Introduction/Preamble: This is just a simple mahjong scoring calculation program
// Description: This program takes in the parameters, han, fu, if a person is the dealer. 
//              It then displays how much each player[s] should pay the person who has won
// Date: 2024/09/10
using System.Numerics;
using System.Runtime.CompilerServices;

bool userDealer;
bool userRon;
bool repeatCalculations = true;
int userHan = 0;
int userFu = 0;
int multipleYakuman = -1;
int pointsDealt = 0;


while (repeatCalculations)
{
    if (repeatCalculations)
    {
        userHan = 0;
        userFu = 0;
        multipleYakuman = 0;
        pointsDealt = 0;
    }

    //Asking the user if they are a dealer or not. And if they won with a ron
    userDealer = usefulMethods.getUserInput("Are you the Dealer Or Not [Y/N]");
    userRon = usefulMethods.getUserInput("Did you win the game with a Ron [Y/N]");

    //Obtaining the amount of fu and Han a user has.
    userHan = usefulMethods.getUserInput("How many han is there in the winning hand", 1, 103);

    //Check if there is multiple yakuman
    if (userHan > 12)
    {
        userHan = 13;
        multipleYakuman = usefulMethods.getUserInput("How many Yakuman is there?", 0, 7);
    }

    if (userHan < 5)
    {
        int fuMinimum = 0;
        int fuMaximum = 110;

        if (userRon)
            fuMinimum = 25;
        else
            fuMinimum = 20;


        //Edge case and impossible hands
        if(userHan == 1)
        {
            fuMaximum = 100;
            fuMinimum = 30;
        }
        else if(userHan == 2 && !userRon)
        {
            fuMinimum = 30;
        }

        userFu = usefulMethods.getUserInput("How many fu is there in the winning hand", fuMinimum, fuMaximum);

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
            case 6: case 7:
                pointsDealt = 18000;
                break;
            case 8: case 9: case 10:
                pointsDealt = 24000;
                break;
            case 11: case 12:
                pointsDealt = 36000;
                break;
            case 13:
                pointsDealt = 48000;
                break;
        }
        if (!userDealer)
            pointsDealt = (int)(pointsDealt / 1.5);
    }
    else
    {
        //Calculating base points
        pointsDealt = userFu * (int)Math.Pow(2, (2 + userHan));

        //Obtaining the amount of points dealt for dealer and nondealer
        if (!userDealer)
            pointsDealt = (int)(pointsDealt / 1.5);

        pointsDealt = pointsDealt * 6;

        //Rounding the number up to the nearest 100
        pointsDealt = (int)Math.Ceiling((double)pointsDealt / 100) * 100;
    }

    //Adjusting points if there is multiple yakuman
    if (multipleYakuman > 1)
        pointsDealt = pointsDealt * multipleYakuman;

    //Determine if it was a tsumo or a ron and recalculate if it was a tsumo
    if (userRon)
    {
        Console.WriteLine("The person who dealt in has to pay: " + pointsDealt);
    }
    else
    {
        //Calculating how much each person has to pay the dealer in a tsumo.
        if (userDealer)
        {
            pointsDealt = (int)Math.Ceiling((double)pointsDealt / 300) * 100;
            Console.WriteLine("Everyone has to pay the dealer: " + pointsDealt);
        }
        else
        {
            //If the points are odd they need to be bumped up by 100 to split evenly
            if(pointsDealt % 200 != 0)
                pointsDealt += 100;

            //Calculate the points dealer has to pay
            int pointsDealtDealer = pointsDealt / 2;
            int pointsDealtNonDealer = (int)Math.Ceiling((double)pointsDealtDealer / 200) * 100;

            Console.WriteLine("Non Dealers have to pay: " + pointsDealtNonDealer);
            Console.WriteLine("The Dealer has to pay: " + pointsDealtDealer);
        }
    }

    Console.ReadKey();
    repeatCalculations = usefulMethods.getUserInput("Would you like to calculate another winning hand? [Y/N]");

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
            userInput = userInput.ToUpper();
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
