using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    ///    Type of strategy of traversing of tree
    ///    --  width of all children and if not found, then deeper
    ///    --  depth deep deep and deep then next to ...
    /// </summary>
    public enum TypeOfTraversingStrategy
    {
        WIDTH_FIRST,
        DEPTH_FIRST
    }
}
