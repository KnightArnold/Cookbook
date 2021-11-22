using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using Eg.Core;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace ConfigByAppConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhConfig = new Configuration().Configure();
            var mapper = new ConventionModelMapper();
            nhConfig.AddMapping(mapper.CompileMappingFor(new[] { typeof(TestClass) }));
            var update = new SchemaUpdate(nhConfig);
            update
                .Execute(false, true);
            Console.WriteLine("The tables have been updated");
            Console.ReadKey();
        }
    }
}
