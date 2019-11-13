using Builders.DotNetCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Builders.DotNetCore.Domain.Interfaces
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
