using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    /// <summary>
    /// 性能监控中间件
    /// </summary>
    public class PerformanceMiddleware
    {
        #region 构造函数
        private readonly RequestDelegate _next;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="next"></param>
        public PerformanceMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();
            if (stopwatch.ElapsedMilliseconds > 1)
            {
                Console.WriteLine("性能问题:"+ stopwatch.ElapsedMilliseconds);
            }
        }

    }
}
