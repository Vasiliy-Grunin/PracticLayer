using DAL.Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DAL.Entitys.Dto;
using DAL.Entitys.Model;
using DAL.Data;

namespace Library.PAL.Controllers
{
    public class AuthorController : Controller
    {
        public AuthorController(IUnityOfWork unityWork, LibraryDbContext context)
        {
            service = unityWork;
            this.context = context;
        }

        private readonly IUnityOfWork service;
        private readonly LibraryDbContext context;

        /// <summary>
        /// Get all author where name is input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("PeopleDto/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AuthorDto>> GetAuthor(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(@"\d+"))
                return BadRequest("name is null");

            var result = service.Authors.Get(name);
            return result is null
                ? NotFound()
                : Ok();
        }

        [HttpGet("test")]
        public ActionResult<List<AuthorModel>> Test()
        {
            var test = context.Authors.Find(1);
            return Ok(test);
        }

        /// <summary>
        /// Get all autthors
        /// </summary>
        /// <returns></returns>
        [HttpGet("AuthorDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AuthorDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<AuthorDto>> GetAllAuthor()
        {
            var result = service.Authors.Get();
            return result is null
                ? NotFound()
                : Ok();
        }

        /// <summary>
        /// delete author
        /// </summary>
        /// <returns>status</returns>
        [HttpDelete("AuthorDto/NameLastNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthorDto> Delete([FromBody][Bind("LastName,Name,MidleName")] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Authors.Remove(author);
            service.Complete();
            return Ok(author);
        }

        /// <summary>
        /// add new author
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("AuthorDto /LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AuthorDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<AuthorDto> AddAuthor([FromBody][Bind("LastName,Name,MidleName")] AuthorDto author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Authors.Add(author);
            service.Complete();
            return Ok(author);
        }
    }
}
