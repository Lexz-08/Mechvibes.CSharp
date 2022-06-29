using System.Collections.Generic;
using System.Linq;

namespace Mechvibes.CSharp
{
	internal class SoundPack
	{
		private string packName;
		private List<Keymap> keybinds;

		public string Name => packName;
		public List<Keymap> Keybinds => keybinds;

		public bool IncludesNumPad
		{
			get
			{
				int[] codes = new int[17] { 69, 3637, 55, 74, 78, 3612, 83, 79, 80, 81, 75, 76, 77, 71, 72, 73, 82 };
				foreach (int code in codes)
					foreach (Keymap keymap in keybinds)
						if (KeymapHelper.GetCodeFromKey(keymap.Keybind) == code)
							return true;

				return false;
			}
		}

		public SoundPack(string Packname, List<Keymap> Keybinds)
		{
			packName = Packname;
			keybinds = Keybinds.Where(keymap => keymap.Keybind != Key.Unsupported).ToList();

			for (int i = 0; i < keybinds.Count - 1; i++)
				for (int j = 1; j < keybinds.Count; j++)
					if (KeymapHelper.GetCodeFromKey(keybinds[j].Keybind) > KeymapHelper.GetCodeFromKey(keybinds[i].Keybind))
					{
						Keymap temp_ = keybinds[i];

						keybinds[i] = keybinds[j];
						keybinds[j] = temp_;
					}

			Keymap temp__ = keybinds[0];

			keybinds[0] = keybinds[keybinds.Count - 1];
			keybinds[keybinds.Count - 1] = temp__;
		}

		public string GetBindedAudio(Key Keybind)
		{
			foreach (Keymap keymap in keybinds)
				if (keymap.Keybind == Keybind)
					return keymap.AudioFile;

			return string.Empty;
		}
	}
}
