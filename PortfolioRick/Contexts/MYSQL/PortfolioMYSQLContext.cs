using MySql.Data.MySqlClient;
using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts.MYSQL
{
	public class PortfolioMYSQLContext : ConnectionHelper, IPortfolio
	{
		public bool CreateNewItem(PortfolioItem b)
		{
			MySqlConnection cnn = ReturnMYSQLConnection();
			string query = "INSERT INTO PortfolioItem (Name, Description, FrontpageImg, Thumbnail, CategoryName, ItemTitle, CreatedDate, UrlTitle, UrlLink) VALUES (@Name, @Description, @FrontpageImg, @Thumbnail, @CategoryName, @ItemTitle, @CreatedDate, @UrlTitle, @UrlLink)";
			MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);

			newCmd.Parameters.AddWithValue("@Name", b.RetrieveTitle());
			newCmd.Parameters.AddWithValue("@Description", b.RetrieveDescription());
			newCmd.Parameters.AddWithValue("@FrontpageImg", b.FrontpageImg);
			newCmd.Parameters.AddWithValue("@Thumbnail", b.Thumbnail);
			newCmd.Parameters.AddWithValue("@CategoryName", b.categoryName);
			newCmd.Parameters.AddWithValue("@ItemTitle", b.RetrieveTitle());
			newCmd.Parameters.AddWithValue("@CreatedDate", b.createdDate);
			newCmd.Parameters.AddWithValue("@UrlTitle", b.urlTitle);
			newCmd.Parameters.AddWithValue("@UrlLink", b.urlLink);
			newCmd.ExecuteNonQuery();
			cnn.Close();
			return true;
		}

		public bool DeleteItemById(int itemId)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "DELETE FROM PortfolioItem WHERE ID = @Id";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@Id", itemId);
				cmd.ExecuteNonQuery();
				cnn.Close();
				return true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			return false;
		}

		public List<PortfolioItem> RetrieveAllItems()
		{
			var listOfItems = new List<PortfolioItem>();

			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "SELECT * FROM PortfolioItem";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);

				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var name = dr["Name"].ToString();
					var description = dr["Description"].ToString();
					var frontpageimg = dr["FrontpageImg"].ToString();
					var thumbnail = dr["Thumbnail"].ToString();
					var categoryname = dr["CategoryName"].ToString();
					var itemtitle = dr["ItemTitle"].ToString();
					var createddate = Convert.ToDateTime(dr["CreatedDate"]);
					string urltitle = dr["UrlTitle"].ToString();
					string urlname = dr["UrlLink"].ToString();

					PortfolioItem p = new PortfolioItem(itemId, name, description);
					p.categoryName = categoryname;
					p.FrontpageImg = frontpageimg;
					p.Thumbnail = thumbnail;
					p.createdDate = createddate;
					p.urlTitle = urltitle;
					p.urlLink = urlname;

					listOfItems.Add(p);
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}

			return listOfItems;
		}

		public PortfolioItem RetrieveItemById(int id)
		{
			var p = new PortfolioItem(-1, null, null);
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "SELECT * FROM PortfolioItem WHERE ID=@ID";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@ID", id);
				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var name = dr["Name"].ToString();
					var description = dr["Description"].ToString();
					var frontpageimg = dr["FrontpageImg"].ToString();
					var thumbnail = dr["Thumbnail"].ToString();
					var categoryname = dr["CategoryName"].ToString();
					var itemtitle = dr["ItemTitle"].ToString();
					var createddate = Convert.ToDateTime(dr["CreatedDate"]);
					string urltitle = dr["UrlTitle"].ToString();
					string urlname = dr["UrlLink"].ToString();

					p = new PortfolioItem(itemId, name, description);
					p.categoryName = categoryname;
					p.FrontpageImg = frontpageimg;
					p.createdDate = createddate;
					p.Thumbnail = thumbnail;
					p.urlTitle = urltitle;
					p.urlLink = urlname;
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return p;
		}

		public bool UpdateItemById(PortfolioItem b)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "UPDATE PortfolioItem SET Name=@Name, Description=@Description, FrontpageImg=@FrontpageImg, Thumbnail=@Thumbnail, CategoryName=@CategoryName, ItemTitle=@ItemTitle, CreatedDate=@CreatedDate, UrlTitle=@UrlTitle, UrlLink=@UrlLink WHERE ID = @Id";
				MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);

				newCmd.Parameters.AddWithValue("@Id", b.RetrieveId());
				newCmd.Parameters.AddWithValue("@Name", b.RetrieveTitle());
				newCmd.Parameters.AddWithValue("@Description", b.RetrieveDescription());
				newCmd.Parameters.AddWithValue("@FrontpageImg", b.FrontpageImg);
				newCmd.Parameters.AddWithValue("@Thumbnail", b.Thumbnail);
				newCmd.Parameters.AddWithValue("@CategoryName", b.categoryName);
				newCmd.Parameters.AddWithValue("@ItemTitle", b.RetrieveTitle());
				newCmd.Parameters.AddWithValue("@CreatedDate", b.createdDate);
				newCmd.Parameters.AddWithValue("@UrlTitle", b.urlTitle);
				newCmd.Parameters.AddWithValue("@UrlLink", b.urlLink);

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
