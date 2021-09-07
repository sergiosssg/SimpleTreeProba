using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TraverserOfTree<I> where I : IElementOfTreeContent
    {


        private Predicate<ITreeNode<I>> _predicateIsFoundNode;
        private ITreeNode<I> _treeNode;


        public TraverserOfTree()
        {

        }

        public TraverserOfTree(ITreeNode<I> treeNode)
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, Predicate<ITreeNode<I>> predicateIsFoundNode) : this(treeNode)
        {
            this._predicateIsFoundNode = predicateIsFoundNode;
        }


    }
}
