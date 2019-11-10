using AutoMapper;
using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using Builders.DotNetCore.WebApi.Domain.Services;
using Builders.DotNetCore.WebApi.Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Builders.DotNetCore.WebApi.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void InsertMany()
        {

            INodeRepository nodeRepository = new NodeRepository();
            IBinaryTreeService binaryTree = new BinaryTreeService(nodeRepository);

            binaryTree.Add(1);
            binaryTree.Add(2);
            binaryTree.Add(3);
            binaryTree.Add(8);
            binaryTree.Add(5);
            binaryTree.Add(7);
            binaryTree.Add(9);

            var node2 = binaryTree.FindWithValue(2);

            NodeRepository repository = new NodeRepository();
            Node model = binaryTree.RootNode;
            string id = repository.Insert(model);

            model.Id = id;
            model.Value = 99;

            repository.Update(model);

            Assert.IsTrue(binaryTree != null &&
                          node2.Value.Equals(2) &&
                          node2.Left.Value.Equals(1) &&
                          node2.Right.Equals(3));
        }
    }
}
