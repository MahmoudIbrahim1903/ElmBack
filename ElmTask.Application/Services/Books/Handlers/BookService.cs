using ElmTask.Common.Dtos;
using ElmTask.Common.Extentions;
using ElmTask.Application.Common.Dtos;
using ElmTask.Application.Common.Interfaces;
using ElmTask.Application.Services.Books.Interfaces;
using AutoMapper;
using ElmTask.Application.Services.Books.Dtos;
using LinqKit;
using ElmTask.Domain.Entites.Book;
using System.Data.Entity;
using ElmTask.Application.Services.Caching.Interfaces;
using ElmTask.Application.Services.Caching.Dtos;

namespace ElmTask.Application.Services.Books.Handlers
{
    public class BookService : IBookService
    {
        private readonly IElmDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        private readonly string _booksCacheKey = "CachedBooks";

        public BookService(IElmDbContext dbContext, IMapper mapper, ICacheService cacheService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _cacheService = cacheService;
        }

        public async Task<BaseResponse<QueryResult<BookResultDto>>> GetAll(BookSearch search)
         {
            var cachedBooks = _cacheService.GetItemsFromCache<CacheDto<Book>>(_booksCacheKey);

            if (cachedBooks == null || cachedBooks.Entities.Count == 0 || cachedBooks.ExripyDate < DateTime.Now)
            {
                cachedBooks  = CacheBooks();
            }

            var predicate = PredicateBuilder.New<Book>(b => true);

            if (!string.IsNullOrEmpty(search?.Keyword))
            {
                predicate = predicate.And(b => false);

                predicate = predicate.Or(b => b.BookInfo.BookTitle.ToLower().Contains(search.Keyword.ToLower()));

                predicate.Or(b => b.BookInfo.BookDescription.ToLower().Contains(search.Keyword.ToLower()));

                predicate.Or(b => b.BookInfo.Author.ToLower().Contains(search.Keyword.ToLower()));

                if (DateTime.TryParse(search.Keyword, out DateTime searchByDateResult))
                    predicate.Or(b => b.BookInfo.PublishDate.Date == searchByDateResult.Date);
            }



            var result = cachedBooks.Entities
                .Where(predicate)
                .Select(x => x.BookInfo)
                .ToQueryResult(search.PageNumber, search.PageSize);

            return new BaseResponse<QueryResult<BookResultDto>>
            {
                Data = _mapper.Map<QueryResult<BookResultDto>>(result)
            };
        }

        private CacheDto<Book> CacheBooks()
        {
            var dbBooks = _dbContext.Books.ToList();
            var booksCacheDto = new CacheDto<Book>
            {
                Entities = dbBooks,
                ExripyDate = DateTime.Now.AddHours(1)
            };
            _cacheService.SaveItemsToCache(_booksCacheKey, booksCacheDto);
            return booksCacheDto;
        }
    }
}
