using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TraverserOfTree<I> : ITraverser<I> where I : IElementOfTreeContent
    {


        private TypeOfTraversingStrategyOfTree _typeOfTraversingStrategyOfTree;

        private bool _isConstintentState;

        private ITraverser<I>.PredicateForTraversingOfTreeByNode _predicateIsFoundNode;
        private ITreeNode<I> _treeNode;

        private ITraverser<I>.MakeupCandidatesOfTreeNodesForTraversing _delegateMakeupCandidatesOfTreeNodesForTraversing;


        public TraverserOfTree()
        {
            this._typeOfTraversingStrategyOfTree = TypeOfTraversingStrategyOfTree.DEPTH_FIRST;
            this._isConstintentState = true;
        }

        public TraverserOfTree(ITreeNode<I> treeNode) : this()
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, ITraverser<I>.PredicateForTraversingOfTreeByNode predicateIsFoundNode) : this(treeNode)
        {
            this._predicateIsFoundNode = predicateIsFoundNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, ITraverser<I>.PredicateForTraversingOfTreeByNode predicateIsFoundNode, 
            TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree) : this(treeNode, predicateIsFoundNode)
        {
            this._typeOfTraversingStrategyOfTree = typeOfTraversingStrategyOfTree;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, ITraverser<I>.PredicateForTraversingOfTreeByNode predicateIsFoundNode,
            TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree,
            ITraverser<I>.MakeupCandidatesOfTreeNodesForTraversing makeupCandidatesOfTreeNodesForTraversing) : this(treeNode, predicateIsFoundNode, typeOfTraversingStrategyOfTree)
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


        public ITraverser<I>.PredicateForTraversingOfTreeByNode PredicateForTraversingOfTreeByNodeIn
        {
            set
            {
                this._predicateIsFoundNode = value;
            }
        }


        public ITraverser<I>.MakeupCandidatesOfTreeNodesForTraversing DelegateMakeupCandidatesOfTreeNodesForTraversingOfTree
        {
            set
            {
                this._delegateMakeupCandidatesOfTreeNodesForTraversing = value;
            }
        }

        public bool SearchNodeInTree(in ITreeNode<I> treeNodeWhereSearching, in ITreeNode<I> nodeForSearchingSample, out ITreeNode<I> treeNode, TypeOfComparingStrategyOfTreeNode typeOfComparingStrategyOfTreeNode)
        {
            throw new NotImplementedException();
        }

        protected bool  JumpIntoNextNodeByNodeSample(in ITreeNode<I> treeNodeWhereSearching, in ITreeNode<I> nodeForSearchingSample, out ITreeNode<I> treeNode)
        {
            treeNode = null;
            if (!_isConstintentState ||  treeNodeWhereSearching == null || nodeForSearchingSample == null) return false;
            if(treeNodeWhereSearching == nodeForSearchingSample || treeNodeWhereSearching.Equals(nodeForSearchingSample))
            {
                treeNode = treeNodeWhereSearching;
                return true;
            }
            if(treeNodeWhereSearching.AmIleaf() && nodeForSearchingSample.AmIleaf())
            {
                bool returnOfPredicate = _predicateIsFoundNode( treeNodeWhereSearching, nodeForSearchingSample);
                if (returnOfPredicate)
                {
                    treeNode = treeNodeWhereSearching;
                }
                return returnOfPredicate;
            }
            if (_predicateIsFoundNode(treeNodeWhereSearching, nodeForSearchingSample))
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



    }
}
