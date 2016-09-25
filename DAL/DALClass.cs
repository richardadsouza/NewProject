using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DAL
{
    public class DALClass
    {
        #region Variables
        SqlConnection con;
        SqlCommand cmd;
        private StringBuilder query = new StringBuilder();
        #endregion

        #region Methods
        /// <summary>
        /// Method to return the list of zip codes.
        /// </summary>
        /// <returns>DataTable</returns>
        public DataTable GetZipcodeList()
        {
            DataTable dt = new DataTable();
            query = new StringBuilder("SELECT  * FROM Zipcode");

            try
            {
                dt = ExecuteQuery(query);
                return dt;
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
                return dt;
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
                return dt;
            }
        }

        /// <summary>
        /// Method to log the errors generated while execution of the code.
        /// </summary>
        /// <param name="message">Error message</param>
        /// <param name="stackTrace">Error stack trace</param>    
        public void LogError(string message, string stackTrace)
        {
            string path = @"E:\Practice\GG Project\New Project\GroceryGuys";
            FileStream fs = new FileStream((path + "/ErrorLog.txt"), FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);
            writer.WriteLine(DateTime.Now + ", Message: " + message + ", Stack Trace: " + stackTrace);
            writer.WriteLine("*********************************************************************");
            writer.Flush();
            writer.Close();
            fs.Close();
        }

        /// <summary>
        /// Method to execute sql command
        /// </summary>
        /// <param name="query">Sql query to be executed</param>
        /// <returns></returns>
        private DataTable ExecuteQuery(StringBuilder query)
        {
            InitializeSqlConnection();
            DataTable dt = new DataTable();

            using (con)
            {
                cmd = new SqlCommand(query.ToString(), con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }

            return dt;
        }

        /// <summary>
        /// Method to execute query.
        /// </summary>
        /// <param name="query">Sql query to be executed.</param>
        /// <param name="sqlParams">List of SqlParameters.</param>
        /// <returns>Data Table</returns>
        private DataTable ExecuteQuery(StringBuilder query, List<SqlParameter> sqlParams)
        {
            InitializeSqlConnection();
            DataTable dt = new DataTable();

            using (con)
            {
                cmd = new SqlCommand(query.ToString(), con);

                foreach (var param in sqlParams)
                {
                    cmd.Parameters.Add(param);
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                return dt;
            }
        }

        /// <summary>
        /// Method to execute sql query.
        /// </summary>
        /// <param name="query">Sql query to be executed.</param>
        /// <param name="sqlParam">SqlParamter</param>
        /// <returns></returns>
        private DataTable ExecuteQuery(StringBuilder query, SqlParameter sqlParam)
        {
            InitializeSqlConnection();
            DataTable dt = new DataTable();

            using (con)
            {
                cmd = new SqlCommand(query.ToString(), con);
                cmd.Parameters.Add(sqlParam);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// Method to initialize sql connection object.
        /// </summary>
        internal void InitializeSqlConnection()
        {
            if (con == null || con.ConnectionString == "")
            {
                con = new SqlConnection("Data Source=RICHIE-PC; Initial Catalog=NewProject; User ID=sa; Password=RICHIE");
            }
        }

        /// <summary>
        /// Method to get the latest 2 delivery dates
        /// </summary>
        /// <param name="today">Todays date</param>
        /// <returns></returns>
        public List<DateTime> GetCurrentDelDate(DateTime today)
        {
            List<DateTime> dateList = new List<DateTime>();
            query = new StringBuilder("SELECT TOP 2 Date FROM DeliveryDate WHERE Date > @today");

            SqlParameter sqlParam = new SqlParameter() { ParameterName = "today", SqlDbType = SqlDbType.Date, Value = today };

            try
            {
                DataTable dt = ExecuteQuery(query, sqlParam);

                foreach (DataRow row in dt.Rows)
                {
                    DateTime date = (DateTime)row["Date"];

                    dateList.Add(date);
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
                return dateList;
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
                return dateList;
            }

            return dateList;
        }

        /// <summary>
        /// Method to get list of aisle top
        /// </summary>
        /// <returns></returns>
        public DataTable BindAisleTop()
        {
            DataTable dt = new DataTable();
            query = new StringBuilder("SELECT * FROM AisleTop WHERE IsHide = 0");
            dt = ExecuteQuery(query);

            return dt;
        }

        /// <summary>
        /// Method to return aisletop.
        /// </summary>
        /// <param name="aisleTopID">Aisle Top ID</param>
        /// <returns></returns>
        public string GetAisleTop(string aisleTopID)
        {
            DataTable dt = new DataTable();
            string aisleTopName = String.Empty;

            query.Clear();
            query.Append("SELECT Name FROM AisleTop WHERE AisleTopID = @ID AND IsHide = 0");

            try
            {
                SqlParameter sqlParam = new SqlParameter() { ParameterName = "ID", Value = aisleTopID, Size = 10, SqlDbType = SqlDbType.NVarChar };

                aisleTopName = Convert.ToString(ExecuteScalar(query, sqlParam));
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
                return aisleTopName;
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
                return aisleTopName;
            }

            return aisleTopName;
        }

        /// <summary>
        /// Method to retireve first single column from the database.
        /// </summary>
        /// <param name="query">Sql query to be executed.</param>
        /// <param name="sqlParam">SqlParameter</param>
        /// <returns></returns>
        private object ExecuteScalar(StringBuilder query, SqlParameter sqlParam)
        {
            object obj = new object();

            InitializeSqlConnection();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            using (con)
            {
                cmd = new SqlCommand(query.ToString(), con);
                cmd.Parameters.Add(sqlParam);

                obj = cmd.ExecuteScalar();
            }

            return obj;
        }

        /// <summary>
        /// Method to retrieve aisle id and name from database.
        /// </summary>
        /// <param name="aisleTopID">AisleTopID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAisle(string aisleTopID)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.Append(@"SELECT DISTINCT AisleID = ale.AisleID, ale.Name 
                            FROM Aisle ale JOIN AisleTopAisleLink alk ON ale.AisleID  = alk.AisleID 
                            JOIN AisleShelfLink asl ON asl.AisleID = alk.AisleID
                            JOIN Shelf slf ON slf.ShelfID = asl.ShelfID
                            WHERE alk.AisleTopID = @AisleTopID
                            AND ale.IsHide = 0");

            try
            {
                SqlParameter sqlParam = new SqlParameter() { ParameterName = "AisleTopID", Value = aisleTopID, SqlDbType = SqlDbType.NVarChar, Size = 10 };
                dt = ExecuteQuery(query, sqlParam);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Method to retrieve shelf id, shelf name, aisle id and aisle top id from the database.
        /// </summary>
        /// <param name="aisleID">AisleID</param>
        /// <param name="aisleTopID">AisleTopID</param>
        /// <returns>DataTable</returns>
        public DataTable GetShelf(string aisleID, string aisleTopID)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.Append("SELECT ShelfID = slf.ShelfID,  slf.Name, asl.AisleID, alk.AisleTopID"
            + " FROM Shelf slf JOIN AisleShelfLink asl"
            + " ON slf.ShelfID = asl.ShelfID JOIN AisleTopAisleLink alk"
            + " ON asl.AisleID = alk.AisleID"
            + " WHERE asl.AisleID = @AisleID"
            + " AND IsHide = 0"
            + " AND AisleTopID = @AisleTopID");

            try
            {
                List<SqlParameter> sqlParams = new List<SqlParameter>() 
                {
                    new SqlParameter(){ ParameterName = "AisleID", SqlDbType = SqlDbType.NVarChar, Value = aisleID, Size = 10 },
                    new SqlParameter(){ ParameterName ="AisleTopID", SqlDbType = SqlDbType.NVarChar, Value = aisleTopID, Size = 10 }
                };

                dt = ExecuteQuery(query, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Function to get the names of aisletop, aisle and shelf of the selected shelf.
        /// </summary>
        /// <param name="aisleTopID">AisleTopID</param>
        /// <param name="aisleID">AisleID</param>
        /// <param name="shelfID">ShelfID</param>
        /// <returns>DataTable</returns>
        public DataTable GetAisleShelfInfo(string aisleTopID, string aisleID, string shelfID)
        {
            DataTable dt = new DataTable();

            query.Clear();
            query.Append("SELECT atp.AisleTopID, AisleTopName = atp.Name, ale.AisleID, AisleName = ale.Name, slf.ShelfID, ShelfName = slf.Name "
                            + "FROM AisleTop atp JOIN AisleTopAisleLink atlk "
                            + "ON atp.AisleTopID = atlk.AisleTopID JOIN Aisle ale "
                            + "ON atlk.AisleID = ale.AisleID JOIN AisleShelfLink aslk "
                            + "ON ale.AisleID = aslk.AisleID JOIN Shelf slf "
                            + "ON aslk.ShelfID = slf.ShelfID "
                            + "WHERE atp.AisleTopID = @AisleTopID "
                            + "AND ale.AisleID = @AisleID "
                            + "AND slf.ShelfID = @ShelfID");

            try
            {
                List<SqlParameter> paramList = new List<SqlParameter>()
            {
                new SqlParameter() { ParameterName = "AisleTopID", SqlDbType = SqlDbType.NVarChar, Value = aisleTopID, Size = 10 },
                new SqlParameter() { ParameterName = "AisleID", SqlDbType = SqlDbType.NVarChar, Value = aisleID, Size = 10 },
                new SqlParameter() { ParameterName = "ShelfID", SqlDbType = SqlDbType.NVarChar, Value = shelfID, Size = 10 }
            };

                dt = ExecuteQuery(query, paramList);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Function to get the list of products for the selected shelf.
        /// </summary>
        /// <param name="shelfID">Shelf ID</param>
        /// <returns>List of products</returns>
        public DataTable GetProductList(string shelfID)
        {
            DataTable dt = new DataTable();

            try
            {
                InitializeSqlConnection();

                query.Clear();
                query.Append("SELECT plk.ProductID, Name, Image, Image2, Size, BeforeSalePrice = CONVERT(NVARCHAR,BeforeSalePrice), Price = CONVERT(NVARCHAR,Price) "
                    + "FROM Product prt JOIN ProductShelfLink plk "
                    + "ON prt.ProductID = plk.ProductID "
                    + "WHERE ShelfID = @ShelfID "
                    + "AND IsHidden = 0");

                SqlParameter sqlParam = new SqlParameter() { ParameterName = "ShelfID", SqlDbType = SqlDbType.NVarChar, Size = 10, Value = shelfID };

                dt = ExecuteQuery(query, sqlParam);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Function to get the list of popular products for the selected shelf.
        /// </summary>
        /// <param name="shelfID">Shelf ID</param>
        /// <returns>List of popular products</returns>
        public DataTable GetPopularProducts(string shelfID)
        {
            DataTable dt = new DataTable();

            try
            {
                InitializeSqlConnection();

                query.Clear();
                query.Append("SELECT plk.ProductID, Name, Image, Image2, Size, BeforeSalePrice = CONVERT(NVARCHAR,BeforeSalePrice), Price = CONVERT(NVARCHAR,Price) "
                    + "FROM Product prt JOIN ProductShelfLink plk "
                    + "ON prt.ProductID = plk.ProductID "
                    + "WHERE ShelfID = @ShelfID "
                    + "AND IsHidden = 0 "
                    + "AND IsFeatured = 1");

                SqlParameter sqlParam = new SqlParameter() { ParameterName = "ShelfID", SqlDbType = SqlDbType.NVarChar, Size = 10, Value = shelfID };

                dt = ExecuteQuery(query, sqlParam);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Method to get the product detail of selected product.
        /// </summary>
        /// <param name="productID">ProductId of selected product.</param>
        /// <returns>DataRow containing product details.</returns>
        public DataRow GetProductDetails(string productID, int qty)
        {
            DataRow row;

            query.Clear();
            query.Append("SELECT DISTINCT ProductID, Name, Size, Price, Qty = '', TaxType FROM Product WHERE ProductID = @ProductID");

            SqlParameter sqlParam = new SqlParameter { ParameterName = "ProductID", SqlDbType = SqlDbType.NVarChar, Value = productID, Size = 10 };

            DataTable dt = ExecuteQuery(query, sqlParam);

            if (dt.Rows.Count > 0)
            {
                dt.Rows[0]["Qty"] = qty;
                row = dt.Rows[0];
                return row;
            }
            else
            {
                dt = new DataTable();
                dt.Columns.Add("ProductID");
                dt.Columns.Add("Name");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Price");
                dt.Columns.Add("Size");
                dt.Columns.Add("TaxType");

                row = dt.NewRow();
                return row;
            }
        }

        /// <summary>
        /// Function to check if the login credentials are correct or not.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public DataTable CheckUser(string email, string password)
        {
            DataTable dt = new DataTable();

            try
            {
                InitializeSqlConnection();

                query.Clear();
                query.Append(@"SELECT DISTINCT UserID, FirstName, LastName, EmailID, Password, AccountFunds 
                            FROM Users
                            WHERE EmailID = @EmailID 
                            AND Password = @Password");

                List<SqlParameter> sqlParams = new List<SqlParameter>()
                {
                    new SqlParameter { ParameterName = "EmailID", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = email },
                    new SqlParameter{ParameterName = "Password", SqlDbType = SqlDbType.NVarChar, Size = 100, Value = password }
                };

                dt = ExecuteQuery(query, sqlParams);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Function to get data from ShoppingCartVariables table
        /// </summary>
        /// <returns>ShoppingCartVariables</returns>
        public DataTable GetShoppingCartVariables()
        {
            DataTable dt = new DataTable();

            try
            {
                InitializeSqlConnection();

                query.Clear();
                query.Append("SELECT TOP(1) * FROM ShoppingCartVariables");

                dt = ExecuteQuery(query);
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return dt;
        }

        /// <summary>
        /// Function to get selected coupon code
        /// </summary>
        /// <param name="couponCode">Coupon code</param>
        /// <returns>Coupon code list</returns>
        public DataTable CheckCouponCode(string couponCode)
        {
            InitializeSqlConnection();

            try
            {
                query.Clear();
                query.Append("SELECT DISTINCT * FROM Coupon WHERE CouponCode = @CouponCode AND IsHidden = 0");

                SqlParameter param = new SqlParameter { ParameterName = "CouponCode", Value = couponCode, SqlDbType = SqlDbType.NVarChar, Size = 50 };

                DataTable dt = ExecuteQuery(query, param);

                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);
            }

            return new DataTable();
        }
               
        public bool CheckCouponCode(string couponID, string userID)
        {
            InitializeSqlConnection();

            try
            {
                query.Clear();
                query.Append("SELECT * FROM CouponLink WHERE CouponID = @CouponID AND UserID = @UserID");

                List<SqlParameter> sqlParams = new List<SqlParameter>
                {
                    new SqlParameter{ ParameterName = "CouponID", Value = couponID, SqlDbType = SqlDbType.NVarChar, Size = 10 },
                    new SqlParameter { ParameterName = "UserID", Value = userID, SqlDbType = SqlDbType.NVarChar, Size = 10 }
                };

                DataTable dt = ExecuteQuery(query, sqlParams);

                if (dt.Rows.Count > 0)
                {
                    return false;
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);

                return false;               
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);

                return false;
            }           
        }

        public bool CheckOrder(string userID)
        {
            InitializeSqlConnection();

            try
            {
                query.Clear();
                query.Append("SELECT * FROM Orders WHERE UserID = @UserID");

                SqlParameter param = new SqlParameter { ParameterName = "UserID", SqlDbType = SqlDbType.NVarChar, Value = userID, Size = 10 };

                DataTable dt = ExecuteQuery(query, param);

                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message, sqlEx.StackTrace);

                return true;
            }
            catch (Exception ex)
            {
                LogError(ex.Message, ex.StackTrace);

                return true;
            }
        }
        #endregion
    }
}


