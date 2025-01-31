class RentingService
{
    private Dictionary<Book, int> bookInventory;
    private Dictionary<Book,int> currentlyBorrowed;
    private Dictionary<Book,int> returnBook;

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
        returnBook = new Dictionary<Book, int>{
            { new Book("Martian", "Jim"), 1 },
            { new Book("Foundation", "Jack"), 1 }, 
        };
    }

    public Dictionary<Book, int> ListAllBooks()
    {
        return bookInventory;
    }

    public BorrowReciept? BorrowBook(string bookTitle)
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
            BorrowReciept receipt = new BorrowReciept(bookTitle);
            //Oppdater utlånt listen vår
            currentlyBorrowed[book] = amountBorrowed + 1;
            //Returner kvittering
            return receipt;
        }
    }
    public ReturnReceipt? ReturnBook(string bookTitle)
    {
        Book? book = returnBook
        .Where((entry) => entry.Key.Title == bookTitle)
        .First()
        .Key;


        return null;
    }
}


class Book
{
  public string Title { get; set; }
  public string Author { get; set; }

  public Book(string title, string author)
  {
    Title = title;
    Author = author;
  }
}
class BorrowReciept
{
  public DateTime BorrowingDate { get; set; }
  public DateTime DueDate { get; set; }
  public String BookTitle { get; set; }

  public BorrowReciept(string bookTitle)
  {
    BookTitle = bookTitle;
    BorrowingDate = DateTime.Today;
    DueDate = DateTime.Today.AddDays(30);
  }
}

class ReturnReceipt
{
    public DateTime ReturnDate { get; set; }
    public DateTime DueDate { get; set; }
    public string BookTitle { get; set; }

    public ReturnReceipt(string bookTitle, DateTime dueDate)
    {
        BookTitle = bookTitle;
        DueDate = dueDate;
        ReturnDate = DateTime.Today;
    }
}