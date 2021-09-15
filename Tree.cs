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
        #endregion

    }
}
