using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public interface ITreeNode<T> where T : IElementOfTreeContent
    {
        public bool AmIleaf();

        public T GetCurrentElement();

        public ITreeNode<T> GetParent();

        public IEnumerable<ITreeNode<T>> GetChildren();
    }
}
