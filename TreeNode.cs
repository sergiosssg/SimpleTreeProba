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
        /// <summary>
        /// 
        /// </summary>
        public ITreeNode<T> Parent 
        { 
            get => this._parent; 
            set => this._parent = (TreeNode<T>)value; 
        }
        /// <summary>
        /// 
        /// </summary>
        public IList<ITreeNode<T>> Children => 
            this._childern.AsReadOnly();
        #endregion

        #region Methods
        /// <param name="child"> childe to be added for current node</param>
        /// <returns>  true if the child was added, false otherwise</returns>
        public bool AddChild(ITreeNode<T> child)
        {
            // don't add duplicate children
            if(this._childern.Contains(child))
            {
                return false;
            }
            else if (child == this)
            {
                return false;
            }
            else
            {
                this._childern.Add(child);
                child.Parent = this;
                return true;
            }
        }

        /// <returns> true if the all children are removed, false otherwise </returns>
        public bool RemoveAllChildren()
        {
            for(int i= this._childern.Count - 1; i>= 0; i--)
            {
                this._childern[i].Parent = null;
                this._childern.RemoveAt(i);
            }
            return true;
        }

        /// <summary>
        /// Removes the given node as a child of this node
        /// </summary>
        /// <param name="child"> child to remove</param>
        /// <returns> true if the child was removed, false otherwise</returns>
        public bool RemoveChild(ITreeNode<T> child)
        {
            // only remove child in list
            if (this._childern.Contains(child))
            {
                child.Parent = null;
                return this._childern.Remove(child);
            }
            else
            {
                return false;
            }

        }
        #endregion
    }
}
