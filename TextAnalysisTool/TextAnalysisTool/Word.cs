using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class Word : IComparable {
        private string word = "";
        private int occurrences = 0;
        LinkedList<Location> locations = new LinkedList<Location>();

        public Word(String word, int occurrences, LinkedList<Location> locations) {
            this.word = word;
            this.occurrences = occurrences;
            this.locations = locations;
        }

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


        public int CompareTo(object other) {
            if(other == null) {
                return 1;
            }

            return word.CompareTo(other.ToString());
        }
    }
}
