using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TraverserOfTree<I> where I : IElementOfTreeContent
    {

        public delegate bool PredicateForTraversingOfTreeByNode(
                       ITreeNode<I> treeNodeWhereSearching,
                       in ITreeNode<I> nodeForSearchingSample);

        public delegate IEnumerable<ITreeNode<I>> MakeupCandidatesOfTreeNodesForTraversing(
                       in ITreeNode<I> treeNodeWhereSearching,
                       TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree);


        private TypeOfTraversingStrategyOfTree _typeOfTraversingStrategyOfTree;

        private bool _isConstintentState;

        private PredicateForTraversingOfTreeByNode _predicateIsFoundNode;
        private ITreeNode<I> _treeNode;

        private MakeupCandidatesOfTreeNodesForTraversing _delegateMakeupCandidatesOfTreeNodesForTraversing;


        public TraverserOfTree()
        {
            this._typeOfTraversingStrategyOfTree = TypeOfTraversingStrategyOfTree.DEPTH_FIRST;
            this._isConstintentState = true;
        }

        public TraverserOfTree(ITreeNode<I> treeNode) : this()
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateForTraversingOfTreeByNode predicateIsFoundNode) : this(treeNode)
        {
            this._predicateIsFoundNode = predicateIsFoundNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateForTraversingOfTreeByNode predicateIsFoundNode, 
            TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree) : this(treeNode, predicateIsFoundNode)
        {
            this._typeOfTraversingStrategyOfTree = typeOfTraversingStrategyOfTree;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateForTraversingOfTreeByNode predicateIsFoundNode,
            TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree,
            MakeupCandidatesOfTreeNodesForTraversing makeupCandidatesOfTreeNodesForTraversing) : this(treeNode, predicateIsFoundNode, typeOfTraversingStrategyOfTree)
        {
            this._delegateMakeupCandidatesOfTreeNodesForTraversing = makeupCandidatesOfTreeNodesForTraversing;
        }

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


        public PredicateForTraversingOfTreeByNode PredicateForTraversingOfTreeByNodeIn
        {
            set
            {
                this._predicateIsFoundNode = value;
            }
        }


        public MakeupCandidatesOfTreeNodesForTraversing DelegateMakeupCandidatesOfTreeNodesForTraversingOfTree
        {
            set
            {
                this._delegateMakeupCandidatesOfTreeNodesForTraversing = value;
            }
        }


        public bool  JumpIntoNextNodeByNodeSample(in ITreeNode<I> treeNodeWhereSearching, in ITreeNode<I> nodeForSearchingSample, out ITreeNode<I> treeNode)
        {
            treeNode = null;
            if (!_isConstintentState ||  treeNodeWhereSearching == null || nodeForSearchingSample == null) return false;
            if(treeNodeWhereSearching == nodeForSearchingSample)
            {
                treeNode = treeNodeWhereSearching;
                return true;
            }
            if((treeNodeWhereSearching is TreeNodeSimple<I> && nodeForSearchingSample is TreeNodeSimple<I>) || (treeNodeWhereSearching is Tree<I> && nodeForSearchingSample is Tree<I>))
            {
                bool returnOfPredicate = _predicateIsFoundNode( treeNodeWhereSearching, nodeForSearchingSample);
                if (returnOfPredicate)
                {
                    treeNode = treeNodeWhereSearching;
                }
                return returnOfPredicate;
            }

            IEnumerable<ITreeNode<I>> treeNodeCandidates = _delegateMakeupCandidatesOfTreeNodesForTraversing(in treeNodeWhereSearching, _typeOfTraversingStrategyOfTree);


            return false;
        }



    }
}
