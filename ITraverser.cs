﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TreeLib
{
    /// <summary>
    ///   This predicate compare sample with given node of tree, if comparing true, predicate should return true,
    ///   and false otherwise
    /// </summary>
    /// <typeparam name="T">  any object type implemented  IElementOfTreeContent interface </typeparam>
    /// <param name="tree"> </param>
    /// <param name="treeNodeForComparing"> node with which we compare sample</param>
    /// <param name="goalOfSearch"> sample is to one node should be compared</param>
    /// <returns> true , when first argument is equal to sample , false otherwise </returns>
    public delegate bool PredicateComparingTreeNodeAndSample<T> (
                       in ITree<T> tree,
                       in ITreeNode<T> treeNodeForComparing,
                       GoalOfSearchInTree<T> goalOfSearch) where T : IElementOfTreeContent;


    /// <summary>
    ///   This  delegate  makes up  list for traversing of tree nodes through
    /// </summary>
    /// <typeparam name="T"> any object type implemented  IElementOfTreeContent interface  </typeparam>
    /// <param name="tree"> </param>
    /// <param name="treeNodeWhereSearching"> tree node to make candidates </param>
    /// <param name="typeOfTraversingStrategyOfTree"> type how need to traverse tree, width first, or depth first</param>
    /// <returns> IEnumerable of that tree nodes, they aren't traversed yet</returns>
    public delegate IEnumerable<ITreeNode<T>> ComposerOfCandidatesForTreeTraversor<T>(
                       in ITree<T>   tree,
                       in ITreeNode<T> treeNodeWhereSearching,
                       TypeOfTraversingStrategy typeOfTraversingStrategyOfTree) where T : IElementOfTreeContent;


    public interface ITraverser<I>  where I : IElementOfTreeContent
    {

        public bool IsConstintentState
        {
            get;
        }

        public ResultOfSearchInTree<I> SearchNodeInTree(
                                      in ITree<I> tree,
                                      ITreeNode<I> treeNode,
                                      in GoalOfSearchInTree<I> goalOfSearchInTree);


    }
}
