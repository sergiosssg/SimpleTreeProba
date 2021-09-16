using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<T>  where T : IElementOfTreeContent
    {
        #region Fields
        private ITreeNode<T> _root = null;
        private List<ITreeNode<T>> _nodes = new List<ITreeNode<T>>();
        #endregion

        #region Constructors
        public Tree( T content)
        {

        }
        #endregion

        #region Properties
        public int Count
        {
            get
            {
                return _nodes.Count;
            }
        }

        public ITreeNode<T> Root
        {
            get => this._root;
        }
        #endregion

        #region Methods
        /// <summary>
        ///  Clear all the nodes from the tree
        /// </summary>
        public void Clear()
        {
            // remove all the children from each node
            // so nodes can be garbage collected
            foreach(ITreeNode<T> node in this._nodes)
            {
                node.Parent = null;
                node.RemoveAllChildren();
            }
            // now remove all the nodes from the tree
            // and set root to null
            for ( int i = this._nodes.Count - 1; i >= 0; i--)
            {
                this._nodes.RemoveAt(i);
            }
            this._root = null;
        }

        /// <summary>
        /// Adds the given node to the tree. If the given node is null, the method returns false.
        /// If the parent node is null or isn't in the tree the method returns false.
        /// If the given node is already a child of the parent node the method returns false.
        /// </summary>
        /// <param name="node"> node to add</param>
        /// <returns> true if the node is added, false otherwise</returns>
        public bool AddNode(ITreeNode<T> node)
        {
            if( node == null || node.Parent == null || !this._nodes.Contains(node.Parent))
            {
                return false;
            }
            else if ( node.Parent.Children.Contains(node))
            {
                // node already a child of present
                return false;
            }
            else
            {
                // add child as tree node and as a child to parent
                this._nodes.Add( node);
                return node.Parent.AddChild( node);
            }


        }

        #endregion
    }
}
