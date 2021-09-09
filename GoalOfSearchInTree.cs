using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public struct GoalOfSearchInTree<I> where I : IElementOfTreeContent
    {
        public TypeOfComparingStrategyOfTreeNode typeOfComparingStrategyOfTreeNode;
        public ITreeNode<I> treeNode;
        public I nodeContent;
        public int depthLevel;
        public int siblingOrder;
    }
}
