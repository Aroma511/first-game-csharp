// First Comment
using System.Runtime.InteropServices;

int[] numbers = new int[4];

Random rnd = new Random();

int userMoney = 100;
int betMoney = 0;
int goalMoney = 1000;

int multiplierPairTwo = 2;
int multiplierPairThree = 3;
int multiplierPairFour = 4;
void fpsFunction(userMoney, betMoney, numbers)
{
    Console.WriteLine("{1} | {2} | {3} | {4}                        {5}/{6}");
    Console.WriteLine("");

}

void moneySytem(int moneyMultiplier)
{
    switch (moneyMultiplier)
    {
        case 0:
            userMoney += betMoney * multiplierPairTwo;
            break;

        case 1:
            userMoney += betMoney * multiplierPairThree;
            break;

        case 2:
            userMoney += betMoney * multiplierPairFour;
            break;

        default:
            userMoney -= betMoney;
            break;

    }
    if (userMoney >= goalMoney)
    {
        Console.WriteLine("Game Finished");
    }
    else
    {
        Console.WriteLine("{0}/{1}", userMoney, goalMoney);
    }
}

void animation(int[] numbers, int currentNumber)
{
    for (int i = 0; i < 3; i++)
    {
        Console.Clear();
        for (int j = 0; j < currentNumber - 1; j++)
        {
            Console.Write(numbers[j] + " | ");
        }
        Console.Write(rnd.Next(0, 10));
        Thread.Sleep(100);
        
    }
    Console.Clear();
}
void generateNubers() 
{

    Console.Clear();

    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = rnd.Next(0, 10);

        animation(numbers, i + 1);

        for (int j = 0; j <= i; j++)
        {
            Console.Write(numbers[j] + " | ");
        }
    }
    Console.WriteLine("");
}
void checkNumbers()
{
    bool pairOfTwo =
        numbers[0] == numbers[1] ||
        numbers[1] == numbers[2] ||
        numbers[2] == numbers[3] ||
        numbers[0] == numbers[2] ||
        numbers[1] == numbers[3] ||
        numbers[0] == numbers[3];

    bool pairOfThree =
        (numbers[0] == numbers[1] && numbers[1] == numbers[2]) ||
        (numbers[1] == numbers[2] && numbers[2] == numbers[3]);
    bool pairOfFour =
        numbers[0] == numbers[1] && numbers[1] == numbers[2] && numbers[2] == numbers[3];
    Console.WriteLine("");
    if (pairOfFour)
    {
        Console.WriteLine("You Won with Pair of four");
        moneySytem(2);
    }
    else if (pairOfThree)
    {
        Console.WriteLine("You won with pair of Three");
        moneySytem(1);
    }
    else if (pairOfTwo)
    {
        Console.WriteLine("You won with pair of two");
        moneySytem(0);
    }
    else
    {
        Console.WriteLine("You Lost");
        moneySytem(-1);
    }

}
void Main()
{

    bool result = true;

    do
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.Write("Whats your bet (0 to leave): ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out betMoney))
            {
                Console.WriteLine("Invalid Bet");
                continue;
            }
            if (betMoney < 0 || betMoney > userMoney)
            {
                Console.WriteLine("Invalid Bet");
                continue;
            }
            
            validInput = true;
        }

        if (betMoney == 0)
        {
            break;
        }
        
        generateNubers();
        checkNumbers();

    }
    while (betMoney != 0 && userMoney > 0);
}
Main();
Console.WriteLine("Press any Key to leave");
Console.ReadKey();