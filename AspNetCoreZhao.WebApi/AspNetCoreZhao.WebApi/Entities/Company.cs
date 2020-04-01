using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }

        public ICollection<Employee> Employees { get; set; } //Alt+Enter快速创建类
    }
}
