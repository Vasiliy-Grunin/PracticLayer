using DAL.Entitys.Dto;
using Service.UnityOfwork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.PAL.Controllers
{
    public class GenryController : Controller
    {
        public GenryController(IUnityOfWork context)
        {
            service = context;
        }

        private readonly IUnityOfWork service;

        /// <summary>
        /// Get all genry
        /// </summary>
        /// <returns>List uniqlo genry</returns>
        [HttpGet("GenryBaseDto/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GenryBaseDto>> GetGenrys()
        {
            var result = service.BaseGenrys.Get();
            return result is null
                ? NotFound()
                : Ok(result);
        }

        /// <summary>
        /// Get all genry include book
        /// </summary>
        /// <returns>List uniqlo genry</returns>
        [HttpGet("GenryDto/")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<List<GenryDto>> GetGenry()
        {
            var result = service.Genrys.Get();
            return result is null
                ? NotFound()
                : Ok(result);
        }

        /// <summary>
        /// Get statistic
        /// </summary>
        /// <returns></returns>
        [HttpGet("GenryDto/Statistic")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Dictionary<string, int>> GetStatistics()
        {
            var result = service.Genrys.GetStatistic();
            return result is null
                ? NotFound()
                : Ok(result);
        }

        /// <summary>
        /// Create the genry
        /// </summary>
        /// <returns>status</returns>
        [HttpPost("GenryDto/")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<GenryDto> Add(GenryDto genry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Genrys.Add(genry);
            service.Complete();
            return Ok(genry);
        }
    }
}
