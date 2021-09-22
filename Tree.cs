using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<T> : ITree<T> where T : IElementOfTreeContent
    {
        #region Fields
        private bool _consistentState;
        private ITreeNode<T> _root = null;
        private List<ITreeNode<T>> _nodes = new List<ITreeNode<T>>();
        #endregion

        #region Constructors
        public Tree( T content)
        {
            this._consistentState = true;
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

        public bool ConsistentState
        {
            get  => this._consistentState;
            set
            {
                this._consistentState = value;
            }
        }

        /// <summary>
        ///    Gets  all  nodes  of  that tree, despite where and when they added
        /// </summary>
        public IList<ITreeNode<T>> AllNodes
        {
            get
            {
                if (_consistentState)
                {
                    return _nodes.AsReadOnly();
                }
                return null;
            }
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
            this._consistentState = false;
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
                this._consistentState = false;
                return node.Parent.AddChild( node);
            }


        }

        /// <summary>
        ///    Rempves the given node from the tree
        ///  If the node isn't found in the tree, the method returns false.
        ///  Note that the subtree with the node to remove as its root is pruned
        ///  from tree.
        /// </summary>
        /// <param name="removedNode"> node to remove</param>
        /// <returns> true if successful, false otherwise</returns>
        public bool RemoveNode(ITreeNode<T> removedNode)
        {
            if(removedNode == null)
            {
                return false;
            }
            else if(removedNode == this._root)
            {
                // removing the root, clears the tree
                this.Clear();
                return true;
            }
            else
            {
                // remove as child of parent
                bool successReturned = removedNode.Parent.RemoveChild(removedNode);
                if(!successReturned)
                {
                    return false;
                }
                // remove node from tree
                successReturned = this._nodes.Remove(removedNode);
                if (!successReturned)
                {
                    return false;
                }
                // check for branch node
                if(removedNode.Children.Count > 0)
                {
                    // recursively prune subtree
                    IList<ITreeNode<T>> children = removedNode.Children;
                    for (int i = children.Count - 1; i >= 0; i--)
                    {
                        this.RemoveNode(children[i]);
                    }
                }
                this._consistentState = false;
                return true;
            }
        }

        #endregion
    }
}
