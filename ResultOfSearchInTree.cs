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
        private int _siblingOrder;

        public ResultOfSearchInTree()
        {
            this._foundResult = false;
            this._founndByContent = false;
            this._founndByTreeNode = false;
            this._foundByThopology = false;
            this._depthLevel = 0;
            this._siblingOrder = 0;

        }

        public ResultOfSearchInTree(I foundElementOfTreeContent) : this ()
        {
            this._foundResult = true;
            this._founndByContent = true;
            this._foundElementOfTreeContent = foundElementOfTreeContent;
        }

        public ResultOfSearchInTree(ITreeNode<I> foundTreeNode) : this()
        {
            this._foundResult = true;
            this._founndByTreeNode = true;
            this._foundTreeNode = foundTreeNode;
        }

        public ResultOfSearchInTree(int depthLevel, int siblingOrder) : this()
        {
            this._foundResult = true;
            this._foundByThopology = true;
            this._depthLevel = depthLevel;
            this._siblingOrder = siblingOrder;
        }



        public bool IsResultFound() => this._foundResult;
        public bool IsResultRepresentedByContent() => this._founndByContent;
        public bool IsResultRepresantedByTreeNode() => this._founndByTreeNode;
        public bool ISResultRepresantedByThopology() => this._foundByThopology;

        public I FoundElementOfTreeContent
        {
            get => this._foundElementOfTreeContent;
        }

        public ITreeNode<I> FoundTreeNode
        {
            get => this._foundTreeNode;
        }

        public Tuple<int, int> FoundThopology
        {
            get =>  new Tuple<int, int>(this._depthLevel, this._siblingOrder); 
        }
    }
}
