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
        private ITreeNode<I> _treeNode;

        private ComposerOfCandidatesForTreeTraversor<I> _delegateMakeupCandidatesOfTreeNodesForTraversing;
        #endregion


        #region Constructors
        public TraverserOfTree()
        {
            this._typeOfTraversingStrategyOfTree = TypeOfTraversingStrategy.DEPTH_FIRST;
            this._isConstintentState = true;
        }

        public TraverserOfTree(ITreeNode<I> treeNode) : this()
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateComparingTreeNodeAndSample<I> predicateComparing) : this(treeNode)
        {
            this._predicateComparingTreeNodeAndSmplee = predicateComparing;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateComparingTreeNodeAndSample<I> predicateComparing, 
            TypeOfTraversingStrategy typeOfTraversingStrategyOfTree) : this(treeNode, predicateComparing)
        {
            this._typeOfTraversingStrategyOfTree = typeOfTraversingStrategyOfTree;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateComparingTreeNodeAndSample<I> predicateComparing,
            TypeOfTraversingStrategy typeOfTraversingStrategyOfTree,
            ComposerOfCandidatesForTreeTraversor<I> makeupCandidatesOfTreeNodesForTraversing) : this(treeNode, predicateComparing, typeOfTraversingStrategyOfTree)
        {
            this._delegateMakeupCandidatesOfTreeNodesForTraversing = makeupCandidatesOfTreeNodesForTraversing;
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


        public ComposerOfCandidatesForTreeTraversor<I> DelegateMakeupCandidatesOfTreeNodesForTraversingOfTree
        {
            set
            {
                this._delegateMakeupCandidatesOfTreeNodesForTraversing = value;
            }
        }
        #endregion

        #region Methods
        public ResultOfSearchInTree<I> SearchNodeInTree(
                               in ITreeNode<I> treeNodeWhereSearching, 
                               in GoalOfSearchInTree<I> goalOfSearchInTree)
        {
            if (goalOfSearchInTree.typeOfComparingStrategyOfTreeNode == TypeOfComparingStrategy.COMPARING_BY_NODE)
            {
                ITreeNode<I> fondTreeNode;
                bool resultOfFound = this.JumpIntoNextNodeByNodeSample(in treeNodeWhereSearching, in goalOfSearchInTree.treeNode, out fondTreeNode);
                if(resultOfFound && fondTreeNode != null)
                {
                    return new ResultOfSearchInTree<I>(fondTreeNode);
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

            IEnumerable<ITreeNode<I>> treeNodeCandidates = _delegateMakeupCandidatesOfTreeNodesForTraversing(in treeNodeWhereSearching, _typeOfTraversingStrategyOfTree);

            foreach(var oneTreeNode in treeNodeCandidates)
            {
                bool returnOfPredicate = JumpIntoNextNodeByNodeSample( oneTreeNode, nodeForSearchingSample, out treeNode);
                if (returnOfPredicate)
                {
                    treeNode = oneTreeNode;
                    return true;
                }
            }
            return false;
        }



        #endregion
    }
}
