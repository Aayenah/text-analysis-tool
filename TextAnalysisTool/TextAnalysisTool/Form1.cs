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

        bool sortedByOccurrenceDesc = false;

        List<Word> itemsList = new List<Word>();


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
                                avl.GetNode(w).Key.Occurrences++;
                                avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1));
                            }
                            else
                            {
                                avl.InsertItem(w);
                                avl.GetNode(w).Key.Occurrences++;
                                avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1));

                                //wordsListBox.DisplayMember = "Hello";

                                wordsListBox.Items.Add(avl.GetNode(w).Key);
                            }
                        }
                    }
                }

                itemsList = wordsListBox.Items.OfType<Word>().ToList();

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
            if (wordsListBox.SelectedItem != null)
            {
                Word w = (Word)wordsListBox.SelectedItem;
                String locations = "";

                foreach (Location loc in w.Locations)
                {
                    locations += loc + " | ";
                }

                MessageBox.Show("Word: " + w.TheWord +
                    "\nOccurences: " + w.Occurrences +
                    "\nLocation (line, position): " + locations);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(wordsListBox.SelectedItem != null)
            {
                Word w = (Word)wordsListBox.SelectedItem;
                string locations = "";

                foreach (Location loc in w.Locations)
                {
                    locations += loc + " | ";
                }

                EditForm form = new EditForm(w);
                form.ShowDialog();
            }
        }

        private void delWordButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItem != null)
            {
                Word w = (Word)wordsListBox.SelectedItem;
                avl.RemoveItem(w);
                wordsListBox.Items.Remove(w);
                unqWordLabel.Text = "Unique words: " + avl.Count();
            }
        }


        
        private void sortOccurButton_Click(object sender, EventArgs e)
        {
            if(sortedByOccurrenceDesc == false)
            {
                List<Word> descSortList = wordsListBox.Items.OfType<Word>().OrderByDescending(w => w.Occurrences).ToList();
                wordsListBox.Items.Clear();
                foreach (Word item in descSortList)
                {
                    wordsListBox.Items.Add(item);
                    Console.WriteLine(item);
                }
                sortedByOccurrenceDesc = true;
            }
            else
            {
                List<Word> sortList = wordsListBox.Items.OfType<Word>().OrderBy(w => w.Occurrences).ToList();
                wordsListBox.Items.Clear();
                foreach (Word item in sortList)
                {
                    wordsListBox.Items.Add(item);
                    Console.WriteLine(item);
                }
                sortedByOccurrenceDesc = false;
            }
            
        }


        private void searchField_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void searchField_KeyUp(object sender, KeyEventArgs e)
        {
            wordsListBox.Items.Clear();
            foreach (Word word in itemsList)
            {
                if (word.TheWord.StartsWith(searchField.Text, StringComparison.CurrentCultureIgnoreCase))
                {
                    wordsListBox.Items.Add(word);
                }
            }
        }

        private void wordSearchLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
