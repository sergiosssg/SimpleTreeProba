using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<IElementOfTreeContent> : ITreeNode<IElementOfTreeContent>
    {
        private ITreeNode<IElementOfTreeContent> _parent;
        private IList<ITreeNode<IElementOfTreeContent>> _children;

        public Tree()
        {

        }

        public Tree(IElementOfTreeContent contentElement)
        {

        }

        public Tree(ITreeNode<IElementOfTreeContent> parentNode)
        {

        }


        public bool AmIleaf()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITreeNode<IElementOfTreeContent>> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IElementOfTreeContent GetCurrentElement()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<IElementOfTreeContent> GetParent()
        {
            throw new NotImplementedException();
        }
    }
}
