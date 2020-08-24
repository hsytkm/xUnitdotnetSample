using Microsoft.Extensions.DependencyInjection;
using System;
using TestTargetLibrary;

namespace XUnitTestProject
{
    // Nuget: Xunit.DependencyInjection
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services) =>
            services.AddLogging()
                .AddScoped<IMyClass, MyInternalClass>();

        //public void Configure(ILoggerFactory loggerFactory, ITestOutputHelperAccessor accessor) =>
        //    loggerFactory.AddProvider(new XunitTestOutputLoggerProvider(accessor));
    }
}
