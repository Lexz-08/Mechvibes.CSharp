using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	public partial class SoundEditor : Form
	{
		public SoundEditor()
		{
			InitializeComponent();

			string cursorPath = Registry.CurrentUser.OpenSubKey("Control Panel").OpenSubKey("Cursors").GetValue("Hand").ToString();
			IntPtr cursorHandle = string.IsNullOrEmpty(cursorPath) ? IntPtr.Zero : LoadCursorFromFile(cursorPath);
			Cursor cursorHand = cursorHandle == IntPtr.Zero ? Cursors.Hand : new Cursor(cursorHandle);

			picMinimize.Cursor = cursorHand;
			picClose.Cursor = cursorHand;
			btnResetCurrentPack.Cursor = cursorHand;
			btnImportFromManifest.Cursor = cursorHand;
			btnExportToManifest.Cursor = cursorHand;

			void Unfocus(object sender, EventArgs e) => lblTitle.Focus();

			btnResetCurrentPack.Click += new EventHandler(Unfocus);
			btnImportFromManifest.Click += new EventHandler(Unfocus);
			btnExportToManifest.Click += new EventHandler(Unfocus);

			picMinimize.Image = Bitmaps.Instance[32, Color.Gray, Color.White, BitmapType.Minimize];
			picClose.Image = Bitmaps.Instance[32, Color.Black, Color.White, BitmapType.Close];

			Bitmap iconBitmap = new Bitmap(32, 32);
			using (Graphics iconGraphics = Graphics.FromImage(iconBitmap))
				iconGraphics.DrawIcon(Icon, new Rectangle(0, 0, 32, 32));

			picIcon.Image = iconBitmap;
		}

		#region Basic Window Functionality

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
		private void MinimizeWindow(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}
		private void CloseWindow(object sender, EventArgs e)
		{
			Close();
		}

		private void Minimize_MouseEnter(object sender, EventArgs e) => picMinimize.BackColor = SystemColors.Control;
		private void Minimize_MouseLeave(object sender, EventArgs e) => picMinimize.BackColor = Color.White;

		private void Close_MouseEnter(object sender, EventArgs e) => picClose.BackColor = SystemColors.Control;
		private void Close_MouseLeave(object sender, EventArgs e) => picClose.BackColor = Color.White;

		#endregion

		#region SoundPack Management

		private void ResetCurrentPack(object sender, EventArgs e)
		{
			foreach (TextBox input in Controls.OfType<TextBox>())
				input.Text = string.Empty;
		}

		private void ImportPackFromManifest(object sender, EventArgs e)
		{
			using (OpenFileDialog ofd = new OpenFileDialog
			{
				Title = "Please select a Mechvibes soundpack config to import...",
				Filter = "Mechvibes SoundPack Config|*.json",
			}) if (ofd.ShowDialog() == DialogResult.OK)
				{
					SoundPack loadedPack = SoundPackHelper.LoadFromManifest(ofd.FileName);
					txtPackName.Text = loadedPack.Name;

					foreach (Keymap keymap in loadedPack.Keybinds)
						foreach (TextBox input in Controls.OfType<TextBox>().Where(textbox => textbox.Name != "txtPackName"))
							if (input.Name == keymap.Keybind.ToString())
								input.Text = Path.GetFileName(keymap.AudioFile);
				}
		}

		private void ExportPackToManifest(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txtPackName.Text))
			{
				using (SaveFileDialog sfd = new SaveFileDialog
				{
					Title = "Please choose where you want to save your soundpack config...",
					Filter = "Mechvibes SoundPack Config|*.json",
				}) if (sfd.ShowDialog() == DialogResult.OK)
					{
						List<Keymap> keybinds = new List<Keymap>();

						foreach (TextBox input in Controls.OfType<TextBox>().Where(textbox => textbox.Name != "txtPackName"))
							if (!string.IsNullOrEmpty(input.Text))
							{
								Key keybind = (Key)TypeDescriptor.GetConverter(typeof(Key)).ConvertFromString(input.Name);
								string audioFile = input.Text;

								keybinds.Add(new Keymap(keybind, audioFile));
							}

						SoundPackHelper.SaveToManifest(new SoundPack(txtPackName.Text, keybinds), sfd.FileName);
					}
			}
			else MessageBox.Show("Soundpack must at least have a name to be exported.");
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
