using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace Tools
{
    public class OracleHelper
    {
        private string connectionString=string.Empty;

        public OracleHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 查询返回一个DataTable
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataTable ExcuteDataTable(string commandText,Dictionary<string,object> parameters=null)
        {
            DataTable dt=new DataTable();
            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                using (OracleCommand cmd = conn.CreateCommand())
                {
                    // 开启链接
                    conn.Open();

                    
                    cmd.CommandText = commandText;

                    if (parameters != null)
                    {
                        // 增加参数
                        foreach (var keyValue in parameters)
                        {
                            var p = cmd.CreateParameter();
                            p.ParameterName = keyValue.Key;
                            p.Value = keyValue.Value;
                            cmd.Parameters.Add(p);
                        }
                    }
                   

                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
    }
}
