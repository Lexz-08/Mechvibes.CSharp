namespace Mechvibes.CSharp
{
	internal struct AudioRange
	{
		public int Position;
		public int Duration;

		public static readonly AudioRange Empty = new AudioRange();
	}
}
