/*
 *┌──────────────────────────────────────────┐
 *│  描   述: MySqlTest
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/16 15:26:54
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlDemo
{
    internal class MySqlHelper
    {

        public string _connectionStr;
        public MySqlHelper(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public void ExecuteNonQuery(string cmdText)
        {
            using (var SqlConnection = new MySqlConnection(_connectionStr))
            using (MySqlCommand mySqlCommand = new MySqlCommand(cmdText, SqlConnection))
            {
                SqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
            }
        }

        public List<Dictionary<string, string>> GetSqlDatas(string cmdText)
        {
            List<Dictionary<string, string>> sqlDatas_list = new List<Dictionary<string, string>>();
            using (var SqlConnection = new MySqlConnection(_connectionStr))
            using (MySqlCommand cmd = new MySqlCommand(cmdText, SqlConnection))
            {
                SqlConnection.Open();
                
                using (MySqlDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Dictionary<string, string> pairs = new Dictionary<string, string>();
                        for (int i = 0; i < dataReader.FieldCount; i++)
                        {
                            pairs[dataReader.GetName(i)] = dataReader[dataReader.GetName(i)].ToString();
                        }
                        sqlDatas_list.Add(pairs);
                    }
                }
            }

            return sqlDatas_list;
        }
    }
}
