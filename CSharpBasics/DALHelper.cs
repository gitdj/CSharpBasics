using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpBasics
{
    class DALHelper
    {
        public bool Insert(ClientProductModel prod)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source =.; Initial Catalog=OnPremSQLDB;Integrated Security=SSPI;";
            sqlConn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = sqlConn;
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "INSERT INTO [dbo].[Products] ([ProductName] ,[Quantity] ,[Rate]) VALUES('"+ prod.Name+"',"+ prod.Qty.ToString() + ","+ prod.Rate +")";
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
            return true;
        }

        public ClientProductModel SelectQuery(int Id)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source =.; Initial Catalog=OnPremSQLDB;Integrated Security=SSPI;";
            sqlConn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = "SELECT * FROM [Products] Where ProductID =@Id";
            sqlcmd.Connection = sqlConn;
            sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataReader sqldr = sqlcmd.ExecuteReader();

            ClientProductModel prod = new ClientProductModel();

            while (sqldr.Read())
            {
                prod.Name = (string)sqldr["ProductName"];
                prod.Id = Convert.ToString(sqldr["ProductID"]);
                prod.Qty = Convert.ToString(sqldr["Quantity"]);
                prod.Rate = Convert.ToString(sqldr["Rate"]);
            }

            return prod;
        }

        public ClientProductModel SPExecute(int Id)
        {
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Data Source =.; Initial Catalog=OnPremSQLDB;Integrated Security=SSPI;";
            sqlConn.Open();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = "Sp_GetProductById";
            sqlcmd.CommandType = CommandType.StoredProcedure;

            sqlcmd.Connection = sqlConn;
            sqlcmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
            SqlDataReader sqldr = sqlcmd.ExecuteReader();

            ClientProductModel prod = new ClientProductModel();

            while (sqldr.Read())
            {
                prod.Name = (string)sqldr["ProductName"];
                prod.Id = Convert.ToString(sqldr["ProductID"]);
                prod.Qty = Convert.ToString(sqldr["Quantity"]);
                prod.Rate = Convert.ToString(sqldr["Rate"]);
            }

            return prod;
        }

    }

    public  class ClientProductModel
    {
        public string Name { get; set; }
        public string Qty { get; set; }
        public string Rate { get; set; }
        public string Id { get; set; }

    }
    
}
