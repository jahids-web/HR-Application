using FluentAssertions.Execution;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int TotalYearlyAllocatedleave { get; set; }
        public int MobileNo { get; set; }
        public string Leave { get; set; }
        public string IsEmployed { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DeparturedDate { get; set; }
        public int WorkHour { get; set; }
    }

    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.EmployeeId);
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Designation).NotNull().NotEmpty();
            RuleFor(x => x.Status).NotNull().NotEmpty();
            RuleFor(x => x.TotalYearlyAllocatedleave).NotNull().NotEmpty();
            RuleFor(x => x.MobileNo).NotNull().NotEmpty();
            RuleFor(x => x.Leave).NotNull().NotEmpty();
            RuleFor(x => x.IsEmployed).NotNull().NotEmpty();
            RuleFor(x => x.JoiningDate).NotNull().NotEmpty();
            RuleFor(x => x.DeparturedDate).NotNull().NotEmpty();
            RuleFor(x => x.WorkHour).NotNull().NotEmpty();

        }
    }
}
