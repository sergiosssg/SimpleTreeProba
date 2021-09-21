using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    ///    Which manner We should campare nodes sample and nodes in tree
    ///    -  by  content
    ///    -  by strict  node comparing
    ///    -  by topology in tree
    /// </summary>
    public enum TypeOfComparingStrategy
    {
        COMPARING_BY_CONTENT_ONLY,
        COMPARING_BY_NODE,
        COMPARING_BY_TOPOLOGY
    }
}
