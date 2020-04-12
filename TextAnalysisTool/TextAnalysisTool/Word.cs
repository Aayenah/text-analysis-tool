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

        public LinkedList<Location> Locations {
            get {
                if (locations == null) {
                    return new LinkedList<Location>();
                }
                return locations;
            }
            set {
                locations = value;
            }
        }


        public int CompareTo(object obj) {
            Word other = (Word) obj;
            
            if(other == null) {
                return 1;
            }

            return this.word.CompareTo(other.word);
        }

        public override bool Equals(object obj)
        {
            return this.ToString().Equals(obj.ToString());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }


        public override string ToString() {
            return word;// +" ("+occurrences+")";
        }
    }
}
