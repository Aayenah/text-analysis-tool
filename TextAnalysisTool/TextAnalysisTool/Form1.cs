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

        AVLTree<Word> avl = new AVLTree<Word>();

        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName);
                string[] wordsArray;
                int wordCount = 0;

                for (int i = 0; i < allLines.Length; i++) { //FOR EACH LINE
                    wordsArray = allLines[i].Split(charsToTrim);

                    for (int j = 0; j < wordsArray.Length; j++) { //FOR EACH WORD
                        if (wordsArray[j] != "") {
                            wordCount++;
                            Word w = new Word(wordsArray[j].ToLower());
                            if (avl.Contains(w))
                            {
                                Console.WriteLine(w + " is already in tree");
                                avl.GetItem(w).Locations.AddLast(new Location(i + 1, j + 1));
                                Console.WriteLine(w + "Location added");
                                //w.Occurrences += 1;
                                Console.WriteLine("Occurrences increased");
                                avl.GetNode(w).Key.Occurrences++;
                                avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1));
                            }
                            else
                            {
                                avl.InsertItem(w);
                                avl.GetNode(w).Key.Occurrences++;
                                avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1));
                                wordsListBox.Items.Add(avl.GetItem(w));
                            }
                        }
                    }
                }

                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;

                wordCountLabel.Text = "Word count: " + wordCount;
                unqWordLabel.Text = "Unique words: "+avl.Count();
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
                //wordsListBox.SelectedItem = avl.GetItem((Word)wordsListBox.SelectedItem);

                //Word w = avl.GetItem((Word)wordsListBox.SelectedItem);

                Word w = (Word)wordsListBox.SelectedItem;
                String locations = "";

                foreach (Location loc in w.Locations)
                {
                    locations += loc+" | ";
                }

                MessageBox.Show("Word: "+w.TheWord+
                    "\nOccurences: "+w.Occurrences+
                    "\nLocation (line, position): " + locations); //+w.Locations.ElementAt(0)
            }
        }
    }
}
