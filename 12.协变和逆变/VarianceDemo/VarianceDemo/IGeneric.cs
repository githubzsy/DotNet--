/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Convariance
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 16:22:56
 *│  说   明:
 *└──────────────────────────────────────────┘
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarianceDemo
{
    /// <summary>
    /// 协变和逆变接口
    /// </summary>
    /// <typeparam name="V">无限制</typeparam>
    internal interface IGeneric<V>
    {
        /// <summary>
        /// 示例普通泛型
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public V Generic(V v);
    }
}
