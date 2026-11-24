using Session1.Models;

namespace Session1
{
    public class Program
    {
        public static void Main()
        {
            // TODO 4: Instantiate b1 with 'new', set Title, Price, and Stock
            Book b1 = new Book();
            b1.Title = "Youtobia";
            b1.Price = 200.00m;
            b1.Stock = 12;

            // TODO 5: Assign b2 = b1 and modify b2.Stock; then call b1.PrintSummary()
            Book b2 = b1;
            b2.Stock = 14;
            b1.PrintSummary();

            // TODO 6: Declare Book? missingBook = null; test ?.PrintSummary() and ?? fallback
            Book? missingBook = null;
            missingBook?.PrintSummary();
            Console.WriteLine(missingBook?.Title ?? "No Book Selected");

            // TODO 7: Create one more Book instance and print Book.TotalBooksCreated
            Book b3 = new Book();
            Console.WriteLine($"TotalBooksCreated: {Book.TotalBooksCreated}");
        }
    }
}