namespace Mechvibes.CSharp
{
	internal class Keymap
	{
		private readonly Key keybind;
		private readonly string audioFile;

		public Key Keybind => keybind;
		public string AudioFile => audioFile;

		public Keymap(Key Keybind, string AudioFile)
		{
			keybind = Keybind;
			audioFile = AudioFile;
		}
	}
}
