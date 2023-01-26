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
        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string MobileNo { get; set; }
        public string WorkHour { get; set; }
    }

    public class EmployeeViewModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Email).NotNull().NotEmpty();
            RuleFor(x => x.Designation).NotNull().NotEmpty();
            RuleFor(x => x.Status).NotNull().NotEmpty();
            RuleFor(x => x.MobileNo).NotNull().NotEmpty();
            RuleFor(x => x.WorkHour).NotNull().NotEmpty();

        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public string MobileNo { get; set; }
        public string WorkHour { get; set; }
    }
}
