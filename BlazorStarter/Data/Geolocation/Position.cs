using System;

namespace BlazorStarter.Data.Geolocation
{
	public class PositionOptions
	{
		public bool EnableHighAccuracy { get; set; } = false;
		public int Timeout { get; set; }
		public int MaximumAge { get; set; } = 0;
	}

	public class Coords
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}

	public class Position
	{
		public Coords Coords { get; set; }
		public DateTime Timestamp { get; set; }
	}

	public enum PositionError
	{
		PERMISSION_DENIED = 1,
		POSITION_UNAVAILABLE,
		TIMEOUT
	}
}
