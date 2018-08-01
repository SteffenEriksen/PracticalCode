    using System;
    using System.Data.SqlClient;
    using System.Collections.Generic;


    // 'Main' class with Constructor & Generic query methods
    public partial class SqlAdapter
    {
        private string _connectionString;

        public SqlAdapter(string connectionString)
        {
            _connectionString = connectionString;
        }

        private static List<T> MapSqlQueryToList<T>(List<Dictionary<string, object>> sqlQueryResult) where T : class, new()
        {
            var result = new List<T>();
            foreach (var item in sqlQueryResult)
            {
                var cust = new T();

                foreach (var prop in cust.GetType().GetProperties())
                {
                    if (item.ContainsKey(prop.Name))
                    {
                        var temp = item[prop.Name];
                        prop.SetValue(cust, temp);
                    }
                }
                result.Add(cust);
            }
            return result;
        }

        private object GenericSqlQuerySingle(string query, List<SqlParameter> parameters = null)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = query;
                        if (parameters != null)
                        {
                            foreach (var param in parameters) command.Parameters.Add(param);
                        }

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
        private List<Dictionary<string, object>> GenericSqlQueryMultiple(string query, List<SqlParameter> parameters = null)
        {
            var result = new List<Dictionary<string, object>>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = query;
                        if (parameters != null)
                        {
                            foreach (var param in parameters) command.Parameters.Add(param);
                        }

                        command.Connection.Open();
                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                var lookup = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
                                for (var i = 0; i < dataReader.FieldCount; i++)
                                {
                                    var fieldName = dataReader.GetName(i);
                                    if (dataReader[fieldName] != DBNull.Value)
                                    {
                                        lookup.Add(fieldName, dataReader[fieldName]);
                                    }
                                }
                                result.Add(lookup);
                            }
					}
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return result;
        }

        private string SetStr(string field, SqlDataReader dr)
        {
            return dr[field] != DBNull.Value ? dr[field].ToString() : string.Empty;
        }
        private Guid SetGuid(string field, SqlDataReader dr)
        {
            return dr[field] != DBNull.Value ? (Guid)dr[field] : Guid.Empty;
        }

    }