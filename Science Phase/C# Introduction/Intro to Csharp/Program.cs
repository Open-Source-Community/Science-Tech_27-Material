// =====================================================================
//  C# BASICS: EXERCISES WITH SOLUTIONS
//  Note: exercise 2 waits for keyboard input.
// =====================================================================


using Introduction_to_Csharp;
public class Program
{
    public static void Main(string[] args)
    {

        // ---------------------------------------------------------------------
        // 1. VARIABLES AND DATA TYPES
        // EXERCISE: Declare a student's name (string), age (int), GPA (double)
        // and enrolled status (bool). Print them using string interpolation.
        // ---------------------------------------------------------------------
        #region Solution 1

        string first = " first";
        Console.WriteLine($"hello there is {first}");


        string name = "ali";
        int age = 21;
        double gpa = 3.7;
        bool isEnrolled = true;

        Console.WriteLine("--- 1. Variables ---");
        {
            Console.WriteLine($"{name}, age {age}, GPA {gpa}, enrolled: {isEnrolled}");
        }
        #endregion


        // ---------------------------------------------------------------------
        // 2. INPUT AND OUTPUT
        // EXERCISE: Ask the user for their name and age.
        // Print a greeting that tells them how old they will be next year.
        // ---------------------------------------------------------------------
        #region Solution 2
        //Console.WriteLine("\n--- 2. Input and output ---");
        //{
        //    Console.Write("Enter your name: ");
        //    name = Console.ReadLine();

        //    Console.Write("Enter your age: ");
        //    age = int.Parse(Console.ReadLine());

        //    Console.WriteLine($"Hello {name}! Next year you will be {age + 1}.");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 3. OPERATORS
        // EXERCISE: Given a = 17 and b = 5, print the sum, difference, product,
        // integer division and remainder. Then check whether a is even.
        // ---------------------------------------------------------------------
        #region Solution 3
        //Console.WriteLine("\n--- 3. Operators ---");
        //{
        //    int a = 17, b = 5;

        //    Console.WriteLine($"{a} + {b} = {a + b}");
        //    Console.WriteLine($"{a} - {b} = {a - b}");
        //    Console.WriteLine($"{a} * {b} = {a * b}");
        //    Console.WriteLine($"{a} / {b} = {a / b} (integer division)");
        //    Console.WriteLine($"{a} % {b} = {a % b} (remainder)");
        //    Console.WriteLine($"Is {a} even? {a % 2 == 0}");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 4. IF CONDITIONS
        // EXERCISE: Given a score, print the grade:
        // 90+ = A, 80+ = B, 70+ = C, 60+ = D, otherwise F.
        // ---------------------------------------------------------------------
        #region Solution 4
        //Console.WriteLine("\n--- 4. If conditions ---");
        //{
        //    int score = 82;

        //    if (score >= 90)
        //    {
        //        Console.WriteLine("Grade: A");
        //    }
        //    else if (score >= 80)
        //    {
        //        Console.WriteLine("Grade: B");
        //    }
        //    else if (score >= 70)
        //    {
        //        Console.WriteLine("Grade: C");
        //    }
        //    else if (score >= 60)
        //    {
        //        Console.WriteLine("Grade: D");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Grade: F");
        //    }
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 5. TERNARY OPERATOR
        // EXERCISE: Using ONE line with the ternary operator, set status to
        // "Adult" if age is 18 or more, otherwise "Minor".
        // ---------------------------------------------------------------------
        #region Solution 5
        //Console.WriteLine("\n--- 5. Ternary operator ---");
        //{
        //    int age2 = 16;
        //    string status = age2 >= 18 ? "Adult" : "Minor";

        //    Console.WriteLine($"Age {age2}: {status}");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 6. SWITCH
        // EXERCISE A: Use a classic switch to print the name of day 1, 2 or 3
        //             (Monday, Tuesday, Wednesday). Anything else: "Another day".
        // EXERCISE B: Use a switch expression to turn a traffic-light color
        //             into an action: red = Stop, yellow = Get ready, green = Go.
        // ---------------------------------------------------------------------
        #region Solution 6
        //Console.WriteLine("\n--- 6. Switch ---");
        //{
        //    int day = 3;

        //    switch (day)
        //    {
        //        case 1:
        //            Console.WriteLine("Monday");
        //            break;
        //        case 2:
        //            Console.WriteLine("Tuesday");
        //            break;
        //        case 3:
        //            Console.WriteLine("Wednesday");
        //            break;
        //        default:
        //            Console.WriteLine("Another day");
        //            break;
        //    }

        //    string light = "yellow";
        //    string action = light switch
        //    {
        //        "red" => "Stop",
        //        "yellow" => "Get ready",
        //        "green" => "Go",
        //        _ => "Unknown color"
        //    };

        //    Console.WriteLine($"{light} light: {action}");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 7. LOOPS
        // EXERCISE A (for):        Print the multiplication table of 3 (1 to 10).
        // EXERCISE B (while):      Count down from 5 to 1 on one line.
        // EXERCISE C (do...while): Show that the body runs once even when the
        //                          condition is false from the start.
        // EXERCISE D (foreach):    Print every fruit in a string array.
        // EXERCISE E (break / continue): Print 1 to 10, but skip multiples of 3
        //                          and stop completely when the number reaches 8.
        // ---------------------------------------------------------------------
        #region Solution 7
        //Console.WriteLine("\n--- 7. Loops ---");
        //{
        //    // A: for
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        Console.WriteLine($"3 x {i} = {3 * i}");
        //    }

        //    // B: while
        //    int n = 5;
        //    while (n >= 1)
        //    {
        //        Console.Write(n + " ");
        //        n--;
        //    }
        //    Console.WriteLine();

        //    // C: do...while
        //    int x = 10;
        //    do
        //    {
        //        Console.WriteLine($"x = {x} (the body ran once)");
        //        x++;
        //    } while (x < 5);

        //    // D: foreach
        //    string[] fruits = { "Apple", "Banana", "Orange" };
        //    foreach (string fruit in fruits)
        //    {
        //        Console.WriteLine(fruit);
        //    }

        //    // E: break and continue (prints 1 2 4 5 7)
        //    for (int i = 1; i <= 10; i++)
        //    {
        //        if (i % 3 == 0) continue;
        //        if (i == 8) break;
        //        Console.Write(i + " ");
        //    }
        //    Console.WriteLine();
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 8. ARRAYS, LISTS AND DICTIONARIES
        // EXERCISE A (array):      Find the largest number in { 4, 18, 7, 25, 9 }
        //                          using a loop (no built-in Max).
        // EXERCISE B (list):       Add Ali, Mona and Omar, remove Mona,
        //                          then print the count and the remaining names.
        // EXERCISE C (dictionary): Store the ages of Ali (20) and Mona (22).
        //                          Print every pair, then look up Mona's age.
        // ---------------------------------------------------------------------
        #region Solution 8
        //Console.WriteLine("\n--- 8. Arrays, lists and dictionaries ---");
        //{
        //    // A: array
        //    int[] numbers = { 4, 18, 7, 25, 9 };
        //    int max = numbers[0];
        //    foreach (int number in numbers)
        //    {
        //        if (number > max)
        //        {
        //            max = number;
        //        }
        //    }
        //    Console.WriteLine($"Largest number: {max}");

        //    // B: list
        //    List<string> names = new List<string>();
        //    names.Add("Ali");
        //    names.Add("Mona");
        //    names.Add("Omar");
        //    names.Remove("Mona");
        //    Console.WriteLine($"Names count: {names.Count}");
        //    foreach (string _name in names)
        //    {
        //        Console.WriteLine(name);
        //    }

        //    // C: dictionary
        //    Dictionary<string, int> ages = new Dictionary<string, int>();
        //    ages["Ali"] = 20;
        //    ages["Mona"] = 22;
        //    foreach (var pair in ages)
        //    {
        //        Console.WriteLine($"{pair.Key} is {pair.Value}");
        //    }
        //    Console.WriteLine($"Mona's age: {ages["Mona"]}");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 9. METHODS
        // EXERCISE : Write a method Greet(string name) that returns nothing
        //             and prints a greeting. Call it.
        // ---------------------------------------------------------------------
        #region Solution 9
        //Console.WriteLine("\n--- 9. Methods ---");
        //{
        //    static void Greet(string name)
        //    {
        //        Console.WriteLine($"Hello, {name}!");
        //    }

        //    Greet("Committee");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 10. CLASSES AND OBJECTS
        // EXERCISE: Create a BankAccount class (it is written at the bottom of
        // this file) with an owner, a balance, a Deposit method and a Withdraw
        // method that refuses to go below zero. Then use it here.
        // ---------------------------------------------------------------------
        #region Solution 10
        //Console.WriteLine("\n--- 10. Classes and objects ---");
        //{
        //    BankAccount account = new BankAccount("Omar", 100m);

        //    account.Deposit(50m);
        //    Console.WriteLine($"After deposit: {account.Balance}");

        //    bool ok = account.Withdraw(500m);
        //    Console.WriteLine($"Withdraw 500 succeeded? {ok}. Balance: {account.Balance}");

        //    ok = account.Withdraw(30m);
        //    Console.WriteLine($"Withdraw 30 succeeded? {ok}. Balance: {account.Balance}");
        //}
        #endregion


        // ---------------------------------------------------------------------
        // 11. EXCEPTION HANDLING
        // EXERCISE A: Convert the text "abc" to a number. Catch the error and
        //             print a friendly message. Add a finally block.
        // EXERCISE B: Divide 10 by zero and catch the specific exception.
        // ---------------------------------------------------------------------
        #region Solution 11
        //Console.WriteLine("\n--- 11. Exception handling ---");
        //{
        //    try
        //    {
        //        int number = int.Parse("abc");
        //        Console.WriteLine(number);
        //    }
        //    catch (FormatException)
        //    {
        //        Console.WriteLine("That is not a valid number.");
        //    }
        //    finally
        //    {
        //        Console.WriteLine("This always runs.");
        //    }

        //    int zero = 0;
        //    try
        //    {
        //        Console.WriteLine(10 / zero);
        //    }
        //    catch (DivideByZeroException)
        //    {
        //        Console.WriteLine("You cannot divide by zero.");
        //    }
        //}
        #endregion

    }
}










