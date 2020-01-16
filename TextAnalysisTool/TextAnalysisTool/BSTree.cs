using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class BSTree<T> : BinTree<T> where T : IComparable {
        public BSTree() {
            root = null;
        }

        public void InsertItem(T item) {
            InsertItem(item, ref root);
        }

        private void InsertItem(T item, ref Node<T> tree) {
            if (tree == null) {
                tree = new Node<T>(item);
            }
            else if (item.CompareTo(tree.Key) < 0) {
                InsertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                InsertItem(item, ref tree.Right);
            }
        }

        public void RemoveItem(T item) {
            RemoveItem(item, ref root);
        }

        private void RemoveItem(T item, ref Node<T> tree) {
            if (tree == null) {
                Console.WriteLine("No tree!");
                return;
            }

            if (item.CompareTo(tree.Key) == 0) //Item found
            {
                if (tree.Left == null && tree.Right == null) //no children
                {
                    tree = null;
                    Console.WriteLine("Leaf item (" + item + ") removed!");
                }
                else if (tree.Left == null) //only has right child
                {
                    tree = tree.Right;
                    Console.WriteLine("Right child item (" + item + ") removed!");
                }
                else if (tree.Right == null) //only has left child
                {
                    tree = tree.Left;
                    Console.WriteLine("Left child item (" + item + ") removed!");
                }
                else //has both children
                {
                    T newRoot = LeastItem(tree.Right);
                    tree.Key = newRoot;
                    RemoveItem(newRoot, ref tree.Right);
                    Console.WriteLine("Item (" + item + ") removed! Has two children.");
                }
            }
            else if (item.CompareTo(tree.Key) < 0) {
                RemoveItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                RemoveItem(item, ref tree.Right);
            }

        }

        public T LeastItem(Node<T> tree) {
            while (tree.Left != null) //find left most node
            {
                tree = tree.Left;
            }
            return tree.Key;
        }


        public int Height() {
            return Height(root);
        }

        protected int Height(Node<T> tree) {
            if (tree == null) {
                Console.WriteLine("Tree is empty");
                return 0;
            }
            else {
                int leftHeight = 0, rightHeight = 0;

                if (tree.Left != null) {
                    leftHeight = Height(tree.Left);
                }

                if (tree.Right != null) {
                    rightHeight = Height(tree.Right);
                }

                int max = 0;
                if (leftHeight > rightHeight) {
                    max = leftHeight;
                }
                else {
                    max = rightHeight;
                }

                return (max + 1);
            }
        }

        public int Count() {
            return Count(root);
        }

        private int Count(Node<T> tree) {
            if (tree == null) {
                return 0;
            }
            else {
                return Count(tree.Left) + Count(tree.Right) + 1;
            }
        }

        public Boolean Contains(T item) {
            return Contains(item, ref root);
        }

        private Boolean Contains(T item, ref Node<T> tree) {
            if (tree == null) {
                Console.WriteLine("Item (" + item + ") not found!");
                return false;
            }

            if (item.CompareTo(tree.Key) == 0) {
                Console.WriteLine("Item (" + item + ") found!");
                return true;
            }
            else if (item.CompareTo(tree.Key) < 0) {
                return Contains(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                return Contains(item, ref tree.Right);
            }
            else {
                return false;
            }
        }
    }
}
