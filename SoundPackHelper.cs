using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mechvibes.CSharp
{
	internal static class SoundPackHelper
	{
		public static SoundPack LoadFromManifest(string JSONFile)
		{
			if (!IsMultikeyPack(JSONFile))
				throw new NotSupportedException("Cannot load soundpack because it uses a single audio file for the entire keymap.\n\nPlease use a multi-key soundpack.");

			Dictionary<string, string> info = File.ReadAllLines(JSONFile)
				.Where(line => line.Contains(':') && !(line.Contains("{") || line.Contains("}")))
				.ToDictionary(pair => pair.Split(':')[0].Replace("\"", "").Trim(), pair => pair.Split(':')[1].Replace("\"", "").Replace(",", "").Trim());

			info.Remove("id");
			info.Remove("key_define_type");
			info.Remove("includes_numpad");
			info.Remove("sound");

			SoundPack soundpack = null;
			List<Keymap> keybinds = new List<Keymap>();

			foreach (string key in info.Keys.Where(jsonkey => jsonkey != "name"))
			{
				int code = int.Parse(key);
				string audioFile = Path.GetDirectoryName(JSONFile) + "\\" + info[key];

				keybinds.Add(new Keymap(KeymapHelper.GetKeyFromManifest(code), audioFile));
			}

			soundpack = new SoundPack(info["name"], keybinds);

			return soundpack;
		}

		public static void SaveToManifest(SoundPack SoundPack, string JSONFile)
		{
			List<string> packinfo = new List<string>
			{
				"{",
				"\t\"id\": \"custom-sound-pack-1612728813651\",",
				"\t\"name\": \"" + SoundPack.Name + "\",",
				"\t\"key_define_type\": \"multi\",",
				"\t\"includes_numpad\": \"" + SoundPack.IncludesNumPad.ToString().ToLower() + "\",",
				"\t\"sound\": \"" + Path.GetFileName(SoundPack.Keybinds[0].AudioFile) + "\",",
				"\t\"defines\": {",
			};

			foreach (Keymap keymap in SoundPack.Keybinds)
				packinfo.Add("\t\t\"" + KeymapHelper.GetCodeFromKey(keymap.Keybind) + "\": \"" + Path.GetFileName(keymap.AudioFile) + "\",");

			packinfo.Add("\t}");
			packinfo.Add("}");

			File.WriteAllLines(JSONFile, packinfo);
		}

		public static bool IsMultikeyPack(string JSONFile) => !File.ReadAllText(JSONFile).Contains("\"key_define_type\": \"single\"");
	}
}
