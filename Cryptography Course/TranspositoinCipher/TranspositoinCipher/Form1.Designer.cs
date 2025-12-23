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
            messageLengthLabel = new ToolStripStatusLabel();
            encryptButton = new ToolStripSplitButton();
            encryptedLabel = new Label();
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
            generateButton.Location = new Point(199, 17);
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
            statusStrip1.Items.AddRange(new ToolStripItem[] { keyLengthLabel, messageLengthLabel, encryptButton });
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
            // messageLengthLabel
            // 
            messageLengthLabel.Name = "messageLengthLabel";
            messageLengthLabel.Size = new Size(98, 17);
            messageLengthLabel.Text = "[message length]";
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
            // encryptedLabel
            // 
            encryptedLabel.AutoSize = true;
            encryptedLabel.Location = new Point(432, 206);
            encryptedLabel.Name = "encryptedLabel";
            encryptedLabel.Size = new Size(117, 15);
            encryptedLabel.TabIndex = 5;
            encryptedLabel.Text = "[encrypted message]";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
