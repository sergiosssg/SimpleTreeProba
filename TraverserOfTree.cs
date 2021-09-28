using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TraverserOfTree<I> : ITraverser<I> where I : IElementOfTreeContent
    {

        #region Fields
        private TypeOfTraversingStrategy _typeOfTraversingStrategyOfTree;

        private bool _isConstintentState;

        private PredicateComparingTreeNodeAndSample<I> _predicateComparingTreeNodeAndSmplee;
        private ITree<I> _tree;

        protected Stack<ITreeNode<I>> _treeNodesUntouched;
        protected Stack<ITreeNode<I>> _treeNodesTouched;


        private ComposerOfCandidatesForTreeTraversor<I> _delegateComposerOfCandidatesForTreeTraversor;
        #endregion


        #region Constructors
        public TraverserOfTree()
        {
            this._treeNodesUntouched = new Stack<ITreeNode<I>>();
            this._treeNodesTouched = new Stack<ITreeNode<I>>();
            this._typeOfTraversingStrategyOfTree = TypeOfTraversingStrategy.DEPTH_FIRST;
            this._isConstintentState = true;
        }

        public TraverserOfTree(ITree<I> tree) : this()
        {
            this._tree = tree;
            Stack<ITreeNode<I>> treeNodesUntouched;
            if(this.PopulateStackFromTree(in tree, out treeNodesUntouched))
            {
                this._treeNodesUntouched = treeNodesUntouched;
            }
        }


        public TraverserOfTree(ITree<I> tree, PredicateComparingTreeNodeAndSample<I> predicateComparing) : this(tree)
        {
            this._predicateComparingTreeNodeAndSmplee = predicateComparing;
        }


        public TraverserOfTree(ITree<I> tree, PredicateComparingTreeNodeAndSample<I> predicateComparing, 
            TypeOfTraversingStrategy typeOfTraversingStrategyOfTree) : this(tree, predicateComparing)
        {
            this._typeOfTraversingStrategyOfTree = typeOfTraversingStrategyOfTree;
        }


        public TraverserOfTree(ITree<I> tree, PredicateComparingTreeNodeAndSample<I> predicateComparing,
            TypeOfTraversingStrategy typeOfTraversingStrategyOfTree,
            ComposerOfCandidatesForTreeTraversor<I> delegateComposerOfCandidatesForTreeTraversor) : this(tree, predicateComparing, typeOfTraversingStrategyOfTree)
        {
            this._delegateComposerOfCandidatesForTreeTraversor = delegateComposerOfCandidatesForTreeTraversor;
        }
        #endregion


        #region Properties
        public bool IsConstintentState
        {
            get
            {
                return this._isConstintentState;
            }
            set
            {
                this._isConstintentState = value;
            }
        }


        public PredicateComparingTreeNodeAndSample<I> PredicateComparingTreeNode
        {
            set
            {
                this._predicateComparingTreeNodeAndSmplee = value;
            }
        }


        public ComposerOfCandidatesForTreeTraversor<I> DelegateComposerOfCandidates
        {
            set
            {
                this._delegateComposerOfCandidatesForTreeTraversor = value;
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="treeNode"></param>
        /// <param name="goalOfSearchInTree"></param>
        /// <returns> instance of ResultOfSearchInTree, when successful value isn't default, and default otherwise</returns>
        public ResultOfSearchInTree<I> SearchNodeInTree(
                               in ITree<I>  tree,
                               ITreeNode<I>  treeNode,
                               in GoalOfSearchInTree<I> goalOfSearchInTree)
        {
            if(this._tree == null || !this._tree.ConsistentState)
            {
                return new ResultOfSearchInTree<I>();
            }

            if (goalOfSearchInTree.typeOfComparingStrategyOfTreeNode == TypeOfComparingStrategy.COMPARING_BY_NODE)
            {
                ITreeNode<I> foundTreeNode;

                ITreeNode<I> currTreeNode = this._treeNodesUntouched.Pop();

                bool resultOfFound = this.JumpIntoNextNodeByNodeSample(in currTreeNode, in goalOfSearchInTree.treeNode, out foundTreeNode);
                if(resultOfFound && foundTreeNode != null)
                {
                    return new ResultOfSearchInTree<I>(foundTreeNode);
                }
                return new ResultOfSearchInTree<I>();
            }
            else if (goalOfSearchInTree.typeOfComparingStrategyOfTreeNode == TypeOfComparingStrategy.COMPARING_BY_CONTENT_ONLY)
            {

            }
            else if (goalOfSearchInTree.typeOfComparingStrategyOfTreeNode == TypeOfComparingStrategy.COMPARING_BY_TOPOLOGY)
            {

            }

            throw new NotImplementedException();
        }

        #endregion


        #region Protected Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="treeNodeWhereSearching"></param>
        /// <param name="nodeForSearchingSample"></param>
        /// <param name="treeNode"></param>
        /// <returns></returns>
        protected bool  JumpIntoNextNodeByNodeSample(in ITreeNode<I> treeNodeWhereSearching, in ITreeNode<I> nodeForSearchingSample, out ITreeNode<I> treeNode)
        {

            //  this  method need to be raplaced by new one

            treeNode = null;
            if (!_isConstintentState ||  treeNodeWhereSearching == null || nodeForSearchingSample == null) return false;
            if(treeNodeWhereSearching == nodeForSearchingSample || treeNodeWhereSearching.Equals(nodeForSearchingSample))
            {
                treeNode = treeNodeWhereSearching;
                return true;
            }
            if( false) //(treeNodeWhereSearching.AmIleaf() && nodeForSearchingSample.AmIleaf())
            {
                bool returnOfPredicate = false; ///  _predicateIsFoundNode( treeNodeWhereSearching, nodeForSearchingSample);
                if (returnOfPredicate)
                {
                    treeNode = treeNodeWhereSearching;
                }
                return returnOfPredicate;
            }
            if ( false) ///(_predicateIsFoundNode(treeNodeWhereSearching, nodeForSearchingSample))
            {
                treeNode = treeNodeWhereSearching;
                return true;
            }

            /*====================================================
            IEnumerable<ITreeNode<I>> treeNodeCandidates = _delegateComposerOfCandidatesForTreeTraversor(in treeNodeWhereSearching, _typeOfTraversingStrategyOfTree);
            

            foreach(var oneTreeNode in treeNodeCandidates)
            {
                bool returnOfPredicate = JumpIntoNextNodeByNodeSample( oneTreeNode, nodeForSearchingSample, out treeNode);
                if (returnOfPredicate)
                {
                    treeNode = oneTreeNode;
                    return true;
                }
            }
            */
            return false;
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///   Factory  method  for creating  stack of  untouched  nodes of tree for  trsversing
        /// </summary>
        /// <param name="tree"> tree of nodes for which is created such stack</param>
        /// <param name="stackOfTreeNods"> output parameter where stak is returned </param>
        /// <returns> true if successfull, false otherwise</returns>
        private bool PopulateStackFromTree(in ITree<I> tree, out Stack<ITreeNode<I>> stackOfTreeNods)
        {
            stackOfTreeNods = null;

            if (tree == null || tree.Count == 0)
            {
                return false;
            }

            stackOfTreeNods = new Stack<ITreeNode<I>>(tree.Count + 2);

            stackOfTreeNods.Push(tree.Root);

            var treeNodes = tree.AllNodes;

            for (int i = treeNodes.Count - 1; i >= 0; i--)
            {
                stackOfTreeNods.Push(treeNodes[i]);
            }

            return true;
        }



        #endregion
    }
}
