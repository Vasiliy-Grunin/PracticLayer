using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using DAL.Service.UnityOfwork;
using DAL.Entitys.Dto;

namespace Library.PAL.Controllers
{
    public class BookController : Controller
    {
        public BookController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// create new list book according to the specified criterion
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet("book/{title}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookDto>> GetBooks(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                return BadRequest("Title is null or whiteSpace");

            var result = service.Books.Get(title);
            return result is null
                ? NotFound()
                : Ok();
        }

        /// <summary>
        /// create list books
        /// </summary>
        /// <returns>all book</returns>
        [HttpGet("book/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<BookDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<BookDto>> GetBooks()
        {
            var result = service.Books.Get();
            return result is null
                ? NotFound()
                : Ok();
        }

        /// <summary>
        /// create new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("book/AuthorNameDirection/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult CreateBook([FromBody][Bind("Author,Name,Direction")] BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Books.Add(book);
            service.Complete();
            return Ok();

        }

        /// <summary>
        /// delete book on this name and author.
        /// </summary>
        [HttpDelete("book/NameAuthor/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BookDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete([FromBody][Bind("Author,Name,Direction")] BookDto book)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Books.Remove(book);
            return Ok(service.Complete());
        }
    }
}
