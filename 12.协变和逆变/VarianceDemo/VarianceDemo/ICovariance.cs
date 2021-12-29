/*
 *┌──────────────────────────────────────────┐
 *│  描   述: ICovariance
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 16:58:04
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
    /// 协变接口
    /// </summary>
    /// <typeparam name="T">只能作为返回值</typeparam>
    internal interface ICovariance<out T>
    {
        /// <summary>
        /// 示例协变方法
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public T Covariance();
    }
}
