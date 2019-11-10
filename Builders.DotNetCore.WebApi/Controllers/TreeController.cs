using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Builders.DotNetCore.WebApi.Controllers
{
    /// <summary>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TreeController : ControllerBase
    {
        readonly IBinaryTreeService _treeService;

        /// <summary>
        /// </summary>
        /// <param name="treeService"></param>
        /// <param name="nodeRepository"></param>
        public TreeController(IBinaryTreeService treeService, INodeRepository nodeRepository)
        {
            _treeService = treeService;
            _treeService.DbRepository = nodeRepository;

        }
        /// <returns></returns>
        [HttpGet]
        public Node Get()
        {
            return _treeService.RootNode ?? new Node();
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public Node Get(int id)
        {
            return _treeService.FindWithValue(id);
        }

        /// <summary>
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        public IActionResult Post([FromBody] int value)
        {
            _treeService.Add(value);
            return CreatedAtAction("Post", _treeService.FindWithValue(value));
        }

        /// <summary>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_treeService.FindWithValue(id) == null)
            {
                return NotFound();
            }

            _treeService.Delete(id);

            return NoContent();
        }
    }
}
