namespace Session2HandsOn.Models
{
    public class Book
    {
        #region Step 1: Properties — Instance + Static
        public static int TotalBooksCreated { get; private set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        #endregion

        #region Step 2: Constructor — Increment TotalBooksCreated
        public Book()
        {
            TotalBooksCreated++;
        }
        #endregion

        #region Step 3: PrintSummary() — Format Price with :F2
        public void PrintSummary()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Price: ${Price:F2}");
            Console.WriteLine($"Stock: {Stock}");
        }
        #endregion
    }
}