namespace Mechvibes.CSharp
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.pnlCaptionBar = new System.Windows.Forms.Panel();
			this.picMinimize = new System.Windows.Forms.PictureBox();
			this.picClose = new System.Windows.Forms.PictureBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.picIcon = new System.Windows.Forms.PictureBox();
			this.picCaptionBarSeparator = new System.Windows.Forms.PictureBox();
			this.lblSoundPack = new System.Windows.Forms.Label();
			this.cmbSelectedSoundPack = new System.Windows.Forms.ComboBox();
			this.picSeparator1 = new System.Windows.Forms.PictureBox();
			this.btnReloadSoundPacks = new System.Windows.Forms.Button();
			this.btnShowSoundPackFolder = new System.Windows.Forms.Button();
			this.btnOpenSoundEditor = new System.Windows.Forms.Button();
			this.picSeparator3 = new System.Windows.Forms.PictureBox();
			this.lblGitHubAccount = new System.Windows.Forms.Label();
			this.lblGitHubRepository = new System.Windows.Forms.Label();
			this.lblLinkSeparator = new System.Windows.Forms.Label();
			this.tooltip = new System.Windows.Forms.ToolTip(this.components);
			this.picSeparator2 = new System.Windows.Forms.PictureBox();
			this.numVolume = new System.Windows.Forms.NumericUpDown();
			this.trckVolume = new System.Windows.Forms.TrackBar();
			this.picMinimizeToSystemTray = new System.Windows.Forms.PictureBox();
			this.pnlCaptionBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMinimize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picCaptionBarSeparator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numVolume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trckVolume)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picMinimizeToSystemTray)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlCaptionBar
			// 
			this.pnlCaptionBar.Controls.Add(this.picMinimizeToSystemTray);
			this.pnlCaptionBar.Controls.Add(this.picMinimize);
			this.pnlCaptionBar.Controls.Add(this.picClose);
			this.pnlCaptionBar.Controls.Add(this.lblTitle);
			this.pnlCaptionBar.Controls.Add(this.picIcon);
			this.pnlCaptionBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlCaptionBar.Location = new System.Drawing.Point(0, 0);
			this.pnlCaptionBar.Name = "pnlCaptionBar";
			this.pnlCaptionBar.Size = new System.Drawing.Size(426, 44);
			this.pnlCaptionBar.TabIndex = 0;
			this.pnlCaptionBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
			// 
			// picMinimize
			// 
			this.picMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picMinimize.Location = new System.Drawing.Point(356, 6);
			this.picMinimize.Name = "picMinimize";
			this.picMinimize.Size = new System.Drawing.Size(32, 32);
			this.picMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picMinimize.TabIndex = 4;
			this.picMinimize.TabStop = false;
			this.tooltip.SetToolTip(this.picMinimize, "Minimize the window");
			this.picMinimize.Click += new System.EventHandler(this.MinimizeWindow);
			this.picMinimize.MouseEnter += new System.EventHandler(this.Minimize_MouseEnter);
			this.picMinimize.MouseLeave += new System.EventHandler(this.Minimize_MouseLeave);
			// 
			// picClose
			// 
			this.picClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picClose.Location = new System.Drawing.Point(388, 6);
			this.picClose.Name = "picClose";
			this.picClose.Size = new System.Drawing.Size(32, 32);
			this.picClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picClose.TabIndex = 2;
			this.picClose.TabStop = false;
			this.tooltip.SetToolTip(this.picClose, "Exit the window");
			this.picClose.Click += new System.EventHandler(this.CloseWindow);
			this.picClose.MouseEnter += new System.EventHandler(this.Close_MouseEnter);
			this.picClose.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Location = new System.Drawing.Point(40, 13);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(121, 19);
			this.lblTitle.TabIndex = 1;
			this.lblTitle.Text = "Mechvibes.CSharp";
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
			// 
			// picIcon
			// 
			this.picIcon.Location = new System.Drawing.Point(6, 6);
			this.picIcon.Name = "picIcon";
			this.picIcon.Size = new System.Drawing.Size(32, 32);
			this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picIcon.TabIndex = 0;
			this.picIcon.TabStop = false;
			this.picIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DragForm);
			// 
			// picCaptionBarSeparator
			// 
			this.picCaptionBarSeparator.BackColor = System.Drawing.Color.Silver;
			this.picCaptionBarSeparator.Location = new System.Drawing.Point(0, 44);
			this.picCaptionBarSeparator.Name = "picCaptionBarSeparator";
			this.picCaptionBarSeparator.Size = new System.Drawing.Size(427, 1);
			this.picCaptionBarSeparator.TabIndex = 1;
			this.picCaptionBarSeparator.TabStop = false;
			// 
			// lblSoundPack
			// 
			this.lblSoundPack.AutoSize = true;
			this.lblSoundPack.Location = new System.Drawing.Point(12, 57);
			this.lblSoundPack.Name = "lblSoundPack";
			this.lblSoundPack.Size = new System.Drawing.Size(79, 19);
			this.lblSoundPack.TabIndex = 2;
			this.lblSoundPack.Text = "SoundPack:";
			// 
			// cmbSelectedSoundPack
			// 
			this.cmbSelectedSoundPack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSelectedSoundPack.FormattingEnabled = true;
			this.cmbSelectedSoundPack.Location = new System.Drawing.Point(97, 54);
			this.cmbSelectedSoundPack.Name = "cmbSelectedSoundPack";
			this.cmbSelectedSoundPack.Size = new System.Drawing.Size(317, 25);
			this.cmbSelectedSoundPack.TabIndex = 3;
			this.tooltip.SetToolTip(this.cmbSelectedSoundPack, "The currently loaded soundpacks in the application");
			this.cmbSelectedSoundPack.SelectionChangeCommitted += new System.EventHandler(this.SoundPackSelected);
			// 
			// picSeparator1
			// 
			this.picSeparator1.BackColor = System.Drawing.Color.Silver;
			this.picSeparator1.Location = new System.Drawing.Point(0, 90);
			this.picSeparator1.Name = "picSeparator1";
			this.picSeparator1.Size = new System.Drawing.Size(427, 1);
			this.picSeparator1.TabIndex = 4;
			this.picSeparator1.TabStop = false;
			// 
			// btnReloadSoundPacks
			// 
			this.btnReloadSoundPacks.Location = new System.Drawing.Point(271, 101);
			this.btnReloadSoundPacks.Name = "btnReloadSoundPacks";
			this.btnReloadSoundPacks.Size = new System.Drawing.Size(143, 37);
			this.btnReloadSoundPacks.TabIndex = 5;
			this.btnReloadSoundPacks.Text = "Reload SoundPacks";
			this.tooltip.SetToolTip(this.btnReloadSoundPacks, "Reloads the soundpack list to prevent the use of deleted soundpacks or to load ne" +
        "w soundpacks without restarting the application");
			this.btnReloadSoundPacks.UseVisualStyleBackColor = true;
			this.btnReloadSoundPacks.Click += new System.EventHandler(this.ReloadSoundPacks);
			// 
			// btnShowSoundPackFolder
			// 
			this.btnShowSoundPackFolder.Location = new System.Drawing.Point(124, 101);
			this.btnShowSoundPackFolder.Name = "btnShowSoundPackFolder";
			this.btnShowSoundPackFolder.Size = new System.Drawing.Size(141, 37);
			this.btnShowSoundPackFolder.TabIndex = 6;
			this.btnShowSoundPackFolder.Text = "Show SoundPacks";
			this.tooltip.SetToolTip(this.btnShowSoundPackFolder, "Opens the soundpack folder in File Explorer");
			this.btnShowSoundPackFolder.UseVisualStyleBackColor = true;
			this.btnShowSoundPackFolder.Click += new System.EventHandler(this.OpenSoundPackFolder);
			// 
			// btnOpenSoundEditor
			// 
			this.btnOpenSoundEditor.Location = new System.Drawing.Point(12, 101);
			this.btnOpenSoundEditor.Name = "btnOpenSoundEditor";
			this.btnOpenSoundEditor.Size = new System.Drawing.Size(106, 37);
			this.btnOpenSoundEditor.TabIndex = 7;
			this.btnOpenSoundEditor.Text = "Sound Editor";
			this.tooltip.SetToolTip(this.btnOpenSoundEditor, "Opens the sound editor for making custom soundpacks");
			this.btnOpenSoundEditor.UseVisualStyleBackColor = true;
			this.btnOpenSoundEditor.Click += new System.EventHandler(this.OpenSoundEditor);
			// 
			// picSeparator3
			// 
			this.picSeparator3.BackColor = System.Drawing.Color.Silver;
			this.picSeparator3.Location = new System.Drawing.Point(0, 192);
			this.picSeparator3.Name = "picSeparator3";
			this.picSeparator3.Size = new System.Drawing.Size(427, 1);
			this.picSeparator3.TabIndex = 8;
			this.picSeparator3.TabStop = false;
			// 
			// lblGitHubAccount
			// 
			this.lblGitHubAccount.AutoSize = true;
			this.lblGitHubAccount.ForeColor = System.Drawing.Color.Blue;
			this.lblGitHubAccount.Location = new System.Drawing.Point(149, 199);
			this.lblGitHubAccount.Name = "lblGitHubAccount";
			this.lblGitHubAccount.Size = new System.Drawing.Size(102, 19);
			this.lblGitHubAccount.TabIndex = 9;
			this.lblGitHubAccount.Text = "github/Lexz-08";
			this.tooltip.SetToolTip(this.lblGitHubAccount, "My GitHub Account");
			this.lblGitHubAccount.Click += new System.EventHandler(this.GitHubAccount_Click);
			this.lblGitHubAccount.MouseEnter += new System.EventHandler(this.GitHubAccount_MouseEnter);
			this.lblGitHubAccount.MouseLeave += new System.EventHandler(this.GitHubAccount_MouseLeave);
			// 
			// lblGitHubRepository
			// 
			this.lblGitHubRepository.AutoSize = true;
			this.lblGitHubRepository.ForeColor = System.Drawing.Color.Blue;
			this.lblGitHubRepository.Location = new System.Drawing.Point(258, 199);
			this.lblGitHubRepository.Name = "lblGitHubRepository";
			this.lblGitHubRepository.Size = new System.Drawing.Size(166, 19);
			this.lblGitHubRepository.TabIndex = 10;
			this.lblGitHubRepository.Text = "github/Mechvibes.CSharp";
			this.tooltip.SetToolTip(this.lblGitHubRepository, "The GitHub repository that stores the source code for this application");
			this.lblGitHubRepository.Click += new System.EventHandler(this.GitHubRepository_Click);
			this.lblGitHubRepository.MouseEnter += new System.EventHandler(this.GitHubRepository_MouseEnter);
			this.lblGitHubRepository.MouseLeave += new System.EventHandler(this.GitHubRepository_MouseLeave);
			// 
			// lblLinkSeparator
			// 
			this.lblLinkSeparator.AutoSize = true;
			this.lblLinkSeparator.ForeColor = System.Drawing.Color.Black;
			this.lblLinkSeparator.Location = new System.Drawing.Point(247, 199);
			this.lblLinkSeparator.Name = "lblLinkSeparator";
			this.lblLinkSeparator.Size = new System.Drawing.Size(15, 19);
			this.lblLinkSeparator.TabIndex = 11;
			this.lblLinkSeparator.Text = "-";
			// 
			// picSeparator2
			// 
			this.picSeparator2.BackColor = System.Drawing.Color.Silver;
			this.picSeparator2.Location = new System.Drawing.Point(0, 148);
			this.picSeparator2.Name = "picSeparator2";
			this.picSeparator2.Size = new System.Drawing.Size(427, 1);
			this.picSeparator2.TabIndex = 12;
			this.picSeparator2.TabStop = false;
			// 
			// numVolume
			// 
			this.numVolume.Location = new System.Drawing.Point(12, 158);
			this.numVolume.Name = "numVolume";
			this.numVolume.Size = new System.Drawing.Size(61, 25);
			this.numVolume.TabIndex = 13;
			this.numVolume.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.numVolume.ValueChanged += new System.EventHandler(this.VolumeChanged);
			// 
			// trckVolume
			// 
			this.trckVolume.Location = new System.Drawing.Point(76, 159);
			this.trckVolume.Maximum = 100;
			this.trckVolume.Name = "trckVolume";
			this.trckVolume.Size = new System.Drawing.Size(338, 45);
			this.trckVolume.TabIndex = 14;
			this.trckVolume.TickStyle = System.Windows.Forms.TickStyle.None;
			this.trckVolume.Value = 50;
			this.trckVolume.ValueChanged += new System.EventHandler(this.VolumeChanged);
			// 
			// picMinimizeToSystemTray
			// 
			this.picMinimizeToSystemTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.picMinimizeToSystemTray.Location = new System.Drawing.Point(324, 6);
			this.picMinimizeToSystemTray.Name = "picMinimizeToSystemTray";
			this.picMinimizeToSystemTray.Size = new System.Drawing.Size(32, 32);
			this.picMinimizeToSystemTray.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.picMinimizeToSystemTray.TabIndex = 5;
			this.picMinimizeToSystemTray.TabStop = false;
			this.tooltip.SetToolTip(this.picMinimizeToSystemTray, "Minimize the window");
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(426, 223);
			this.Controls.Add(this.numVolume);
			this.Controls.Add(this.picSeparator2);
			this.Controls.Add(this.lblLinkSeparator);
			this.Controls.Add(this.lblGitHubRepository);
			this.Controls.Add(this.lblGitHubAccount);
			this.Controls.Add(this.picSeparator3);
			this.Controls.Add(this.btnOpenSoundEditor);
			this.Controls.Add(this.btnShowSoundPackFolder);
			this.Controls.Add(this.btnReloadSoundPacks);
			this.Controls.Add(this.picSeparator1);
			this.Controls.Add(this.cmbSelectedSoundPack);
			this.Controls.Add(this.lblSoundPack);
			this.Controls.Add(this.picCaptionBarSeparator);
			this.Controls.Add(this.pnlCaptionBar);
			this.Controls.Add(this.trckVolume);
			this.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Mechvibes.CSharp";
			this.pnlCaptionBar.ResumeLayout(false);
			this.pnlCaptionBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picMinimize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picCaptionBarSeparator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picSeparator2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numVolume)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trckVolume)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picMinimizeToSystemTray)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel pnlCaptionBar;
		private System.Windows.Forms.PictureBox picIcon;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.PictureBox picMinimize;
		private System.Windows.Forms.PictureBox picClose;
		private System.Windows.Forms.PictureBox picCaptionBarSeparator;
		private System.Windows.Forms.Label lblSoundPack;
		private System.Windows.Forms.ComboBox cmbSelectedSoundPack;
		private System.Windows.Forms.PictureBox picSeparator1;
		private System.Windows.Forms.Button btnReloadSoundPacks;
		private System.Windows.Forms.Button btnShowSoundPackFolder;
		private System.Windows.Forms.Button btnOpenSoundEditor;
		private System.Windows.Forms.PictureBox picSeparator3;
		private System.Windows.Forms.Label lblGitHubAccount;
		private System.Windows.Forms.Label lblGitHubRepository;
		private System.Windows.Forms.Label lblLinkSeparator;
		private System.Windows.Forms.ToolTip tooltip;
		private System.Windows.Forms.PictureBox picSeparator2;
		private System.Windows.Forms.NumericUpDown numVolume;
		private System.Windows.Forms.TrackBar trckVolume;
		private System.Windows.Forms.PictureBox picMinimizeToSystemTray;
	}
}

