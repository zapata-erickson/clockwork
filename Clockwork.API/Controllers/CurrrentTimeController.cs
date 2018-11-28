using System;
using Clockwork.API.Core;
using Clockwork.API.Core.Repository;
using Microsoft.AspNetCore.Mvc;


namespace Clockwork.API.Controllers
{
    [Route("api/currenttime")]
    public class CurrentTimeController : ControllerBase
    {
        private readonly ICurrentTimeQueryService service;

        public CurrentTimeController(ICurrentTimeQueryService service)
        {
            this.service = service;
        }
        
        // GET api/currenttime
        [HttpGet,Route("")]
        public IActionResult Get()
        {
            try
            {
                var utcTime = DateTime.UtcNow;
                var serverTime = DateTime.Now;
                var ip = this.HttpContext.Connection.RemoteIpAddress.ToString();

                var newQuery = new CurrentTimeQuery
                {
                    UTCTime = utcTime,
                    ClientIp = ip,
                    Time = serverTime
                };

                this.service.Log(newQuery);

                return Ok(newQuery);
            }
            catch 
            {
                throw;
            }
        }

        [HttpGet,Route("list")]
        public IActionResult GetAll()
        {
            try
            {
                var list = this.service.GetAllQueries();
                return Ok(list);
            }
            catch
            {
                throw;
            }
        }
    }
}
