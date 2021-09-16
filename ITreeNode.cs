using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///  A tree node, abstraction for holding content and with tree nodes consists any tree
/// </summary>


namespace TreeLib
{
    public interface ITreeNode<T> where T : IElementOfTreeContent
    {

        public T Content 
        {
            get;
            set;
        }

        public ITreeNode<T> Parent
        {
            get;
            set;
        }

        public IList<ITreeNode<T>> Children 
        {
            get;
        }

        /// <summary>
        ///   Add node as new child for current node
        /// </summary>
        /// <param name="child"> node to add</param>
        /// <returns>  true if the child was added, false otherwise</returns>
        public bool AddChild(ITreeNode<T> child);


        /// <summary>
        ///  Removes the given node as child this node
        /// </summary>
        /// <param name="child"> child to remove</param>
        /// <returns> true if child was removed, false otherwise</returns>
        public bool RemoveChild(ITreeNode<T> child);

        /// <summary>
        ///  Removes all the children for the node
        /// </summary>
        /// <returns> true if the children were removed, false otherwise</returns>
        public bool RemoveAllChildren();
    }
}
