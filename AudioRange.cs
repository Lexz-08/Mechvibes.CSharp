namespace Mechvibes.CSharp
{
	internal struct AudioRange
	{
		public int Position;
		public int Duration;

		public static readonly AudioRange Empty = new AudioRange();

		public static bool operator ==(AudioRange left, AudioRange right)
		{
			return (left.Position == right.Position) && (left.Duration == right.Duration);
		}

		public static bool operator !=(AudioRange left, AudioRange right)
		{
			return (right.Position != left.Position) || (right.Duration != left.Duration);
		}
	}
}
