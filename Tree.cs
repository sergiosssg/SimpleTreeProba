using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<T> : ITreeNode<T> where T : IElementOfTreeContent
    {
        private T _elementOfTreeContent;

        private bool _AmIleaf;
        private ITreeNode<T> _parent;
        private IList<ITreeNode<T>> _children;

        private Tree()
        {
            _AmIleaf = true;
        }

        public Tree(T contentElement) : this()
        {
            _elementOfTreeContent = contentElement;
        }

        public Tree(T contentElement, ITreeNode<T> parentNode)
        {

        }


        public Tree(T contentElement, ITreeNode<T> parentNode, IEnumerable<ITreeNode<T>> childen)
        {

        }

        public bool AmIleaf() => _AmIleaf;
        T ITreeNode<T>.GetCurrentElement() => _elementOfTreeContent;


        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            throw new NotImplementedException();
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
