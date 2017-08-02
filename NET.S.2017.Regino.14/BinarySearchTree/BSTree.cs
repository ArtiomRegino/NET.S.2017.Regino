using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTree
{
    public class BSTree<T>: IEnumerable<T>
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

        private readonly IComparer<T> _comparer;
        private Node<T> _root;
        public bool IsEmpty() => _root == null;
        public int Count { get; private set; }
        private IComparer<T> Comparer { get; }

        public BSTree(IComparer<T> comparer = null)
        {
            _root = null;
            Comparer = comparer ?? Comparer<T>.Default;
        }

        public BSTree(Comparison<T> comparison)
            : this(Comparer<T>.Create(comparison))
        {
        }

        public BSTree(IEnumerable<T> collection, IComparer<T> comparer = null)
            : this(comparer)
        {
            if (ReferenceEquals(collection, null))
                throw new ArgumentNullException($"{nameof(collection)} is null");
            Add(collection);
        }

        public void Add(T element)
        {
            _root = Adding(_root, element);
        }

        public void Add(IEnumerable<T> collection)
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            foreach (var item in collection)
            {
                Add(item);
            }
        }

        private Node<T> Adding(Node<T> node, T element)
        {
            if (node == null)
                return new Node<T>(element);

            int comp = Comparer.Compare(element, node.Value);
            if (comp < 0) node.Left = Adding(node.Left, element);

            else if (comp > 0) node.Right = Adding(node.Right, element);

            return node;
        }

        public void Clear() => _root = null;

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            Node<T> current = _root;
            int result;

            while (current != null)
            {
                result = _comparer.Compare(current.Value, value);
                if (result == 0) return true;
                if (result > 0) current = current.Left;
                if (result < 0) current = current.Right;
            }
            return false;
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
    }
}
