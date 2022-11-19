namespace CourseWork
{
    partial class SettingsWindow
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
            this.typesListBox = new System.Windows.Forms.ListBox();
            this.savetypeButton = new System.Windows.Forms.Button();
            this.deleteTypeButton = new System.Windows.Forms.Button();
            this.typeTextBox = new System.Windows.Forms.TextBox();
            this.specsListBox = new System.Windows.Forms.ListBox();
            this.specTextBox = new System.Windows.Forms.TextBox();
            this.saveSpecButton = new System.Windows.Forms.Button();
            this.deleteSpecButton = new System.Windows.Forms.Button();
            this.typesPanel = new System.Windows.Forms.Panel();
            this.typeCancelButton = new System.Windows.Forms.Button();
            this.specsPanel = new System.Windows.Forms.Panel();
            this.specCancelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.typesPanel.SuspendLayout();
            this.specsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // typesListBox
            // 
            this.typesListBox.FormattingEnabled = true;
            this.typesListBox.Location = new System.Drawing.Point(3, 3);
            this.typesListBox.Name = "typesListBox";
            this.typesListBox.Size = new System.Drawing.Size(238, 173);
            this.typesListBox.TabIndex = 0;
            this.typesListBox.SelectedIndexChanged += new System.EventHandler(this.typesListBox_SelectedIndexChanged);
            // 
            // savetypeButton
            // 
            this.savetypeButton.Location = new System.Drawing.Point(3, 208);
            this.savetypeButton.Name = "savetypeButton";
            this.savetypeButton.Size = new System.Drawing.Size(75, 23);
            this.savetypeButton.TabIndex = 1;
            this.savetypeButton.Text = "Save/Add";
            this.savetypeButton.UseVisualStyleBackColor = true;
            this.savetypeButton.Click += new System.EventHandler(this.savetypeButton_Click);
            // 
            // deleteTypeButton
            // 
            this.deleteTypeButton.Location = new System.Drawing.Point(84, 208);
            this.deleteTypeButton.Name = "deleteTypeButton";
            this.deleteTypeButton.Size = new System.Drawing.Size(75, 23);
            this.deleteTypeButton.TabIndex = 2;
            this.deleteTypeButton.Text = "Delete";
            this.deleteTypeButton.UseVisualStyleBackColor = true;
            this.deleteTypeButton.Click += new System.EventHandler(this.deleteTypeButton_Click);
            // 
            // typeTextBox
            // 
            this.typeTextBox.Location = new System.Drawing.Point(3, 182);
            this.typeTextBox.Name = "typeTextBox";
            this.typeTextBox.Size = new System.Drawing.Size(238, 20);
            this.typeTextBox.TabIndex = 3;
            // 
            // specsListBox
            // 
            this.specsListBox.FormattingEnabled = true;
            this.specsListBox.Location = new System.Drawing.Point(3, 3);
            this.specsListBox.Name = "specsListBox";
            this.specsListBox.Size = new System.Drawing.Size(482, 173);
            this.specsListBox.TabIndex = 4;
            // 
            // specTextBox
            // 
            this.specTextBox.Location = new System.Drawing.Point(3, 182);
            this.specTextBox.Name = "specTextBox";
            this.specTextBox.Size = new System.Drawing.Size(482, 20);
            this.specTextBox.TabIndex = 5;
            // 
            // saveSpecButton
            // 
            this.saveSpecButton.Location = new System.Drawing.Point(7, 208);
            this.saveSpecButton.Name = "saveSpecButton";
            this.saveSpecButton.Size = new System.Drawing.Size(75, 23);
            this.saveSpecButton.TabIndex = 6;
            this.saveSpecButton.Text = "Save/Add";
            this.saveSpecButton.UseVisualStyleBackColor = true;
            this.saveSpecButton.Click += new System.EventHandler(this.saveSpecButton_Click);
            // 
            // deleteSpecButton
            // 
            this.deleteSpecButton.Location = new System.Drawing.Point(88, 208);
            this.deleteSpecButton.Name = "deleteSpecButton";
            this.deleteSpecButton.Size = new System.Drawing.Size(75, 23);
            this.deleteSpecButton.TabIndex = 7;
            this.deleteSpecButton.Text = "Delete";
            this.deleteSpecButton.UseVisualStyleBackColor = true;
            this.deleteSpecButton.Click += new System.EventHandler(this.deleteSpecButton_Click);
            // 
            // typesPanel
            // 
            this.typesPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.typesPanel.Controls.Add(this.typeCancelButton);
            this.typesPanel.Controls.Add(this.typesListBox);
            this.typesPanel.Controls.Add(this.typeTextBox);
            this.typesPanel.Controls.Add(this.savetypeButton);
            this.typesPanel.Controls.Add(this.deleteTypeButton);
            this.typesPanel.Location = new System.Drawing.Point(3, 23);
            this.typesPanel.Name = "typesPanel";
            this.typesPanel.Size = new System.Drawing.Size(246, 237);
            this.typesPanel.TabIndex = 8;
            // 
            // typeCancelButton
            // 
            this.typeCancelButton.Location = new System.Drawing.Point(166, 208);
            this.typeCancelButton.Name = "typeCancelButton";
            this.typeCancelButton.Size = new System.Drawing.Size(75, 23);
            this.typeCancelButton.TabIndex = 4;
            this.typeCancelButton.Text = "Cancel";
            this.typeCancelButton.UseVisualStyleBackColor = true;
            this.typeCancelButton.Click += new System.EventHandler(this.typeCancelButton_Click);
            // 
            // specsPanel
            // 
            this.specsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.specsPanel.Controls.Add(this.specCancelButton);
            this.specsPanel.Controls.Add(this.specsListBox);
            this.specsPanel.Controls.Add(this.specTextBox);
            this.specsPanel.Controls.Add(this.saveSpecButton);
            this.specsPanel.Controls.Add(this.deleteSpecButton);
            this.specsPanel.Enabled = false;
            this.specsPanel.Location = new System.Drawing.Point(251, 23);
            this.specsPanel.Name = "specsPanel";
            this.specsPanel.Size = new System.Drawing.Size(415, 237);
            this.specsPanel.TabIndex = 9;
            // 
            // specCancelButton
            // 
            this.specCancelButton.Location = new System.Drawing.Point(170, 208);
            this.specCancelButton.Name = "specCancelButton";
            this.specCancelButton.Size = new System.Drawing.Size(75, 23);
            this.specCancelButton.TabIndex = 8;
            this.specCancelButton.Text = "Cancel";
            this.specCancelButton.UseVisualStyleBackColor = true;
            this.specCancelButton.Click += new System.EventHandler(this.specCancelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Variable types";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(248, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Type specification";
            // 
            // SettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 262);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.specsPanel);
            this.Controls.Add(this.typesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindow";
            this.Text = "SettingsWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SettingsWindow_FormClosing);
            this.typesPanel.ResumeLayout(false);
            this.typesPanel.PerformLayout();
            this.specsPanel.ResumeLayout(false);
            this.specsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox typesListBox;
        private System.Windows.Forms.Button savetypeButton;
        private System.Windows.Forms.Button deleteTypeButton;
        private System.Windows.Forms.TextBox typeTextBox;
        private System.Windows.Forms.ListBox specsListBox;
        private System.Windows.Forms.TextBox specTextBox;
        private System.Windows.Forms.Button saveSpecButton;
        private System.Windows.Forms.Button deleteSpecButton;
        private System.Windows.Forms.Panel typesPanel;
        private System.Windows.Forms.Panel specsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button typeCancelButton;
        private System.Windows.Forms.Button specCancelButton;
    }
}