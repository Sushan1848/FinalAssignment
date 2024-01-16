namespace Software_Engineering_Assignment
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
            this.OutputBox = new System.Windows.Forms.Panel();
            this.RunButton = new System.Windows.Forms.Button();
            this.MultiLineTextBox = new System.Windows.Forms.TextBox();
            this.SingleLineTextBox = new System.Windows.Forms.TextBox();
            this.SyntaxButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MultiLineTextBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputBox
            // 
            this.OutputBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.OutputBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutputBox.Location = new System.Drawing.Point(796, 42);
            this.OutputBox.Name = "OutputBox";
            this.OutputBox.Size = new System.Drawing.Size(364, 406);
            this.OutputBox.TabIndex = 1;
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(331, 388);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 2;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // MultiLineTextBox
            // 
            this.MultiLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MultiLineTextBox.Location = new System.Drawing.Point(25, 42);
            this.MultiLineTextBox.Multiline = true;
            this.MultiLineTextBox.Name = "MultiLineTextBox";
            this.MultiLineTextBox.Size = new System.Drawing.Size(355, 302);
            this.MultiLineTextBox.TabIndex = 3;
            this.MultiLineTextBox.TextChanged += new System.EventHandler(this.MultiLineTextBox_TextChanged);
            // 
            // SingleLineTextBox
            // 
            this.SingleLineTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SingleLineTextBox.Location = new System.Drawing.Point(25, 360);
            this.SingleLineTextBox.Name = "SingleLineTextBox";
            this.SingleLineTextBox.Size = new System.Drawing.Size(744, 22);
            this.SingleLineTextBox.TabIndex = 4;
            this.SingleLineTextBox.TextChanged += new System.EventHandler(this.SingleLineTextBox_TextChanged);
            // 
            // SyntaxButton
            // 
            this.SyntaxButton.Location = new System.Drawing.Point(447, 388);
            this.SyntaxButton.Name = "SyntaxButton";
            this.SyntaxButton.Size = new System.Drawing.Size(75, 23);
            this.SyntaxButton.TabIndex = 5;
            this.SyntaxButton.Text = "Syntax";
            this.SyntaxButton.UseVisualStyleBackColor = true;
            this.SyntaxButton.Click += new System.EventHandler(this.SyntaxButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1186, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMenu,
            this.saveMenu,
            this.exitToolStripMenuItem});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fIleToolStripMenuItem.Text = "File";
            this.fIleToolStripMenuItem.Click += new System.EventHandler(this.fIleToolStripMenuItem_Click);
            // 
            // loadMenu
            // 
            this.loadMenu.Name = "loadMenu";
            this.loadMenu.Size = new System.Drawing.Size(224, 26);
            this.loadMenu.Text = "Load";
            this.loadMenu.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveMenu
            // 
            this.saveMenu.Name = "saveMenu";
            this.saveMenu.Size = new System.Drawing.Size(224, 26);
            this.saveMenu.Text = "Save";
            this.saveMenu.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MultiLineTextBox2
            // 
            this.MultiLineTextBox2.Location = new System.Drawing.Point(402, 42);
            this.MultiLineTextBox2.Multiline = true;
            this.MultiLineTextBox2.Name = "MultiLineTextBox2";
            this.MultiLineTextBox2.Size = new System.Drawing.Size(367, 302);
            this.MultiLineTextBox2.TabIndex = 7;
            this.MultiLineTextBox2.TextChanged += new System.EventHandler(this.MultiLineTextBox2_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 460);
            this.Controls.Add(this.MultiLineTextBox2);
            this.Controls.Add(this.SyntaxButton);
            this.Controls.Add(this.SingleLineTextBox);
            this.Controls.Add(this.MultiLineTextBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.OutputBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel OutputBox;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TextBox MultiLineTextBox;
        private System.Windows.Forms.TextBox SingleLineTextBox;
        private System.Windows.Forms.Button SyntaxButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadMenu;
        private System.Windows.Forms.ToolStripMenuItem saveMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox MultiLineTextBox2;
    }
}

