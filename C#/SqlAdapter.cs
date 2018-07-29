using System;
using System.Data.SqlClient;
using System.Collections.Generic;


public class SqlAdapter
{
	private string _connectionString;

	public SqlAdapter(string connectionString)
	{
		_connectionString = connectionString;
	}


	public void MultipleQuerySimple()
	{
		try
		{
			var query = @"select u.userid, u.username
                            from user u";

			var dataReader = GenericSqlQueryMultiple(query);

			// Iterate over result
			while (dataReader.Read())
			{
				var userId = dataReader["owningbusinessunit"] != DBNull.Value ? dataReader["domainname"].ToString() : string.Empty;
				var username = dataReader["username"] != DBNull.Value ? dataReader["username"].ToString() : string.Empty;

				//var id = dataReader["id"] != DBNull.Value ? (Guid)dataReader["id"] : Guid.Empty;
				//var count = dr["count"] != DBNull.Value ? (int)dr["count"] : 0;
				//var createdOn = dr["createdon"] != DBNull.Value ? (DateTime)dr["createdon"] : new DateTime();

				Console.WriteLine($"userId: '{userId}' & username: '{username}'");
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}



	private Object GenericSqlQuerySingle(string query, List<SqlParameter> parameters = null)
	{
		try
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.Text;
					command.CommandText = query;
					foreach (var param in parameters) command.Parameters.Add(param);

					command.Connection.Open();
					var temp = command.ExecuteScalar();
					command.Connection.Close();
					return temp;
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}
	private SqlDataReader GenericSqlQueryMultiple(string query, List<SqlParameter> parameters = null)
	{
		try
		{
			using (var connection = new SqlConnection(_connectionString))
			{
				using (var command = connection.CreateCommand())
				{
					command.CommandType = System.Data.CommandType.Text;
					command.CommandText = query;
					foreach(var param in parameters) command.Parameters.Add(param);

					command.Connection.Open();
					using (var dataReader = command.ExecuteReader())
					{
						return dataReader;
					}
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex);
			throw;
		}
	}

}