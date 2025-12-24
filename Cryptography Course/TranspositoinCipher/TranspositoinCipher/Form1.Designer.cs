namespace TranspositoinCipher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            keyText = new TextBox();
            generateButton = new Button();
            messageText = new TextBox();
            flowPanel = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            keyLengthLabel = new ToolStripStatusLabel();
            keyLengthLabel2 = new ToolStripStatusLabel();
            messageLengthLabel = new ToolStripStatusLabel();
            ciphertextLengthLabel = new ToolStripStatusLabel();
            encryptButton = new ToolStripSplitButton();
            encryptButton2 = new ToolStripSplitButton();
            decryptButton = new ToolStripSplitButton();
            encryptedLabel = new Label();
            decryptedLabel = new Label();
            keyText2 = new TextBox();
            generateButton2 = new Button();
            encryptedLabel2 = new Label();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // keyText
            // 
            keyText.Location = new Point(12, 17);
            keyText.Name = "keyText";
            keyText.Size = new Size(166, 23);
            keyText.TabIndex = 0;
            keyText.Text = "Key";
            // 
            // generateButton
            // 
            generateButton.Location = new Point(184, 17);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(86, 23);
            generateButton.TabIndex = 1;
            generateButton.Text = "Generate Key";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            // 
            // messageText
            // 
            messageText.Location = new Point(12, 46);
            messageText.Multiline = true;
            messageText.Name = "messageText";
            messageText.Size = new Size(776, 136);
            messageText.TabIndex = 2;
            messageText.Text = "Insert text here";
            // 
            // flowPanel
            // 
            flowPanel.BorderStyle = BorderStyle.FixedSingle;
            flowPanel.Location = new Point(12, 200);
            flowPanel.Name = "flowPanel";
            flowPanel.Size = new Size(388, 206);
            flowPanel.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { keyLengthLabel, keyLengthLabel2, messageLengthLabel, ciphertextLengthLabel, encryptButton, encryptButton2, decryptButton });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // keyLengthLabel
            // 
            keyLengthLabel.Name = "keyLengthLabel";
            keyLengthLabel.Size = new Size(70, 17);
            keyLengthLabel.Text = "[key length]";
            // 
            // keyLengthLabel2
            // 
            keyLengthLabel2.Name = "keyLengthLabel2";
            keyLengthLabel2.Size = new Size(79, 17);
            keyLengthLabel2.Text = "[key 2 length]";
            // 
            // messageLengthLabel
            // 
            messageLengthLabel.Name = "messageLengthLabel";
            messageLengthLabel.Size = new Size(98, 17);
            messageLengthLabel.Text = "[message length]";
            // 
            // ciphertextLengthLabel
            // 
            ciphertextLengthLabel.Name = "ciphertextLengthLabel";
            ciphertextLengthLabel.Size = new Size(105, 17);
            ciphertextLengthLabel.Text = "[ciphertext length]";
            // 
            // encryptButton
            // 
            encryptButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            encryptButton.Image = (Image)resources.GetObject("encryptButton.Image");
            encryptButton.ImageTransparentColor = Color.Magenta;
            encryptButton.Name = "encryptButton";
            encryptButton.Size = new Size(63, 20);
            encryptButton.Text = "Encrypt";
            encryptButton.ButtonClick += encryptButton_ButtonClick;
            // 
            // encryptButton2
            // 
            encryptButton2.DisplayStyle = ToolStripItemDisplayStyle.Text;
            encryptButton2.Image = (Image)resources.GetObject("encryptButton2.Image");
            encryptButton2.ImageTransparentColor = Color.Magenta;
            encryptButton2.Name = "encryptButton2";
            encryptButton2.Size = new Size(104, 20);
            encryptButton2.Text = "Double Encrypt";
            encryptButton2.ButtonClick += encryptButton2_ButtonClick;
            // 
            // decryptButton
            // 
            decryptButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            decryptButton.Image = (Image)resources.GetObject("decryptButton.Image");
            decryptButton.ImageTransparentColor = Color.Magenta;
            decryptButton.Name = "decryptButton";
            decryptButton.Size = new Size(64, 20);
            decryptButton.Text = "Decrypt";
            decryptButton.ButtonClick += decryptButton_ButtonClick;
            // 
            // encryptedLabel
            // 
            encryptedLabel.AutoSize = true;
            encryptedLabel.Location = new Point(432, 206);
            encryptedLabel.Name = "encryptedLabel";
            encryptedLabel.Size = new Size(117, 15);
            encryptedLabel.TabIndex = 5;
            encryptedLabel.Text = "[encrypted message]";
            // 
            // decryptedLabel
            // 
            decryptedLabel.AutoSize = true;
            decryptedLabel.Location = new Point(432, 266);
            decryptedLabel.Name = "decryptedLabel";
            decryptedLabel.Size = new Size(117, 15);
            decryptedLabel.TabIndex = 6;
            decryptedLabel.Text = "[decrypted message]";
            // 
            // keyText2
            // 
            keyText2.Location = new Point(337, 17);
            keyText2.Name = "keyText2";
            keyText2.Size = new Size(166, 23);
            keyText2.TabIndex = 7;
            keyText2.Text = "Key 2";
            // 
            // generateButton2
            // 
            generateButton2.Location = new Point(509, 17);
            generateButton2.Name = "generateButton2";
            generateButton2.Size = new Size(86, 23);
            generateButton2.TabIndex = 8;
            generateButton2.Text = "Generate Key 2";
            generateButton2.UseVisualStyleBackColor = true;
            generateButton2.Click += generateButton2_Click;
            // 
            // encryptedLabel2
            // 
            encryptedLabel2.AutoSize = true;
            encryptedLabel2.Location = new Point(432, 359);
            encryptedLabel2.Name = "encryptedLabel2";
            encryptedLabel2.Size = new Size(157, 15);
            encryptedLabel2.TabIndex = 9;
            encryptedLabel2.Text = "[doubly encrypted message]";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(encryptedLabel2);
            Controls.Add(generateButton2);
            Controls.Add(keyText2);
            Controls.Add(decryptedLabel);
            Controls.Add(encryptedLabel);
            Controls.Add(statusStrip1);
            Controls.Add(flowPanel);
            Controls.Add(messageText);
            Controls.Add(generateButton);
            Controls.Add(keyText);
            Name = "Form1";
            Text = "Form1";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button generateButton;
        private TextBox keyText;
        private TextBox messageText;
        private FlowLayoutPanel flowPanel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel keyLengthLabel;
        private ToolStripSplitButton encryptButton;
        private ToolStripStatusLabel messageLengthLabel;
        private Label encryptedLabel;
        private ToolStripSplitButton decryptButton;
        private Label decryptedLabel;
        private TextBox keyText2;
        private Button generateButton2;
        private ToolStripStatusLabel keyLengthLabel2;
        private ToolStripSplitButton encryptButton2;
        private Label encryptedLabel2;
        private ToolStripStatusLabel ciphertextLengthLabel;
    }
}
