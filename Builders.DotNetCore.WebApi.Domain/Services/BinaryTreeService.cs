using Builders.DotNetCore.WebApi.Domain.Entities;
using Builders.DotNetCore.WebApi.Domain.Interfaces;
using Builders.DotNetCore.WebApi.Domain.Interfaces.Repositories;
using System.Linq;
using System;

namespace Builders.DotNetCore.WebApi.Domain.Services
{
    public class BinaryTreeService : IBinaryTreeService
    {
        INodeRepository _nodeRepository;
        public BinaryTreeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public Node RootNode
        {
            get
            {
                return DbRepository.GetAll().FirstOrDefault();
            }
        }
        public INodeRepository DbRepository { get; set; }

        public int Add(int value)
        {
            var node = AddNodeRecursive(RootNode, value);

            if (RootNode == null)
            {
                DbRepository.Insert(node);
                return value;
            }

            DbRepository.Update(node);

            return value;
        }

        private Node AddNodeRecursive(Node node, int value)
        {
            if (node == null)
            {
                return new Node { Value = value, Id = Guid.NewGuid().ToString() };
            }

            if (value < node.Value)
            {
                node.Left = AddNodeRecursive(node.Left, value);
            }
            else if (value > node.Value)
            {
                node.Right = AddNodeRecursive(node.Right, value);
            }

            return node;
        }

        public Node FindWithValue(int value)
        {
            return FindWithValueRecursive(RootNode, value);
        }

        private Node FindWithValueRecursive(Node current, int value)
        {
            if (current == null)
            {
                return null;
            }

            if (value == current.Value)
            {
                return current;
            }

            if (value < current.Value)
            {
                return FindWithValueRecursive(current.Left, value);
            }
            else
            {
                return FindWithValueRecursive(current.Right, value);
            }
        }

        private int FindSmallestValue(Node root)
        {
            return root.Left == null ? root.Value : FindSmallestValue(root.Left);
        }

        public void Delete(int value)
        {
            if (RootNode == null)
                return;

            var node = DeleteRecursive(RootNode, value);

            DbRepository.Update(node);
        }

        private Node DeleteRecursive(Node node, int value)
        {
            if (node == null)
            {
                return null;
            }

            if (value == node.Value)
            {
                #region node nao tem filhos
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                #endregion

                #region node tem um filho (esquerda ou direita)
                if (node.Right == null)
                {
                    return node.Left;
                }

                if (node.Left == null)
                {
                    return node.Right;
                }
                #endregion

                #region Node tem 2 filhos (esquerda e direita)
                int smallestValue = FindSmallestValue(node.Right);
                node.Value = smallestValue;
                node.Right = DeleteRecursive(node.Right, smallestValue);
                return node;
                #endregion

            }

            if (value < node.Value)
            {
                node.Left = DeleteRecursive(node.Left, value);
                return node;
            }

            node.Right = DeleteRecursive(node.Right, value);

            return node;
        }

    }
}
