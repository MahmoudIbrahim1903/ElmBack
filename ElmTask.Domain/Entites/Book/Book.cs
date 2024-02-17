namespace ElmTask.Domain.Entites.Book
{
    public class Book : BaseEntity
    {
        public BookInfo BookInfo { get; set; }
        public DateTime LastModified { get; set; }
    }
}
