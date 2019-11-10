using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.WebApi.Domain.Interfaces
{
    public interface IBinaryTreeService
    {
        INodeRepository DbRepository { get; set; }
        Node RootNode { get; }
        int Add(int value);
        Node FindWithValue(int value);
        void Delete(int value);
    }
}
