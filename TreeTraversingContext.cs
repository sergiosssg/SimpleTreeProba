using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeTraversingContext<T> where T : IElementOfTreeContent
    {
        #region Variables
        
        private bool _is_TreeConsistent;
        readonly private IList<ITreeNode<T>> _untouchedNodes;
        readonly private Stack<ITreeNode<T>> _touchedNodes;
        private ITree<T> _treeOfNodes;
        private ITreeNode<T> _currentTreeNode;

        #endregion

        #region Constructors
        public TreeTraversingContext()
        {
            this.BacktrackingToggle = false;
            this.IsOrderInWidthDefined = false;
            this.IsLevelInDepthDefined = false;
            this._is_TreeConsistent = false;
            this._untouchedNodes = new List<ITreeNode<T>>();
            this._touchedNodes = new Stack<ITreeNode<T>>();
            this._treeOfNodes = null;
            this._currentTreeNode = null;
        }


        public TreeTraversingContext(ITree<T> treeOfNodes)
        {
            this.BacktrackingToggle = this.IsOrderInWidthDefined  = this.IsLevelInDepthDefined  =  false;

            this._touchedNodes = new Stack<ITreeNode<T>>();

            if (treeOfNodes != null)
            {
                this._treeOfNodes = treeOfNodes;
                this._untouchedNodes = new List<ITreeNode<T>>(this._treeOfNodes.Count + 1);
                this.InitUntouchedNodes(treeOfNodes);
                this._currentTreeNode = this._treeOfNodes.Root;

            }
            else
            {
                this._untouchedNodes = new List<ITreeNode<T>>();
                this._is_TreeConsistent = false;
                this._currentTreeNode = null;
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
        public IList<ITreeNode<T>> UntouchedNodes
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
            protected set 
            { 
                if (value != null)
                {
                    this.InitUntouchedNodes( value);

                    this._treeOfNodes.ConsistentState = true;

                    this._is_TreeConsistent = true;
                }
            }
            get => this._treeOfNodes;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsTreeConsistent
        {
            get  
            {
                if(this._treeOfNodes == null || this._untouchedNodes == null || this._touchedNodes == null)
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
            get => this._currentTreeNode;
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
            this._touchedNodes.Clear();
            if (this._treeOfNodes != null && this._untouchedNodes != null && this._touchedNodes != null)
            {
                this.InitUntouchedNodes(this._treeOfNodes);
                //this._currentTreeNode = this._treeOfNodes.Root;
                return (this._is_TreeConsistent = this._treeOfNodes.ConsistentState = true);

            }
            return (this._is_TreeConsistent = false);
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


        #region Protected Methods
        /// <summary>
        ///  Initialize untouched Nodes of tree list
        /// </summary>
        /// <param name="treeOfNodes"> tree of nedes, need to traverse through </param>
        /// <param name="untouchedTreeNodes"> list of tree nodes, which we initialize</param>
        protected void InitUntouchedNodes(ITree<T> treeOfNodes)
        {
            if (treeOfNodes != null)
            {
                this._treeOfNodes = treeOfNodes;
                this._untouchedNodes.Clear();
                foreach (var oneTreeNode in this._treeOfNodes.AllNodes)
                {
                    this._untouchedNodes.Add(oneTreeNode);
                }
                if (!this._treeOfNodes.ConsistentState)
                {
                    this._treeOfNodes.ConsistentState = true;
                }
                this._currentTreeNode = this._treeOfNodes.Root;
                this._is_TreeConsistent = true;
            }
        }

        #endregion


    }
}
