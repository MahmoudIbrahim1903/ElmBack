using AutoMapper;
using ElmTask.Application.Services.Books.Dtos;
using ElmTask.Common.Dtos;
using ElmTask.Domain.Entites.Book;

namespace ElmTask.Application.Services.Books.Mapper
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookInfo, BookResultDto>()
                .ForMember(b => b.PublishDate, opt => opt.MapFrom(dest => dest.PublishDate.Date.ToString("dd-MM-yyyy")));
            CreateMap<QueryResult<BookInfo>, QueryResult<BookResultDto>>();
        }
    }
}
