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
            _children = new List<ITreeNode<T>>();
            _children.Clear();
        }

        public Tree(T contentElement) : this()
        {
            _elementOfTreeContent = contentElement;
        }


        public Tree(ITreeNode<T> treeNode) : this()
        {
            if(treeNode != null && treeNode is Tree<T>)
            {
                Tree<T> newTree = (Tree<T>)treeNode;
                this._elementOfTreeContent = newTree._elementOfTreeContent;
                this._AmIleaf = newTree._AmIleaf;
                this._parent = newTree._parent;
                this._children = newTree._children;
            }else if(treeNode != null && treeNode is TreeNodeSimple<T>)
            {
                TreeNodeSimple<T> newNodeSimple = (TreeNodeSimple<T>)treeNode;
                this._elementOfTreeContent = newNodeSimple.GetCurrentElement();
                this._AmIleaf = true;
                this._parent = newNodeSimple.GetParent();

                var childrenListOfTreeNode = new List<ITreeNode<T>>();
                childrenListOfTreeNode.Clear();

                this._children = childrenListOfTreeNode;
            }

        }


        public Tree(T contentElement, ITreeNode<T> parentNode) : this (contentElement)
        {
            _parent = parentNode;
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
