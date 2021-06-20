namespace Ambrosial
{
    partial class Launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Launcher));
            this.topBar = new System.Windows.Forms.Panel();
            this.minbut = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.Drag = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.Shadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.clientspanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.settings = new Guna.UI2.WinForms.Guna2CircleButton();
            this.addnew = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Username = new System.Windows.Forms.Label();
            this.Version = new System.Windows.Forms.Label();
            this.Animate = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.topBar.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // topBar
            // 
            this.topBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.topBar.Controls.Add(this.minbut);
            this.topBar.Controls.Add(this.exit);
            this.topBar.Controls.Add(this.title);
            this.topBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBar.Location = new System.Drawing.Point(0, 0);
            this.topBar.Name = "topBar";
            this.topBar.Size = new System.Drawing.Size(800, 26);
            this.topBar.TabIndex = 0;
            // 
            // minbut
            // 
            this.minbut.AutoSize = true;
            this.minbut.Font = new System.Drawing.Font("Yu Gothic UI Light", 8.25F);
            this.minbut.ForeColor = System.Drawing.Color.Yellow;
            this.minbut.Location = new System.Drawing.Point(763, 6);
            this.minbut.Name = "minbut";
            this.minbut.Size = new System.Drawing.Size(19, 13);
            this.minbut.TabIndex = 2;
            this.minbut.Text = "⚫";
            this.minbut.Click += new System.EventHandler(this.minbut_Click);
            // 
            // exit
            // 
            this.exit.AutoSize = true;
            this.exit.Font = new System.Drawing.Font("Yu Gothic UI Light", 8.25F);
            this.exit.ForeColor = System.Drawing.Color.Red;
            this.exit.Location = new System.Drawing.Point(778, 6);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(19, 13);
            this.exit.TabIndex = 1;
            this.exit.Text = "⚫";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.title.Location = new System.Drawing.Point(3, 4);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(69, 19);
            this.title.TabIndex = 0;
            this.title.Text = "Ambrosial";
            // 
            // Drag
            // 
            this.Drag.TargetControl = this.topBar;
            // 
            // Shadow
            // 
            this.Shadow.TargetForm = this;
            // 
            // clientspanel
            // 
            this.clientspanel.AutoScroll = true;
            this.clientspanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.clientspanel.Location = new System.Drawing.Point(-1, 24);
            this.clientspanel.Name = "clientspanel";
            this.clientspanel.Size = new System.Drawing.Size(198, 390);
            this.clientspanel.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.panel4.Controls.Add(this.settings);
            this.panel4.Controls.Add(this.addnew);
            this.panel4.Controls.Add(this.Username);
            this.panel4.Controls.Add(this.Version);
            this.panel4.Location = new System.Drawing.Point(0, 408);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(179, 42);
            this.panel4.TabIndex = 5;
            this.panel4.DoubleClick += new System.EventHandler(this.panel4_DoubleClick);
            // 
            // settings
            // 
            this.settings.Animated = true;
            this.settings.CheckedState.Parent = this.settings;
            this.settings.CustomImages.Parent = this.settings;
            this.settings.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.settings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.settings.ForeColor = System.Drawing.Color.White;
            this.settings.HoverState.Parent = this.settings;
            this.settings.Image = ((System.Drawing.Image)(resources.GetObject("settings.Image")));
            this.settings.Location = new System.Drawing.Point(125, 17);
            this.settings.Name = "settings";
            this.settings.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.settings.ShadowDecoration.Parent = this.settings;
            this.settings.Size = new System.Drawing.Size(26, 25);
            this.settings.TabIndex = 6;
            this.settings.Click += new System.EventHandler(this.guna2CircleButton1_Click);
            // 
            // addnew
            // 
            this.addnew.Animated = true;
            this.addnew.CheckedState.Parent = this.addnew;
            this.addnew.CustomImages.Parent = this.addnew;
            this.addnew.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.addnew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.addnew.ForeColor = System.Drawing.Color.White;
            this.addnew.HoverState.Parent = this.addnew;
            this.addnew.Location = new System.Drawing.Point(150, 17);
            this.addnew.Name = "addnew";
            this.addnew.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.addnew.ShadowDecoration.Parent = this.addnew;
            this.addnew.Size = new System.Drawing.Size(26, 25);
            this.addnew.TabIndex = 5;
            this.addnew.Text = "+";
            this.addnew.Click += new System.EventHandler(this.addnew_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.Username.Location = new System.Drawing.Point(0, 1);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(69, 19);
            this.Username.TabIndex = 4;
            this.Username.Text = "Username";
            this.Username.DoubleClick += new System.EventHandler(this.Username_DoubleClick);
            // 
            // Version
            // 
            this.Version.AutoSize = true;
            this.Version.Font = new System.Drawing.Font("Yu Gothic UI Light", 10.25F);
            this.Version.Location = new System.Drawing.Point(0, 19);
            this.Version.Name = "Version";
            this.Version.Size = new System.Drawing.Size(51, 19);
            this.Version.TabIndex = 3;
            this.Version.Text = "1.16.221";
            this.Version.DoubleClick += new System.EventHandler(this.Version_DoubleClick);
            // 
            // Animate
            // 
            this.Animate.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.Animate.TargetForm = this;
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.topBar);
            this.Controls.Add(this.clientspanel);
            this.Font = new System.Drawing.Font("Yu Gothic UI Light", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Launcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ambrosial";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.topBar.ResumeLayout(false);
            this.topBar.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel topBar;
        private System.Windows.Forms.Label minbut;
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label title;
        private Guna.UI2.WinForms.Guna2DragControl Drag;
        private Guna.UI2.WinForms.Guna2ShadowForm Shadow;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel clientspanel;
        private System.Windows.Forms.Label Version;
        private System.Windows.Forms.Label Username;
        private Guna.UI2.WinForms.Guna2AnimateWindow Animate;
        private Guna.UI2.WinForms.Guna2CircleButton addnew;
        private Guna.UI2.WinForms.Guna2CircleButton settings;
    }
}

