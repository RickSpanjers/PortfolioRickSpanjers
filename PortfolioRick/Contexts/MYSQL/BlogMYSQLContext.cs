using MySql.Data.MySqlClient;
using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts.MYSQL
{
	public class BlogMYSQLContext : ConnectionHelper, IBlog
	{
		public bool CreateNewBlogItem(BlogItem b)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "INSERT INTO BlogItem (Title, Message, CreatedDate, Published, Thumbnail) VALUES (@Title, @Message, @CreatedDate, @Published, @Thumbnail)";
				MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);

				newCmd.Parameters.AddWithValue("@Title", b.RetrieveTitle());
				newCmd.Parameters.AddWithValue("@Message", b.RetrieveMessage());
				newCmd.Parameters.AddWithValue("@CreatedDate", b.CreatedDate);
				newCmd.Parameters.AddWithValue("@Published", b.Publised);
				newCmd.Parameters.AddWithValue("@Thumbnail", b.Thumbnail);
				newCmd.ExecuteNonQuery();
				cnn.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return false;
		}

		public bool DeleteBlogItemById(int itemId)
		{
			MySqlConnection cnn = ReturnMYSQLConnection();
			string query = "DELETE FROM BlogItem WHERE ID=@ID";
			MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);
			newCmd.Parameters.AddWithValue("@ID", itemId);

			newCmd.ExecuteNonQuery();
			cnn.Close();
			return true;
		}

		public List<BlogItem> RetrieveAllBlogItems()
		{
			var listOfItems = new List<BlogItem>();

			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "SELECT * FROM BlogItem";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);

				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var title = dr["Title"].ToString();
					string message = dr["Message"].ToString();
					var createddate = Convert.ToDateTime(dr["CreatedDate"]);
					int published = Convert.ToInt32(dr["Published"]);
					string thumbnail = dr["Thumbnail"].ToString();

					BlogItem b = new BlogItem(itemId, title, message);
					b.CreatedDate = createddate;
					b.Publised = published;
					b.Thumbnail = thumbnail;

					listOfItems.Add(b);
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}

			return listOfItems;
		}

		public BlogItem RetrieveBlogItemById(int id)
		{
			var b = new BlogItem(-1, null, null);
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "SELECT * FROM BlogItem WHERE ID=@ID";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@ID", id);
				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var title = dr["Title"].ToString();
					string message = dr["Message"].ToString();
					var createddate = Convert.ToDateTime(dr["CreatedDate"]);
					int published = Convert.ToInt32(dr["Published"]);
					string thumbnail = dr["Thumbnail"].ToString();

					b = new BlogItem(itemId, title, message);
					b.CreatedDate = createddate;
					b.Publised = published;
					b.Thumbnail = thumbnail;
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return b;
		}

		public bool UpdateBlogItemById(BlogItem b)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "UPDATE BlogItem SET Title=@Title, Message=@Message, CreatedDate=@CreatedDate, Published=@Published, Thumbnail=@Thumbnail WHERE ID = @Id";
				MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);

				newCmd.Parameters.AddWithValue("@Id", b.RetrieveId());
				newCmd.Parameters.AddWithValue("@Title", b.RetrieveTitle());
				newCmd.Parameters.AddWithValue("@Message", b.RetrieveMessage());
				newCmd.Parameters.AddWithValue("@CreatedDate", b.CreatedDate);
				newCmd.Parameters.AddWithValue("@Published", b.Publised);
				newCmd.Parameters.AddWithValue("@Thumbnail", b.Thumbnail);

				newCmd.ExecuteNonQuery();
				cnn.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return false;
		}
	}
}
