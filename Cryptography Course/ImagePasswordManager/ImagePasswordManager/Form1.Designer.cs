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
            messageTextbox = new TextBox();
            keyTextbox = new TextBox();
            generateKeyButton = new Button();
            encryptButton = new Button();
            ((System.ComponentModel.ISupportInitialize)originalPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)encryptedPictureBox).BeginInit();
            SuspendLayout();
            // 
            // originalPictureBox
            // 
            originalPictureBox.Location = new Point(60, 186);
            originalPictureBox.Name = "originalPictureBox";
            originalPictureBox.Size = new Size(429, 401);
            originalPictureBox.TabIndex = 0;
            originalPictureBox.TabStop = false;
            // 
            // encryptedPictureBox
            // 
            encryptedPictureBox.Location = new Point(519, 186);
            encryptedPictureBox.Name = "encryptedPictureBox";
            encryptedPictureBox.Size = new Size(429, 401);
            encryptedPictureBox.TabIndex = 1;
            encryptedPictureBox.TabStop = false;
            // 
            // messageTextbox
            // 
            messageTextbox.Location = new Point(60, 54);
            messageTextbox.Multiline = true;
            messageTextbox.Name = "messageTextbox";
            messageTextbox.Size = new Size(429, 116);
            messageTextbox.TabIndex = 2;
            // 
            // keyTextbox
            // 
            keyTextbox.Location = new Point(60, 25);
            keyTextbox.Name = "keyTextbox";
            keyTextbox.Size = new Size(429, 23);
            keyTextbox.TabIndex = 3;
            // 
            // generateKeyButton
            // 
            generateKeyButton.Location = new Point(519, 25);
            generateKeyButton.Name = "generateKeyButton";
            generateKeyButton.Size = new Size(429, 23);
            generateKeyButton.TabIndex = 4;
            generateKeyButton.Text = "Generate Key";
            generateKeyButton.UseVisualStyleBackColor = true;
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(519, 53);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(429, 117);
            encryptButton.TabIndex = 5;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += encryptButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1009, 608);
            Controls.Add(encryptButton);
            Controls.Add(generateKeyButton);
            Controls.Add(keyTextbox);
            Controls.Add(messageTextbox);
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
        private TextBox messageTextbox;
        private TextBox keyTextbox;
        private Button generateKeyButton;
        private Button encryptButton;
    }
}
