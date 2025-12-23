namespace OneTimePadVisual
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
            textBox1 = new TextBox();
            encryptbutton = new Button();
            keylabel = new Label();
            encryptedlabel = new Label();
            decryptbutton = new Button();
            decryptlabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 18F);
            textBox1.Location = new Point(27, 14);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(366, 39);
            textBox1.TabIndex = 0;
            textBox1.Text = "Input message to encrypt";
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // encryptbutton
            // 
            encryptbutton.Font = new Font("Segoe UI", 18F);
            encryptbutton.Location = new Point(399, 12);
            encryptbutton.Name = "encryptbutton";
            encryptbutton.Size = new Size(157, 42);
            encryptbutton.TabIndex = 1;
            encryptbutton.Text = "Encrypt";
            encryptbutton.UseVisualStyleBackColor = true;
            encryptbutton.Click += Encrypt_Button_Click;
            // 
            // keylabel
            // 
            keylabel.AutoSize = true;
            keylabel.BackColor = SystemColors.GradientActiveCaption;
            keylabel.Font = new Font("Segoe UI", 18F);
            keylabel.Location = new Point(122, 59);
            keylabel.Name = "keylabel";
            keylabel.Size = new Size(0, 32);
            keylabel.TabIndex = 2;
            // 
            // encryptedlabel
            // 
            encryptedlabel.AutoSize = true;
            encryptedlabel.BackColor = SystemColors.GradientActiveCaption;
            encryptedlabel.Font = new Font("Segoe UI", 18F);
            encryptedlabel.Location = new Point(201, 145);
            encryptedlabel.Name = "encryptedlabel";
            encryptedlabel.Size = new Size(0, 32);
            encryptedlabel.TabIndex = 3;
            encryptedlabel.Click += encryptedlabel_Click;
            // 
            // decryptbutton
            // 
            decryptbutton.Font = new Font("Segoe UI", 18F);
            decryptbutton.Location = new Point(562, 12);
            decryptbutton.Name = "decryptbutton";
            decryptbutton.Size = new Size(157, 42);
            decryptbutton.TabIndex = 4;
            decryptbutton.Text = "Decrypt";
            decryptbutton.UseVisualStyleBackColor = true;
            decryptbutton.Click += decryptbutton_Click;
            // 
            // decryptlabel
            // 
            decryptlabel.AutoSize = true;
            decryptlabel.BackColor = SystemColors.GradientActiveCaption;
            decryptlabel.Font = new Font("Segoe UI", 18F);
            decryptlabel.Location = new Point(205, 298);
            decryptlabel.Name = "decryptlabel";
            decryptlabel.Size = new Size(0, 32);
            decryptlabel.TabIndex = 5;
            decryptlabel.Click += decryptlabel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.GradientActiveCaption;
            label1.Font = new Font("Segoe UI", 18F);
            label1.Location = new Point(27, 59);
            label1.Name = "label1";
            label1.Size = new Size(58, 32);
            label1.TabIndex = 6;
            label1.Text = "Key:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.GradientActiveCaption;
            label2.Font = new Font("Segoe UI", 18F);
            label2.Location = new Point(23, 145);
            label2.Name = "label2";
            label2.Size = new Size(172, 32);
            label2.TabIndex = 7;
            label2.Text = "Encrypted text:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.GradientActiveCaption;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(23, 298);
            label3.Name = "label3";
            label3.Size = new Size(176, 32);
            label3.TabIndex = 8;
            label3.Text = "Decrypted text:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(decryptlabel);
            Controls.Add(decryptbutton);
            Controls.Add(encryptedlabel);
            Controls.Add(keylabel);
            Controls.Add(encryptbutton);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button encryptbutton;
        private Label keylabel;
        private Label encryptedlabel;
        private Button decryptbutton;
        private Label decryptlabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
