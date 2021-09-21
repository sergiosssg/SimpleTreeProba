using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public interface ITree<T> where T : IElementOfTreeContent
    {


        public int Count
        {
            get;
        }

        public ITreeNode<T> Root
        {
            get;
        }

        public bool ConsistentState
        {
            get;
            set;
        }

        public IEnumerable<ITreeNode<T>> AllNodes
        {
            get;
        }


        public void Clear();

        public bool AddNode(ITreeNode<T> node);

        public bool RemoveNode(ITreeNode<T> removedNode);
    }
}
