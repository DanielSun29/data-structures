namespace Steganography
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
            hostPicture = new PictureBox();
            hideButton = new Button();
            hidePicture = new PictureBox();
            hiddenPicture = new PictureBox();
            unhideButton = new Button();
            unhiddenPicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)hostPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hidePicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)hiddenPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)unhiddenPicture).BeginInit();
            SuspendLayout();
            // 
            // hostPicture
            // 
            hostPicture.Location = new Point(36, 12);
            hostPicture.Name = "hostPicture";
            hostPicture.Size = new Size(259, 295);
            hostPicture.TabIndex = 0;
            hostPicture.TabStop = false;
            // 
            // hideButton
            // 
            hideButton.Location = new Point(36, 313);
            hideButton.Name = "hideButton";
            hideButton.Size = new Size(535, 39);
            hideButton.TabIndex = 1;
            hideButton.Text = "Hide Image";
            hideButton.UseVisualStyleBackColor = true;
            hideButton.Click += hideButton_Click;
            // 
            // hidePicture
            // 
            hidePicture.Location = new Point(312, 12);
            hidePicture.Name = "hidePicture";
            hidePicture.Size = new Size(259, 295);
            hidePicture.TabIndex = 3;
            hidePicture.TabStop = false;
            // 
            // hiddenPicture
            // 
            hiddenPicture.Location = new Point(36, 358);
            hiddenPicture.Name = "hiddenPicture";
            hiddenPicture.Size = new Size(325, 339);
            hiddenPicture.TabIndex = 4;
            hiddenPicture.TabStop = false;
            hiddenPicture.Click += pictureBox3_Click;
            // 
            // unhideButton
            // 
            unhideButton.Location = new Point(380, 358);
            unhideButton.Name = "unhideButton";
            unhideButton.Size = new Size(191, 339);
            unhideButton.TabIndex = 5;
            unhideButton.Text = "Unhide Image";
            unhideButton.UseVisualStyleBackColor = true;
            unhideButton.Click += unhideButton_Click;
            // 
            // unhiddenPicture
            // 
            unhiddenPicture.Location = new Point(590, 358);
            unhiddenPicture.Name = "unhiddenPicture";
            unhiddenPicture.Size = new Size(325, 339);
            unhiddenPicture.TabIndex = 6;
            unhiddenPicture.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1261, 836);
            Controls.Add(unhiddenPicture);
            Controls.Add(unhideButton);
            Controls.Add(hiddenPicture);
            Controls.Add(hidePicture);
            Controls.Add(hideButton);
            Controls.Add(hostPicture);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)hostPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)hidePicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)hiddenPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)unhiddenPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox hostPicture;
        private Button hideButton;
        private PictureBox hidePicture;
        private PictureBox hiddenPicture;
        private Button unhideButton;
        private PictureBox unhiddenPicture;
    }
}
