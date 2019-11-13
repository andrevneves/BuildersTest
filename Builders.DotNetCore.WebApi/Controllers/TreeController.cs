using Builders.DotNetCore.Domain.Entities;
using Builders.DotNetCore.Domain.Interfaces;
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
        public TreeController(IBinaryTreeService treeService)
        {
            _treeService = treeService;
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
        public IActionResult Post(int value)
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
