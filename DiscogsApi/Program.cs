using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace DiscogsApi
{
	class Program
	{
		static void Main(string[] args)
		{
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
					Console.Clear();
					DiscogsApp discogsApp = new DiscogsApp();
					bool isSuccess = discogsApp.SearchAlbumAndShow(command);//"all eyez on me"
					if (isSuccess)
					{
						Console.ReadKey();
						Console.Clear();
					}
					else
					{
						Console.Clear();
						Console.WriteLine("Album not found, try again");
					}
				}
			} while (true);
		}
	}
}
