using Builders.DotNetCore.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories
{
    public interface INodeRepository : IRepository<Node, string>
    {
    }
}
