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
        char[] charsToTrim = { '.', ',', ' '};


        public Form1() {
            InitializeComponent();
        }

        
        private void browseButton_Click(object sender, EventArgs e) {
            ofd.Filter = "Text Files|*.txt";

            if(ofd.ShowDialog() == DialogResult.OK) {
                string fileName = ofd.FileName;
                //string[] lines = File.ReadAllLines(fileName);
                string fileText = File.ReadAllText(fileName);

                string[] words = fileText.Split(charsToTrim);

                pathTextBox.Text = ofd.FileName;
                filenameLabel.Text = ofd.SafeFileName;
                statusLabel.Text = "Successfully loaded: ";
                filenameLabel.Visible = true;

                for(int i = 0; i < words.Length; i++) {
                    wordsListBox.Items.Add(words[i]);
                }
            }
        }
    }
}
