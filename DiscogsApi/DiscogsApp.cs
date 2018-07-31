using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiscogsApi
{
	public class DiscogsApp
	{
		public string GetReleaseAlbumCDLink(string QueryResult)
		{
			string resourceUrls = "";
			try
			{
				JObject parsed = JObject.Parse(QueryResult);

				for (int i = 0; i <= parsed["results"].ToList().Count - 1; i++)
				{
					JObject p = (JObject)parsed["results"][i];

					if (p["type"].ToString() == "release" && Array.IndexOf(p["format"].ToArray(), "CD") > -1 && Array.IndexOf(p["format"].ToArray(), "Album") > -1)
					{
						resourceUrls = p["resource_url"].ToString();
						break;
					}
				}
				return resourceUrls;
			}
			catch (FormatException)
			{
				Console.WriteLine("Error: Wrong query format");
				return resourceUrls;
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
				return resourceUrls;
			}
		}

		public void ShowRelease(string release)
		{
			try
			{
				JObject parserRelease = JObject.Parse(release);

				Console.WriteLine("----------------------------------------------------------------");
				Console.WriteLine("Album: ");
				Console.WriteLine();

				Console.WriteLine($"Tytuł: {parserRelease["title"]}");
				Console.WriteLine($"Artysta: {parserRelease["artists"][0]["name"]}");

				Console.WriteLine($"Gatunek: {string.Join(", ", parserRelease["genres"])}");
				Console.WriteLine($"Styl: {string.Join(", ", parserRelease["styles"])}");
				Console.WriteLine("Lista utworów: ");//możliwosc tworzenia likow pod nazwami (wklejanie yt na konto user -> BD )
				foreach (var track in parserRelease["tracklist"])
				{
					Console.WriteLine($"{track["position"]}\t{track["duration"]}\t{track["title"]}");
				}

				Console.WriteLine("\nLista teledysków: ");
				if (!(parserRelease["videos"] is null))
				{
					foreach (var track in parserRelease["videos"])
					{
						Console.WriteLine($"{track["title"]}\t{track["uri"]}");
					}
				}

				Console.WriteLine("\nObrazy: ");//lista okładek do sciągnięcia/przejrzenia jak allegro wiele obrazkow i paginacja
				if (!(parserRelease["images"] is null))
				{
					foreach (var track in parserRelease["images"])
					{
						Console.WriteLine($"{track["uri"]}");
					}
				}

				Console.WriteLine("\n\n pracownicy przy płycie:");
				if (!(parserRelease["extraartists"] is null))
				{
					foreach (var track in parserRelease["extraartists"])
					{
						Console.Write($"\n{track["role"]}: {track["name"]}");
					}
				}
				Console.WriteLine("\n----------------------------------------------------------------");
			}
			catch (FormatException)
			{
				Console.WriteLine("Error: Wrong release format");
			}
			catch (Exception e)
			{
				Console.WriteLine("Error: " + e.Message);
			}
		}

		public bool SearchAlbumAndShow(string nameAlbum)
		{
			DiscogsClient discogsClient = new DiscogsClient("NYqvEPnYZdPWmAFFMURi", "kEvfDhiyBRunRURKFjlMmoCKPjIcYiVU");

			string result = discogsClient.SetQuery(nameAlbum).GetQueryResult(); //zapytanie o album

			string link = GetReleaseAlbumCDLink(result); //wyciagniecie linku do konretnego wydania

			string release = discogsClient.SetLink(link).GetLinkResult(); //zapytanie o wydanie konkretne
			if (string.IsNullOrEmpty(release)) return false;
			ShowRelease(release);

			return true;
		}
	}
}
