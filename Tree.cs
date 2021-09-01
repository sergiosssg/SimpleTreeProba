using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class Tree<IElementOfTreeContent> : ITreeNode<IElementOfTreeContent>
    {
        public Tree()
        {

        }

        public Tree(IElementOfTreeContent contentElement)
        {

        }

        public Tree(ITreeNode<IElementOfTreeContent> currentNode)
        {

        }

        public Tree(Tree<IElementOfTreeContent> subTree)
        {

        }

        public bool AmIleaf()
        {
            throw new NotImplementedException();
        }

        public IElementOfTreeContent GetCurrentElement()
        {
            throw new NotImplementedException();
        }
    }
}
