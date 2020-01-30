using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class AVLTree<T> : BSTree<T> where T : IComparable {

        public int occur = 0;

        public new void InsertItem(T item) {
            insertItem(item, ref root);
        }

        private void insertItem(T item, ref Node<T> tree) {
            if (tree == null) {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Key) < 0) {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                insertItem(item, ref tree.Right);
            }
            else { //if equal
                (tree.Count)++;
            }

            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);

            if (tree.BalanceFactor <= -2) {
                rotateLeft(ref tree);
            }
            if (tree.BalanceFactor >= 2) {
                rotateRight(ref tree);
            }

        }


        public int GetWordCount(T item) {
            return GetWordCount(item, ref root);
        }

        private int GetWordCount(T item, ref Node<T> tree) {
            int count = 0;

            if (tree == null) {
                tree = new Node<T>(item);
            }

            if (item.CompareTo(tree.Key) < 0) {
                GetWordCount(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                GetWordCount(item, ref tree.Right);
            }
            else { //if equal
                count++;
            }

            return count;
        }

        public Node<T> ContainsNode(T item) {
            return ContainsNode(item, ref root);
        }

        private Node<T> ContainsNode(T item, ref Node<T> tree) {
            if (tree == null) {
                Console.WriteLine("Item (" + item + ") not found!");
                return null;
            }

            if (item.CompareTo(tree.Key) < 0) {
                return ContainsNode(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                return ContainsNode(item, ref tree.Right);
            }
            else {
                Console.WriteLine("Item (" + item + ") found!");
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

        //public int FindItemCount(T item) {
        //    return FindItemCount(item, ref root);
        //}

        //private int FindItemCount(T item, ref Node<T> tree) {
        //    if (tree == null) {
        //        tree = new Node<T>(item);
        //    }

        //    else if (item.CompareTo(tree.Key) < 0) {
        //        FindItemCount(item, ref tree.Left);
        //    }
        //    else if (item.CompareTo(tree.Key) > 0) {
        //        FindItemCount(item, ref tree.Right);
        //    }
        //    else { //if equal
        //        (tree.Count)++;
        //    }

        //    return tree.Count;
        //}
    }
}
