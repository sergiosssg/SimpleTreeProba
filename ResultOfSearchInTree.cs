using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class ResultOfSearchInTree<I> where I : IElementOfTreeContent
    {
        private bool _foundResult;
        private bool _founndByContent;
        private I _foundElementOfTreeContent;
        private bool _founndByTreeNode;
        private ITreeNode<I> _foundTreeNode;
        private bool _foundByThopology;
        private int _depthLevel;
        private int siblingOrder;

    }
}
