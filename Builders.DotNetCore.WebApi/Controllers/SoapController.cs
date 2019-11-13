using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Builders.DotNetCore.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Builders.DotNetCore.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SoapController : ControllerBase
    {
        ICorreiosService _correiosService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="correiosService"></param>
        public SoapController(ICorreiosService correiosService)
        {
            _correiosService = correiosService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cep"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("PingServer/{cep}")]
        public bool Get(string cep)
        {
            return _correiosService.PingServer(cep);
        }
    }
}