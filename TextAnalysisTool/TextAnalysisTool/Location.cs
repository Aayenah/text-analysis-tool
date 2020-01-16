using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysisTool {
    class Location {
        private int lineNumber = 0;
        private int wordPosition = 0;


        public int LineNumber {
            set { lineNumber = value; }
            get { return lineNumber; }
        }

        public int WordPosition {
            set { wordPosition = value; }
            get { return wordPosition; }
        }
    }
}
