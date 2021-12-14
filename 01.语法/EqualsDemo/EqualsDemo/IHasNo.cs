/*
 *┌──────────────────────────────────────────┐
 *│  描   述: IHasName
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/14 19:31:48
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualsDemo
{
    /// <summary>
    /// 接口
    /// </summary>
    public interface IHasNo
    {
        public int Id { get; set; }

        /// <summary>
        /// 接口方法
        /// </summary>
        /// <returns></returns>
        public string GetNo();
    }
}
