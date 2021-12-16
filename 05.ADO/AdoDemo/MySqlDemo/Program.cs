using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MySqlDemo
{

    class Program
    {
        static string connStr = "server=localhost;Database =biz_db;uid=root;pwd=welcome;charset=utf8;";

        static void Main(string[] args)
        {
            // Console.WriteLine(InsertTest("aaa", "aaa"));


            Console.ReadKey();
        }

        static int InsertTest(string id,string factoryName)
        {
            string sql = @"INSERT INTO biz_db.factory
(Id, FactoryName)
VALUES(@Id, @FactoryName);
            ";
            using (var connection = new MySqlConnection(connStr))
            using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
            {
                connection.Open();
                var p = mySqlCommand.CreateParameter();
                p.ParameterName = "@Id";
                p.Value = id;

                mySqlCommand.Parameters.Add(p);

                var p2 = mySqlCommand.CreateParameter();
                p2.ParameterName = "@FactoryName";
                p2.Value = factoryName;
                mySqlCommand.Parameters.Add(p2);

                return mySqlCommand.ExecuteNonQuery();
            }
        }

        static object SelectTest(string id)
        {
            string sql = @"SELECT * FROM biz_db.factory
WHERE id=@Id;";
            using (var connection = new MySqlConnection(connStr))
            using (MySqlCommand mySqlCommand = new MySqlCommand(sql, connection))
            {
                connection.Open();
                var p = mySqlCommand.CreateParameter();
                p.ParameterName = "@Id";
                p.Value = id;

                mySqlCommand.Parameters.Add(p);

                return mySqlCommand.ExecuteScalar();
            }
        }
    }
}

