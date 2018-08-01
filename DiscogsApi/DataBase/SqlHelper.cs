using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DiscogsApi
{
	public class SqlHelper
	{
		static string connectionString = "Integrated Security=SSPI;" +
											 "Data Source=.\\SQLEXPRESS;" +
											 "Initial Catalog=SLB;";

		public static SqlConnection GetConnection()
		{
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			return conn;
		}

		public static List<AlbumModel> Get(int start, int take)
		{
			var albumList = new List<AlbumModel>();

			using (var connection = GetConnection())
			{
				var sqlCommand = new SqlCommand();
				sqlCommand.Connection = connection;
				sqlCommand.CommandText = "SELECT AlbumID FROM Album ORDER BY AlbumID OFFSET @Start ROWS FETCH NEXT @Take ROWS ONLY;";

				var sqlStartParam = new SqlParameter
				{
					DbType = System.Data.DbType.Int32,
					Value = (start - 1) * take,
					ParameterName = "@Start"
				};

				var sqlTakeParam = new SqlParameter
				{
					DbType = System.Data.DbType.Int32,
					Value = take,
					ParameterName = "@Take"
				};
				sqlCommand.Parameters.Add(sqlStartParam);
				sqlCommand.Parameters.Add(sqlTakeParam);

				var data = sqlCommand.ExecuteReader();

				while (data.HasRows && data.Read())
				{
					AlbumModel album = new AlbumModel();
					album.ID = (int)data["AlbumID"];
					album.Reload();
					albumList.Add(album);
				}
			}
			return albumList;
		}
	}
}
