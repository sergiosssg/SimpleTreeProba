using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    public delegate bool PredicateComparingTreeNodeAndSmple<T> (
                       in ITreeNode<T> treeNodeForComparing,
                       GoalOfSearchInTree<T> goalOfSearch) where T : IElementOfTreeContent;

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
