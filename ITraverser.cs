using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    ///   This predicate compare sample with given node of tree, if comparing true, predicate should return true,
    ///   and false otherwise
    /// </summary>
    /// <typeparam name="T">  any object type implemented  IElementOfTreeContent interface </typeparam>
    /// <param name="treeNodeForComparing"> node with which we compare sample</param>
    /// <param name="goalOfSearch"> sample is to one node should be compared</param>
    /// <returns> true , when first argument is equal to sample , false otherwise </returns>
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
