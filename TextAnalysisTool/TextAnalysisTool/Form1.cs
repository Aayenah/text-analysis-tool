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
            ofd.Filter = "Text Files|*.txt"; //filer dialog option to .txt files

            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                string fileName = ofd.FileName; 
                string[] allLines = File.ReadAllLines(fileName);
                string[] wordsArray;
                int wordCount = 0;

                for (int i = 0; i < allLines.Length; i++) //Read each line
                { 
                    wordsArray = allLines[i].Split(charsToTrim); //Split each line into words array

                    for (int j = 0; j < wordsArray.Length; j++) //Read each word in that line
                    { 
                        if (wordsArray[j] != "") 
                        {
                            //word is not empty
                            wordCount++; //Increase total word count by 1
                            Word w = new Word(wordsArray[j].ToLower()); //Create new Word object
                            if (!avl.Contains(w))
                            {
                                //AVL tree doesn't contain this word
                                avl.InsertItem(w); //Insert word to tree
                                wordsListBox.Items.Add(w); //Add word to ListBox
                            }
                            avl.GetNode(w).Key.Occurrences++; //Update word's occurrences everytime we find the same word
                            avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1)); //Add new location everytime we find the same word
                        }
                    }
                }

                //copy original data into a list
                itemsList = wordsListBox.Items.OfType<Word>().ToList();

                pathTextBox.Text = ofd.FileName; //show file path inside browse field
                filenameLabel.Text = ofd.SafeFileName; //show file name
                statusLabel.Text = "Successfully loaded: "; //TODOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
                filenameLabel.Visible = true;

                wordCountLabel.Text = "Word count: " + wordCount; //display total word count
                unqWordLabel.Text = "Unique words: "+avl.Count(); //display unique word count
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItem != null)
            {
                Node<Word> node = avl.GetNode((Word)wordsListBox.SelectedItem);
                String locations = "";

                foreach (Location loc in node.Key.Locations)
                {
                    locations += loc + " | ";
                }

                MessageBox.Show("Word: " + node.Key.TheWord +
                    "\nOccurences: " + node.Key.Occurrences +
                    "\nLocation (line, position): " + locations);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if(wordsListBox.SelectedItem != null)
            {
                Node<Word> node = avl.GetNode((Word)wordsListBox.SelectedItem);

                string locations = "";

                foreach (Location loc in node.Key.Locations)
                {
                    locations += loc + " | ";
                }

                EditForm form = new EditForm(node.Key);
                form.ShowDialog();
            }
        }

        private void delWordButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItem != null)
            {
                //if there is a selected item
                Node<Word> node = avl.GetNode((Word)wordsListBox.SelectedItem); //retrieve node containing Word
                itemsList.Remove(node.Key); //remove Word from from the copy list for GUI
                wordsListBox.Items.Remove(node.Key); //remove Word from ListBox
                avl.RemoveItem(node.Key); //remove Word from tree
                unqWordLabel.Text = "Unique words: " + avl.Count(); //update unique word counter
            }
        }

        
        private void sortOccurButton_Click(object sender, EventArgs e)
        {
            /*Implements toggle functionality to sort by ascending or descending
             depending on what the current sort is*/

            if(sortedByOccurrenceDesc == false)
            {
                //if sorted by ascedning (or not sorted because the value is initialized false at start of class)
                List<Word> descSortList = wordsListBox.Items.OfType<Word>().OrderByDescending(w => w.Occurrences).ToList(); //create temp list and sort by occurrences desc
                wordsListBox.Items.Clear(); //clear ListBox to redraw
                foreach (Word item in descSortList)
                {
                    wordsListBox.Items.Add(item);
                    Console.WriteLine(item);
                }
                sortedByOccurrenceDesc = true; //set value so when the button is pressed again it will trigger to opposite sort
            }
            else
            {
                //if already sorted by descending
                List<Word> sortList = wordsListBox.Items.OfType<Word>().OrderBy(w => w.Occurrences).ToList(); //create sorted ascending list
                wordsListBox.Items.Clear(); //clear ListBox to redraw
                foreach (Word item in sortList)
                {
                    wordsListBox.Items.Add(item);
                    Console.WriteLine(item);
                }
                sortedByOccurrenceDesc = false; //reset the value
            }
        }


        private void searchField_TextChanged(object sender, EventArgs e)
        {
            
        }

        
        private void searchField_KeyUp(object sender, KeyEventArgs e)
        {
            wordsListBox.Items.Clear(); //clear ListBox to redraw with matching items
            foreach (Word word in itemsList) //loop through the copy list
            {
                if (word.TheWord.StartsWith(searchField.Text, StringComparison.CurrentCultureIgnoreCase)) //compare word prefix and ignore case
                {
                    wordsListBox.Items.Add(word); //add words that match
                }
            }
        }

        private void occurrenceUpDown_ValueChanged(object sender, EventArgs e)
        {
            /*Triggers whenever the value changes either by up/down arrows or by entering
             value and pressing ENTER*/
            wordsListBox.Items.Clear(); //clear ListBox to redraw
            foreach (Word word in itemsList) //loop through copy list
            {
                if (word.Occurrences >= occurrenceUpDown.Value)
                {
                    wordsListBox.Items.Add(word); //add words that match criteria to ListBox
                }
            }
        }
    }
}
