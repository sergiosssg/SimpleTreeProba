using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{

    public delegate bool PredicateForTraversingOfTreeByNode(
                       ITreeNode<IElementOfTreeContent> treeNodeWhereSearching, 
                       in ITreeNode<IElementOfTreeContent> nodeForSearchingSample);

    public class TraverserOfTree<I> where I : IElementOfTreeContent
    {


        private bool _isConstintentState;

        private PredicateForTraversingOfTreeByNode _predicateIsFoundNode;
        private ITreeNode<I> _treeNode;


        public TraverserOfTree()
        {
            _isConstintentState = true;
        }

        public TraverserOfTree(ITreeNode<I> treeNode) : this()
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateForTraversingOfTreeByNode predicateIsFoundNode) : this(treeNode)
        {
            this._predicateIsFoundNode = predicateIsFoundNode;
        }


        public bool IsConstintentState
        {
            get
            {
                return _isConstintentState;
            }
            set
            {
                _isConstintentState = value;
            }
        }


        public PredicateForTraversingOfTreeByNode PredicateForTraversingOfTreeByNodeIn
        {
            set
            {
                _predicateIsFoundNode = value;
            }
        }


        public bool  JumpIntoNextNodeByNodeSample(in ITreeNode<I> treeNodeWhereSearching, in ITreeNode<I> nodeForSearchingSample, out ITreeNode<I> treeNode)
        {
            treeNode = null;

            if (treeNodeWhereSearching == null || nodeForSearchingSample == null) return false;
            if(treeNodeWhereSearching == nodeForSearchingSample)
            {
                treeNode = treeNodeWhereSearching;
                return true;
            }


            return false;
        }



    }
}
