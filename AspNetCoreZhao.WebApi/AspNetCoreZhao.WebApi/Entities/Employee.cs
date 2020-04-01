using System;

namespace AspNetCoreZhao.WebApi.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Company Company { get; set; }

    }
}