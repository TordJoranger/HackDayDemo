using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using DevTest.Models;
using DevTest.Services;

namespace DevTest.Controllers
{
    [Route("/")]
    [ApiController]
    public class ExcecutionsController : ControllerBase
    {
        private readonly IExcecutionService _service;

        public ExcecutionsController(IExcecutionService service)
        {
            _service = service;
        }

        //[HttpGet]
        //public ActionResult<List<Excecution>> Get()
        //{
        //    return _service.GetExcecutions().ToList();
        //}


        [HttpPost]
        [Route("enter-path")]
        public ActionResult<Excecution> EnterPath([FromBody]Path path)
        {
            if (path == null)
            {
                return BadRequest();
            }
            return _service.CreateExcecution(path);
        }
    }
}