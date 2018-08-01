using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsApi
{
	public class ArtistModel
	{
		public ArtistModel(string name, string role, string albumTitle)
		{
			Name = name;
			Role = role;
			AlbumTitle = albumTitle;
		}

		public string Name { get; set; }
		public string Role { get; set; }
		public string AlbumTitle { get; set; }
	}
}
