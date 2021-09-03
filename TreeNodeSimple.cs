using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public class TreeNodeSimple<T> : ITreeNode<T> where T : IElementOfTreeContent
    {

        private T _lementOfTreeContent;

        public bool AmIleaf() => true;
        public T GetCurrentElement() => _lementOfTreeContent;


        public IEnumerable<ITreeNode<T>> GetChildren()
        {
            throw new NotImplementedException();
        }

        public ITreeNode<T> GetParent()
        {
            throw new NotImplementedException();
        }

        public bool HaveIparent()
        {
            throw new NotImplementedException();
        }

        public bool HaveIchildren()
        {
            throw new NotImplementedException();
        }
    }
}
