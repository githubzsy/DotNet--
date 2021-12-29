using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.Json;

namespace AdoOracleDemo
{
    internal partial class Program
    {
        static string connectionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.1.27)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User ID=NetStudy;Password=NetStudy;Max Pool Size=1000;";

        static void Main(string[] args)
        {
            SelectData2();
            Console.ReadKey();
        }

        static void SelectData1()
        {
            OracleConnection conn = null;
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            OracleDataAdapter adapter = null;
            List<Animal> animals = new List<Animal>();
            OracleTransaction transaction = null;
            try
            {
                conn = new OracleConnection(connectionString);
                cmd = conn.CreateCommand();
                conn.Open();
                transaction = conn.BeginTransaction();

                cmd.CommandText = "Update ANIMAL Set Name='Jinmao3' where Name='Jinmao2'";

                string sql = " select * from Animal";

                adapter = new OracleDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Console.WriteLine(dt.Rows.Count);

                OracleParameter p = cmd.CreateParameter();
                p.ParameterName = ":Name";
                p.Value = "哈士奇";

                // 1. 返回第一个单元格内容
                //Console.WriteLine(cmd.ExecuteScalar());
                // 2. 返回受影响的条数(insert delete update)
                Console.WriteLine(cmd.ExecuteNonQuery());
                cmd.Parameters.Add(p);
                
                // 3. 返回表
                dr = cmd.ExecuteReader();
                
                // 循环读取表每一行内容
                while (dr.Read())
                {
                    animals.Add(new Animal
                    {
                        Name = dr["Name"].ToString(),
                        Age = Convert.ToInt32(dr["Age"])
                    });
                }

                Console.WriteLine(JsonSerializer.Serialize(animals));
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                dr?.Close();
                cmd?.Dispose();
                conn?.Close();
                conn.Dispose();
            }
        }

        static void SelectData2()
        {
            using(OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM ANIMAL WHERE Name=:Name";
                    var p = cmd.CreateParameter();
                    p.ParameterName = ":Name";
                    p.Value = "ASD";
                    cmd.Parameters.Add(p);

                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        Console.WriteLine(dt.Rows.Count);
                    }

                    //using (var dr = cmd.ExecuteReader())
                    //{
                    //    while (dr.Read())
                    //    {
                    //        Console.WriteLine("狗年龄: {0}", dr["AGE"]);
                    //    }
                    //}
                }
            }
        }
    }
}
