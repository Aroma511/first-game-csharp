int[] numbers = new int[4];

void animation(int[] numbers, int currentNumber)
{
    for (int i = 0; i < 3; i++)
    {
        Console.Clear();
        for (int j = 0; j < currentNumber - 1; j++)
        {
            Console.Write(numbers[j] + " | ");
        }
        Console.Write(Random.Shared.Next(0, 10));
        Thread.Sleep(100);
        
    }
    Console.Clear();
}
void generateNubers() 
{

    Console.Clear();

    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = Random.Shared.Next(0, 10);

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
    }
    else if (pairOfThree)
    {
        Console.WriteLine("You won with pair of Three");
    }
    else if (pairOfTwo)
    {
        Console.WriteLine("You won with pair of two");
    }


}
void Main()
{

    bool result = true;

    do
    {
        generateNubers();
        checkNumbers();
        Console.WriteLine("Press Enter to play again or type exit to leave");
        string checker = Console.ReadLine();
        if (checker.ToLower() == "exit")
            result = false;
        else
            result = true;
    }
    while (result);
}
Main();
