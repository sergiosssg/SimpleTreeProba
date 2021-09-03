using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeNodeSimple<T> : ITreeNode<T> where T : IElementOfTreeContent
    {


        public bool AmIleaf() => true;


        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            throw new NotImplementedException();
        }

        public T GetCurrentElement()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> GetParent()
        {
            throw new NotImplementedException();
        }
    }
}
