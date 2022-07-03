using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Mechvibes.CSharp
{
	internal static class SoundPackHelper
	{
		public static SoundPack LoadFromManifest(string JSONFile)
		{
			if (IsMultikeyPack(JSONFile) == false)
			{
				try
				{
					throw new Exception("Cannot load multi-key soundpack from a single-key manifest. Please provide a multi-key soundpack file.");
				}
				catch
				{
					MessageBox.Show("Cannot load multi-key soundpack from a single-key manifest. Please provide a multi-key soundpack file.", "Pack Specified Is Not Multi-Key",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			JObject packInfo = JObject.Parse(File.ReadAllText(JSONFile));
			string name = packInfo.Value<string>("name");
			JObject defines = packInfo.Value<JObject>("defines");

			List<Keymap> keybinds = new List<Keymap>();

			foreach (JProperty keybind in defines.Properties())
			{
				Key key = KeymapHelper.GetKeyFromManifest(int.Parse(keybind.Name));
				string audio = Path.GetDirectoryName(JSONFile) + "\\" + keybind.Value;

				keybinds.Add(new Keymap(key, audio));
			}

			return new SoundPack(name, keybinds);
		}

		public static SingleKeySoundPack LoadSingleKeyFromManifest(string JSONFile)
		{
			if (IsMultikeyPack(JSONFile) == true)
			{
				try
				{
					throw new Exception("Cannot load single-key soundpack from a single-key manifest. Please provide a multi-key soundpack file.");
				}
				catch
				{
					MessageBox.Show("Cannot load single-key soundpack from a single-key manifest. Please provide a multi-key soundpack file.", "Pack Specified Is Not Single-Key",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}

			JObject packInfo = JObject.Parse(File.ReadAllText(JSONFile));
			string name = packInfo.Value<string>("name");
			JObject defines = packInfo.Value<JObject>("defines");

			List<(Key, AudioRange)> keybinds = new List<(Key, AudioRange)>();

			foreach (JProperty keybind in defines.Properties())
			{
				Key key = KeymapHelper.GetKeyFromManifest(int.Parse(keybind.Name));

				if (defines[keybind.Name] is JArray audioPoints)
				{
					AudioRange audioInfo = new AudioRange
					{
						Position = int.Parse(audioPoints[0].ToString()),
						Duration = int.Parse(audioPoints[1].ToString()),
					};

					keybinds.Add((key, audioInfo));
				}
			}

			return new SingleKeySoundPack(name, Path.GetDirectoryName(JSONFile) + "\\" + packInfo.Value<string>("sound"), keybinds);
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

		public static void SaveSingleKeyToManifest(SingleKeySoundPack SoundPack, string JSONFile)
		{
			List<string> packinfo = new List<string>
			{
				"{",
				"\t\"id\": \"custom-sound-pack-1612728813651",
				"\t\"name\": " + SoundPack.Name + "\",",
				"\t\"key_define_type\": \"single\",",
				"\t\"includes_numpad\": \"" + SoundPack.IncludesNumPad.ToString().ToLower() + "\",",
				"\t\"sound\": \"" + Path.GetFileName(SoundPack.AudioFile) + "\",",
				"\t\"defines\": {",
			};

			foreach ((Key, AudioRange) keybind in SoundPack.Keybinds)
			{
				packinfo.Add("\t\t" + KeymapHelper.GetCodeFromKey(keybind.Item1) + "\": [");
				packinfo.Add("\t\t\t" + keybind.Item2.Position + ",");
				packinfo.Add("\t\t\t" + keybind.Item2.Duration + ",");
				packinfo.Add("\t\t]" + (keybind.Item1 == SoundPack.Keybinds.Last().Item1 ? "" : ","));
			}

			packinfo.Add("\t}");
			packinfo.Add("}");

			File.WriteAllLines(JSONFile, packinfo);
		}

		public static bool? IsMultikeyPack(string JSONFile)
		{
			JObject packInfo = JObject.Parse(File.ReadAllText(JSONFile));
			bool specifiesKeyType = packInfo.ContainsKey("key_define_type");
			bool specifiesMultikey = specifiesKeyType && (packInfo.Value<string>("key_define_type") == "multi");

			if (!specifiesKeyType)
			{
				MessageBox.Show("The pack manifest (config.json) specified is not in a valid form because it does not specify if the soundpack it represents is a multi-key or single-key soundpack.", "Pack Manifest (config.json) Specified Is Invalid",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return null;
			}

			return specifiesMultikey;
		}
	}
}
