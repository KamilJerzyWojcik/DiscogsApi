using System;
using System.Collections.Generic;
using DiscogsApi.DataBase;

namespace DiscogsApi
{
	public class AlbumModel
	{
		public AlbumModel()
		{
			Genres = new List<string>();
			Styles = new List<string>();
			TrackList = new List<TrackModel>();
			Videos = new List<string>();
			Images = new List<string>();
			ExtraArtistsRoleName = new Dictionary<string, string>();
			ExtraArtists = new List<ArtistModel>();
		}

		public int ID { get; set; }
		public string Title { get; set; }
		public string Artists { get; set; }
		public List<string> Genres { get; set; }
		public List<string> Styles { get; set; }
		public List<TrackModel> TrackList { get; set; }
		public List<string> Videos { get; set; }
		public List<string> Images { get; set; }
		public Dictionary<string, string> ExtraArtistsRoleName { get; set; }
		public List<ArtistModel> ExtraArtists { get; set; }

		public int Save(AlbumModel newAlbum)
		{
			try
			{
				Console.Clear();
				if (SourceManager.AlbumExists(newAlbum)) throw new Exception("Album exist in Base");

				int ID = SourceManager.Add(newAlbum);
				if (ID == -1) throw new Exception("Error, Data didn't save to Base");

				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine($"zapisano {Title} do Bazy Danych pod ID: {ID}");
				Console.ResetColor();
				return ID;
			}
			catch (Exception e)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine(e.Message);
				Console.ResetColor();
				return -1;
			}
		}

		public bool Reload()
		{
			Console.WriteLine("zaktualizowano album id: " + ID);
			Console.ReadKey();
			return true;
		}
	}
}
