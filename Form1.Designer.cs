namespace ExcelComparator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonDown1 = new System.Windows.Forms.Button();
            this.buttonUp1 = new System.Windows.Forms.Button();
            this.buttonRemove1 = new System.Windows.Forms.Button();
            this.buttonAdd1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonDown2 = new System.Windows.Forms.Button();
            this.buttonUp2 = new System.Windows.Forms.Button();
            this.buttonRemove2 = new System.Windows.Forms.Button();
            this.buttonAdd2 = new System.Windows.Forms.Button();
            this.buttonCompare = new System.Windows.Forms.Button();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(25, 36);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(510, 404);
            this.listBox1.TabIndex = 0;
            this.listBox1.Tag = "";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(26, 36);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox2.Size = new System.Drawing.Size(510, 404);
            this.listBox2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonDown1);
            this.groupBox1.Controls.Add(this.buttonUp1);
            this.groupBox1.Controls.Add(this.buttonRemove1);
            this.groupBox1.Controls.Add(this.buttonAdd1);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(561, 520);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Old Files";
            // 
            // buttonDown1
            // 
            this.buttonDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDown1.Location = new System.Drawing.Point(482, 446);
            this.buttonDown1.Name = "buttonDown1";
            this.buttonDown1.Size = new System.Drawing.Size(53, 53);
            this.buttonDown1.TabIndex = 4;
            this.buttonDown1.Text = "▼";
            this.buttonDown1.UseVisualStyleBackColor = true;
            this.buttonDown1.Click += new System.EventHandler(this.buttonDown1_Click);
            // 
            // buttonUp1
            // 
            this.buttonUp1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonUp1.Location = new System.Drawing.Point(423, 446);
            this.buttonUp1.Name = "buttonUp1";
            this.buttonUp1.Size = new System.Drawing.Size(53, 53);
            this.buttonUp1.TabIndex = 3;
            this.buttonUp1.Text = "▲";
            this.buttonUp1.UseVisualStyleBackColor = true;
            this.buttonUp1.Click += new System.EventHandler(this.buttonUp1_Click);
            // 
            // buttonRemove1
            // 
            this.buttonRemove1.Location = new System.Drawing.Point(199, 446);
            this.buttonRemove1.Name = "buttonRemove1";
            this.buttonRemove1.Size = new System.Drawing.Size(168, 53);
            this.buttonRemove1.TabIndex = 2;
            this.buttonRemove1.Text = "Remove";
            this.buttonRemove1.UseVisualStyleBackColor = true;
            this.buttonRemove1.Click += new System.EventHandler(this.buttonRemove1_Click);
            // 
            // buttonAdd1
            // 
            this.buttonAdd1.Location = new System.Drawing.Point(25, 446);
            this.buttonAdd1.Name = "buttonAdd1";
            this.buttonAdd1.Size = new System.Drawing.Size(168, 53);
            this.buttonAdd1.TabIndex = 1;
            this.buttonAdd1.Text = "Add";
            this.buttonAdd1.UseVisualStyleBackColor = true;
            this.buttonAdd1.Click += new System.EventHandler(this.buttonAdd1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonDown2);
            this.groupBox2.Controls.Add(this.buttonUp2);
            this.groupBox2.Controls.Add(this.buttonRemove2);
            this.groupBox2.Controls.Add(this.buttonAdd2);
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Location = new System.Drawing.Point(603, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(561, 520);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add New Files";
            // 
            // buttonDown2
            // 
            this.buttonDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonDown2.Location = new System.Drawing.Point(483, 446);
            this.buttonDown2.Name = "buttonDown2";
            this.buttonDown2.Size = new System.Drawing.Size(53, 53);
            this.buttonDown2.TabIndex = 5;
            this.buttonDown2.Text = "▼";
            this.buttonDown2.UseVisualStyleBackColor = true;
            this.buttonDown2.Click += new System.EventHandler(this.buttonDown2_Click);
            // 
            // buttonUp2
            // 
            this.buttonUp2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonUp2.Location = new System.Drawing.Point(424, 446);
            this.buttonUp2.Name = "buttonUp2";
            this.buttonUp2.Size = new System.Drawing.Size(53, 53);
            this.buttonUp2.TabIndex = 4;
            this.buttonUp2.Text = "▲";
            this.buttonUp2.UseVisualStyleBackColor = true;
            this.buttonUp2.Click += new System.EventHandler(this.buttonUp2_Click);
            // 
            // buttonRemove2
            // 
            this.buttonRemove2.Location = new System.Drawing.Point(200, 446);
            this.buttonRemove2.Name = "buttonRemove2";
            this.buttonRemove2.Size = new System.Drawing.Size(168, 53);
            this.buttonRemove2.TabIndex = 3;
            this.buttonRemove2.Text = "Remove";
            this.buttonRemove2.UseVisualStyleBackColor = true;
            this.buttonRemove2.Click += new System.EventHandler(this.buttonRemove2_Click);
            // 
            // buttonAdd2
            // 
            this.buttonAdd2.Location = new System.Drawing.Point(26, 446);
            this.buttonAdd2.Name = "buttonAdd2";
            this.buttonAdd2.Size = new System.Drawing.Size(168, 53);
            this.buttonAdd2.TabIndex = 2;
            this.buttonAdd2.Text = "Add";
            this.buttonAdd2.UseVisualStyleBackColor = true;
            this.buttonAdd2.Click += new System.EventHandler(this.buttonAdd2_Click);
            // 
            // buttonCompare
            // 
            this.buttonCompare.Location = new System.Drawing.Point(380, 655);
            this.buttonCompare.Name = "buttonCompare";
            this.buttonCompare.Size = new System.Drawing.Size(417, 89);
            this.buttonCompare.TabIndex = 4;
            this.buttonCompare.Text = "Compare";
            this.buttonCompare.UseVisualStyleBackColor = true;
            this.buttonCompare.Click += new System.EventHandler(this.buttonCompare_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(971, 25);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(147, 48);
            this.buttonSelectFolder.TabIndex = 5;
            this.buttonSelectFolder.Text = "Select";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(25, 35);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.ReadOnly = true;
            this.textBoxFolder.Size = new System.Drawing.Size(925, 26);
            this.textBoxFolder.TabIndex = 6;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxFolder);
            this.groupBox3.Controls.Add(this.buttonSelectFolder);
            this.groupBox3.Location = new System.Drawing.Point(21, 553);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1143, 88);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Select Folder to Save Results";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 759);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonCompare);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1208, 815);
            this.MinimumSize = new System.Drawing.Size(1208, 815);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel Comparator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonCompare;
        private System.Windows.Forms.Button buttonDown1;
        private System.Windows.Forms.Button buttonUp1;
        private System.Windows.Forms.Button buttonRemove1;
        private System.Windows.Forms.Button buttonAdd1;
        private System.Windows.Forms.Button buttonDown2;
        private System.Windows.Forms.Button buttonUp2;
        private System.Windows.Forms.Button buttonRemove2;
        private System.Windows.Forms.Button buttonAdd2;
        private System.Windows.Forms.Button buttonSelectFolder;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

