using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<T> : ITreeNode<T> where T : IElementOfTreeContent
    {
        private T _lementOfTreeContent;

        private bool _AmIleaf;
        private ITreeNode<T> _parent;
        private IList<ITreeNode<T>> _children;

        private Tree()
        {
            _AmIleaf = true;
        }

        public Tree(T contentElement) : this()
        {
            _lementOfTreeContent = contentElement;
        }

        public Tree(ITreeNode<T> parentNode)
        {

        }


        public Tree(ITreeNode<T> parentNode, IEnumerable<ITreeNode<T>> childen)
        {

        }

        public bool AmIleaf() => _AmIleaf;
        T ITreeNode<T>.GetCurrentElement() => _lementOfTreeContent;


        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> GetParent()
        {
            throw new NotImplementedException();
        }
    }
}
