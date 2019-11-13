using Builders.DotNetCore.WebApi.Domain.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Builders.DotNetCore.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        /// <summary>
        /// Verifica se uma determinada palavra é um palindromo.
        /// </summary>
        /// <param name="palavra">A palavra a ser testada.</param>
        /// <returns></returns>
        //[HttpGet("{palavra}", Name = "isPalindrome")]
        [HttpGet]
        [Route("isPalindrome/{palavra}")]
        public bool Get(string palavra)
        {
            return Text.IsPalindrome(palavra);
        }
    }
}