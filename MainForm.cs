using Gma.System.MouseKeyHook;
using Microsoft.Win32;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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
		private readonly List<SoundPack> soundpacks = new List<SoundPack>();
		private SoundPack currentSoundpack;

		private Keys prevKey = Keys.None;
		private int audioVolume = 50;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			DownloadDefaultPacks();

			IKeyboardMouseEvents hook = Hook.GlobalEvents();
			hook.KeyDown += Keyboard_KeyDown;
			hook.KeyUp += Keyboard_KeyUp;

			FormClosing += (s, ee) =>
			{
				hook.KeyDown -= Keyboard_KeyDown;
				hook.KeyUp -= Keyboard_KeyUp;
				hook.Dispose();
			};
		}

		private void DownloadDefaultPacks()
		{
			void Extract(string Resource, string File)
			{
				using (Stream s = Assembly.GetExecutingAssembly().GetManifestResourceStream(Resource))
				using (BinaryReader br = new BinaryReader(s))
				using (FileStream fs = new FileStream(File, FileMode.OpenOrCreate))
				using (BinaryWriter bw = new BinaryWriter(fs))
					bw.Write(br.ReadBytes((int)s.Length));
			}

			Assembly asm = Assembly.GetExecutingAssembly();

			string[] nk_cream = asm.GetManifestResourceNames().Where(name => name.Contains("nk_cream")).ToArray();

			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-abs");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-pbt");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-abs");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-pbt");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-abs");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-pbt");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-abs");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-pbt");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\eg-crystal-purple");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\eg-oreo");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\nk-cream");
			Directory.CreateDirectory($"{Application.StartupPath}\\DefaultPacks\\topre-purple-hybrid-pbt");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_abs.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-abs\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_abs.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-abs\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_pbt.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-pbt\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_black_pbt.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-black-pbt\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_abs.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-abs\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_abs.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-abs\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_pbt.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-pbt\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_blue_pbt.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-blue-pbt\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_abs.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-abs\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_abs.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-abs\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_pbt.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-pbt\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_brown_pbt.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-brown-pbt\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_abs.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-abs\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_abs.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-abs\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_pbt.config.json", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-pbt\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.cherrymx_red_pbt.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\cherrymx-red-pbt\\sound.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.eg_crystal_purple.config.json", $"{Application.StartupPath}\\DefaultPacks\\eg-crystal-purple\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.eg_crystal_purple.purple.wav", $"{Application.StartupPath}\\DefaultPacks\\eg-crystal-purple\\purple.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.eg_oreo.config.json", $"{Application.StartupPath}\\DefaultPacks\\eg-oreo\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.eg_oreo.oreo.wav", $"{Application.StartupPath}\\DefaultPacks\\eg-oreo\\oreo.wav");

			Extract("Mechvibes.CSharp.DefaultPacks.topre_purple_hybrid_pbt.config.json", $"{Application.StartupPath}\\DefaultPacks\\topre-purple-hybrid-pbt\\config.json");
			Extract("Mechvibes.CSharp.DefaultPacks.topre_purple_hybrid_pbt.sound.wav", $"{Application.StartupPath}\\DefaultPacks\\topre-purple-hybrid-pbt\\sound.wav");

			foreach (string nk_cream_file in nk_cream)
			{
				string[] parts = nk_cream_file.Split('.');
				string name = parts[parts.Length - 2];
				string type = parts[parts.Length - 1];

				Extract(nk_cream_file, $"{Application.StartupPath}\\DefaultPacks\\nk-cream\\{name}.{type}");
			}

			LoadDefaultPacks();
		}

		private void LoadDefaultPacks()
		{
			cmbSelectedSoundPack.Items.Clear();

			foreach (string defaultpack in Directory.EnumerateDirectories($"{Application.StartupPath}\\DefaultPacks"))
			{
				if (SoundPackHelper.IsMultikeyPack(defaultpack + "\\config.json") == true)
				{
					SoundPack mechvibesPack = SoundPackHelper.LoadFromManifest(defaultpack + "\\config.json");

					soundpacks.Add(mechvibesPack);
					cmbSelectedSoundPack.Items.Add(mechvibesPack.Name);
				}
				else
				{
					SingleKeySoundPack mechvibesPack = SoundPackHelper.LoadSingleKeyFromManifest(defaultpack + "\\config.json");

					soundpacks.Add(mechvibesPack);
					cmbSelectedSoundPack.Items.Add(mechvibesPack.Name);
				}
			}

			cmbSelectedSoundPack.Text = cmbSelectedSoundPack.Items[0].ToString();
			currentSoundpack = soundpacks.Where(soundpack => soundpack.Name == cmbSelectedSoundPack.Text).First();

			LoadSoundPacks();
		}

		private void LoadSoundPacks()
		{
			foreach (string soundpack in Directory.EnumerateDirectories(mechvibesFolder))
			{
				if (SoundPackHelper.IsMultikeyPack(soundpack + "\\config.json") == true)
				{
					SoundPack mechvibesPack = SoundPackHelper.LoadFromManifest(soundpack + "\\config.json");

					soundpacks.Add(mechvibesPack);
					cmbSelectedSoundPack.Items.Add(mechvibesPack.Name);
				}
				else
				{
					SingleKeySoundPack mechvibesPack = SoundPackHelper.LoadSingleKeyFromManifest(soundpack + "\\config.json");

					soundpacks.Add(mechvibesPack);
					cmbSelectedSoundPack.Items.Add(mechvibesPack.Name);
				}
			}

			cmbSelectedSoundPack.Text = cmbSelectedSoundPack.Items[0].ToString();
			currentSoundpack = soundpacks.Where(soundpack => soundpack.Name == cmbSelectedSoundPack.Text).First();
		}

		private async void PlayAudio(string file, int volume)
		{
			await Task.Run(() =>
			{
				WaveOutEvent output = new WaveOutEvent { Volume = volume / 100.0f };
				AudioFileReader audio = new AudioFileReader(file);
				output.Init(audio);

				output.PlaybackStopped += (s, e) =>
				{
					output.Dispose();
					audio.Dispose();
				};

				output.Play();
			});

			GC.Collect();
		}

		private async void PlayTrimmedAudio(string file, int volume, AudioRange range)
		{
			await Task.Run(() =>
			{
				WaveOutEvent output = new WaveOutEvent { Volume = volume / 100.0f };
				AudioFileReader audio = new AudioFileReader(file);
				OffsetSampleProvider trimmed = new OffsetSampleProvider(audio)
				{
					SkipOver = TimeSpan.FromMilliseconds(range.Position),
					Take = TimeSpan.FromMilliseconds(range.Duration),
				};
				output.Init(trimmed);

				output.PlaybackStopped += (s, e) =>
				{
					output.Dispose();
					audio.Dispose();
				};

				output.Play();
			});
		}

		private async void Keyboard_KeyDown(object sender, KeyEventArgs e)
		{
			GC.Collect();

			await Task.Run(() =>
			{
				GC.Collect();

				if (e.KeyCode != prevKey)
				{
					if (currentSoundpack.GetType() == typeof(SoundPack))
						PlayAudio(currentSoundpack.GetBindedAudio(KeymapHelper.GetSoundPackKey(e.KeyCode, false)), audioVolume);
					else if (currentSoundpack.GetType() == typeof(SingleKeySoundPack))
					{
						SingleKeySoundPack soundpack = (SingleKeySoundPack)currentSoundpack;

						PlayTrimmedAudio(soundpack.AudioFile, audioVolume, soundpack.GetBindedRange(KeymapHelper.GetSoundPackKey(e.KeyCode, false)));
					}

					prevKey = e.KeyCode;
				}
			});

			GC.Collect();
		}

		private async void Keyboard_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == prevKey) await Task.Run(() => prevKey = Keys.None );
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

		private void ReloadSoundPacks(object sender, EventArgs e) => LoadDefaultPacks();

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
