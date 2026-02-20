

int[] numbers = {0,0,0,0};

Random rnd = new Random();

string betInput = "";
bool betFinished = false;


int userMoney = 100;
int betMoney = 0;
int goalMoney = 1000;

int multiplierPairTwo = 2;
int multiplierPairThree = 3;
int multiplierPairFour = 4;

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
        
    }
    else
    {
    
    }
}

void generateNubers() 
{
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = rnd.Next(0, 10);
    }
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

    if (pairOfFour)
    {
        moneySytem(2);
    }
    else if (pairOfThree)
    {
        moneySytem(1);
    }
    else if (pairOfTwo)
    {
        moneySytem(0);
    }
    else
    {
        moneySytem(-1);
    }

}
void playAnimation(int durationMs = 800)
{
    int elapsed = 0;

    while (elapsed < durationMs)
    {
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = rnd.Next(0, 10);
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(
            $"{numbers[0]} | {numbers[1]} | {numbers[2]} | {numbers[3]}    {userMoney}/{goalMoney}"
        );
        Console.WriteLine();
        Console.WriteLine("           ");

        Thread.Sleep(60);
        elapsed += 60;
    }
}

void fpsFunction()
{
    betInput = "";
    betFinished = false;

    while (!betFinished)
    {

        // Non-blocking Input
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Enter)
            {
                if (int.TryParse(betInput, out betMoney) &&
                    betMoney > 0 &&
                    betMoney <= userMoney)
                {
                    betFinished = true;
                }
                else
                {
                    betInput = "";
                }
            }
            else if (key.Key == ConsoleKey.Backspace && betInput.Length > 0)
            {
                betInput = betInput[..^1];
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.Write(" ");
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
            }
            else if (char.IsDigit(key.KeyChar))
            {
                betInput += key.KeyChar;
            }
        }

        // Render
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.WriteLine(
            $"{numbers[0]} | {numbers[1]} | {numbers[2]} | {numbers[3]}    {userMoney}/{goalMoney}"
        );
        Console.WriteLine();
        Console.Write("Bet: " + betInput);

        Thread.Sleep(8); // FPS
    }
    playAnimation();
    generateNubers();
    checkNumbers();
}

do
{
    fpsFunction();
}
while (betMoney != 0 && userMoney > 0);

Console.WriteLine("Press any Key to leave");
Console.ReadKey();