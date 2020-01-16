using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class Node<T> where T : IComparable {
        private T key;
        private int count;
        public Node<T> Left, Right;
        private int balanceFactor = 0;

        public Node(T item) {
            key = item;
            Left = null;
            Right = null;
            count = 1;
        }
        public T Key {
            set { key = value; }
            get { return key; }
        }
        public int BalanceFactor {
            set { balanceFactor = value; }
            get { return balanceFactor; }
        }
        public int Count {
            set { count = value; }
            get { return count; }
        }
    }
}
