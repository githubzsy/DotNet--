
using NLog;
using NLog.Web;
using WebApplication1;

public class Program
{/// <summary>
 /// ����ʼ�ű�
 /// </summary>
 /// <typeparam name="T">Startup��</typeparam>
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
            logger.Error(ex, "վ������ʱ�������쳣");
        }
        finally
        {
            LogManager.Shutdown();
        }
    }

    /// <summary>
    /// ����Web����
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
