namespace TextAnalysisTool {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.browseButton = new System.Windows.Forms.Button();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statsGroup = new System.Windows.Forms.GroupBox();
            this.wordCountLabel = new System.Windows.Forms.Label();
            this.unqWordLabel = new System.Windows.Forms.Label();
            this.loadGroup = new System.Windows.Forms.GroupBox();
            this.filenameLabel = new System.Windows.Forms.Label();
            this.mainGroup = new System.Windows.Forms.GroupBox();
            this.viewButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.wordsListLabel = new System.Windows.Forms.Label();
            this.wordsListBox = new System.Windows.Forms.ListBox();
            this.delWordButton = new System.Windows.Forms.Button();
            this.statsGroup.SuspendLayout();
            this.loadGroup.SuspendLayout();
            this.mainGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(350, 29);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(9, 30);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(335, 20);
            this.pathTextBox.TabIndex = 1;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(6, 53);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(75, 13);
            this.statusLabel.TabIndex = 3;
            this.statusLabel.Text = "No file loaded.";
            // 
            // statsGroup
            // 
            this.statsGroup.Controls.Add(this.wordCountLabel);
            this.statsGroup.Controls.Add(this.unqWordLabel);
            this.statsGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statsGroup.Location = new System.Drawing.Point(12, 12);
            this.statsGroup.Name = "statsGroup";
            this.statsGroup.Size = new System.Drawing.Size(185, 426);
            this.statsGroup.TabIndex = 5;
            this.statsGroup.TabStop = false;
            this.statsGroup.Text = "Word Stats";
            // 
            // wordCountLabel
            // 
            this.wordCountLabel.AutoSize = true;
            this.wordCountLabel.Location = new System.Drawing.Point(7, 33);
            this.wordCountLabel.Name = "wordCountLabel";
            this.wordCountLabel.Size = new System.Drawing.Size(63, 13);
            this.wordCountLabel.TabIndex = 1;
            this.wordCountLabel.Text = "Word count";
            // 
            // unqWordLabel
            // 
            this.unqWordLabel.AutoSize = true;
            this.unqWordLabel.Location = new System.Drawing.Point(7, 61);
            this.unqWordLabel.Name = "unqWordLabel";
            this.unqWordLabel.Size = new System.Drawing.Size(72, 13);
            this.unqWordLabel.TabIndex = 0;
            this.unqWordLabel.Text = "Unique words";
            // 
            // loadGroup
            // 
            this.loadGroup.Controls.Add(this.filenameLabel);
            this.loadGroup.Controls.Add(this.statusLabel);
            this.loadGroup.Controls.Add(this.browseButton);
            this.loadGroup.Controls.Add(this.pathTextBox);
            this.loadGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadGroup.Location = new System.Drawing.Point(202, 12);
            this.loadGroup.Name = "loadGroup";
            this.loadGroup.Size = new System.Drawing.Size(586, 92);
            this.loadGroup.TabIndex = 6;
            this.loadGroup.TabStop = false;
            this.loadGroup.Text = "Load File";
            // 
            // filenameLabel
            // 
            this.filenameLabel.AutoSize = true;
            this.filenameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filenameLabel.Location = new System.Drawing.Point(109, 53);
            this.filenameLabel.Name = "filenameLabel";
            this.filenameLabel.Size = new System.Drawing.Size(64, 13);
            this.filenameLabel.TabIndex = 4;
            this.filenameLabel.Text = "{filename}";
            this.filenameLabel.Visible = false;
            // 
            // mainGroup
            // 
            this.mainGroup.Controls.Add(this.delWordButton);
            this.mainGroup.Controls.Add(this.viewButton);
            this.mainGroup.Controls.Add(this.editButton);
            this.mainGroup.Controls.Add(this.wordsListLabel);
            this.mainGroup.Controls.Add(this.wordsListBox);
            this.mainGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainGroup.Location = new System.Drawing.Point(203, 110);
            this.mainGroup.Name = "mainGroup";
            this.mainGroup.Size = new System.Drawing.Size(585, 328);
            this.mainGroup.TabIndex = 6;
            this.mainGroup.TabStop = false;
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(430, 33);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(149, 23);
            this.viewButton.TabIndex = 6;
            this.viewButton.Text = "View";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(430, 62);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(149, 23);
            this.editButton.TabIndex = 5;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // wordsListLabel
            // 
            this.wordsListLabel.AutoSize = true;
            this.wordsListLabel.Location = new System.Drawing.Point(6, 16);
            this.wordsListLabel.Name = "wordsListLabel";
            this.wordsListLabel.Size = new System.Drawing.Size(75, 13);
            this.wordsListLabel.TabIndex = 5;
            this.wordsListLabel.Text = "Unique Words";
            // 
            // wordsListBox
            // 
            this.wordsListBox.FormattingEnabled = true;
            this.wordsListBox.Location = new System.Drawing.Point(8, 33);
            this.wordsListBox.Name = "wordsListBox";
            this.wordsListBox.Size = new System.Drawing.Size(416, 277);
            this.wordsListBox.TabIndex = 5;
            // 
            // delWordButton
            // 
            this.delWordButton.Location = new System.Drawing.Point(430, 120);
            this.delWordButton.Name = "delWordButton";
            this.delWordButton.Size = new System.Drawing.Size(149, 23);
            this.delWordButton.TabIndex = 7;
            this.delWordButton.Text = "Delete";
            this.delWordButton.UseVisualStyleBackColor = true;
            this.delWordButton.Click += new System.EventHandler(this.delWordButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainGroup);
            this.Controls.Add(this.loadGroup);
            this.Controls.Add(this.statsGroup);
            this.Name = "Form1";
            this.Text = "Text Analysis Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statsGroup.ResumeLayout(false);
            this.statsGroup.PerformLayout();
            this.loadGroup.ResumeLayout(false);
            this.loadGroup.PerformLayout();
            this.mainGroup.ResumeLayout(false);
            this.mainGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.GroupBox statsGroup;
        private System.Windows.Forms.Label unqWordLabel;
        private System.Windows.Forms.GroupBox loadGroup;
        private System.Windows.Forms.Label filenameLabel;
        private System.Windows.Forms.GroupBox mainGroup;
        private System.Windows.Forms.ListBox wordsListBox;
        private System.Windows.Forms.Label wordsListLabel;
        private System.Windows.Forms.Label wordCountLabel;
        private System.Windows.Forms.Button viewButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button delWordButton;
    }
}

