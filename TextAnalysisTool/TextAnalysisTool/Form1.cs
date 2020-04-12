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

        public int countOccurences(string w, string[] arr) {
            string word = w.ToLower();

            int count = 0;

            for (int i = 0; i < arr.Length; i++) {
                string lower = arr[i].ToLower();
                if (word.Equals(lower)) {
                    count++;
                } 
            }
            Console.WriteLine("Count of " + word + "(" + count + ")");
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

        AVLTree<Word> avl = new AVLTree<Word>();
        List<Word> myList = new List<Word>();
        List<string> stringList = new List<string>();

        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName);
                string[] wordsArray;

                for (int i = 0; i < allLines.Length; i++) { //FOR EACH LINE
                    wordsArray = allLines[i].Split(charsToTrim);

                    for (int j = 0; j < wordsArray.Length; j++) { //FOR EACH WORD
                        if (wordsArray[j] != "") {
                            Word w = new Word(wordsArray[j].ToLower());
                            w.Locations.AddLast(new Location(i+1, j+1));
                            avl.InsertItem(w);
                            myList.Add(w);
                        }
                    }
                }

                foreach (Word word in myList)
                {
                    if (!wordsListBox.Items.Contains(word))
                    {
                        wordsListBox.Items.Add(word);
                        foreach(Location loc in word.Locations)
                        {
                            Console.WriteLine(word+"----"+loc + " | ");
                        }
                    }
                    else
                    {
                        //avl.GetItem(word).Locations.AddLast(new Location(7, 7));
                    }
                    
                    //wordsListBox.Items.Add(word);
                    word.Occurrences = avl.GetNode(word).Count;
                }

                string output = "";

                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;

                wordCountLabel.Text = "Word count: " + myList.Count();
                unqWordLabel.Text = "Unique words: "+wordsListBox.Items.Count;
                
                avl.PreOrder(ref output);

                
                //Console.WriteLine("PreOrder AVL: " + output);
                //Console.WriteLine("Nodes in tree: " + avl.Count());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItems.Count == 0)
            {
                unqWordLabel.Text = "No";
            }
            else
            {
                Word w = avl.GetItem((Word)wordsListBox.SelectedItem);
                MessageBox.Show("Word: "+w.TheWord+
                    "\nOccurences: "+w.Occurrences+
                    "\nLocation (line, position): "+w.Locations.ElementAt(0));
            }
        }
    }
}
