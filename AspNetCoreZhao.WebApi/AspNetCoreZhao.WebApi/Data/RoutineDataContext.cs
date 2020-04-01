using AspNetCoreZhao.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreZhao.WebApi.Data
{
    public class RoutineDataContext:DbContext
    {
        public RoutineDataContext(DbContextOptions<RoutineDataContext> options)
            :base(options)
        {

        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// 属性限制
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Company>().Property(x => x.Introduction).HasMaxLength(500);
            modelBuilder.Entity<Employee>().Property(x => x.EmployeeNo).IsRequired().HasMaxLength(10);
            modelBuilder.Entity<Employee>().Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().Property(x => x.LastName).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Employee>().HasOne(x => x.Company).WithMany(x => x.Employees).HasForeignKey(x => x.CompanyId).OnDelete(DeleteBehavior.Restrict);

            //生成公司默认数据
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Id = Guid.Parse("0f47e01a-c072-427d-a5a6-27a8ae96380e"),
                    Name = "Microsoft",
                    Introduction = "Great Company",
                },
                 new Company
                 {
                     Id = Guid.Parse("35ca78f2-d595-4890-93c4-db6d5d258f5c"),
                     Name = "Google",
                     Introduction = "No Company",
                 },
                  new Company
                  {
                      Id = Guid.NewGuid(),
                      Name = "Alibaba",
                      Introduction = "TuBaolan Company",
                  }
            );
            //生成员工
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    CompanyId = Guid.Parse("0f47e01a-c072-427d-a5a6-27a8ae96380e"),
                    DateOfBirth = new DateTime(1976, 1, 2),
                    EmployeeNo = "0321",
                    FirstName = "123",
                    LastName = "456",
                    gender = Gender.男,
                },
                 new Employee
                 {
                     Id=Guid.NewGuid(),
                     CompanyId = Guid.Parse("35ca78f2-d595-4890-93c4-db6d5d258f5c"),
                     DateOfBirth = new DateTime(1976, 1, 2),
                     EmployeeNo = "0321",
                     FirstName = "098",
                     LastName = "124",
                     gender = Gender.男,
                 }
              );  
        }
    }
}
