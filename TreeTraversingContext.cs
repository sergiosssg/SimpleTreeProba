using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeTraversingContext<T> where T : IElementOfTreeContent
    {
        #region Variables
        private Stack<ITreeNode<T>> _untouchedNodes;
        private Stack<ITreeNode<T>> _touchedNodes;

        #endregion

        #region Constructors
        public TreeTraversingContext()
        {
            _untouchedNodes = new Stack<ITreeNode<T>>();
            _touchedNodes = new Stack<ITreeNode<T>>();
        }


        #endregion


        #region Properties
        /// <summary>
        /// Backtracking Toggle Switch
        ///  When is true,
        ///  Should accomplish backtracking movement so double goaround every node in tree
        ///  and to have use Untouched nodes
        /// </summary>
        public bool BacktrackingToggle
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Stack<ITreeNode<T>> UntouchedNodes
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public Stack<ITreeNode<T>> TouchedNodes
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public ITree<T> CurrentTree
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTreeConsistent
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public ITreeNode<T> CurrentTreeNode
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOrderInWidthDefined
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public int OrderInWidth
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLevelInDepthDefined
        {
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public  int LevelInDepth
        {
            get;
        }
        #endregion


        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ResetContext()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ResetLevelInDepth()
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ResetOrderInWidth()
        {
            return true;
        }
        #endregion
    }
}
