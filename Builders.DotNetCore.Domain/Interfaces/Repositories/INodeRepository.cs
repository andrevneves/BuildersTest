using Builders.DotNetCore.Domain.Entities;
using Builders.DotNetCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.Domain.Interfaces.Repositories
{
    public interface INodeRepository : IRepository<Node, string>
    {
    }
}
