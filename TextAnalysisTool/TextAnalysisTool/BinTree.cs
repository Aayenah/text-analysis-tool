using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class BinTree<T> where T : IComparable {
        public Node<T> root;
        public BinTree()  //creates an empty tree
        {
            root = null;
        }
        public BinTree(Node<T> node)  //creates a tree with node as the root
        {
            root = node;
        }

        public void PreOrder(ref string buffer) {
            PreOrder(root, ref buffer);
        }

        public void PreOrder(Node<T> tree, ref string buffer) {
            if (tree != null) {
                buffer += tree.Key.ToString() +"("+tree.Count+")"+ ",";
                PreOrder(tree.Left, ref buffer);
                PreOrder(tree.Right, ref buffer);
            }
        }

        public void InOrder(ref string buffer) {
            InOrder(root, ref buffer);
        }

        public void InOrder(Node<T> tree, ref string buffer) {
            if (tree != null) {
                InOrder(tree.Left, ref buffer);
                buffer += tree.Key.ToString() + ",";
                InOrder(tree.Right, ref buffer);
            }
        }


        public void PostOrder(ref string buffer) {
            PostOrder(root, ref buffer);
        }

        public void PostOrder(Node<T> tree, ref string buffer) {
            if (tree != null) {
                PostOrder(tree.Left, ref buffer);
                PostOrder(tree.Right, ref buffer);
                buffer += tree.Key.ToString() + ",";
            }
        }
    }
}
