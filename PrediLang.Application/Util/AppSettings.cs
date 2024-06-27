using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Application.Util
{
    public static class AppSettings
    {
        public static string GetValue(string source)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            // Obter o valor do nó informado na variável 'source'
            string value = configuration[source];
            return value;
        }
    }
}
