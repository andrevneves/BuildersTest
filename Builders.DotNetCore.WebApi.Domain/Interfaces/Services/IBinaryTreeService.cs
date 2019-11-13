using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.WebApi.Domain.Interfaces
{
    public interface IBinaryTreeService
    {
        Node RootNode { get; }
        int Add(int value);
        int[] AddMany(int[] values);
        Node FindWithValue(int value);
        void Delete(int value);
        void Reset();
    }
}
