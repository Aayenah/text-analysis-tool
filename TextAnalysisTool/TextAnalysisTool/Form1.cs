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
        char[] charsToTrim = { ' ', ',', '.', '?', ';', '\t'}; //selection of characters to trim

        bool sortedByOccurrenceDesc = false; //used to track the sort by occurrences state

        AVLTree<Word> avl = new AVLTree<Word>(); //initialize AVL tree
        List<Word> itemsList = new List<Word>(); //initialize a list that will hold a copy of ListBox


        public Form1() {
            InitializeComponent();
        }

        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt"; //filer dialog option to .txt files only

            if(ofd.ShowDialog() == DialogResult.OK) 
            {
                /*First we need to check that we don't already have data
                 loaded from before, otherwise the user can load multiple
                 files into the data structure and listbox*/
                if (wordsListBox.Items.Count > 0) //if items already exist after we press OK in dialog
                {
                    foreach (Word item in wordsListBox.Items)
                    {
                        avl.RemoveItem(item); //remove item from tree
                    }
                    wordsListBox.Items.Clear(); //remove all items from listbox
                }

                string fileName = ofd.FileName;
                string[] allLines = File.ReadAllLines(fileName); //store each line as an array element
                string[] wordsArray; //declare an array to hold individual words
                int wordCount = 0;

                for (int i = 0; i < allLines.Length; i++) //Read each line
                { 
                    wordsArray = allLines[i].Split(charsToTrim); //Split each line into words array

                    for (int j = 0; j < wordsArray.Length; j++) //Read each word in that line
                    { 
                        if (wordsArray[j] != "") //if word is not an empty string
                        {   
                            //word is not empty
                            wordCount++; //Increase total word count by 1
                            Word w = new Word(wordsArray[j].ToLower()); //Create new Word object
                            if (!avl.Contains(w)) //if AVL tree doesn't contain this word
                            {
                                avl.InsertItem(w); //Insert word to tree
                                wordsListBox.Items.Add(w); //Add word to ListBox
                            }
                            avl.GetNode(w).Key.Occurrences++; //Update word's occurrences everytime we find the same word
                            avl.GetNode(w).Key.Locations.AddLast(new Location(i + 1, j + 1)); //Add new location everytime we find the same word
                        }
                    }
                }

                itemsList = wordsListBox.Items.OfType<Word>().ToList(); //copy original data into a list

                pathTextBox.Text = ofd.FileName; //show file path inside browse field
                filenameLabel.Text = ofd.SafeFileName; //show file name
                statusLabel.Text = "Successfully loaded: "; //set file status label
                filenameLabel.Visible = true; //show filename label

                ///*WORD STATS*///
                wordCountLabel.Text = "Word count: " + wordCount; //display total word count
                unqWordLabel.Text = "Unique words: "+avl.Count(); //display unique word count
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItem != null && wordsListBox.SelectedItems.Count == 1)
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
            if(wordsListBox.SelectedItem != null && wordsListBox.SelectedItems.Count == 1)
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
            if (wordsListBox.SelectedItem != null && wordsListBox.SelectedItems.Count == 1)
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

        private void concordanceButton_Click(object sender, EventArgs e)
        {
            List<Word> concorList = wordsListBox.Items.OfType<Word>().OrderBy(w => w.TheWord).ToList();

            wordsListBox.Items.Clear(); //clear ListBox to redraw
            foreach (Word word in concorList) //loop through concordance list
            {
                wordsListBox.Items.Add(word);
            }
        }

        private void mostCommonButton_Click(object sender, EventArgs e)
        {
            List<Word> tempList = wordsListBox.Items.OfType<Word>().OrderByDescending(w => w.Occurrences).ToList();
            if (tempList.Count > 0)
            {
                int index = wordsListBox.Items.IndexOf(tempList.ElementAt(0));
                wordsListBox.ClearSelected();
                wordsListBox.SetSelected(index, true);
            }
        }

        private void adjButton_Click(object sender, EventArgs e)
        {
            /*This method was created because I initially misunderstood Task 9, somehow.
             It just displays the child nodes of a selected word from the tree*/
            if(wordsListBox.SelectedItem != null && wordsListBox.SelectedItems.Count == 1)
            {
                Word word = (Word)wordsListBox.SelectedItem;
                string adjNodes = "";
                foreach (Node<Word> node in avl.GetChildNodes(word))
                {
                    adjNodes += node.Key + " | ";
                }
                MessageBox.Show("Child nodes: "+adjNodes);
            }
        }

        private void collocButton_Click(object sender, EventArgs e)
        {
            if (wordsListBox.SelectedItems.Count == 2) //must have 2 selected items 
            {
                List<Word> selectedWords = wordsListBox.SelectedItems.OfType<Word>().ToList(); //place the two words in list for easier access
                int adjCount = 0; //counter for humber of times words appeared next to each other

                foreach (Location word1Loc in avl.GetNode(selectedWords.ElementAt(0)).Key.Locations) //for each Location of Word1
                {
                    foreach (Location word2Loc in avl.GetNode(selectedWords.ElementAt(1)).Key.Locations) //loop through each Location of Word2
                    {
                        if(word1Loc.LineNumber == word2Loc.LineNumber) //words must exist on same line
                        {
                            if(word2Loc.WordPosition - word1Loc.WordPosition == 1) //if the difference of position is 1 it means they're adjacent
                            {
                                Console.WriteLine(word1Loc + " and " + word2Loc + " are adjacent");
                                adjCount++; //increment count
                            }
                        }
                    }
                }
                countTextBox.Text = adjCount.ToString(); //display count in text box
            }
        }

        private void wordsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(wordsListBox.SelectedItems.Count == 1) //if one element selected
            {
                //set text box value to selected item
                word1TextBox.Text = wordsListBox.SelectedItems.OfType<Word>().ElementAt(0).ToString();
                countTextBox.Text = "";
            }
            else if (wordsListBox.SelectedItems.Count == 2) //if two elements selected
            {
                //set text box values to selected items
                word1TextBox.Text = wordsListBox.SelectedItems.OfType<Word>().ElementAt(0).ToString();
                word2TextBox.Text = wordsListBox.SelectedItems.OfType<Word>().ElementAt(1).ToString();
            }
            else if (wordsListBox.SelectedItems.Count > 2) //if more than two elements selected
            {
                //Clear selected items and text boxes
                wordsListBox.ClearSelected();
                word1TextBox.Text = "";
                word2TextBox.Text = "";
                countTextBox.Text = "";
            }
            else
            {
                word1TextBox.Text = "";
                word2TextBox.Text = "";
                countTextBox.Text = "";
            }
        }
    }
}
