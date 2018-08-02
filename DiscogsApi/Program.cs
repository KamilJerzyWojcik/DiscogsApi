using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using DiscogsApi.DataBase;


namespace DiscogsApi
{
	class Program
	{
		static void Main(string[] args)
		{

			int n = SqlHelper.NumberAllAlbums();
			Console.WriteLine("liczba albumów: " + n);
			AlbumModel album = SqlHelper.GetByID(31);

			Console.WriteLine("Tytuł: " + album.Title);
			Console.WriteLine("pierwszy utwór: " + album.TrackList[0].Title);

			List<AlbumModel> albums = SqlHelper.GetByName("All", out int numberAllAlbums, 1);

			Console.WriteLine("liczba albumów: " + numberAllAlbums);
			Console.WriteLine("tytuł pierwszego albumu: " + albums[0].Title);

			Console.ReadKey();
		/*
			string command;
			
			do
			{
				Console.WriteLine("Exit: exit");
				Console.Write("\nAlbum name: ");
				command = Console.ReadLine().Trim();

				if (command == "exit") break;
				if (command == "") Console.Clear();

				if (!string.IsNullOrEmpty(command))
				{
					ShowAlbum(command);
				}

			} while (true);
			*/
		}

		private static void ShowAlbum(string command)
		{
			Console.Clear();
			DiscogsApp discogsApp = new DiscogsApp();
			bool isSuccess = discogsApp.SearchAlbumAndShow(command, out string release);
			if (!isSuccess)
			{
				Console.Clear();
				Console.WriteLine("Album not found, try again");
				return;
			}

			AlbumModel newAlbum = discogsApp.CreateAlbumByRelease(release);
			SaveToDB(newAlbum);
		}

		private static int SaveToDB(AlbumModel newAlbum)
		{
			Console.Write("\nSave to DB? (y/n): ");
			string command = Console.ReadLine();
			int ID;
			switch(command)
			{
				case "y":
					Console.Clear();
					ID = newAlbum.Save();
					return ID;
				case "n":
					Console.Clear();
					return -1;
				default:
					SaveToDB(newAlbum);
					Console.Clear();
					return 0;
			}
		}

	}
}
