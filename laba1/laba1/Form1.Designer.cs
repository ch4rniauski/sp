namespace laba1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            generatePassButton = new Button();
            passLabel = new Label();
            withNumsCheckBox = new CheckBox();
            passLengthMenuStrip = new MenuStrip();
            длинаПароляToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            passLengthLabel = new Label();
            passHistoryListBox = new ListBox();
            passHistoryLabel = new Label();
            loadHistoryFromFileButton = new Button();
            passLengthMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // generatePassButton
            // 
            generatePassButton.BackColor = SystemColors.Window;
            generatePassButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            generatePassButton.Location = new Point(0, 113);
            generatePassButton.Name = "generatePassButton";
            generatePassButton.Size = new Size(119, 33);
            generatePassButton.TabIndex = 1;
            generatePassButton.Text = "Сгенерировать";
            generatePassButton.UseVisualStyleBackColor = false;
            generatePassButton.Click += generatePassButton_Click;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passLabel.Location = new Point(0, 64);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(70, 21);
            passLabel.TabIndex = 2;
            passLabel.Text = "Пароль: ";
            // 
            // withNumsCheckBox
            // 
            withNumsCheckBox.AutoSize = true;
            withNumsCheckBox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            withNumsCheckBox.Location = new Point(0, 88);
            withNumsCheckBox.Name = "withNumsCheckBox";
            withNumsCheckBox.Size = new Size(93, 21);
            withNumsCheckBox.TabIndex = 3;
            withNumsCheckBox.Text = "С цифрами";
            withNumsCheckBox.UseVisualStyleBackColor = true;
            withNumsCheckBox.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // passLengthMenuStrip
            // 
            passLengthMenuStrip.Anchor = AnchorStyles.None;
            passLengthMenuStrip.BackColor = Color.RosyBrown;
            passLengthMenuStrip.Dock = DockStyle.None;
            passLengthMenuStrip.Items.AddRange(new ToolStripItem[] { длинаПароляToolStripMenuItem });
            passLengthMenuStrip.Location = new Point(0, 0);
            passLengthMenuStrip.Name = "passLengthMenuStrip";
            passLengthMenuStrip.Size = new Size(105, 24);
            passLengthMenuStrip.TabIndex = 4;
            passLengthMenuStrip.Text = "menuStrip1";
            // 
            // длинаПароляToolStripMenuItem
            // 
            длинаПароляToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4 });
            длинаПароляToolStripMenuItem.Name = "длинаПароляToolStripMenuItem";
            длинаПароляToolStripMenuItem.Size = new Size(97, 20);
            длинаПароляToolStripMenuItem.Text = "Длина пароля";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(86, 22);
            toolStripMenuItem2.Text = "8";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(86, 22);
            toolStripMenuItem3.Text = "12";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(86, 22);
            toolStripMenuItem4.Text = "16";
            toolStripMenuItem4.Click += toolStripMenuItem4_Click;
            // 
            // passLengthLabel
            // 
            passLengthLabel.AutoSize = true;
            passLengthLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            passLengthLabel.Location = new Point(108, 2);
            passLengthLabel.Name = "passLengthLabel";
            passLengthLabel.Size = new Size(18, 20);
            passLengthLabel.TabIndex = 5;
            passLengthLabel.Text = "8";
            // 
            // passHistoryListBox
            // 
            passHistoryListBox.FormattingEnabled = true;
            passHistoryListBox.Location = new Point(231, 52);
            passHistoryListBox.Name = "passHistoryListBox";
            passHistoryListBox.Size = new Size(150, 94);
            passHistoryListBox.TabIndex = 6;
            // 
            // passHistoryLabel
            // 
            passHistoryLabel.AutoSize = true;
            passHistoryLabel.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            passHistoryLabel.Location = new Point(240, 29);
            passHistoryLabel.Name = "passHistoryLabel";
            passHistoryLabel.Size = new Size(132, 20);
            passHistoryLabel.TabIndex = 7;
            passHistoryLabel.Text = "История паролей";
            // 
            // loadHistoryFromFileButton
            // 
            loadHistoryFromFileButton.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            loadHistoryFromFileButton.Location = new Point(0, 152);
            loadHistoryFromFileButton.Name = "loadHistoryFromFileButton";
            loadHistoryFromFileButton.Size = new Size(119, 42);
            loadHistoryFromFileButton.TabIndex = 8;
            loadHistoryFromFileButton.Text = "Загрузить пароли из файла";
            loadHistoryFromFileButton.UseVisualStyleBackColor = true;
            loadHistoryFromFileButton.Click += loadHistoryFromFileButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(384, 211);
            Controls.Add(loadHistoryFromFileButton);
            Controls.Add(passHistoryLabel);
            Controls.Add(passHistoryListBox);
            Controls.Add(passLengthLabel);
            Controls.Add(withNumsCheckBox);
            Controls.Add(passLabel);
            Controls.Add(generatePassButton);
            Controls.Add(passLengthMenuStrip);
            MainMenuStrip = passLengthMenuStrip;
            Name = "Form1";
            Text = "Генератор паролей";
            passLengthMenuStrip.ResumeLayout(false);
            passLengthMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button generatePassButton;
        private Label passLabel;
        private CheckBox withNumsCheckBox;
        private MenuStrip passLengthMenuStrip;
        private ToolStripMenuItem длинаПароляToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private Label passLengthLabel;
        private ListBox passHistoryListBox;
        private Label passHistoryLabel;
        private Button loadHistoryFromFileButton;
    }
}
