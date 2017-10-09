namespace UseCase1.App.WinForms.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.createDemoDataButton = new System.Windows.Forms.Button();
            this.openFormButton = new System.Windows.Forms.Button();
            this.editSubmissionButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createDemoDataButton
            // 
            this.createDemoDataButton.Location = new System.Drawing.Point(12, 12);
            this.createDemoDataButton.Name = "createDemoDataButton";
            this.createDemoDataButton.Size = new System.Drawing.Size(122, 23);
            this.createDemoDataButton.TabIndex = 0;
            this.createDemoDataButton.Text = "Create Demo Data";
            this.createDemoDataButton.UseVisualStyleBackColor = true;
            this.createDemoDataButton.Click += new System.EventHandler(this.createDemoDataButton_Click);
            // 
            // openFormButton
            // 
            this.openFormButton.Location = new System.Drawing.Point(12, 41);
            this.openFormButton.Name = "openFormButton";
            this.openFormButton.Size = new System.Drawing.Size(122, 23);
            this.openFormButton.TabIndex = 1;
            this.openFormButton.Text = "Open Form";
            this.openFormButton.UseVisualStyleBackColor = true;
            this.openFormButton.Click += new System.EventHandler(this.openFormButton_Click);
            // 
            // editSubmissionButton
            // 
            this.editSubmissionButton.Location = new System.Drawing.Point(12, 70);
            this.editSubmissionButton.Name = "editSubmissionButton";
            this.editSubmissionButton.Size = new System.Drawing.Size(122, 23);
            this.editSubmissionButton.TabIndex = 2;
            this.editSubmissionButton.Text = "Open Submission";
            this.editSubmissionButton.UseVisualStyleBackColor = true;
            this.editSubmissionButton.Click += new System.EventHandler(this.editSubmissionButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(150, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(1019, 582);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 606);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.editSubmissionButton);
            this.Controls.Add(this.openFormButton);
            this.Controls.Add(this.createDemoDataButton);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createDemoDataButton;
        private System.Windows.Forms.Button openFormButton;
        private System.Windows.Forms.Button editSubmissionButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

