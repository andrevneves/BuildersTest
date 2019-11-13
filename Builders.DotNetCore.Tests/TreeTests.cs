using Builders.DotNetCore.Domain.Interfaces;
using Builders.DotNetCore.Domain.Interfaces.Repositories;
using Builders.DotNetCore.Domain.Services;
using Builders.DotNetCore.Infrastructure.Implementation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Builders.DotNetCore.Tests
{
    [TestClass]
    public class TreeTests
    {
        readonly string server;
        readonly string databaseName;
        readonly string collectionName;
        INodeRepository nodeRepository;
        IBinaryTreeService binaryTree;

        public TreeTests()
        {
            server = "mongodb://localhost";
            databaseName = "Builders_Andre_Test";
            collectionName = "Nodes";

            nodeRepository = new NodeRepository(server, databaseName, collectionName);
            binaryTree = new BinaryTreeService(nodeRepository);
        }
                
        [TestMethod]
        [Priority(0)]
        public void AddOne()
        {
            int value = 2;
            binaryTree.Reset();
            binaryTree.Add(value);
            Assert.IsTrue(binaryTree.RootNode.Value == value);
        }

        [TestMethod]
        [Priority(1)]
        public void FindWithValue()
        {
            int value = 2;
            var node = binaryTree.FindWithValue(value);

            Assert.IsTrue(node != null && node.Value == value);
        }
        
        [TestMethod]
        [Priority(2)]
        public void AddMany()
        {
            binaryTree.Reset();
            var values = new int[] { 9, 2, 3, 5, 8, 7, 1, 4 };

            binaryTree.AddMany(values);

            Assert.IsTrue(
                binaryTree.RootNode.Value == 9 &&
                binaryTree.RootNode.Left.Value == 2 &&
                binaryTree.RootNode.Left.Right.Value == 3 &&
                binaryTree.RootNode.Left.Left.Value == 1 &&
                binaryTree.RootNode.Left.Right.Right.Value == 5 &&
                binaryTree.RootNode.Left.Right.Right.Left.Value == 4 &&
                binaryTree.RootNode.Left.Right.Right.Right.Value == 8 &&
                binaryTree.RootNode.Left.Right.Right.Right.Left.Value == 7); ;
        }
    }
}
