using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeNodeSimple<T> : ITreeNode<T> where T : IElementOfTreeContent
    {

        bool _emptyNode;
        private T _elementOfTreeContent;



        public static ITreeNode<T> CreateEmptyNode()
        {

            return new TreeNodeSimple<T>();
        }


        public TreeNodeSimple()
        {
            this._emptyNode = true;
        }

        public bool AmIleaf() => true;
        public T GetCurrentElement() => _elementOfTreeContent;


        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            var returnedListOfTreeNode = new List<ITreeNode<T>>();
            returnedListOfTreeNode.Clear();
            return returnedListOfTreeNode;
        }

        public ITreeNode<T> GetParent()
        {
            throw new NotImplementedException();
        }

        public bool HaveIparent()
        {
            throw new NotImplementedException();
        }

        public bool HaveIchildren()
        {
            throw new NotImplementedException();
        }
    }
}
