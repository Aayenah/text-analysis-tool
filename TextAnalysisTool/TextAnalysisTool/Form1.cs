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
        char[] charsToTrim = { ' ', ',', '.', '?', ';', '\n'};


        public Form1() {
            InitializeComponent();
        }

        public int findCount(string word, string[] wordsArray) {
            int length = wordsArray.Length;
            int count = 0;

            for (int i = 0; i < length; i++) {
                if (wordsArray[i].Equals(word)) {
                    count++;
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



        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName);
                string fileText = File.ReadAllText(fileName);
                int wordCount = 0;
                string[] words = new string[allLines.Length];

                foreach (string line in allLines) {
                    words = fileText.Split(charsToTrim);
                    
                }

                foreach (string word in words) {
                    if (word != "") {
                        string word2 = word.ToLower();
                        int count = findCount(word2, words);
                        wordsListBox.Items.Add(word2+" | "+count+" | "+findLines(word2, allLines));
                        Word w = new Word(word2);
                    }
                }

                //for (int i = 0; i < allLines.Length; i++) {
                //    words = fileText.Split(charsToTrim);

                //    for (int j = 0; j < words.Length; j++) {
                //        Word word = new Word(words[j], );
                //    }

                //}




                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;



                //unqWordLabel.Text = wordsListBox.Items.Count.ToString();
                unqWordLabel.Text = allLines.Length.ToString();
            }
        }
    }
}
