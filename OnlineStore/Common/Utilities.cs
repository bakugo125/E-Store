using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace OnlineStore.Common
{
    public class Utilities
    {
        Connection c = new Connection();

        public int ExecuteQuery(string queryStr)
        {
            SqlConnection connection = new SqlConnection(c.connectionString());
            connection.Open();

            SqlCommand command = new SqlCommand(queryStr, connection);
            int rowsEffected = command.ExecuteNonQuery();

            connection.Close();
            return rowsEffected;
        }

        public int ExecuteParameterizedQuery(string text, string[] parameterNames, params object[] parameters)
        {
            using (var connection = new SqlConnection(c.connectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;

                    if (parameters.Any())
                    {
                        command.CommandText = text;

                        for (int i = 0; i < parameters.Length; i++)
                        {
                            command.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                        }
                    }
                    else
                    {
                        command.CommandText = text;
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public int ExecuteInsertOrUpdateQuery(string selectQuery, string insertQuery, string updateQuery)
        {
            SqlConnection connection = new SqlConnection(c.connectionString());
            connection.Open();

            DataTable dt = new DataTable();
            dt = GetDataTable(selectQuery);
            int rowsEffected = 0;

            if (dt.Rows.Count > 0)
            {
                rowsEffected = ExecuteQuery(updateQuery);
            }

            else
            {
                rowsEffected = ExecuteQuery(insertQuery);
            }

            connection.Close();
            return rowsEffected;
        }

        public int executeInsertQueryOnBasisOfSelectQuery(string selectQuery, string insertQuery)
        {
            SqlConnection connection = new SqlConnection(c.connectionString());
            connection.Open();

            DataTable dt = new DataTable();
            dt = GetDataTable(selectQuery);
            int rowsEffected = 0;

            if (dt.Rows.Count > 0)
            {
            }

            else
            {
                rowsEffected = ExecuteQuery(insertQuery);
            }

            connection.Close();
            return rowsEffected;
        }

        public bool ifRecordsExist(string query)
        {
            SqlConnection connection = new SqlConnection(c.connectionString());
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                connection.Close();
                return true;

            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public string FixString(string input)
        {
            input = input.Replace("'", "''");
            return input;
        }

        internal DataTable GetDataTable(string query)
        {
            DataTable dt = new DataTable();
            string str = c.connectionString();
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                using (SqlCommand cmd = connection.CreateCommand())
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, connection))
                    {
                        try
                        {
                            da.Fill(dt);
                            return dt;
                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine("SQL Error" + ex.Message.ToString());
                            return dt;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }

                }

            }
        }

        internal string getWarningMessage(string s)
        {
            string message = "An error has occurred:  " + s;
            return message;
        }

        internal string getSuccessMessage(string s)
        {
            string message = "Congratulations:  " + s;
            return message;
        }

        internal Dictionary<string, object> getIntObjectDictionary(string query)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            SqlConnection connection = new SqlConnection(c.connectionString());
            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader dr = command.ExecuteReader();

            while (dr.Read())
            {
                string d = dr[0].ToString();
                object s = dr[1];

                dict.Add(d, s);
            }

            connection.Close();
            return dict;
        }
    }
}