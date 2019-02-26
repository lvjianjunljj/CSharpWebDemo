using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CSharpMVCWebAPIApplication.DAO.Azure
{
    public class AzureSQLDatabase
    {
        public static List<string> GetAllData()
        {
            List<string> res = new List<string>();
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

                // your_server.database.windows.net
                builder.DataSource = @"tcp:csharpmvcwebapidatabaseserver.database.windows.net";
                // your_username
                builder.UserID = @"jianjlv";
                // your_password
                builder.Password = "6076361Abb";
                // your_database
                builder.InitialCatalog = "CSharpMVCWebAPIDatabase";

                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    res.Add("\nQuery data example:");
                    res.Add("=========================================\n");

                    connection.Open();
                    StringBuilder sb = new StringBuilder();
                    //sb.Append("SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName ");
                    //sb.Append("FROM [SalesLT].[ProductCategory] pc ");
                    //sb.Append("JOIN [SalesLT].[Product] p ");
                    //sb.Append("ON pc.productcategoryid = p.productcategoryid;");
                    sb.Append(@"select * from dbo.user_info");
                    String sql = sb.ToString();

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                res.Add(string.Format("{0} {1}", reader.GetString(1), reader.GetString(2)));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                res.Add(string.Format("Exception Message: {0}", e.Message));
            }
            res.Add("\nDone. Press enter.");
            return res;
        }
    }
}