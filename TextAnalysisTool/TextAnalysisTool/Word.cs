using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class Word {
        private string word = "";
        private int occurrences = 0;
        LinkedList<Location> locations = new LinkedList<Location>();

        public Word(String word) {
            this.word = word;
        }


        public string TheWord {
            set { word = value; }
            get { return word; }
        }

        public int Occurrences {
            set { occurrences = value; }
            get { return occurrences; }
        }
    }
}
