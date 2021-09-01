using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public interface ITreeNode<IElementOfTree>
    {
        public bool AmIleaf();

        public IElementOfTree GetCurrentElement();
    }
}
