using System.Windows.Forms;

namespace Gma.UserActivityMonitor
{
	public class KeyEventExtArgs : KeyEventArgs
	{
		private bool extended;

		public bool Extended => extended;

		public KeyEventExtArgs(Keys keyData, bool Extended) : base(keyData) => extended = Extended;
	}
}
