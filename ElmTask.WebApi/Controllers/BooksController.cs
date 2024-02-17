using ElmTask.Application.Services.Books.Dtos;
using ElmTask.Application.Services.Books.Interfaces;
using ElmTask.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ElmTask.WebApi.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpPost]
        public async Task<IActionResult> GetAll([FromBody] BookSearch search) 
        {
            return Ok(await _bookService.GetAll(search));
        }
    }
}
