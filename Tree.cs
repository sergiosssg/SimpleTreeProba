using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<T> : ITreeNode<T> where T : IElementOfTreeContent
    {
        private ITreeNode<T> _parent;
        private IList<ITreeNode<T>> _children;

        public Tree()
        {

        }

        public Tree(T contentElement)
        {

        }

        public Tree(ITreeNode<T> parentNode)
        {

        }


        public Tree(ITreeNode<T> parentNode, IEnumerable<ITreeNode<T>> childen)
        {

        }

        public bool AmIleaf()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> GetParent()
        {
            throw new NotImplementedException();
        }

        T ITreeNode<T>.GetCurrentElement()
        {
            throw new NotImplementedException();
        }
    }
}
