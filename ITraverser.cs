using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public delegate bool PredicateForSearchInTree<T> (
                       in ITreeNode<T> treeNodeWhereSearching,
                       in ITreeNode<T> nodeForSearchingSample) where T : IElementOfTreeContent;

    public interface ITraverser<I>  where I : IElementOfTreeContent
    {

        public delegate IEnumerable<ITreeNode<I>> MakeupCandidatesOfTreeNodesForTraversing(
                       in ITreeNode<I> treeNodeWhereSearching,
                       TypeOfTraversingStrategyOfTree typeOfTraversingStrategyOfTree);


        public bool IsConstintentState
        {
            get;
        }

        public ResultOfSearchInTree<I> SearchNodeInTree(
                                      in ITreeNode<I> treeNodeWhereSearching,
                                      in GoalOfSearchInTree<I> goalOfSearchInTree);


    }
}
