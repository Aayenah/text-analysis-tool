using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class WordAVL : AVLTree<Word> {
        public new void InsertItem(Word item) {
            insertItem(item, ref root);
        }

        private void insertItem(Word item, ref Node<Word> tree) {
            if (tree == null) {
                tree = new Node<Word>(item);
            }
            else if (item.CompareTo(tree.Key) < 0) {
                insertItem(item, ref tree.Left);
            }
            else if (item.CompareTo(tree.Key) > 0) {
                insertItem(item, ref tree.Right);
            }
            else { //if equal
                (tree.Count)++;
                item.Occurrences++;
            }

            tree.BalanceFactor = Height(tree.Left) - Height(tree.Right);

            if (tree.BalanceFactor <= -2) {
                rotateLeft(ref tree);
            }
            if (tree.BalanceFactor >= 2) {
                rotateRight(ref tree);
            }

        }

        private void rotateLeft(ref Node<Word> tree) {
            if (tree == null) {
                return;
            }

            if (tree.Right.BalanceFactor > 0) //double rotate
            {
                rotateRight(ref tree.Right);
            }

            Node<Word> oldRoot = tree;
            Node<Word> newRoot = oldRoot.Right;

            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;

            // tree ?
            tree = newRoot;
        }

        private void rotateRight(ref Node<Word> tree) {
            if (tree == null) {
                return;
            }

            if (tree.Left.BalanceFactor < 0) //double rotate
            {
                rotateLeft(ref tree.Left);
            }

            Node<Word> oldRoot = tree;
            Node<Word> newRoot = tree.Left;

            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;
            tree = newRoot;
        }
    }
}
