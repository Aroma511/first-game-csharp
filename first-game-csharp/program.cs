Console.OutputEncoding = System.Text.Encoding.UTF8;

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
int multiplierLose = 0;
int moneyMultipier = 0;



string UI =
    (
    """
    ┌───────────────────────────┐
    │       Slot Machine        │
    │                           │
    │                           │
    │                           │     
    │                           │
    │                           │
    │                           │
    │                           │
    └───────────────────────────┘
    """
    );
string DISPLAY(int indicatorDisplay)
{
    Console.SetCursorPosition(1, 1);
    switch (indicatorDisplay)
    {
        case 1:
            return $"""

            │ {numbers[0]} |
            """;
        case 2:
            return $"""

            │ {numbers[0]} | {numbers[1]} |
            """;
        case 3:
            return $"""

            │ {numbers[0]} | {numbers[1]} | {numbers[2]} |
            """;
        case 4:
            return $"""

            │ {numbers[0]} | {numbers[1]} | {numbers[2]} | {numbers[3]}     
            """;
        case 10:
            multiplier
            return $"""

            │ {numbers[0]} | {numbers[1]} | {numbers[2]} | {numbers[3]}    
            │ {userMoney}/{goalMoney} 
            │ Pot: {betMoney} {moneyMultiplier}x
            """;
        default:
            return $"""

            │ {numbers[0]} | {numbers[1]} | {numbers[2]} | {numbers[3]}    
            │ {userMoney}/{goalMoney} 
            │ Pot: {betMoney} 
            """;

    ;
    }
    
}
    
void moneySytem(int moneyMultiplier)
{
    userMoney += betMoney * moneyMultiplier;

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
        moneySytem(multiplierPairFour);
    }
    else if (pairOfThree)
    {
        moneySytem(multiplierPairThree);
        }
    else if (pairOfTwo)
    {
        moneySytem(multiplierPairTwo);
    }
    else
    {
        moneySytem(multiplierLose);
    }

}
void playAnimation(int durationMs = 2000)
{
    int elapsed = 0;
    int indicatorDisplay = 0;
    while (elapsed < durationMs)
    {
       
        
        for (int i = indicatorDisplay; i < numbers.Length; i++)
        {
            numbers[i] = rnd.Next(0, 10);
        }
                
        if (elapsed == 240)
        {
            indicatorDisplay = 1;
            Console.WriteLine(DISPLAY(indicatorDisplay));
        }
        else if (elapsed == 480)
        {
            indicatorDisplay = 2;
            Console.WriteLine(DISPLAY(indicatorDisplay));
        }
        else if (elapsed == 960)
        {
            indicatorDisplay = 3;
            Console.WriteLine(DISPLAY(indicatorDisplay));
        }
        else if (elapsed == 1920)
        {
            indicatorDisplay = 4;
            Console.WriteLine(DISPLAY(indicatorDisplay));
        }


        Console.CursorVisible = false;
        Console.SetCursorPosition(1, 1);
        Console.WriteLine(DISPLAY(-1));

       

        Thread.Sleep(60);
        elapsed += 60;
        
        
    }
    Thread.Sleep(300);
    betInput = "";
    Console.SetCursorPosition(1, 8);
    Console.WriteLine("Bet:        ");


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
                if (int.TryParse(betInput, out betMoney) && betMoney > 0 && betMoney <= userMoney)
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
        
        Console.SetCursorPosition(1, 1);
        Console.WriteLine(DISPLAY(-1));
        
        Console.Write($"""
            
            
            
            
            │Bet: {betInput}
            """);

        Thread.Sleep(8); // FPS
    }
    playAnimation();
    //generateNubers();
    checkNumbers();
}
Console.WriteLine(UI);
do
{
    fpsFunction();

    
}
while (betMoney != 0 && userMoney > 0);

Console.WriteLine("Press any Key to leave");
Console.ReadKey();