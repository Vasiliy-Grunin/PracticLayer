using DAL.Entitys.Dto;
using Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.PAL.Controllers
{
    public class ReaderController : Controller
    {
        public ReaderController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// Get all author where name is input name
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Readers which have a input name</returns>
        [HttpGet("PersonDto/{Name}/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReaderBaseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ReaderBaseDto>> GetPeople(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Contains(@"\d+"))
                return BadRequest("name is null");

            return Ok(service.Readers.Get(name));
        }

        /// <summary>
        /// Get all autthors
        /// </summary>
        /// <returns>All rreaders</returns>
        [HttpGet("PersonDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReaderBaseDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ReaderBaseDto>> GetAllPeople()
        {
            var result = service.Readers.Get();
            return result is null
                ? NotFound()
                : Ok(result);
        }

        /// <summary>
        /// elete reader
        /// </summary>
        /// <returns>reader</returns>
        [HttpDelete("PersonDto/NameLastNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReaderDto> Delete([FromBody][Bind("LastName,Name,MidleName")] ReaderDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Readers.Remove(people);
            service.Complete();
            return Ok(people);
        }

        /// <summary>
        /// Delete reader
        /// </summary>
        /// <returns>reader</returns>
        [HttpDelete("PersonDto/NameLastNameMidleName/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReaderDto> Delete(int id)
        {;
            return service.Readers.Remove(id)
                ? Ok(service.Complete())
                : NotFound(id);
        }

        /// <summary>
        /// Delete a reader's book
        /// </summary>
        /// <returns>reader</returns>
        [HttpDelete("PersonDto/Reader/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<int> DeleteBook([FromBody][Bind("LastName,Name,MidleName,Books")] ReaderDto reader)
        {
            return service.Readers.RemoveBook(reader)
                ? Ok(service.Complete())
                : NotFound(reader);
        }

        /// <summary>
        /// Add new reader
        /// </summary>
        /// <param name="person"></param>
        /// <returns>raeder</returns>
        [HttpPost("PersonDto/LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReaderDto> AddPerson([FromBody][Bind("LastName,Name,MidleName")] ReaderDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Readers.Add(people);
            service.Complete();
            return Ok(people);
        
        }

        /// <summary>
        /// Add book to reader
        /// </summary>
        /// <param name="person"></param>
        /// <returns>raeder</returns>
        [HttpGet("PersonDto/LibraryCard/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ReaderDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<ReaderDto>> GetLibraryCard()
        {
            var result = service.Readers.GetLibraryCard();
            return result is null
                ? NotFound()
                : Ok(result);
        }

        /// <summary>
        /// Update reader
        /// </summary>
        /// <param name="person"></param>
        /// <returns>raeder</returns>
        [HttpPut("PersonDto/LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReaderDto> UpdatePerson([FromBody][Bind("LastName,Name,MidleName")] ReaderDto people)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Readers.Update(people);
            service.Complete();
            return Ok(people);
        }

        /// <summary>
        /// Update reader
        /// </summary>
        /// <param name="person"></param>
        /// <returns>raeder</returns>
        [HttpPut("PersonDto/LastNameNameMidleName/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ReaderDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReaderDto> UpdeteBook([FromBody][Bind("LastName,Name,MidleName")] ReaderDto reader)
        {
            return service.Readers.RemoveBook(reader)
                ? Ok(reader)
                : NotFound(reader);
        }
    }
}
