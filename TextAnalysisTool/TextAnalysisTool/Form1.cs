using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalysisTool {
    public partial class Form1 : Form {

        OpenFileDialog ofd = new OpenFileDialog();
        char[] charsToTrim = { ' ', ',', '.', '?', ';'};


        public Form1() {
            InitializeComponent();
        }

        public int countOccurences(string w, string text) {
            string word = w.ToLower();
            string lowerText = text.ToLower();
            string[] wordsInText = lowerText.Split(charsToTrim);
            int count = 0;

            for (int i = 0; i < wordsInText.Length; i++) {
                if (word.Equals(wordsInText[i])) {
                    count++;
                } 
            }
            //Console.WriteLine("Count of " + word + "(" + count + ")");
            return count;
        }

        public List<string> removeDuplicates(string text) {
            string lowerText = text.ToLower();
            string[] wordsInText = lowerText.Split(charsToTrim);
            List<string> newList = new List<string>();

            for (int i = 0; i < wordsInText.Length; i++) {
                if(countOccurences(wordsInText[i], lowerText) == 1) {
                    newList.Add(wordsInText[i]);
                }
            }
            Console.WriteLine("New list count: "+newList.Count);
            return newList;
        }

        public string findLines(string word, string[] lines) {
            int length = lines.Length;
            string lineNumber = "";


            for (int i = 0; i < length; i++) {
                if (lines[i].Contains(word)) {
                    lineNumber = i + ",";
                }
            }
            return lineNumber;
        }

        AVLTree<Word> avl = new AVLTree<Word>();
        //WordAVL avl = new WordAVL();

        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName);
                string fileText = File.ReadAllText(fileName);
                string[] words;

                for (int i = 0; i < allLines.Length; i++) { //FOR EACH LINE
                    words = allLines[i].Split(charsToTrim);

                    for (int j = 0; j < words.Length; j++) { //FOR EACH WORD
                        if (words[j] != "") {
                            string wordToLower = words[j].ToLower();
                            Word w = new Word(wordToLower);
                            avl.InsertItem(w);

                            if (!wordsListBox.Items.Cast<Word>().Any(item => w == w)) {
                                wordsListBox.Items.Add(w);
                            }
                        }
                    }
                }

                

                string output = "";

                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;


                unqWordLabel.Text = wordsListBox.Items.Count.ToString();
                //unqWordLabel.Text = avl.Count().ToString();
                avl.PreOrder(ref output);

                
                Console.WriteLine("PreOrder AVL: " + output);
                Console.WriteLine("Nodes in tree: " + avl.Count());
            }
        }
    }
}
