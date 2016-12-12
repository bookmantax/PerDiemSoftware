namespace ExcelTest2
{
    partial class Form1
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runButton = new System.Windows.Forms.Button();
            this.perdiemAmount = new System.Windows.Forms.Label();
            this.totalDaysLabel = new System.Windows.Forms.Label();
            this.daysForMonthLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.homeAirportTextBox = new System.Windows.Forms.TextBox();
            this.totalLayoversLabel = new System.Windows.Forms.Label();
            this.daysForMonthLabel2 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.yearComboBox = new System.Windows.Forms.ComboBox();
            this.shuttleFeeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(80, 24);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(294, 20);
            this.filePathTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Path";
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(349, 139);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 2;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // perdiemAmount
            // 
            this.perdiemAmount.AutoSize = true;
            this.perdiemAmount.Location = new System.Drawing.Point(119, 109);
            this.perdiemAmount.Name = "perdiemAmount";
            this.perdiemAmount.Size = new System.Drawing.Size(0, 13);
            this.perdiemAmount.TabIndex = 3;
            // 
            // totalDaysLabel
            // 
            this.totalDaysLabel.AutoSize = true;
            this.totalDaysLabel.Location = new System.Drawing.Point(217, 109);
            this.totalDaysLabel.Name = "totalDaysLabel";
            this.totalDaysLabel.Size = new System.Drawing.Size(0, 13);
            this.totalDaysLabel.TabIndex = 8;
            // 
            // daysForMonthLabel
            // 
            this.daysForMonthLabel.AutoSize = true;
            this.daysForMonthLabel.Location = new System.Drawing.Point(12, 206);
            this.daysForMonthLabel.Name = "daysForMonthLabel";
            this.daysForMonthLabel.Size = new System.Drawing.Size(0, 13);
            this.daysForMonthLabel.TabIndex = 9;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(376, 123);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(0, 13);
            this.errorLabel.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Home Airport:";
            // 
            // homeAirportTextBox
            // 
            this.homeAirportTextBox.Location = new System.Drawing.Point(80, 50);
            this.homeAirportTextBox.Name = "homeAirportTextBox";
            this.homeAirportTextBox.Size = new System.Drawing.Size(84, 20);
            this.homeAirportTextBox.TabIndex = 28;
            // 
            // totalLayoversLabel
            // 
            this.totalLayoversLabel.AutoSize = true;
            this.totalLayoversLabel.Location = new System.Drawing.Point(369, 109);
            this.totalLayoversLabel.Name = "totalLayoversLabel";
            this.totalLayoversLabel.Size = new System.Drawing.Size(0, 13);
            this.totalLayoversLabel.TabIndex = 29;
            // 
            // daysForMonthLabel2
            // 
            this.daysForMonthLabel2.AutoSize = true;
            this.daysForMonthLabel2.Location = new System.Drawing.Point(12, 236);
            this.daysForMonthLabel2.Name = "daysForMonthLabel2";
            this.daysForMonthLabel2.Size = new System.Drawing.Size(0, 13);
            this.daysForMonthLabel2.TabIndex = 30;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(380, 22);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 23);
            this.clearButton.TabIndex = 31;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Year";
            // 
            // yearComboBox
            // 
            this.yearComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yearComboBox.FormattingEnabled = true;
            this.yearComboBox.Items.AddRange(new object[] {
            "2014",
            "2015",
            "2016",
            "2017",
            "2018"});
            this.yearComboBox.Location = new System.Drawing.Point(215, 51);
            this.yearComboBox.Name = "yearComboBox";
            this.yearComboBox.Size = new System.Drawing.Size(121, 21);
            this.yearComboBox.TabIndex = 33;
            // 
            // shuttleFeeLabel
            // 
            this.shuttleFeeLabel.AutoSize = true;
            this.shuttleFeeLabel.Location = new System.Drawing.Point(494, 109);
            this.shuttleFeeLabel.Name = "shuttleFeeLabel";
            this.shuttleFeeLabel.Size = new System.Drawing.Size(0, 13);
            this.shuttleFeeLabel.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 406);
            this.Controls.Add(this.shuttleFeeLabel);
            this.Controls.Add(this.yearComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.daysForMonthLabel2);
            this.Controls.Add(this.totalLayoversLabel);
            this.Controls.Add(this.homeAirportTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.daysForMonthLabel);
            this.Controls.Add(this.totalDaysLabel);
            this.Controls.Add(this.perdiemAmount);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label perdiemAmount;
        private System.Windows.Forms.Label totalDaysLabel;
        private System.Windows.Forms.Label daysForMonthLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox homeAirportTextBox;
        private System.Windows.Forms.Label totalLayoversLabel;
        private System.Windows.Forms.Label daysForMonthLabel2;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox yearComboBox;
        private System.Windows.Forms.Label shuttleFeeLabel;
    }
}

