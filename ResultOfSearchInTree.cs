using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="I"></typeparam>
    public class ResultOfSearchInTree<I> where I : IElementOfTreeContent
    {
        #region Fields
        readonly private bool _foundResult;
        readonly private bool _founndByContent;
        readonly private bool _rootReached;
        readonly private bool _leafReached;
        readonly private I _foundElementOfTreeContent;
        readonly private bool _founndByTreeNode;
        readonly private ITreeNode<I> _foundTreeNode;
        readonly private bool _foundByThopology;
        readonly private int _depthLevel;
        readonly private string _orderInTree;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public ResultOfSearchInTree()
        {
            this._rootReached = false;
            this._leafReached = false;
            this._foundResult = false;
            this._founndByContent = false;
            this._founndByTreeNode = false;
            this._foundByThopology = false;
            this._depthLevel = 0;
            this._orderInTree = string.Empty;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootReached"></param>
        /// <param name="leafReached"></param>
        public ResultOfSearchInTree(bool rootReached, bool leafReached) : this()
        {
            this._rootReached = rootReached;
            this._leafReached = leafReached;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundElementOfTreeContent"></param>
        public ResultOfSearchInTree(I foundElementOfTreeContent) : this ()
        {
            this._foundResult = true;
            this._founndByContent = true;
            this._foundElementOfTreeContent = foundElementOfTreeContent;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundTreeNode"></param>
        public ResultOfSearchInTree(ITreeNode<I> foundTreeNode) : this()
        {
            this._foundResult = true;
            this._founndByTreeNode = true;
            this._foundTreeNode = foundTreeNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depthLevel"></param>
        /// <param name="treeOrder"></param>
        public ResultOfSearchInTree(int depthLevel, string treeOrder) : this()
        {
            this._foundResult = true;
            this._foundByThopology = true;
            this._depthLevel = depthLevel;
            this._orderInTree = treeOrder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundElementOfTreeContent"></param>
        /// <param name="foundTreeNode"></param>
        public ResultOfSearchInTree(I foundElementOfTreeContent, ITreeNode<I> foundTreeNode) : this()
        {
            this._foundResult = true;
            this._founndByContent = true;
            this._founndByTreeNode = true;
            this._foundElementOfTreeContent = foundElementOfTreeContent;
            this._foundTreeNode = foundTreeNode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundTreeNode"></param>
        /// <param name="depthLevel"></param>
        /// <param name="treeOrder"></param>
        public ResultOfSearchInTree(ITreeNode<I> foundTreeNode, int depthLevel, string treeOrder) : this()
        {
            this._foundResult = true;
            this._founndByTreeNode = true;
            this._foundByThopology = true;
            this._foundTreeNode = foundTreeNode;
            this._depthLevel = depthLevel;
            this._orderInTree = treeOrder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundElementOfTreeContent"></param>
        /// <param name="depthLevel"></param>
        /// <param name="treeOrder"></param>
        public ResultOfSearchInTree(I foundElementOfTreeContent, int depthLevel, string treeOrder) : this()
        {
            this._foundResult = true;
            this._founndByContent = true;
            this._foundByThopology = true;
            this._foundElementOfTreeContent = foundElementOfTreeContent;
            this._depthLevel = depthLevel;
            this._orderInTree = treeOrder;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="foundElementOfTreeContent"></param>
        /// <param name="foundTreeNode"></param>
        /// <param name="depthLevel"></param>
        /// <param name="treeOrder"></param>
        public ResultOfSearchInTree(I foundElementOfTreeContent, ITreeNode<I> foundTreeNode, int depthLevel, string treeOrder)
        {
            this._foundResult = true;
            this._founndByContent = true;
            this._founndByTreeNode = true;
            this._foundByThopology = true;
            this._foundElementOfTreeContent = foundElementOfTreeContent;
            this._foundTreeNode = foundTreeNode;
            this._depthLevel = depthLevel;
            this._orderInTree = treeOrder;
        }
        #endregion


        #region Properties
        public bool IsResultFound() => this._foundResult;
        public bool IsRootReached() => this._rootReached;
        public bool IsLeafReached() => this._leafReached;
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
        /// <summary>
        /// 
        /// </summary>
        public Tuple<int, string> FoundThopology
        {
            get =>  new Tuple<int, string>(this._depthLevel, this._orderInTree); 
        }
        #endregion
    }
}
