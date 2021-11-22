using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using Eg.Core;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace ConfigByCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var nhConfig = new Configuration().Configure();
            var mapper = new ConventionModelMapper();
            nhConfig.AddMapping(mapper.CompileMappingFor(new[] { typeof(TestClass) }));

            var schemaExport = new SchemaExport(nhConfig);
            schemaExport.Create(false, true);

            Console.WriteLine("The tables have been created");
            Console.ReadKey();
        }
    }
}
