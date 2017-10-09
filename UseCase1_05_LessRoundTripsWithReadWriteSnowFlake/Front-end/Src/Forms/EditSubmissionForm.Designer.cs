namespace UseCase1.App.WinForms.Forms
{
    partial class EditSubmissionForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.submissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.formTextBox = new System.Windows.Forms.TextBox();
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.inputsGrid = new System.Windows.Forms.DataGridView();
            this.inputsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.closeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.submissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Customer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Form";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Date";
            // 
            // submissionBindingSource
            // 
            this.submissionBindingSource.DataSource = typeof(UseCase1.Submission);
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(74, 12);
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.ReadOnly = true;
            this.customerTextBox.Size = new System.Drawing.Size(250, 20);
            this.customerTextBox.TabIndex = 4;
            // 
            // formTextBox
            // 
            this.formTextBox.Location = new System.Drawing.Point(74, 38);
            this.formTextBox.Name = "formTextBox";
            this.formTextBox.ReadOnly = true;
            this.formTextBox.Size = new System.Drawing.Size(250, 20);
            this.formTextBox.TabIndex = 5;
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(411, 12);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.ReadOnly = true;
            this.dateTextBox.Size = new System.Drawing.Size(250, 20);
            this.dateTextBox.TabIndex = 6;
            // 
            // inputsGrid
            // 
            this.inputsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputsGrid.AutoGenerateColumns = false;
            this.inputsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inputsGrid.DataSource = this.inputsBindingSource;
            this.inputsGrid.Location = new System.Drawing.Point(74, 64);
            this.inputsGrid.Name = "inputsGrid";
            this.inputsGrid.RowHeadersVisible = false;
            this.inputsGrid.Size = new System.Drawing.Size(586, 218);
            this.inputsGrid.TabIndex = 7;
            this.inputsGrid.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.inputsGrid_DefaultValuesNeeded);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(585, 379);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(504, 379);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Inputs";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Comments";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.submissionBindingSource, "Comments", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.textBox4.Location = new System.Drawing.Point(74, 288);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox4.Size = new System.Drawing.Size(586, 78);
            this.textBox4.TabIndex = 12;
            // 
            // groupTextBox
            // 
            this.groupTextBox.Location = new System.Drawing.Point(411, 38);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.ReadOnly = true;
            this.groupTextBox.Size = new System.Drawing.Size(250, 20);
            this.groupTextBox.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(369, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Group";
            // 
            // EditSubmissionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 414);
            this.Controls.Add(this.groupTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.inputsGrid);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.formTextBox);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditSubmissionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Submission";
            this.Shown += new System.EventHandler(this.EditSubmissionForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.submissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource submissionBindingSource;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.TextBox formTextBox;
        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.DataGridView inputsGrid;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource inputsBindingSource;
    }
}