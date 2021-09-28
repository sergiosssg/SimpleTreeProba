using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeTraversingContext<T> where T : IElementOfTreeContent
    {
        #region Private Variables
        private bool _is_TreeConsistent;
        readonly private IList<ITreeNode<T>> _untouchedNodes;
        readonly private Stack<ITreeNode<T>> _touchedNodes;
        private ITree<T> _treeOfNodes;
        private ITreeNode<T> _currentTreeNode;
        #endregion
        #region Protected Variables
        protected PredicateComparingTreeNodeAndSample<T> _predicateComparingTreeNodeAndSample;
        protected ComposerOfCandidatesForTreeTraversor<T> _composerOfCandidatesForTreeTraversor;
        protected int _orderInWidth;
        protected int _levelInDepth;
        #endregion



        #region Constructors
        public TreeTraversingContext()
        {
            this._orderInWidth = this._levelInDepth = 0;
            this.BacktrackingToggle = false;
            this._is_TreeConsistent = false;
            this._untouchedNodes = new List<ITreeNode<T>>();
            this._touchedNodes = new Stack<ITreeNode<T>>();
            this._treeOfNodes = null;
            this._currentTreeNode = null;

            this._composerOfCandidatesForTreeTraversor = DefaultComposerOfCandidates;
            this._predicateComparingTreeNodeAndSample = DefaultPredicateComparing;
        }


        public TreeTraversingContext(ITree<T> treeOfNodes)
        {
            this._orderInWidth = this._levelInDepth = 0;
            this.BacktrackingToggle = false;
            this._touchedNodes = new Stack<ITreeNode<T>>();


            this._composerOfCandidatesForTreeTraversor = DefaultComposerOfCandidates;
            this._predicateComparingTreeNodeAndSample = DefaultPredicateComparing;

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
            get => this._orderInWidth > 0 ;
        }

        /// <summary>
        /// 
        /// </summary>
        public int OrderInWidth
        {
            get => this._orderInWidth;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsLevelInDepthDefined
        {
            get => this._levelInDepth > 0 ;
        }

        /// <summary>
        /// 
        /// </summary>
        public  int LevelInDepth
        {
            get => this._levelInDepth;
        }


        /// <summary>
        /// 
        /// </summary>
        public ComposerOfCandidatesForTreeTraversor<T> ComposerOfCandidatesForTreeTraversorProperty
        {
            set
            {
                this._composerOfCandidatesForTreeTraversor = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public PredicateComparingTreeNodeAndSample<T> PredicateComparingTreeNodeAndSampleProperty
        {
            set
            {
                this._predicateComparingTreeNodeAndSample = value;
            }
        }

        #endregion


        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prevTreeNode"></param>
        /// <returns></returns>
        public ResultOfSearchInTree<T> FindNext(ITreeNode<T> currTreeNode, GoalOfSearchInTree<T> goalOfSearch)
        {
            ResultOfSearchInTree<T> result;
            if (this.IsTreeConsistent)
            {

            }

            return new ResultOfSearchInTree<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ResetContext()
        {
            this._orderInWidth = this._levelInDepth = 0;
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
            this._levelInDepth = 0;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool ResetOrderInWidth()
        {
            this._orderInWidth = 0;
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
            if (treeOfNodes != null && treeOfNodes.Count > 0)
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
        
        /// <summary>
        ///   Checks out whether or not current node of tree has upper node
        /// </summary>
        ///   true if the node has upper node, false otherwise
        /// <returns></returns>
        protected bool HasParent()
        {
            if (this.IsTreeConsistent && this._currentTreeNode != _treeOfNodes.Root)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        ///  Checks out whether or not current node of tree has children
        /// </summary>
        ///   true if the node has children nodes, false otherwise
        /// <returns></returns>
        protected bool HasChildren()
        {
            if (this.IsTreeConsistent && this._currentTreeNode.Children.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="treeNodeWhereSearching"></param>
        /// <param name="typeOfTraversingStrategyOfTree"></param>
        /// <returns></returns>
        protected  IEnumerable<ITreeNode<T>> DefaultComposerOfCandidates<T>(
                   in ITree<T> tree,
                   in ITreeNode<T> treeNodeWhereSearching,
                   TypeOfTraversingStrategy typeOfTraversingStrategyOfTree) where T : IElementOfTreeContent
        {
            return null;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tree"></param>
        /// <param name="treeNodeForComparing"></param>
        /// <param name="goalOfSearch"></param>
        /// <returns></returns>
        protected bool DefaultPredicateComparing<T>(
                       in ITree<T> tree,
                       in ITreeNode<T> treeNodeForComparing,
                       GoalOfSearchInTree<T> goalOfSearch) where T : IElementOfTreeContent
        {
            return false;
        }


        #endregion


    }
}
