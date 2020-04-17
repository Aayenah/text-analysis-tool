namespace TextAnalysisTool
{
    partial class EditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wLabel = new System.Windows.Forms.Label();
            this.modButton = new System.Windows.Forms.Button();
            this.numericField = new System.Windows.Forms.NumericUpDown();
            this.delLocationButton = new System.Windows.Forms.Button();
            this.addLocationButton = new System.Windows.Forms.Button();
            this.numericLine = new System.Windows.Forms.NumericUpDown();
            this.numericPos = new System.Windows.Forms.NumericUpDown();
            this.lineLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Word: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Occurrences: ";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 155);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(143, 160);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Locations (Line, Position) ";
            // 
            // wLabel
            // 
            this.wLabel.AutoSize = true;
            this.wLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wLabel.Location = new System.Drawing.Point(61, 47);
            this.wLabel.Name = "wLabel";
            this.wLabel.Size = new System.Drawing.Size(38, 13);
            this.wLabel.TabIndex = 5;
            this.wLabel.Text = "{word}";
            // 
            // modButton
            // 
            this.modButton.Location = new System.Drawing.Point(178, 83);
            this.modButton.Name = "modButton";
            this.modButton.Size = new System.Drawing.Size(137, 23);
            this.modButton.TabIndex = 7;
            this.modButton.Text = "Modify";
            this.modButton.UseVisualStyleBackColor = true;
            this.modButton.Click += new System.EventHandler(this.modButton_Click);
            // 
            // numericField
            // 
            this.numericField.Location = new System.Drawing.Point(98, 84);
            this.numericField.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericField.Name = "numericField";
            this.numericField.Size = new System.Drawing.Size(74, 20);
            this.numericField.TabIndex = 8;
            this.numericField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // delLocationButton
            // 
            this.delLocationButton.Location = new System.Drawing.Point(178, 292);
            this.delLocationButton.Name = "delLocationButton";
            this.delLocationButton.Size = new System.Drawing.Size(137, 23);
            this.delLocationButton.TabIndex = 9;
            this.delLocationButton.Text = "Delete";
            this.delLocationButton.UseVisualStyleBackColor = true;
            this.delLocationButton.Click += new System.EventHandler(this.delLocationButton_Click);
            // 
            // addLocationButton
            // 
            this.addLocationButton.Location = new System.Drawing.Point(240, 173);
            this.addLocationButton.Name = "addLocationButton";
            this.addLocationButton.Size = new System.Drawing.Size(75, 60);
            this.addLocationButton.TabIndex = 10;
            this.addLocationButton.Text = "Add Location";
            this.addLocationButton.UseVisualStyleBackColor = true;
            this.addLocationButton.Click += new System.EventHandler(this.addLocationButton_Click);
            // 
            // numericLine
            // 
            this.numericLine.Location = new System.Drawing.Point(178, 173);
            this.numericLine.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericLine.Name = "numericLine";
            this.numericLine.Size = new System.Drawing.Size(56, 20);
            this.numericLine.TabIndex = 11;
            this.numericLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericPos
            // 
            this.numericPos.Location = new System.Drawing.Point(178, 213);
            this.numericPos.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericPos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericPos.Name = "numericPos";
            this.numericPos.Size = new System.Drawing.Size(56, 20);
            this.numericPos.TabIndex = 12;
            this.numericPos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lineLabel
            // 
            this.lineLabel.AutoSize = true;
            this.lineLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lineLabel.Location = new System.Drawing.Point(175, 157);
            this.lineLabel.Name = "lineLabel";
            this.lineLabel.Size = new System.Drawing.Size(27, 13);
            this.lineLabel.TabIndex = 13;
            this.lineLabel.Text = "Line";
            // 
            // positionLabel
            // 
            this.positionLabel.AutoSize = true;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.positionLabel.Location = new System.Drawing.Point(175, 197);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(44, 13);
            this.positionLabel.TabIndex = 14;
            this.positionLabel.Text = "Position";
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 334);
            this.Controls.Add(this.positionLabel);
            this.Controls.Add(this.lineLabel);
            this.Controls.Add(this.numericPos);
            this.Controls.Add(this.numericLine);
            this.Controls.Add(this.addLocationButton);
            this.Controls.Add(this.delLocationButton);
            this.Controls.Add(this.numericField);
            this.Controls.Add(this.modButton);
            this.Controls.Add(this.wLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)(this.numericField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label wLabel;
        private System.Windows.Forms.Button modButton;
        private System.Windows.Forms.NumericUpDown numericField;
        private System.Windows.Forms.Button delLocationButton;
        private System.Windows.Forms.Button addLocationButton;
        private System.Windows.Forms.NumericUpDown numericLine;
        private System.Windows.Forms.NumericUpDown numericPos;
        private System.Windows.Forms.Label lineLabel;
        private System.Windows.Forms.Label positionLabel;
    }
}