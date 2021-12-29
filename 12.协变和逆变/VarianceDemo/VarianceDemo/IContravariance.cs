/*
 *┌──────────────────────────────────────────┐
 *│  描   述: IContravariance
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 16:59:51
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
    /// 逆变接口
    /// </summary>
    /// <typeparam name="U">只能作为参数</typeparam>
    internal interface IContravariance<in U>
    {

        /// <summary>
        /// 示例逆变方法
        /// </summary>
        /// <param name="u"></param>
        public void Contravariance(U u);
    }
}
