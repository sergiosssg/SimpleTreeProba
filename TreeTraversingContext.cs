using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeTraversingContext<T> where T : IElementOfTreeContent
    {
        #region Variables
        private bool _is_TreeConsistent;
        private Stack<ITreeNode<T>> _untouchedNodes;
        private Stack<ITreeNode<T>> _touchedNodes;
        private ITree<T> _treeOfNodes;

        #endregion

        #region Constructors
        public TreeTraversingContext()
        {
            this._is_TreeConsistent = false;
            this._untouchedNodes = new Stack<ITreeNode<T>>();
            this._touchedNodes = new Stack<ITreeNode<T>>();
            this._treeOfNodes = null;
        }


        public TreeTraversingContext(ITree<T> treeOfNodes) : this()
        {
            if(treeOfNodes != null)
            {
                this._treeOfNodes = treeOfNodes;
                this._untouchedNodes = new Stack<ITreeNode<T>>(this._treeOfNodes.Count + 1);
                IList<ITreeNode<T>> treeNodes = this._treeOfNodes.AllNodes;
                for (int ii = treeNodes.Count - 1; ii >= 0; ii--)
                {
                    this._untouchedNodes.Push(treeNodes[ii]);
                }
                if (!this._treeOfNodes.ConsistentState)
                {
                    this._treeOfNodes.ConsistentState = true;
                }
                this._is_TreeConsistent = true;
            }
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
            get => this._untouchedNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        public Stack<ITreeNode<T>> TouchedNodes
        {
            get => this._touchedNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        public ITree<T> CurrentTree
        {
            protected set;
            get;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTreeConsistent
        {
            get  
            {
                if(this._treeOfNodes == null)
                {
                    this._is_TreeConsistent = false;
                }
                else
                {
                    this._is_TreeConsistent = this._treeOfNodes.ConsistentState;
                }
                return this._is_TreeConsistent;
            } 
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
