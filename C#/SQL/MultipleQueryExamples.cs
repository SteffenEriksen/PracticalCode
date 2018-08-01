    using System;
    using System.Collections.Generic;

    // File for multiple query examples
    public partial class SqlAdapter
    {
        // #1 Example 
        public List<CustomerInfo> GetAllCustomers()
        {
            var result = new List<CustomerInfo>();
            try
            {
                var query = @"select u.userid id, u.username 
						  from [Local_Test].[dbo].[User] u";

                var queryResult = GenericSqlQueryMultiple(query);

                var queryResultMapped = MapSqlQueryToList<CustomerInfo>(queryResult);

                result.AddRange(queryResultMapped);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return result;
        }



        // Example TODO
        public void MultipleQuerySimple()
        {
            try
            {
                var query = @"select u.userid, u.username
                          from user u";

                var dataReader = GenericSqlQueryMultiple(query);

                //while (dataReader.Read())
                //{
                //    var userId = dataReader["userid"] != DBNull.Value ? dataReader["userid"].ToString() : string.Empty;
                //    var username = dataReader["username"] != DBNull.Value ? dataReader["username"].ToString() : string.Empty;

                //    //var id = dataReader["id"] != DBNull.Value ? (Guid)dataReader["id"] : Guid.Empty;
                //    //var count = dr["count"] != DBNull.Value ? (int)dr["count"] : 0;
                //    //var active = dr["active"] != DBNull.Value ? (bool)dr["active"] : false;
                //    //var createdOn = dr["createdon"] != DBNull.Value ? (DateTime)dr["createdon"] : new DateTime();

                //    Console.WriteLine($"userId: '{userId}' & username: '{username}'");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }


    // Class used in the examples
    public class CustomerInfo
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModified { get; set; }
    }