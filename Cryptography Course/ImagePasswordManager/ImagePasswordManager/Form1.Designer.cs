namespace ImagePasswordManager
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
            originalPictureBox = new PictureBox();
            encryptedPictureBox = new PictureBox();
            passwordTextbox = new TextBox();
            keyTextbox = new TextBox();
            generateKeyButton = new Button();
            storeButton = new Button();
            getButton = new Button();
            passwordTextbox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            labelTextbox = new TextBox();
            labelTextbox2 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            initButton = new Button();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)encryptedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // originalPictureBox
            // 
            originalPictureBox.Location = new Point(557, 25);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(224, 269);
            originalPictureBox.TabIndex = 0;
            originalPictureBox.TabStop = false;
            originalPictureBox.Visible = false;
            // 
            // encryptedPictureBox
            // 
            encryptedPictureBox.Location = new Point(557, 314);
            encryptedPictureBox.Name = "encryptedPictureBox";
            encryptedPictureBox.Size = new Size(224, 269);
            encryptedPictureBox.TabIndex = 1;
            encryptedPictureBox.TabStop = false;
            // 
            // passwordTextbox
            // 
            passwordTextbox.Location = new Point(60, 81);
            passwordTextbox.Multiline = true;
            passwordTextbox.Name = "passwordTextbox";
            passwordTextbox.Size = new Size(429, 89);
            passwordTextbox.TabIndex = 2;
            passwordTextbox.Visible = false;
            // 
            // keyTextbox
            // 
            keyTextbox.Location = new Point(60, 25);
            keyTextbox.Name = "keyTextbox";
            keyTextbox.Size = new Size(341, 23);
            keyTextbox.TabIndex = 3;
            keyTextbox.Text = "[Key]";
            // 
            // generateKeyButton
            // 
            generateKeyButton.Location = new Point(407, 24);
            generateKeyButton.Name = "generateKeyButton";
            generateKeyButton.Size = new Size(82, 23);
            generateKeyButton.TabIndex = 4;
            generateKeyButton.Text = "Generate Key";
            generateKeyButton.UseVisualStyleBackColor = true;
            generateKeyButton.Click += generateKeyButton_Click;
            // 
            // storeButton
            // 
            storeButton.Location = new Point(60, 300);
            storeButton.Name = "storeButton";
            storeButton.Size = new Size(429, 51);
            storeButton.TabIndex = 5;
            storeButton.Text = "Store";
            storeButton.UseVisualStyleBackColor = true;
            storeButton.Visible = false;
            storeButton.Click += storeButton_Click;
            // 
            // getButton
            // 
            getButton.Location = new Point(60, 390);
            getButton.Name = "getButton";
            getButton.Size = new Size(117, 88);
            getButton.TabIndex = 7;
            getButton.Text = "Get";
            getButton.UseVisualStyleBackColor = true;
            getButton.Visible = false;
            getButton.Click += getButton_Click;
            // 
            // passwordTextbox2
            // 
            passwordTextbox2.Location = new Point(60, 500);
            passwordTextbox2.Multiline = true;
            passwordTextbox2.Name = "passwordTextbox2";
            passwordTextbox2.Size = new Size(429, 83);
            passwordTextbox2.TabIndex = 6;
            passwordTextbox2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(60, 63);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 8;
            label1.Text = "Password:";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 183);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 9;
            label2.Text = "Use/Label:";
            label2.Visible = false;
            // 
            // labelTextbox
            // 
            labelTextbox.Location = new Point(60, 201);
            labelTextbox.Multiline = true;
            labelTextbox.Name = "labelTextbox";
            labelTextbox.Size = new Size(429, 89);
            labelTextbox.TabIndex = 10;
            labelTextbox.Visible = false;
            // 
            // labelTextbox2
            // 
            labelTextbox2.Location = new Point(183, 408);
            labelTextbox2.Multiline = true;
            labelTextbox2.Name = "labelTextbox2";
            labelTextbox2.Size = new Size(306, 70);
            labelTextbox2.TabIndex = 11;
            labelTextbox2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(183, 390);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 12;
            label3.Text = "Use/Label:";
            label3.Visible = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(60, 482);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 13;
            label4.Text = "Password:";
            label4.Visible = false;
            // 
            // initButton
            // 
            initButton.Location = new Point(495, 24);
            initButton.Name = "initButton";
            initButton.Size = new Size(286, 24);
            initButton.TabIndex = 14;
            initButton.Text = "Enter";
            initButton.UseVisualStyleBackColor = true;
            initButton.Click += initButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 608);
            Controls.Add(initButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(labelTextbox2);
            Controls.Add(labelTextbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(getButton);
            Controls.Add(passwordTextbox2);
            Controls.Add(storeButton);
            Controls.Add(generateKeyButton);
            Controls.Add(keyTextbox);
            Controls.Add(passwordTextbox);
            Controls.Add(encryptedPictureBox);
            Controls.Add(originalPictureBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)encryptedPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox originalPictureBox;
        private PictureBox encryptedPictureBox;
        private TextBox passwordTextbox;
        private TextBox keyTextbox;
        private Button generateKeyButton;
        private Button storeButton;
        private Button getButton;
        private TextBox passwordTextbox2;
        private Label label1;
        private Label label2;
        private TextBox labelTextbox;
        private TextBox labelTextbox2;
        private Label label3;
        private Label label4;
        private Button initButton;
    }
}
