using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class Employee
    {
        [MinLength(10)]
        [MaxLength(10)]
        public string Id;
        [StringLength(50, ErrorMessage = "")]
        public string FirstName;
        [StringLength(50, ErrorMessage = "")]
        public string MiddleName;
        [StringLength(50, ErrorMessage = "")]
        public string LastName;
        public int Age;

        public static Employee RandomEmployee()
        {
            return new Employee()
            {
                Id = Guid.NewGuid().ToString("N").Substring(0, 10),
                Age = new Random().Next(20, 100),
                FirstName = Guid.NewGuid().ToString("N"),
                MiddleName = Guid.NewGuid().ToString("N"),
                LastName = Guid.NewGuid().ToString("N")
            };
        }

        public Employee GetEmployeeDetails(int i)
        {
            return RandomEmployee();
        }

        public bool SaveEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
