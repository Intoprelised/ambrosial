namespace Ambrosial.Ambrosial.Forms
{
    partial class SettingsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.topBar = new System.Windows.Forms.Panel();
            this.minbut = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.Drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Shadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.shouldcheck = new Guna.UI2.WinForms.Guna2CheckBox();
            this.saveBut = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.topBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.topBar.Controls.Add(this.minbut);
            this.topBar.Controls.Add(this.title);
            this.topBar.Controls.Add(this.exit);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(281, 26);
            this.topBar.TabIndex = 1;
            // 
            // minbut
            // 
            this.minbut.AutoSize = true;
            this.minbut.Font = new System.Drawing.Font("Yu Gothic UI Light", 8.25F);
            this.minbut.ForeColor = System.Drawing.Color.Yellow;
            this.minbut.Location = new System.Drawing.Point(244, 7);
            this.minbut.Name = "minbut";
            this.minbut.Size = new System.Drawing.Size(19, 13);
            this.minbut.TabIndex = 2;
            this.minbut.Text = "⚫";
            this.minbut.Click += new System.EventHandler(this.minbut_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(3, 4);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(55, 19);
            this.title.TabIndex = 0;
            this.title.Text = "Settings";
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Yu Gothic UI Light", 8.25F);
            this.exit.ForeColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(259, 7);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(19, 13);
            this.exit.TabIndex = 1;
            this.exit.Text = "⚫";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Drag
            // 
            this.Drag.TargetControl = this.topBar;
            // 
            // Shadow
            // 
            this.Shadow.TargetForm = this;
            // 
            // shouldcheck
            // 
            this.shouldcheck.Animated = true;
            this.shouldcheck.AutoSize = true;
            this.shouldcheck.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.shouldcheck.CheckedState.BorderRadius = 0;
            this.shouldcheck.CheckedState.BorderThickness = 0;
            this.shouldcheck.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.shouldcheck.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.shouldcheck.ForeColor = System.Drawing.Color.White;
            this.shouldcheck.Location = new System.Drawing.Point(7, 32);
            this.shouldcheck.Name = "shouldcheck";
            this.shouldcheck.Size = new System.Drawing.Size(153, 23);
            this.shouldcheck.TabIndex = 4;
            this.shouldcheck.Text = "Should check version";
            this.shouldcheck.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.shouldcheck.UncheckedState.BorderRadius = 0;
            this.shouldcheck.UncheckedState.BorderThickness = 0;
            this.shouldcheck.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.shouldcheck.CheckedChanged += new System.EventHandler(this.shouldcheck_CheckedChanged);
            // 
            // saveBut
            // 
            this.saveBut.Animated = true;
            this.saveBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveBut.CheckedState.Parent = this.saveBut;
            this.saveBut.CustomImages.Parent = this.saveBut;
            this.saveBut.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.saveBut.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.saveBut.ForeColor = System.Drawing.Color.White;
            this.saveBut.HoverState.Parent = this.saveBut;
            this.saveBut.Location = new System.Drawing.Point(47, 404);
            this.saveBut.Name = "saveBut";
            this.saveBut.ShadowDecoration.Enabled = true;
            this.saveBut.ShadowDecoration.Parent = this.saveBut;
            this.saveBut.Size = new System.Drawing.Size(180, 45);
            this.saveBut.TabIndex = 7;
            this.saveBut.Text = "Save";
            this.saveBut.Click += new System.EventHandler(this.saveBut_Click);
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.Animated = true;
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2CheckBox1.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.White;
            this.guna2CheckBox1.Location = new System.Drawing.Point(7, 61);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(142, 23);
            this.guna2CheckBox1.TabIndex = 8;
            this.guna2CheckBox1.Text = "Launch with debug";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2CheckBox1.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.ClientSize = new System.Drawing.Size(281, 450);
            this.Controls.Add(this.guna2CheckBox1);
            this.Controls.Add(this.saveBut);
            this.Controls.Add(this.shouldcheck);
            this.Controls.Add(this.topBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load_1);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Label minbut;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label exit;
        private Guna.UI2.WinForms.Guna2DragControl Drag;
        private Guna.UI2.WinForms.Guna2ShadowForm Shadow;
        private Guna.UI2.WinForms.Guna2Button saveBut;
        public Guna.UI2.WinForms.Guna2CheckBox shouldcheck;
        public Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
    }
}