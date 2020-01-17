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
            string[] wordsInText = text.Split(charsToTrim);
            int count = 0;

            for (int i = 0; i < wordsInText.Length; i++) {
                //Console.WriteLine("FOR: "+ line[i]);
                // if match found increase count 
                if (word.Equals(wordsInText[i])) {
                    count++;
                    Console.WriteLine("HEERE");
                }
                    
            }

            return count;
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

        //AVLTree<Word> avl = new AVLTree<Word>();
        WordAVL avl = new WordAVL();

        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName);
                string fileText = File.ReadAllText(fileName);
                string[] words = new string[50000];

                for (int i = 0; i < allLines.Length; i++) { //FOR
                    words = allLines[i].Split(charsToTrim);

                    for (int j = 0; j < words.Length; j++) { //FOR 
                        if (words[j] != "") {
                            string word2 = words[j].ToLower();
                            Word w = new Word(word2);
                            
                            
                            w.Locations.AddLast(new Location(i, j));
                            //w.Occurrences = countOccurences(word2, fileText);
                            wordsListBox.Items.Add(w + "(" + w.Occurrences + ")");
                            avl.InsertItem(w);
                        }
                    }
                }
                

                //for (int i = 0; i < allLines.Length; i++) {
                //    words = fileText.Split(charsToTrim);

                //    for (int j = 0; j < words.Length; j++) {
                //        Word word = new Word(words[j], );
                //    }

                //}


                string output = "";

                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;


                //unqWordLabel.Text = wordsListBox.Items.Count.ToString();
                unqWordLabel.Text = avl.Count().ToString();
                avl.PreOrder(ref output);

                
                Console.WriteLine("PreOrder AVL: " + output);
            }
        }
    }
}
