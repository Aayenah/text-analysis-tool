using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextAnalysisTool
{
    public partial class EditForm : Form
    {
        Word word;
        public EditForm(Word w) //string word, int occur, LinkedList<Location> loc
        {
            InitializeComponent();
            wLabel.Text = w.TheWord;
            numericField.Value = w.Occurrences;

            foreach (Location l in w.Locations)
            {
                listBox1.Items.Add(l);
            }
            word = w;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modButton_Click(object sender, EventArgs e)
        {
            word.Occurrences = Convert.ToInt32(Math.Round(numericField.Value, 0));
        }

        private void delLocationButton_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                Location loc = (Location)listBox1.SelectedItem;
                word.Locations.Remove(loc);
                listBox1.Items.Remove(loc);
            }
        }

        private void addLocationButton_Click(object sender, EventArgs e)
        {
            int line = Convert.ToInt32(Math.Round(numericLine.Value, 0));
            int position = Convert.ToInt32(Math.Round(numericPos.Value, 0));
            Location loc = new Location(line, position);
            word.Locations.AddLast(loc);
            listBox1.Items.Add(loc);
        }
    }
}
