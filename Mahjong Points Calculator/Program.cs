// Introduction/Preamble: This is just a simple mahjong scoring calculation program
// Description: This program takes in the parameters, han, fu, if a person is the dealer. 
//              It then displays how much each player[s] should pay the person who has won
// Date: 2024/09/10
//
string userDealer = "";
Boolean userRon = false;
int userHan = 0;
int userFu = 0;
int multipleYakuman = -1;
int pointsDealt = 0;

//Asking the user if they are a dealer or not.
//Loops while not supplied a valid answer
while (!string.Equals(userDealer, "Y") && !string.Equals(userDealer, "N"))
{
    Console.Clear();
    Console.WriteLine("Are you the Dealer Or Not [Y/N]");
    userDealer = Console.ReadLine() ?? "";
    userDealer.ToUpper();
}


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





Console.WriteLine(userDealer, userHan, userFu, pointsDealt);
Console.ReadKey();

