    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    // File for single query examples
    public partial class SqlAdapter 
    {
        // #1 Example 
        public Guid GetUserId(string username)
        {
            try
            {
                const string query = @"select u.userid id
						            from [Local_Test].[dbo].[User] u
                                    where u.username = @Username";

                // This field is optional 
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Username", username)
                };

                var queryResultAsObject = GenericSqlQuerySingle(query, parameters);

                return (Guid?) queryResultAsObject ?? Guid.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Guid.Empty;
        }
        // #2 Example 
        public string GetUsername(Guid userId)
        {
            try
            {
                const string query = @"select u.username
						            from [Local_Test].[dbo].[User] u
                                    where u.userid = @UserId";

                // This field is optional 
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserId", userId.ToString())
                };

                var queryResultAsObject = GenericSqlQuerySingle(query, parameters);

                return queryResultAsObject != null ? (string)queryResultAsObject : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return string.Empty;
        }


        // #3 Example 
        public Guid GetSingleGuidSimple()
        {
            try
            {
                const string query = @"select top 1 u.userid id
						            from [Local_Test].[dbo].[User] u";

                var queryResultAsObject = GenericSqlQuerySingle(query);

                return (Guid?)queryResultAsObject ?? Guid.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Guid.Empty;
        }
        // #4 Example 
        public string GetSingleStringSimple()
        {
            try
            {
                const string query = @"select top 1 u.username
						                from [Local_Test].[dbo].[User] u";

                var queryResultAsObject = GenericSqlQuerySingle(query);
                //Console.WriteLine(queryResultAsObject.GetType()); // Use this to debug the type to cast 

                return queryResultAsObject != null ? (string)queryResultAsObject : string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return string.Empty;
        }
    }