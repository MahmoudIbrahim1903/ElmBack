using ElmTask.Common.Dtos;
using ElmTask.Application.Common.Dtos;
using ElmTask.Application.Services.Books.Dtos;

namespace ElmTask.Application.Services.Books.Interfaces
{
    public interface IBookService
    {
        public Task<BaseResponse<QueryResult<BookResultDto>>> GetAll(BookSearch search);
    }
}
