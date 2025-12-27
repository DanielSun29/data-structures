namespace VigenereCipher
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            inputTextbox = new TextBox();
            encryptButton = new Button();
            ciphertextTextbox = new TextBox();
            keyTextbox = new TextBox();
            visualizeButton = new Button();
            decryptButton = new Button();
            decryptedTextbox = new TextBox();
            visualizeButton2 = new Button();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Location = new Point(404, 24);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(550, 550);
            flowLayoutPanel1.TabIndex = 0;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // inputTextbox
            // 
            inputTextbox.Location = new Point(12, 66);
            inputTextbox.Multiline = true;
            inputTextbox.Name = "inputTextbox";
            inputTextbox.Size = new Size(356, 80);
            inputTextbox.TabIndex = 1;
            inputTextbox.Text = "[input here]";
            // 
            // encryptButton
            // 
            encryptButton.Location = new Point(12, 152);
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(356, 26);
            encryptButton.TabIndex = 2;
            encryptButton.Text = "Encrypt";
            encryptButton.UseVisualStyleBackColor = true;
            encryptButton.Click += encryptButton_Click;
            // 
            // ciphertextTextbox
            // 
            ciphertextTextbox.Location = new Point(12, 240);
            ciphertextTextbox.Multiline = true;
            ciphertextTextbox.Name = "ciphertextTextbox";
            ciphertextTextbox.Size = new Size(355, 80);
            ciphertextTextbox.TabIndex = 3;
            ciphertextTextbox.Text = "[ciphertext here]";
            // 
            // keyTextbox
            // 
            keyTextbox.Location = new Point(13, 24);
            keyTextbox.Name = "keyTextbox";
            keyTextbox.Size = new Size(355, 23);
            keyTextbox.TabIndex = 4;
            keyTextbox.Text = "[key (letter only)]";
            // 
            // visualizeButton
            // 
            visualizeButton.Location = new Point(12, 184);
            visualizeButton.Name = "visualizeButton";
            visualizeButton.Size = new Size(356, 26);
            visualizeButton.TabIndex = 5;
            visualizeButton.Text = "Visualize";
            visualizeButton.UseVisualStyleBackColor = true;
            visualizeButton.Click += visualizeButton_Click;
            // 
            // decryptButton
            // 
            decryptButton.Location = new Point(12, 326);
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(356, 26);
            decryptButton.TabIndex = 6;
            decryptButton.Text = "Decrypt";
            decryptButton.UseVisualStyleBackColor = true;
            decryptButton.Click += decryptButton_Click;
            // 
            // decryptedTextbox
            // 
            decryptedTextbox.Location = new Point(12, 413);
            decryptedTextbox.Multiline = true;
            decryptedTextbox.Name = "decryptedTextbox";
            decryptedTextbox.ReadOnly = true;
            decryptedTextbox.Size = new Size(355, 80);
            decryptedTextbox.TabIndex = 7;
            decryptedTextbox.Text = "[decrypted text here]";
            // 
            // visualizeButton2
            // 
            visualizeButton2.Location = new Point(13, 358);
            visualizeButton2.Name = "visualizeButton2";
            visualizeButton2.Size = new Size(356, 26);
            visualizeButton2.TabIndex = 8;
            visualizeButton2.Text = "Visualize";
            visualizeButton2.UseVisualStyleBackColor = true;
            visualizeButton2.Click += visualizeButton2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 595);
            Controls.Add(visualizeButton2);
            Controls.Add(decryptedTextbox);
            Controls.Add(decryptButton);
            Controls.Add(visualizeButton);
            Controls.Add(keyTextbox);
            Controls.Add(ciphertextTextbox);
            Controls.Add(encryptButton);
            Controls.Add(inputTextbox);
            Controls.Add(flowLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox inputTextbox;
        private Button encryptButton;
        private TextBox ciphertextTextbox;
        private TextBox keyTextbox;
        private Button visualizeButton;
        private Button decryptButton;
        private TextBox decryptedTextbox;
        private Button visualizeButton2;
    }
}
