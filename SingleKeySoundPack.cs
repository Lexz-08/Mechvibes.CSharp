using System.Collections.Generic;

namespace Mechvibes.CSharp
{
	internal class SingleKeySoundPack : SoundPack
	{
		private List<(Key, AudioRange)> keybinds = new List<(Key, AudioRange)>();
		private string audioFile;

		public new List<(Key, AudioRange)> Keybinds => keybinds;
		public string AudioFile => audioFile;

		public override bool IncludesNumPad
		{
			get
			{
				int[] codes = new int[17] { 69, 3637, 55, 74, 78, 3612, 83, 79, 80, 81, 75, 76, 77, 71, 72, 73, 82 };
				foreach (int code in codes)
					foreach ((Key, AudioRange) keybind in keybinds)
						if (KeymapHelper.GetCodeFromKey(keybind.Item1) == code)
							return true;

				return false;
			}
		}

		public SingleKeySoundPack(string Packname, string AudioFile, List<(Key, AudioRange)> Keybinds) : base(Packname, new List<Keymap>())
		{
			keybinds = Keybinds;
			audioFile = AudioFile;
		}

		public AudioRange GetBindedRange(Key Keybind)
		{
			foreach ((Key, AudioRange) keybind in keybinds)
				if (keybind.Item1 == Keybind)
					return keybind.Item2;

			return AudioRange.Empty;
		}
	}
}
