/*
 *┌──────────────────────────────────────────┐
 *│  描   述: AnimalRepository
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/23 19:08:16
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;
using WebApiDAL.Entity;

namespace WebApiDAL.Repository
{
    /// <summary>
    /// 动物仓储层
    /// </summary>
    public class AnimalRepository
    {
        OracleHelper helper = new OracleHelper(@"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.6.1.27)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));User ID=NetStudy;Password=NetStudy;Max Pool Size=1000;");

        public Animal Get(string name)
        {
            throw new NotImplementedException();
        }

        public List<Animal> GetAll()
        {
            var dt = helper.ExcuteDataTable("select * from Animal");
            List<Animal> list = new List<Animal>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Animal
                {
                    Name = row["Name"].ToString(),
                    Age = Convert.ToInt32(row["Age"]),
                    Id = row["Id"].ToString()
                });
            }
            return list;

            // DataTableHelper.ConvertTo<Animal>(dt);
        }


        public void Add(Animal animal)
        {

        }


        public void Delete(string name)
        {

        }

        public void Update(Animal animal)
        {

        }
    }
}
