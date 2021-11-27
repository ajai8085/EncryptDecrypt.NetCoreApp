using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.DataProtection;


using EnctyptDecrypt.NetCore.App.Security;

namespace EnctyptDecrypt.NetCore.App
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = new HostBuilder()
               .ConfigureServices((hostContext, services) =>
               {
                   services.AddDataProtection(opt =>
                   {

                   });
                   
                   services.AddSingleton<DataProtectionPurposes>()
                   .AddScoped<PasswordServices>().AddScoped<IdentityModelEncryptionDecryption>();
                    

               }).ConfigureLogging(logbuilder =>
               {
                   logbuilder.AddLog4Net("log4net.config.xml");

               });


            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                var appLogger = services.GetRequiredService<ILoggerFactory>().CreateLogger("Program");
                try
                {
                    var test = services.GetRequiredService<IdentityModelEncryptionDecryption>();

                    test.Test();

                    var pwdSvc=services.GetRequiredService<PasswordServices>();
                    Console.WriteLine("Please enter plaintext password to Encrypt:");
                    var plainTextPwd=Console.ReadLine();
                    
                    var enctypted = pwdSvc.EncryptString(plainTextPwd);

                    Console.WriteLine($"Enctypted password is:: {enctypted}");

                    var decrypted = pwdSvc.Decrypt(enctypted);

                    Console.WriteLine($"Decrypted:: {decrypted}");



                    Console.WriteLine("Press any key to exit");
                    Console.ReadLine();

                }
                catch (Exception ex)
                {
                    appLogger.LogError($"Exception {ex}");
                    throw;
                }
            }
        }
    }
}
