using MySql.Data.MySqlClient;
using PortfolioRick.Interface;
using PortfolioRick.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioRick.Contexts.MYSQL
{
	public class ReviewMYSQLContext : ConnectionHelper, IReview
	{
		public bool CreateNewReview(Review r)
		{
			MySqlConnection cnn = ReturnMYSQLConnection();
			string query = "INSERT INTO Review (Name, Description) VALUES (@Name, @Description)";
			MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);
			newCmd.Parameters.AddWithValue("@Name", r.RetrieveName());
			newCmd.Parameters.AddWithValue("@Description", r.RetrieveMessage());
			newCmd.ExecuteNonQuery();
			cnn.Close();
			return true;
		}

		public bool DeleteReviewById(int Id)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "DELETE FROM Review WHERE ID = @Id";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@Id", Id);
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

		public List<Review> RetrieveAllReviews()
		{
			var listOfItems = new List<Review>();

			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "SELECT * FROM Review";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);

				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var name = dr["Name"].ToString();
					var description = dr["Description"].ToString();
					Review R = new Review(itemId, name, description);
					listOfItems.Add(R);
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}

			return listOfItems;
		}

		public Review RetrieveReviewById(int id)
		{
			var r = new Review(-1, null, null);
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				string query = "SELECT * FROM Review WHERE ID=@ID";
				MySqlCommand cmd = CreateMYSQLCommandText(query, cnn);
				cmd.Parameters.AddWithValue("@ID", id);
				var dr = cmd.ExecuteReader();
				while (dr.Read())
				{
					var itemId = Convert.ToInt32(dr["ID"]);
					var name = dr["Name"].ToString();
					var description = dr["Description"].ToString();
					r = new Review(itemId, name, description);
				}

				cnn.Close();
			}
			catch (NullReferenceException e)
			{
				Console.WriteLine(e.Message);
			}
			return r;
		}

		public bool UpdateReviewById(Review r)
		{
			try
			{
				MySqlConnection cnn = ReturnMYSQLConnection();
				var query = "UPDATE Review SET Name=@Name, Description=@Message WHERE ID = @Id";
				MySqlCommand newCmd = CreateMYSQLCommandText(query, cnn);
				newCmd.Parameters.AddWithValue("@Id", r.RetrieveId());
				newCmd.Parameters.AddWithValue("@Name", r.RetrieveName());
				newCmd.Parameters.AddWithValue("@Message", r.RetrieveMessage());
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
