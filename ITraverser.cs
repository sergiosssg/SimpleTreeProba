using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public interface ITraverser<I>  where I : IElementOfTreeContent
    {
        public delegate bool PredicateForTraversingOfTreeByNode(
                       ITreeNode<I> treeNodeWhereSearching,
                       in ITreeNode<I> nodeForSearchingSample);

        public delegate IEnumerable<ITreeNode<I>> MakeupCandidatesOfTreeNodesForTraversing(
                       in ITreeNode<I> treeNodeWhereSearching,
                       TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree);


    }
}
