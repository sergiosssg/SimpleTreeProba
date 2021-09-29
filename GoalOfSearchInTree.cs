using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="I"> type I have to implement interface IElementOfTreeContent </typeparam>
    public struct GoalOfSearchInTree<I> where I : IElementOfTreeContent
    {
        public TypeOfComparingStrategy typeOfComparingStrategyOfTreeNode;
        public ITreeNode<I> treeNode;
        public I nodeContent;
        public int depthLevel;
        public string orderInTree;
    }
}
