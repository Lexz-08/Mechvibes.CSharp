using Gma.UserActivityMonitor;
using Microsoft.Win32;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			string cursorPath = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Cursors").GetValue("Hand").ToString();
			IntPtr cursorHandle = string.IsNullOrEmpty(cursorPath) ? IntPtr.Zero : LoadCursorFromFile(cursorPath);
			Cursor cursorHand = cursorHandle == IntPtr.Zero ? Cursors.Hand : new Cursor(cursorHandle);

			picMinimizeToSystemTray.Cursor = cursorHand;
			picMinimize.Cursor = cursorHand;
			picClose.Cursor = cursorHand;
			cmbSelectedSoundPack.Cursor = cursorHand;
			btnReloadSoundPacks.Cursor = cursorHand;
			btnShowSoundPackFolder.Cursor = cursorHand;
			btnOpenSoundEditor.Cursor = cursorHand;
			lblGitHubAccount.Cursor = cursorHand;
			lblGitHubRepository.Cursor = cursorHand;

			void Unfocus(object sender, EventArgs e) => lblTitle.Focus();

			cmbSelectedSoundPack.SelectionChangeCommitted += new EventHandler(Unfocus);
			btnReloadSoundPacks.Click += new EventHandler(Unfocus);
			btnShowSoundPackFolder.Click += new EventHandler(Unfocus);
			btnOpenSoundEditor.Click += new EventHandler(Unfocus);

			picMinimizeToSystemTray.Image = Bitmaps.Instance[32, Color.Gray, Color.White, BitmapType.DownArrow];
			picMinimize.Image = Bitmaps.Instance[32, Color.Gray, Color.White, BitmapType.Minimize];
			picClose.Image = Bitmaps.Instance[32, Color.Black, Color.White, BitmapType.Close];

			Bitmap iconBitmap = new Bitmap(32, 32);
			using (Graphics iconGraphics = Graphics.FromImage(iconBitmap))
				iconGraphics.DrawIcon(Icon, new Rectangle(0, 0, 32, 32));

			picIcon.Image = iconBitmap;
		}

		#region Basic Window Functionality

		private readonly string startupFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\";

		[DllImport("user32.dll")]
		private static extern IntPtr LoadCursorFromFile(string lpFilename);

		[DllImport("user32.dll")]
		private static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		private void DragForm(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, 161, 2, 0);
			}
		}
		private void UnminimizeWindowToNormal(object sender, EventArgs e)
		{
			Visible = true;
		}
		private void MinimizeToSystemTray(object sender, EventArgs e)
		{
			Visible = false;
		}
		private void MinimizeWindow(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		private void CloseWindow(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void MinimizeSysTray_MouseEnter(object sender, EventArgs e) => picMinimizeToSystemTray.BackColor = SystemColors.Control;
		private void MinimizeSysTray_MouseLeave(object sender, EventArgs e) => picMinimizeToSystemTray.BackColor = Color.White;

		private void Minimize_MouseEnter(object sender, EventArgs e) => picMinimize.BackColor = SystemColors.Control;
		private void Minimize_MouseLeave(object sender, EventArgs e) => picMinimize.BackColor = Color.White;

		private void Close_MouseEnter(object sender, EventArgs e) => picClose.BackColor = SystemColors.Control;
		private void Close_MouseLeave(object sender, EventArgs e) => picClose.BackColor = Color.White;

		private void GitHubAccount_MouseEnter(object sender, EventArgs e) => lblGitHubAccount.Font = new Font("Segoe UI", 10.0f, FontStyle.Underline);
		private void GitHubAccount_MouseLeave(object sender, EventArgs e) => lblGitHubAccount.Font = new Font("Segoe UI", 10.0f);

		private void GitHubRepository_MouseEnter(object sender, EventArgs e) => lblGitHubRepository.Font = new Font("Segoe UI", 10.0f, FontStyle.Underline);
		private void GitHubRepository_MouseLeave(object sender, EventArgs e) => lblGitHubRepository.Font = new Font("Segoe UI", 10.0f);

		private void GitHubAccount_Click(object sender, EventArgs e) => Process.Start("https://github.com/Lexz-08");
		private void GitHubRepository_Click(object sender, EventArgs e) => Process.Start("https://github.com/Lexz-08/Mechvibes.CSharp");

		#endregion

		#region SoundPack Management

		private readonly string mechvibesFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\mechvibes_custom";
		private List<SoundPack> soundpacks = new List<SoundPack>();
		private SoundPack currentSoundpack;

		private Keys prevKey = Keys.None;
		private int audioVolume = 50;

		private void LoadSoundPacks()
		{
			cmbSelectedSoundPack.Items.Clear();

			foreach (string soundpack in Directory.EnumerateDirectories(mechvibesFolder))
				if (SoundPackHelper.IsMultikeyPack(soundpack + "\\config.json"))
				{
					SoundPack mechvibesPack = SoundPackHelper.LoadFromManifest(soundpack + "\\config.json");

					soundpacks.Add(mechvibesPack);
					cmbSelectedSoundPack.Items.Add(mechvibesPack.Name);
				}

			cmbSelectedSoundPack.Text = cmbSelectedSoundPack.Items[0].ToString();
			currentSoundpack = soundpacks.Where(soundpack => soundpack.Name == cmbSelectedSoundPack.Text).First();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			LoadSoundPacks();

			HookManager.KeyDown += new KeyEventHandler(Keyboard_KeyDown);
			HookManager.KeyUp += new KeyEventHandler(Keyboard_KeyUp);
		}

		private async void Keyboard_KeyDown(object sender, KeyEventArgs e)
		{
			await Task.Run(() =>
			{
				if (e.KeyCode != prevKey)
				{
					WaveOutEvent outputDevice = new WaveOutEvent();
					AudioFileReader audioFile = new AudioFileReader(currentSoundpack.GetBindedAudio(KeymapHelper.GetSoundPackKey(e.KeyCode)));
					outputDevice.Init(audioFile);
					outputDevice.Volume = audioVolume / 100.0f;
					outputDevice.Play();

					prevKey = e.KeyCode;
				}
			});
		}

		private async void Keyboard_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == prevKey) await Task.Run(() => prevKey = Keys.None);
		}

		private void SoundPackSelected(object sender, EventArgs e)
		{
			currentSoundpack = soundpacks.Where(soundpack => soundpack.Name == cmbSelectedSoundPack.Text).First();
		}

		private void VolumeChanged(object sender, EventArgs e)
		{
			if (sender == trckVolume)
				numVolume.Value = audioVolume = trckVolume.Value;
			else if (sender == numVolume)
				trckVolume.Value = audioVolume = (int)numVolume.Value;
		}

		private void ReloadSoundPacks(object sender, EventArgs e) => LoadSoundPacks();

		private void OpenSoundPackFolder(object sender, EventArgs e) => Process.Start("explorer.exe", mechvibesFolder);

		private void OpenSoundEditor(object sender, EventArgs e)
		{
			SoundEditor soundEditor = new SoundEditor();
			soundEditor.Shown += (s, ee) => soundEditor.Focus();
			soundEditor.Show();
		}

		#endregion

		#region Custom Windows Drop Shadow

		private bool m_aeroEnabled = false;

		[DllImport("dwmapi.dll")]
		private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

		[DllImport("dwmapi.dll")]
		private static extern int DwmSetWindowAttribute(IntPtr hWnd, int attr, ref int attrValue, int attrSize);

		[DllImport("dwmapi.dll")]
		private static extern int DwmIsCompositionEnabled(ref int pfEnabled);

		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0;
				DwmIsCompositionEnabled(ref enabled);

				return enabled == 1;
			}

			return false;
		}

		private struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				m_aeroEnabled = CheckAeroEnabled();

				if (!m_aeroEnabled)
					cp.ClassStyle |= 0x20000;

				return cp;
			}
		}

		protected override void WndProc(ref Message m)
		{
			if (m_aeroEnabled)
			{
				int v = 2;
				DwmSetWindowAttribute(Handle, 2, ref v, 4);
				MARGINS margins = new MARGINS
				{
					leftWidth = 0,
					rightWidth = 0,
					topHeight = 1,
					bottomHeight = 0,
				};
				DwmExtendFrameIntoClientArea(Handle, ref margins);
			}

			base.WndProc(ref m);
		}

		#endregion
	}
}
