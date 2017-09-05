using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Provides binary search tree.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class BinarySearchTree<T>: IEnumerable<T>
    {
        internal sealed class Node<T>
        {
            public T Value { get; set; }
            public Node<T> Left { get; set; }
            public Node<T> Right { get; set; }
            
            public Node(T t)
            {
                Value = t;
                Left = null;
                Right = null;
            }
        }

        private readonly IComparer<T> comparer;
        private Node<T> root;

        public int Count { get; private set; }
        private IComparer<T> Comparer { get; }

        #region Constructors

        /// <summary>
        /// Creates a tree with default or user's  comparision.
        /// </summary>
        /// <param name="comparer">Comparer for tree.</param>
        public BinarySearchTree(IComparer<T> comparer = null)
        {
            root = null;
            Comparer = comparer ?? Comparer<T>.Default;
        }

        /// <summary>
        /// Creates a tree with comparision.
        /// </summary>
        /// <param name="comparison">Comparison for tree.</param>
        public BinarySearchTree(Comparison<T> comparison)
            : this(Comparer<T>.Create(comparison))
        {
        }

        /// <summary>
        /// Creates a tree from collection and with/without comparision.
        /// </summary>
        /// <param name="collection">Collection of elements.</param>
        /// <param name="comparer">Comparison for tree.</param>
        public BinarySearchTree(IEnumerable<T> collection, IComparer<T> comparer = null)
            : this(comparer)
        {
            if (ReferenceEquals(collection, null))
                root = null;
            Add(collection);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Provides information whether the tree is empty.
        /// </summary>
        /// <returns>True if tree is emty. False in the opposite case.</returns>
        public bool IsEmpty() => root == null;

        /// <summary>
        /// Adding of an element.
        /// </summary>
        /// <param name="element">Element to add.</param>
        public void Add(T element)
        {
            root = Adding(root, element);
            Count++;
        }

        /// <summary>
        /// Adding of the range of elements.
        /// </summary>
        /// <param name="collection">Range of elements to add.</param>
        public void Add(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        /// <summary>
        /// Clear tree.
        /// </summary>
        public void Clear()
        {
            root = null;
            Count = 0;
        }

        /// <summary>
        /// Provides enumerator on binary search tree.
        /// </summary>
        /// <returns>Enumerator on binary search tree.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return InOrder(root).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Provides information about the presence of a current element in binary search tree.
        /// </summary>
        /// <param name="value">Value to search.</param>
        /// <returns>True if value exists. False otherwise.</returns>
        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            Node<T> current = root;
            int result;

            while (current != null)
            {
                result = comparer.Compare(current.Value, value);
                if (result == 0) return true;
                if (result > 0) current = current.Left;
                if (result < 0) current = current.Right;
            }
            return false;
        }

        /// <summary>
        /// Provides elements of binary search tree in preorder.
        /// </summary>
        /// <returns>IEnumerable for preorder.</returns>
        public IEnumerable<T> PreOrder() => PreOrder(root);

        /// <summary>
        /// Provides elements of binary search tree in postorder.
        /// </summary>
        /// <returns>IEnumerable for postorder.</returns>
        public IEnumerable<T> PostOrder() => PostOrder(root);

        /// <summary>
        /// Provides elements of binary search tree in inorder.
        /// </summary>
        /// <returns>IEnumerable for inorder.</returns>
        public IEnumerable<T> InOrder() => InOrder(root);

        #endregion

        #region Private Methods

        private Node<T> Adding(Node<T> node, T element)
        {
            if (node == null)
                return new Node<T>(element);

            int comp = Comparer.Compare(element, node.Value);
            if (comp < 0)
                node.Left = Adding(node.Left, element);

            else if (comp > 0)
                node.Right = Adding(node.Right, element);

            return node;
        }

        private IEnumerable<T> PreOrder(Node<T> node)
        {
            while (true)
            {
                if (node == null) yield break;
                yield return node.Value;
                foreach (var n in PreOrder(node.Left))
                    yield return n;
                node = node.Right;
            }
        }

        private IEnumerable<T> InOrder(Node<T> node)
        {
            while (true)
            {
                if (node == null) yield break;
                foreach (var n in InOrder(node.Left))
                    yield return n;
                yield return node.Value;
                node = node.Right;
            }
        }

        private IEnumerable<T> PostOrder(Node<T> node)
        {
            if (node == null) yield break;
            foreach (var n in PostOrder(node.Left))
                yield return n;
            foreach (var n in PostOrder(node.Right))
                yield return n;
            yield return node.Value;
        }

        #endregion
    }
}
