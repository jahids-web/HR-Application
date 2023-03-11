using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ViewModel
{
    public class EmployeeWisePresentAbsentViewModel
    {
        public string EmployeeWisePresentAbsentId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int IsPresent { get; set; }
        public int DepartureTime { get; set; }
    }

    public class EmployeeWisePresentAbsentViewModelValidator : AbstractValidator<EmployeeWisePresentAbsentViewModel>
    {
        public EmployeeWisePresentAbsentViewModelValidator()
        {
            RuleFor(x => x.EmployeeWisePresentAbsentId).NotNull().NotEmpty();
            RuleFor(x => x.EmployeeId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Date).NotNull().NotEmpty();
            RuleFor(x => x.IsPresent).NotNull().NotEmpty();
            RuleFor(x => x.DepartureTime).NotNull().NotEmpty();
        }
    }
}
