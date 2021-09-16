using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    ///    Tree is made of such nodes
    ///    
    /// </summary>
    /// <typeparam name="T">  content of node, every class have implement  IElementOfTreeContent  interface </typeparam>
    class TreeNode<T> : ITreeNode<T> where T : IElementOfTreeContent
    {
        #region Fields
        private ITreeNode<T> _parent;
        private T _contentValue;
        private List<ITreeNode<T>> _childern;
        #endregion

        #region Constructors

        /// <summary>
        ///     One constructor, it is enough
        /// </summary>
        /// <param name="  the main content in current node"></param>
        /// <param name="parent"> parent for current node</param>
        public TreeNode(T contentValue, ITreeNode<T> parent)
        {
            this._contentValue = contentValue;
            this._parent = parent;
        }
        #endregion

        #region Properties
        public T Content 
        { 
            get => this._contentValue; 
            set => this._contentValue = value; 
        }
        
        public ITreeNode<T> Parent 
        { 
            get => this._parent; 
            set => this._parent = (TreeNode<T>)value; 
        }

        public IEnumerable<ITreeNode<T>> Children => 
            _childern.AsReadOnly();
        #endregion

        #region Methods
        /// <param name="child"> childe to be added for current node</param>
        /// <returns>  true if the child was added, false otherwise</returns>
        public bool AddChild(ITreeNode<T> child)
        {
            throw new NotImplementedException();
        }

        /// <returns> true if the all children are removed, false otherwise </returns>
        public bool RemoveAllChildren()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the given node as a child of this node
        /// </summary>
        /// <param name="child"> child to remove</param>
        /// <returns> true if the child was removed, false otherwise</returns>
        public bool RemoveChild(ITreeNode<T> child)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
