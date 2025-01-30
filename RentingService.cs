class RentingService
{
    private Dictionary<Book, int> bookInventory;
    private Dictionary<Book, int> currentlyBorrowed;

    public RentingService()
    {
        bookInventory = new Dictionary<Book, int>{ 
            { new Book("Martian", "Jim"), 2 },
            { new Book("Foundation", "Jack"), 30 },
        };
        currentlyBorrowed = new Dictionary<Book, int>{
            { new Book("Martian", "Jim"), 2 },
            { new Book("Foundation", "Jack"), 30 },
        };
        
    }

    public Dictionary<Book, int> ListAllBooks()
    {
        return bookInventory;
    }

    public BorrowReceipt? BorrowBook(string bookTitle)
    {
        // Vi må finne om vi har boken
       Book? book = bookInventory
       .Where((entry) => entry.Key.Title == bookTitle) // Finne elementet som har samme title
       .First() // Ta først elementet
       .Key; // Tar boken, ignorer antall

        // Hvis vi ikke har boken registrert return ingenting
       if (book == null) {
        return null;
       }
        // Vi må finne ut om vi har minst en bok tigjengelig
        currentlyBorrowed.TryGetValue(book, out int amountBorrowed);
        bookInventory.TryGetValue(book, out int amountInInventory);
        bool isAvailable = amountInInventory - amountBorrowed > 0;

        if (!isAvailable) 
        {
            // Vi har ikke eksempler tilgjengelig
            return null;
        }
        else
        {
            // Lage ein ny kvittering
            BorrowReceipt receipt = new BorrowReceipt(bookTitle);
            //Oppdater utlånt listen vår
            currentlyBorrowed[book] = amountBorrowed + 1;
            //Returner kvittering
            return receipt;
        }
    }
}

class Book
{   
    public string Title;
    public string Author;

    public Book(string title, string author)
    {

        Title = title;
        Author = author;
    }
}

class BorrowReceipt
{
    public DateTime BorrowedDate;
    public DateTime ReturnDate;
    public string BookTitle;

    public BorrowReceipt(string bookTitle)
    {
        BookTitle = bookTitle;
        BorrowedDate = DateTime.Now;
        ReturnDate = new DateTime().AddMonths(1);
    }
}

class ReturnReceipt
{

}