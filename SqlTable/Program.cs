using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace SQLConnect
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLClass sql = new SQLClass();
            sql.OpenConnection();
            string TableName = Console.ReadLine();

            SqlCommand commandselect = new SqlCommand(@"select * from @tablename; select * from Books;", sql.GetConnection());
            SqlParameter parameterTableName = new SqlParameter();
            parameterTableName.ParameterName = "tablename";
            parameterTableName.SqlDbType = System.Data.SqlDbType.NVarChar;
            parameterTableName.Value = TableName;
            commandselect.Parameters.Add(parameterTableName);
            
            SqlDataReader reader;
            reader = commandselect.ExecuteReader();
            do
            {
                if (reader != null)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[2].ToString());
                    }
                }
            }
            while ((reader = commandselect.ExecuteReader()) != null);
            reader.Close();
            sql.CloseConnection();
            Console.ReadLine();
        }
    }

    internal class SQLClass
    {
        internal void CloseConnection()
        {
            throw new NotImplementedException();
        }

        internal object GetConnection()
        {
            throw new NotImplementedException();
        }

        internal void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}
