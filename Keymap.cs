namespace Mechvibes.CSharp
{
	internal class Keymap
	{
		private Key keybind;
		private string audioFile;

		public Key Keybind => keybind;
		public string AudioFile => audioFile;

		public Keymap(Key Keybind, string AudioFile)
		{
			keybind = Keybind;
			audioFile = AudioFile;
		}
	}
}
