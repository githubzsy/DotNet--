
using NLog;
using NLog.Web;
using WebApplication1;

public class Program
{/// <summary>
 /// 程序开始脚本
 /// </summary>
 /// <typeparam name="T">Startup类</typeparam>
 /// <param name="args"></param>
    public virtual void Start(string[] args)
    {
        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
        try
        {
            logger.Info("Init Log API Information");

            CreateHostBuilder(args).Build().Run();
        }
        catch (Exception ex)
        {
            logger.Error(ex, "站点启动时出现了异常");
        }
        finally
        {
            LogManager.Shutdown();
        }
    }

    /// <summary>
    /// 创建Web宿主
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="args"></param>
    /// <returns></returns>
    public virtual IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory(builder => builder.RegisterAssemblyModules(assemblies)))
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseCustomWebHostBuilder();
                webBuilder.UseStartup<T>();
            });
    }
}
