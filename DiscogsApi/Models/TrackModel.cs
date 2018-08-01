using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsApi
{
	public class TrackModel
	{
		public TrackModel(string position, string duration, string title)
		{
			Position = position;
			Duration = duration;
			Title = title;
		}

		public string Position{ get; set; }
		public string Duration { get; set; }
		public string Title{ get; set; }
	}
}
