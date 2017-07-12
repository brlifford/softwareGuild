using DvdLibrary.Data.Factories;
using DvdLibrary.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DvdLibrary.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdAPIController : ApiController
    {
        
        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetById(int dvdId)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetById(dvdId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll()
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByTitle(string title)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByTitle(title);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/year/{date}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByReleaseDate(DateTime date)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByReleaseDate(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/director/{directorName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByDirector(string directorName)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByDirector(directorName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("dvds/rating/{ratingName}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetByRating(string ratingName)
        {
            var repo = DvdRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByRating(ratingName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[Route("api/dvd")]
        //[AcceptVerbs("POST")]
        //public IHttpActionResult AddDvd(string title, DateTime date, string directorName, string ratingName, string dvdNotes)
        //{
        //    var repo = DvdRepositoryFactory.GetRepository();

        //    //try
        //    //{
        //    //    //var result = repo.Insert(title, date, directorName, ratingName, dvdNotes);
        //    //    return Ok(result);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    return BadRequest(ex.Message);
        //    //}
        //}
    }
}
