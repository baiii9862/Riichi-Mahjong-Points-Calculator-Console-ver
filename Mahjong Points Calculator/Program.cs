// Introduction/Preamble: This is just a simple mahjong scoring calculation program
// Description: This program takes in the parameters, han, fu, if a person is the dealer. 
//              It then displays how much each player[s] should pay the person who has won
// Date: 2024/09/10
//
bool userDealer;
bool userRon;
int userHan = 0;
int userFu = 0;
int multipleYakuman = -1;
int pointsDealt = 0;

//Asking the user if they are a dealer or not. And if they won with a ron
userDealer = getUserInput("Are you the Dealer Or Not [Y/N]");
userRon = getUserInput("Did you win the game with a Ron [Y/N]");


//Asks the user to input the amount of han
while(userHan == 0)
{
    Console.Clear();
    Console.WriteLine("How many han is there in the winning hand");
    int.TryParse(Console.ReadLine(),out userHan);
}

//Check if there is multiple yakuman
if(userHan > 12)
{
    userHan = 13;
    while(multipleYakuman > -1 && multipleYakuman < 7)
    {
        Console.Clear();
        Console.WriteLine("How many yakuman is there?");
        int.TryParse(Console.ReadLine(), out multipleYakuman);
    }
}






//If the user's Han value is over 4 then it is already a mangan
if(userHan > 4)
{
    //Check how much their hand is actually worth
    switch (userHan)
    {
        case 5: pointsDealt = 8000;
            break;
        case 6: case 7:
            pointsDealt = 12000;
            break;
        case 8: case 9: case 10:
            pointsDealt = 16000;
            break;
        case 11: case 12:
            pointsDealt = 24000;
            break;
        case 13:
            pointsDealt = 32000;
            break;
        default:
            Console.WriteLine("Something has gone wrong");
            break;
    }
}





Console.ReadKey();

//Method for obtaining user's input in a true or false form
bool getUserInput(string question)
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