using ElmTask.Common.Dtos;

namespace ElmTask.Application.Services.Books.Dtos
{
    public class BookSearch : SearchCriteria
    {
        public string Keyword { get; set; }
    }
}
