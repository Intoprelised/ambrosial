namespace Ambrosial.Ambrosial.Forms
{
    partial class DeveloperForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(236, 346);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "AmbrosialPacketEncrypt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 364);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(236, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "AmbrosialPacketEncrypt_usingClientRegistry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(254, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(236, 346);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(496, 364);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(236, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "AmbrosialPacketDecrypt";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(496, 12);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(292, 346);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // DeveloperForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "DeveloperForm";
            this.Text = "DeveloperForm";
            this.Load += new System.EventHandler(this.DeveloperForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox3;
    }
}