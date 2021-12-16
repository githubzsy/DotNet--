using Oracle.ManagedDataAccess.Client;
using System;

namespace AdoOracleDemo
{
    internal class Program
    {
        static string connectionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.1.27)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User ID=evetest;Password=evetest;Max Pool Size=1000;";

        static void Main(string[] args)
        {
            SelectTest1();
            Console.ReadKey();
        }

        static void SelectTest1()
        {
            OracleConnection conn = null;
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            try
            {
                conn = new(connectionString);
                cmd = conn.CreateCommand();
                conn.Open();
                cmd.CommandText = "SELECT * FROM EMPLOYEE WHERE EMPLOYEENAME=:EmployeeName";
                var p = cmd.CreateParameter();
                p.ParameterName = ":EmployeeName";
                p.Value = "CamstarAdmin";
                cmd.Parameters.Add(p);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("员工名称: {0}", dr["EMPLOYEENAME"]);
                }
            }
            catch
            {
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

        static void SelectData2(string connectionString)
        {
            using(OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM EMPLOYEE WHERE EMPLOYEENAME=:EmployeeName";
                    var p = cmd.CreateParameter();
                    p.ParameterName = ":EmployeeName";
                    p.Value = "CamstarAdmin";
                    cmd.Parameters.Add(p);
                    using (var dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("员工名称: {0}", dr["EMPLOYEENAME"]);
                        }
                    }
                }
            }
        }
    }
}
