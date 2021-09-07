﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{

    public delegate bool PredicateForTraversingOfTree(ITreeNode<IElementOfTreeContent> treeNode, IElementOfTreeContent contentForSearching);

    public class TraverserOfTree<I> where I : IElementOfTreeContent
    {


        private bool _isConstintentState;

        private PredicateForTraversingOfTree _predicateIsFoundNode;
        private ITreeNode<I> _treeNode;


        public TraverserOfTree()
        {
            _isConstintentState = true;
        }

        public TraverserOfTree(ITreeNode<I> treeNode)
        {
            this._treeNode = treeNode;
        }


        public TraverserOfTree(ITreeNode<I> treeNode, PredicateForTraversingOfTree predicateIsFoundNode) : this(treeNode)
        {
            this._predicateIsFoundNode = predicateIsFoundNode;
        }


    }
}
