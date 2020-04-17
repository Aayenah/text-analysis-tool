using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class AVLTree<T> : BSTree<T> where T : IComparable {

        public new void InsertItem(T item) {
            InsertItem(item, ref root);
        }

        private void InsertItem(T item, ref Node<T> tree) {
            if (tree == null) {
                tree = new Node<T>(item);
            }

            if (item.CompareTo(tree.Key) < 0) {
                InsertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                InsertItem(item, ref tree.Right);
            }
            else { //if equal
                //(tree.Count)++;
            }

            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);

            if (tree.BalanceFactor <= -2) {
                rotateLeft(ref tree);
            }
            if (tree.BalanceFactor >= 2) {
                rotateRight(ref tree);
            }

        }

        public Node<T> GetNode(T item) {
            return GetNode(item, ref root);
        }

        private Node<T> GetNode(T item, ref Node<T> tree) {
            if (tree == null) {
                return null;
            }

            if (item.CompareTo(tree.Key) < 0) {
                return GetNode(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                return GetNode(item, ref tree.Right);
            }
            else {
                return tree;
            }
        }


        private void rotateLeft(ref Node<T> tree) {
            if (tree == null) {
                return;
            }

            if (tree.Right.BalanceFactor > 0) //double rotate
            {
                rotateRight(ref tree.Right);
            }

            Node<T> oldRoot = tree;
            Node<T> newRoot = oldRoot.Right;

            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;

            // tree ?
            tree = newRoot;
        }

        private void rotateRight(ref Node<T> tree) {
            if (tree == null) {
                return;
            }

            if (tree.Left.BalanceFactor < 0) //double rotate
            {
                rotateLeft(ref tree.Left);
            }

            Node<T> oldRoot = tree;
            Node<T> newRoot = tree.Left;

            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;
            tree = newRoot;
        }
    }
}
