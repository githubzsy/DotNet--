/*
 *┌──────────────────────────────────────────┐
 *│  描   述: Convariance
 *│  作   者: zhoushiya
 *│  版   本: 1.0
 *│  创建时间: 2021/12/29 16:25:02
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
    /// 自定义类
    /// </summary>
    /// <typeparam name="T">只能用作返回值</typeparam>
    /// <typeparam name="U">只能用作参数</typeparam>
    /// <typeparam name="V">无限制</typeparam>
    internal class Variance<T, U, V> : ICovariance<T>, IContravariance<U>, IGeneric<V> where T : new()
    {
        /// <summary>
        /// 示例逆变方法
        /// </summary>
        /// <param name="u"></param>
        public void Contravariance(U u)
        {
            Console.WriteLine(u);
        }

        /// <summary>
        /// 示例协变方法
        /// </summary>
        /// <returns></returns>
        public T Covariance()
        {
            T t = new T();
            Console.WriteLine(t);
            return t;
        }

        /// <summary>
        /// 示例普通泛型方法
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public V Generic(V v)
        {
            Console.WriteLine(v);
            return v;
        }
    }
}
